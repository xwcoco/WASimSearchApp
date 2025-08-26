namespace WASimSearchApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            initSearchBtn = new Button();
            ConnButton = new Button();
            splitContainer1 = new SplitContainer();
            panel3 = new Panel();
            varLists = new ListBox();
            panel2 = new Panel();
            copyBtn = new Button();
            lValueCheck = new CheckBox();
            SearchBtn = new Button();
            label1 = new Label();
            ValueEdit = new TextBox();
            logList = new ListBox();
            progressBar1 = new ProgressBar();
            aValueCheck = new CheckBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.Controls.Add(initSearchBtn);
            panel1.Controls.Add(ConnButton);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(5, 4, 5, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1499, 44);
            panel1.TabIndex = 0;
            // 
            // initSearchBtn
            // 
            initSearchBtn.Dock = DockStyle.Right;
            initSearchBtn.Location = new Point(1306, 0);
            initSearchBtn.Margin = new Padding(5, 4, 31, 4);
            initSearchBtn.Name = "initSearchBtn";
            initSearchBtn.Size = new Size(193, 44);
            initSearchBtn.TabIndex = 1;
            initSearchBtn.Text = "Init Search";
            initSearchBtn.UseVisualStyleBackColor = true;
            // 
            // ConnButton
            // 
            ConnButton.Location = new Point(19, 8);
            ConnButton.Margin = new Padding(5, 4, 5, 4);
            ConnButton.Name = "ConnButton";
            ConnButton.Size = new Size(118, 32);
            ConnButton.TabIndex = 0;
            ConnButton.Text = "Connect";
            ConnButton.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 44);
            splitContainer1.Margin = new Padding(5, 4, 5, 4);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(panel3);
            splitContainer1.Panel1.Controls.Add(panel2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(logList);
            splitContainer1.Size = new Size(1499, 752);
            splitContainer1.SplitterDistance = 500;
            splitContainer1.SplitterWidth = 6;
            splitContainer1.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Controls.Add(varLists);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(314, 0);
            panel3.Margin = new Padding(5, 4, 5, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(1185, 500);
            panel3.TabIndex = 1;
            // 
            // varLists
            // 
            varLists.Dock = DockStyle.Fill;
            varLists.Font = new Font("Microsoft YaHei UI", 18F);
            varLists.FormattingEnabled = true;
            varLists.ItemHeight = 46;
            varLists.Location = new Point(0, 0);
            varLists.Margin = new Padding(5, 4, 5, 4);
            varLists.Name = "varLists";
            varLists.Size = new Size(1185, 500);
            varLists.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(aValueCheck);
            panel2.Controls.Add(progressBar1);
            panel2.Controls.Add(copyBtn);
            panel2.Controls.Add(lValueCheck);
            panel2.Controls.Add(SearchBtn);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(ValueEdit);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(5, 4, 5, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(314, 500);
            panel2.TabIndex = 0;
            // 
            // copyBtn
            // 
            copyBtn.Location = new Point(33, 375);
            copyBtn.Name = "copyBtn";
            copyBtn.Size = new Size(235, 34);
            copyBtn.TabIndex = 4;
            copyBtn.Text = "Copy To Clipboard";
            copyBtn.UseVisualStyleBackColor = true;
            copyBtn.Click += button1_Click;
            // 
            // lValueCheck
            // 
            lValueCheck.AutoSize = true;
            lValueCheck.Checked = true;
            lValueCheck.CheckState = CheckState.Checked;
            lValueCheck.Location = new Point(22, 136);
            lValueCheck.Margin = new Padding(5, 4, 5, 4);
            lValueCheck.Name = "lValueCheck";
            lValueCheck.Size = new Size(102, 28);
            lValueCheck.TabIndex = 3;
            lValueCheck.Text = "L: Value";
            lValueCheck.UseVisualStyleBackColor = true;
            // 
            // SearchBtn
            // 
            SearchBtn.Location = new Point(64, 212);
            SearchBtn.Margin = new Padding(5, 4, 5, 4);
            SearchBtn.Name = "SearchBtn";
            SearchBtn.Size = new Size(118, 32);
            SearchBtn.TabIndex = 2;
            SearchBtn.Text = "Search";
            SearchBtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 32);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(113, 24);
            label1.TabIndex = 1;
            label1.Text = "Seach Value";
            // 
            // ValueEdit
            // 
            ValueEdit.Location = new Point(19, 76);
            ValueEdit.Margin = new Padding(5, 4, 5, 4);
            ValueEdit.Name = "ValueEdit";
            ValueEdit.Size = new Size(266, 30);
            ValueEdit.TabIndex = 0;
            ValueEdit.KeyPress += ValueEdit_KeyPress;
            // 
            // logList
            // 
            logList.BackColor = SystemColors.Desktop;
            logList.Dock = DockStyle.Fill;
            logList.Font = new Font("Microsoft YaHei UI", 18F);
            logList.ForeColor = SystemColors.Menu;
            logList.FormattingEnabled = true;
            logList.ItemHeight = 46;
            logList.Location = new Point(0, 0);
            logList.Margin = new Padding(5, 4, 5, 4);
            logList.Name = "logList";
            logList.Size = new Size(1499, 246);
            logList.TabIndex = 0;
            // 
            // progressBar1
            // 
            progressBar1.Dock = DockStyle.Bottom;
            progressBar1.Location = new Point(0, 466);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(314, 34);
            progressBar1.TabIndex = 5;
            // 
            // aValueCheck
            // 
            aValueCheck.AutoSize = true;
            aValueCheck.Location = new Point(141, 136);
            aValueCheck.Name = "aValueCheck";
            aValueCheck.Size = new Size(106, 28);
            aValueCheck.TabIndex = 6;
            aValueCheck.Text = "A: Value";
            aValueCheck.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1499, 796);
            Controls.Add(splitContainer1);
            Controls.Add(panel1);
            Margin = new Padding(5, 4, 5, 4);
            Name = "MainForm";
            Text = "MainForm";
            panel1.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button initSearchBtn;
        private Button ConnButton;
        private SplitContainer splitContainer1;
        private Panel panel3;
        private Panel panel2;
        private ListBox logList;
        private CheckBox lValueCheck;
        private Button SearchBtn;
        private Label label1;
        private TextBox ValueEdit;
        private ListBox varLists;
        private Button copyBtn;
        private ProgressBar progressBar1;
        private CheckBox aValueCheck;
    }
}
