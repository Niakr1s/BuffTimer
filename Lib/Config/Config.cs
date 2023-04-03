using buff_timer.gui.BeepOptionForm;

namespace buff_timer
{
    internal static class Config
    {
        internal static Options Options
        {
            get => new(
                    Properties.Settings.Default.Duration,
                    Properties.Settings.Default.BeepLast,
                    Properties.Settings.Default.BeepInterval
                    );
            set
            {
                Properties.Settings.Default.Duration = value.Duration;
                Properties.Settings.Default.BeepLast = value.BeepLast;
                Properties.Settings.Default.BeepInterval = value.BeepInterval;
                Properties.Settings.Default.Save();
            }
        }
    }
}
