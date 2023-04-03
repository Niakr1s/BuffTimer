namespace buff_timer
{
    public partial class BeepOptionsForm : Form
    {
        readonly BeepOptions _beepOptions;

        public BeepOptionsForm(BeepOptions beepOptions)
        {
            InitializeComponent();

            _beepOptions = beepOptions;

            InitializeTrackBar(everyTickBar, _beepOptions.BeepEveryTickAfter);
            InitializeTrackBar(everySecondBar, _beepOptions.BeepEverySecondAfter);
        }

        private void InitializeTrackBar(TrackBar trackBar, int value)
        {
            trackBar.Maximum = _beepOptions.Ticks;
            trackBar.Value = value;
            trackBar.ValueChanged += TrackBar_ValueChanged;
            UpdateLabels();
        }

        private void TrackBar_ValueChanged(object? sender, EventArgs e)
        {
            UpdateLabels();
        }

        private void UpdateLabels()
        {
            everyTickLabel.Text =
                $"Beep every TICK when {everyTickBar.Value}/{_beepOptions.Ticks} or less remain:";
            everySecondLabel.Text =
                $"Beep every SECOND when {everySecondBar.Value}/{_beepOptions.Ticks} or less remain:";
        }

        public BeepOptions BeepOptions
        {
            get => new(_beepOptions.Ticks, everyTickBar.Value, everySecondBar.Value);
        }
    }
}
