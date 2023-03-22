namespace buff_timer
{
    partial class BeepOptionsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BeepOptionsForm));
            everyTickLabel = new Label();
            everyTickBar = new TrackBar();
            everySecondLabel = new Label();
            everySecondBar = new TrackBar();
            ((System.ComponentModel.ISupportInitialize)everyTickBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)everySecondBar).BeginInit();
            SuspendLayout();
            // 
            // everyTickLabel
            // 
            everyTickLabel.AutoSize = true;
            everyTickLabel.Location = new Point(12, 14);
            everyTickLabel.Name = "everyTickLabel";
            everyTickLabel.Size = new Size(234, 15);
            everyTickLabel.TabIndex = 2;
            everyTickLabel.Text = "Beep every TICK when 10/20 or less remain:";
            // 
            // everyTickBar
            // 
            everyTickBar.Location = new Point(12, 32);
            everyTickBar.Maximum = 20;
            everyTickBar.Name = "everyTickBar";
            everyTickBar.Size = new Size(267, 45);
            everyTickBar.TabIndex = 8;
            // 
            // everySecondLabel
            // 
            everySecondLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            everySecondLabel.AutoSize = true;
            everySecondLabel.Location = new Point(12, 93);
            everySecondLabel.Name = "everySecondLabel";
            everySecondLabel.Size = new Size(250, 15);
            everySecondLabel.TabIndex = 10;
            everySecondLabel.Text = "Beep every SECOND when 1/20 or less remain:";
            // 
            // everySecondBar
            // 
            everySecondBar.Location = new Point(12, 111);
            everySecondBar.Maximum = 20;
            everySecondBar.Name = "everySecondBar";
            everySecondBar.Size = new Size(267, 45);
            everySecondBar.TabIndex = 9;
            // 
            // BeepOptionsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(291, 168);
            Controls.Add(everySecondLabel);
            Controls.Add(everySecondBar);
            Controls.Add(everyTickBar);
            Controls.Add(everyTickLabel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BeepOptionsForm";
            Text = "BeepOptionsForm";
            ((System.ComponentModel.ISupportInitialize)everyTickBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)everySecondBar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label everyTickLabel;
        private TrackBar everyTickBar;
        private Label everySecondLabel;
        private TrackBar everySecondBar;
    }
}