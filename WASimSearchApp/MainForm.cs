using System;
using System.Drawing;
using System.Windows.Forms;
using WASimCommander.CLI.Client;
using WASimCommander.CLI.Enums;
using WASimCommander.CLI.Structs;

namespace WASimSearchApp
{
    public partial class MainForm : Form
    {
        private WASimClient client;
        private readonly AutoResetEvent dataUpdateEvent = new AutoResetEvent(false);

        private Boolean initOk = false;

        private Dictionary<int, string> searchResults = new Dictionary<int, string>();

        private SimvarManager simvarManager = new SimvarManager();

        private List<SimvarInfo> simvarList = new List<SimvarInfo>();

        public MainForm()
        {
            InitializeComponent();
            this.ConnButton.Click += new EventHandler(this.onConnectButtonClick);
            this.initSearchBtn.Click += new EventHandler(this.onInitSearchBtnClick);
            this.SearchBtn.Click += new EventHandler(this.searchBtnClick);
            this.FormClosed += this.onClosedEvent;
            this.client = new WASimClient(0xA7E57E91);
            this.init();
        }

        private void onClosedEvent(object? sender, EventArgs e)
        {
            client.disconnectServer();
            client.disconnectSimulator();
            // delete the client
            client.Dispose();

        }



        private void init()
        {
            this.client.OnClientEvent += ClientStatusHandler;
            this.client.OnLogRecordReceived += LogHandler;
            this.client.OnListResults += ListResultsHandler;

            client.setLogLevel(LogLevel.Info, LogFacility.Remote, LogSource.Client);
            // Set client's console log level to None to avoid double logging to our console. (Client also logs to a file by default.)
            client.setLogLevel(LogLevel.None, LogFacility.Console, LogSource.Client);
            // Lets also see some log messages from the server
            client.setLogLevel(LogLevel.Info, LogFacility.Remote, LogSource.Server);

        }

        void ClientStatusHandler(ClientEvent ev)
        {
            // 使用 BeginInvoke 确保在 UI 线程上执行控件操作
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(() => UpdateClientStatus(ev)));
                return;
            }

