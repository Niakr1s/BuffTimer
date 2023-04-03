using buff_timer.gui.BeepOptionForm;

namespace buff_timer
{
    public partial class OptionsForm : Form
    {
        public OptionsForm(Options options)
        {
            InitializeComponent();
            UpdateAll(options);
        }

        private void UpdateAll(Options options)
        {
            timerDurationMinutesNumericUpDown.Value = (int)options.Duration.TotalMinutes;

            beepLastSecondsBar.Maximum = (int)options.Duration.TotalSeconds;
            beepLastSecondsBar.Value = (int)options.BeepLast.TotalSeconds;

            beepIntervalSecondsBar.Maximum = 5;
            beepIntervalSecondsBar.Value = (int)options.BeepInterval.TotalSeconds;

            summaryLabel.Text =
                $"Summary:\nTimer will last for {options.Duration};\nwhen {options.BeepLast} remains, will beep each {options.BeepInterval}";
        }

        private void timerDurationMinutesNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateAll(Options);
        }

        private void beepLastSecondsBar_ValueChanged(object sender, EventArgs e)
        {
            UpdateAll(Options);
        }

        private void beepIntervalSecondsBar_ValueChanged(object sender, EventArgs e)
        {
            UpdateAll(Options);
        }

        public Options Options
        {
            get => new
                (
                    TimeSpan.FromMinutes((int)timerDurationMinutesNumericUpDown.Value),
                    TimeSpan.FromSeconds(beepLastSecondsBar.Value),
                    TimeSpan.FromSeconds(beepIntervalSecondsBar.Value)
                );
        }
    }
}
