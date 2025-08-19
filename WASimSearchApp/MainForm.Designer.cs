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
            button2 = new Button();
            ConnButton = new Button();
            splitContainer1 = new SplitContainer();
            panel3 = new Panel();
            resultList = new ListBox();
            panel2 = new Panel();
            checkBox1 = new CheckBox();
            button3 = new Button();
            label1 = new Label();
            ValueEdit = new TextBox();
            logList = new ListBox();
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
            panel1.Controls.Add(button2);
            panel1.Controls.Add(ConnButton);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(954, 32);
            panel1.TabIndex = 0;
            // 
            // button2
            // 
            button2.Dock = DockStyle.Right;
            button2.Location = new Point(831, 0);
            button2.Margin = new Padding(3, 3, 20, 3);
            button2.Name = "button2";
            button2.Size = new Size(123, 32);
            button2.TabIndex = 1;
            button2.Text = "Init Search";
            button2.UseVisualStyleBackColor = true;
            // 
            // ConnButton
            // 
            ConnButton.Location = new Point(12, 6);
            ConnButton.Name = "ConnButton";
            ConnButton.Size = new Size(75, 23);
            ConnButton.TabIndex = 0;
            ConnButton.Text = "Connect";
            ConnButton.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 32);
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
            splitContainer1.Size = new Size(954, 532);
            splitContainer1.SplitterDistance = 354;
            splitContainer1.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Controls.Add(resultList);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(200, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(754, 354);
            panel3.TabIndex = 1;
            // 
            // resultList
            // 
            resultList.Dock = DockStyle.Fill;
            resultList.FormattingEnabled = true;
            resultList.ItemHeight = 17;
            resultList.Location = new Point(0, 0);
            resultList.Name = "resultList";
            resultList.Size = new Size(754, 354);
            resultList.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(checkBox1);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(ValueEdit);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(200, 354);
            panel2.TabIndex = 0;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = CheckState.Checked;
            checkBox1.Location = new Point(14, 96);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(72, 21);
            checkBox1.TabIndex = 3;
            checkBox1.Text = "L: Value";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(41, 150);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 2;
            button3.Text = "Search";
            button3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 23);
            label1.Name = "label1";
            label1.Size = new Size(78, 17);
            label1.TabIndex = 1;
            label1.Text = "Seach Value";
            // 
            // ValueEdit
            // 
            ValueEdit.Location = new Point(12, 54);
            ValueEdit.Name = "ValueEdit";
            ValueEdit.Size = new Size(171, 23);
            ValueEdit.TabIndex = 0;
            // 
            // logList
            // 
            logList.Dock = DockStyle.Fill;
            logList.FormattingEnabled = true;
            logList.ItemHeight = 17;
            logList.Location = new Point(0, 0);
            logList.Name = "logList";
            logList.Size = new Size(954, 174);
            logList.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(954, 564);
            Controls.Add(splitContainer1);
            Controls.Add(panel1);
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
        private Button button2;
        private Button ConnButton;
        private SplitContainer splitContainer1;
        private Panel panel3;
        private Panel panel2;
        private ListBox logList;
        private CheckBox checkBox1;
        private Button button3;
        private Label label1;
        private TextBox ValueEdit;
        private ListBox resultList;
    }
}
