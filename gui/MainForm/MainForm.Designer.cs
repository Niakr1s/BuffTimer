namespace buff_timer
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            timerLabel = new Label();
            summaryTooltip = new ToolTip(components);
            contextMenu = new ContextMenuStrip(components);
            restartToolStripMenuItem = new ToolStripMenuItem();
            stopTimerToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            optionsToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            contextMenu.SuspendLayout();
            SuspendLayout();
            // 
            // timerLabel
            // 
            timerLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            timerLabel.AutoSize = true;
            timerLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            timerLabel.ForeColor = Color.White;
            timerLabel.Location = new Point(12, 9);
            timerLabel.Name = "timerLabel";
            timerLabel.Size = new Size(49, 21);
            timerLabel.TabIndex = 0;
            timerLabel.Text = "02:39";
            timerLabel.MouseDown += OnMouseDown;
            // 
            // summaryTooltip
            // 
            summaryTooltip.Popup += summaryTooltip_Popup;
            // 
            // contextMenu
            // 
            contextMenu.Items.AddRange(new ToolStripItem[] { stopTimerToolStripMenuItem, restartToolStripMenuItem, toolStripSeparator1, optionsToolStripMenuItem, toolStripSeparator2, exitToolStripMenuItem });
            contextMenu.Name = "contextMenu";
            contextMenu.Size = new Size(181, 126);
            contextMenu.Opening += contextMenu_Opening;
            contextMenu.Opened += contextMenu_Opened;
            // 
            // restartToolStripMenuItem
            // 
            restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            restartToolStripMenuItem.Size = new Size(180, 22);
            restartToolStripMenuItem.Text = "Restart (F12)";
            restartToolStripMenuItem.Click += restartToolStripMenuItem_Click;
            // 
            // stopTimerToolStripMenuItem
            // 
            stopTimerToolStripMenuItem.Name = "stopTimerToolStripMenuItem";
            stopTimerToolStripMenuItem.Size = new Size(180, 22);
            stopTimerToolStripMenuItem.Text = "Stop (F11)";
            stopTimerToolStripMenuItem.Click += stopTimerToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(177, 6);
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            optionsToolStripMenuItem.Size = new Size(180, 22);
            optionsToolStripMenuItem.Text = "Options";
            optionsToolStripMenuItem.Click += optionsToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(177, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(180, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(70, 40);
            ControlBox = false;
            Controls.Add(timerLabel);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(70, 40);
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            MinimumSize = new Size(70, 40);
            Name = "MainForm";
            Opacity = 0.8D;
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "MainForm";
            TopMost = true;
            MouseDown += OnMouseDown;
            contextMenu.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label timerLabel;
        private ToolTip summaryTooltip;
        private ContextMenuStrip contextMenu;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem restartToolStripMenuItem;
        private ToolStripMenuItem stopTimerToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
    }
}