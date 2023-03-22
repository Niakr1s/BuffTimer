namespace buff_timer
{
    internal static class Config
    {
        internal static BeepOptions BeepOptions
        {
            get => new(
                    Properties.Settings.Default.BeepOptions_Ticks,
                    Properties.Settings.Default.BeepOptions_BeepEveryTickAfter,
                    Properties.Settings.Default.BeepOptions_BeepEverySecondAfter
                    );
            set
            {
                Properties.Settings.Default.BeepOptions_Ticks = value.Ticks;
                Properties.Settings.Default.BeepOptions_BeepEveryTickAfter = value.BeepEveryTickAfter;
                Properties.Settings.Default.BeepOptions_BeepEverySecondAfter = value.BeepEverySecondAfter;
                Properties.Settings.Default.Save();
            }
        }

        internal static BuffTimerType BuffTimerType
        {
            get => (BuffTimerType)Properties.Settings.Default.BuffTimerType;
            set
            {
                Properties.Settings.Default.BuffTimerType = ((int)value);
                Properties.Settings.Default.Save();
            }
        }
    }
}
