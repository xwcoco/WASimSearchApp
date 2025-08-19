using WASimCommander.CLI.Client;
using WASimCommander.CLI.Enums;
using WASimCommander.CLI.Structs;

namespace WASimSearchApp
{
    public partial class MainForm : Form
    {
        private WASimClient client;
        public MainForm()
        {
            InitializeComponent();
            this.ConnButton.Click += new EventHandler(this.onConnectButtonClick);
            this.init();
        }

        private void init()   
        {
            this.client = new WASimClient(0xA7E57E91);
            this.client.OnClientEvent += ClientStatusHandler;
            this.client.OnLogRecordReceived += LogHandler;

            client.setLogLevel(LogLevel.Info, LogFacility.Remote, LogSource.Client);
            // Set client's console log level to None to avoid double logging to our console. (Client also logs to a file by default.)
            client.setLogLevel(LogLevel.None, LogFacility.Console, LogSource.Client);
            // Lets also see some log messages from the server
            client.setLogLevel(LogLevel.Info, LogFacility.Remote, LogSource.Server);

        }

        void ClientStatusHandler(ClientEvent ev)
        {
            if (ev.status == ClientStatus.SimConnected)
            {
                this.ConnButton.Text = "Connected";
                this.ConnButton.BackColor = Color.Green;
            } else if (ev.status == ClientStatus.ShuttingDown)
            {
                this.ConnButton.Text = "connect";
                this.ConnButton.BackColor = Color.White;

            }
                this.logList.Items.Add($"Client event {ev.eventType} - \"{ev.message}\"; Client status: {ev.status}");
        }

        void LogHandler(LogRecord lr, LogSource src)
        {
            this.logList.Items.Add($"{src} Log: {lr}");
        }

        private void Log(string log, string prfx = "=:")
        {
            string msg = string.Format("[{0}] {1} {2}", DateTime.Now.ToString("mm:ss.fff"), prfx, log);
            this.logList.SelectedIndex = this.logList.Items.Add(msg);
            
        }

        void onConnectButtonClick(Object sender,EventArgs e)
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
    }
}
