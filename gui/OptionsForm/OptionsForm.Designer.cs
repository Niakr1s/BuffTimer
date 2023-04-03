namespace buff_timer
{
    partial class OptionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
            beepLastLabel = new Label();
            beepLastSecondsBar = new TrackBar();
            beepIntervalLabel = new Label();
            beepIntervalSecondsBar = new TrackBar();
            timerDurationMinutesNumericUpDown = new NumericUpDown();
            timerDurationLabel = new Label();
            summaryLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)beepLastSecondsBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)beepIntervalSecondsBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)timerDurationMinutesNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // beepLastLabel
            // 
            beepLastLabel.AutoSize = true;
            beepLastLabel.Location = new Point(12, 56);
            beepLastLabel.Name = "beepLastLabel";
            beepLastLabel.Size = new Size(77, 15);
            beepLastLabel.TabIndex = 2;
            beepLastLabel.Text = "Beep last, sec";
            // 
            // beepLastSecondsBar
            // 
            beepLastSecondsBar.Location = new Point(12, 74);
            beepLastSecondsBar.Maximum = 20;
            beepLastSecondsBar.Minimum = 1;
            beepLastSecondsBar.Name = "beepLastSecondsBar";
            beepLastSecondsBar.Size = new Size(267, 45);
            beepLastSecondsBar.TabIndex = 8;
            beepLastSecondsBar.TickStyle = TickStyle.None;
            beepLastSecondsBar.Value = 1;
            beepLastSecondsBar.ValueChanged += beepLastSecondsBar_ValueChanged;
            // 
            // beepIntervalLabel
            // 
            beepIntervalLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            beepIntervalLabel.AutoSize = true;
            beepIntervalLabel.Location = new Point(12, 131);
            beepIntervalLabel.Name = "beepIntervalLabel";
            beepIntervalLabel.Size = new Size(98, 15);
            beepIntervalLabel.TabIndex = 10;
            beepIntervalLabel.Text = "Beep interval, sec";
            // 
            // beepIntervalSecondsBar
            // 
            beepIntervalSecondsBar.Location = new Point(12, 149);
            beepIntervalSecondsBar.Maximum = 20;
            beepIntervalSecondsBar.Minimum = 1;
            beepIntervalSecondsBar.Name = "beepIntervalSecondsBar";
            beepIntervalSecondsBar.Size = new Size(267, 45);
            beepIntervalSecondsBar.TabIndex = 9;
            beepIntervalSecondsBar.Value = 1;
            beepIntervalSecondsBar.ValueChanged += beepIntervalSecondsBar_ValueChanged;
            // 
            // timerDurationMinutesNumericUpDown
            // 
            timerDurationMinutesNumericUpDown.Location = new Point(159, 12);
            timerDurationMinutesNumericUpDown.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            timerDurationMinutesNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            timerDurationMinutesNumericUpDown.Name = "timerDurationMinutesNumericUpDown";
            timerDurationMinutesNumericUpDown.Size = new Size(120, 23);
            timerDurationMinutesNumericUpDown.TabIndex = 11;
            timerDurationMinutesNumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            timerDurationMinutesNumericUpDown.ValueChanged += timerDurationMinutesNumericUpDown_ValueChanged;
            // 
            // timerDurationLabel
            // 
            timerDurationLabel.AutoSize = true;
            timerDurationLabel.Location = new Point(12, 14);
            timerDurationLabel.Name = "timerDurationLabel";
            timerDurationLabel.Size = new Size(112, 15);
            timerDurationLabel.TabIndex = 12;
            timerDurationLabel.Text = "Timer duration, min";
            // 
            // summaryLabel
            // 
            summaryLabel.AutoSize = true;
            summaryLabel.Location = new Point(12, 197);
            summaryLabel.Name = "summaryLabel";
            summaryLabel.Size = new Size(61, 15);
            summaryLabel.TabIndex = 13;
            summaryLabel.Text = "Summary:";
            // 
            // OptionsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(291, 251);
            Controls.Add(summaryLabel);
            Controls.Add(timerDurationLabel);
            Controls.Add(timerDurationMinutesNumericUpDown);
            Controls.Add(beepIntervalLabel);
            Controls.Add(beepIntervalSecondsBar);
            Controls.Add(beepLastSecondsBar);
            Controls.Add(beepLastLabel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "OptionsForm";
            Text = "BeepOptionsForm";
            ((System.ComponentModel.ISupportInitialize)beepLastSecondsBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)beepIntervalSecondsBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)timerDurationMinutesNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label beepLastLabel;
        private TrackBar beepLastSecondsBar;
        private Label beepIntervalLabel;
        private TrackBar beepIntervalSecondsBar;
        private NumericUpDown timerDurationMinutesNumericUpDown;
        private Label timerDurationLabel;
        private Label summaryLabel;
    }
}