            UpdateClientStatus(ev);
        }

        private void UpdateClientStatus(ClientEvent ev)
        {
            if (ev.status == ClientStatus.SimConnected)
            {
                this.ConnButton.Text = "Connected";
                this.ConnButton.BackColor = Color.Green;
            }
            else if (ev.status == ClientStatus.ShuttingDown)
            {
                this.ConnButton.Text = "connect";
                this.ConnButton.BackColor = Color.White;
            }

            this.logList.Items.Add($"Client event {ev.eventType} - \"{ev.message}\"; Client status: {ev.status}");
        }

        void LogHandler(LogRecord lr, LogSource src)
        {
            SafeLog(lr.ToString(), src.ToString());
        }

        void SafeLog(string log, string prfx = ":")
        {
            if (this.logList.InvokeRequired)
            {
                this.logList.BeginInvoke(new Action(() => SafeLog(log, prfx)));
                return;
            }
            Log(log, prfx);
        }

        void showResult()
        {
            this.varLists.Items.Clear();
            Dictionary<int, string>.Enumerator enumerator = this.searchResults.GetEnumerator();
            while (enumerator.MoveNext())
            {
                string value = "L:"+enumerator.Current.Value;
                this.varLists.Items.Add(value);
            }

            this.simvarList.ForEach(s => {
                string value = "A:"+s.Name;
                this.varLists.Items.Add(value);
            });

        }

        void safeShowResult()
        {
            if (this.varLists.InvokeRequired)
            {
                this.varLists.BeginInvoke(new Action(() => safeShowResult()));
                return;
            }
            showResult();
        }


        private void Log(string log, string prfx = ":")
        {
            string msg = string.Format("[{0}] {1} {2}", DateTime.Now.ToString("hh:mm:ss.fff"), prfx, log);
            this.logList.SelectedIndex = this.logList.Items.Add(msg);

        }

        void onConnectButtonClick(object? sender, EventArgs e)
        {
            this.Log("connect msfs2024....");
            HR hr;  // store method invocation results for logging
            // Connect to Simulator (SimConnect) using default timeout period and network configuration (local Simulator)
            if ((hr = client.connectSimulator()) != HR.OK)
            {
                this.Log("Cannot connect to Simulator, quitting. Error: " + hr.ToString(), "XX");
                client.Dispose();
                return;
            }

            // Ping the WASimCommander server to make sure it's running and get the server version number (returns zero if no response).
            UInt32 version = client.pingServer();
            if (version == 0)
            {
                Log("Server did not respond to ping, quitting.", "XX");
                client.Dispose();
                return;
            }
            // Decode version number to dotted format and print it
            Log($"Found WASimModule Server v{version >> 24}.{(version >> 16) & 0xFF}.{(version >> 8) & 0xFF}.{version & 0xFF}");

            // Try to connect to the server, using default timeout value.
            if ((hr = client.connectServer()) != HR.OK)
            {
                Log("Server connection failed, quitting. Error: " + hr.ToString(), "XX");
                return;
            }

        }

        void onInitSearchBtnClick(object? sender, EventArgs e)
        {
            try
            {
                if (this.ValueEdit.Text == "")
                {
                    this.Log("Please input search value");
                    return;
                }

                if (this.lValueCheck.Checked == false && this.aValueCheck.Checked == false)
                {
                    this.Log("Please check at least one value type");
                    return;
                }

                Log("begin Search: " + this.ValueEdit.Text);

                this.initOk = false;
                this.searchResults.Clear();
                this.varLists.Items.Clear();
                this.simvarList.Clear();

                if (this.lValueCheck.Checked)
                {
                    // 使用更安全的方式调用 list 方法
                    HR hr;
                    if ((hr = this.client.list(LookupItemType.LocalVariable)) != HR.OK)
                    {
                        Log("Server list failed, Error: " + hr.ToString(), "XX");
                        return;
                    }

                    Log("List command sent successfully", ">>");

                    if (!AwaitData(10000))
                    {
                        // Log("Data update timed out!", "!!");
                        return;
                    }
                }
                if (this.aValueCheck.Checked)
                {
                    this.simvarList = this.simvarManager.GetNumericSimvars();
                }
                float originalFloat;
                if (float.TryParse(this.ValueEdit.Text, out originalFloat))
                {
                    originalFloat = (float)Math.Round(originalFloat, 2);
                    Dictionary<int, string>.Enumerator enumerator = this.searchResults.GetEnumerator();
                    Dictionary<int, string> varList = new Dictionary<int, string>();
                    while (enumerator.MoveNext())
                    {
                        string value = enumerator.Current.Value;
                        int arg = enumerator.Current.Key;
                        this.SafeLog($"check {value} value");
                        double fResult = 0;
                        if (client.getLocalVariable(value, out fResult) == HR.OK)
                        {
                            float tempValue = (float)Math.Round((float)fResult, 2);
                            if (tempValue == originalFloat)
                            {
                                varList.Add(arg, value);
                            }
                        }
                        else
                        {
                            this.SafeLog($"get {value} value error");
                        }
                    }
                    this.searchResults = varList;

                    List<SimvarInfo> tempSimvarList = new List<SimvarInfo>();

                    this.simvarList.ForEach(s =>
                    {
                        client.getVariable(new VariableRequest(s.Name, s.Unit, 0), out double fResult, out string sResult);
                        float tempValue = (float)Math.Round((float)fResult, 2);
                        if (tempValue == originalFloat)
                        {
                            tempSimvarList.Add(s);
                        }
                    });

                    this.simvarList = tempSimvarList;

                    this.SafeLog($"init find {this.searchResults.Count} local vars");
                    this.SafeLog($"init find {this.simvarList.Count} sim vars");
                    safeShowResult();

                }
            }
            catch (Exception ex)
            {
                Log($"Error in search: {ex.Message}", "ERROR");
            }
        }

        private void ListResultsHandler(ListResult lr)
        {
            // if (this.logList.InvokeRequired)
            // {
            //     this.logList.BeginInvoke(new Action(() => Log(lr.ToString())));
            //     return;
            // }

            dataUpdateEvent.Set();
            this.searchResults = lr.list;
            this.initOk = true;
            // Log(lr.ToString());
        }

        bool AwaitData(int ms = 1000)
        {
            if (dataUpdateEvent.WaitOne(ms))
                return true;
            Log("Data update timed out!", "!!");
            return false;
        }

        private void searchBtnClick(object? sender, EventArgs e)
        {
            if (this.ValueEdit.Text == "")
            {
                this.Log("Please input search value");
                return;
            }

            Log("begin Search: " + this.ValueEdit.Text);
            float originalFloat;
            if (float.TryParse(this.ValueEdit.Text, out originalFloat))
            {
                originalFloat = (float)Math.Round(originalFloat, 2);
                Dictionary<int, string>.Enumerator enumerator = this.searchResults.GetEnumerator();
                Dictionary<int, string> varList = new Dictionary<int, string>();
                while (enumerator.MoveNext())
                {
                    string value = enumerator.Current.Value;
                    int arg = enumerator.Current.Key;
                    this.SafeLog($"check {value} value");
                    double fResult = 0;
                    if (client.getLocalVariable(value, out fResult) == HR.OK)
                    {
                        float tempValue = (float)Math.Round((float)fResult, 2);
                        if (tempValue == originalFloat)
                        {
                            varList.Add(arg, value);
                        }
                    }
                    else
                    {
                        this.SafeLog($"get {value} value error");
                    }
                }
                this.searchResults = varList;
                this.SafeLog($"find {this.searchResults.Count} vars");

                List<SimvarInfo> tempSimvarList = new List<SimvarInfo>();

                this.simvarList.ForEach(s => {
                    client.getVariable(new VariableRequest(s.Name, s.Unit, 0), out double fResult, out string sResult);
                    float tempValue = (float)Math.Round((float)fResult, 2);
                    if (tempValue == originalFloat) {
                        tempSimvarList.Add(s);
                    }
                });
                
                this.simvarList = tempSimvarList;

                this.SafeLog($"find {this.simvarList.Count} sim vars");

                this.initOk = true;
                safeShowResult();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.varLists.Items.Count > 0)
            {
                if (this.varLists.SelectedIndex != -1)
                {
                    Clipboard.SetText(varLists.Items[this.varLists.SelectedIndex].ToString());
                    this.SafeLog("var name copyed");
                }
            }

        }

        private void ValueEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (this.initOk)
                {
                    this.searchBtnClick(sender, e);
                    return;
                }
                this.onInitSearchBtnClick(sender, e);
            }
        }
    }
}
