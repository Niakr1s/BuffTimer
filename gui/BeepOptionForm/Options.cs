namespace buff_timer.gui.BeepOptionForm
{
    public record Options
    {
        public TimeSpan Duration { get; private set; }
        public TimeSpan BeepLast { get; private set; }
        public TimeSpan BeepInterval { get; private set; }
        public Options(TimeSpan duration, TimeSpan beepLast, TimeSpan beepInterval)
        {
            Duration = duration;
            BeepLast = beepLast;
            BeepInterval = beepInterval;

            Validate();
        }

        private void Validate()
        {
            if (BeepLast > Duration)
            {
                BeepLast = Duration;
            }

            if (Duration == TimeSpan.Zero)
            {
                Duration = TimeSpan.FromSeconds(1);
            }

            if (BeepLast == TimeSpan.Zero)
            {
                BeepLast = TimeSpan.FromSeconds(1);
            }

            if (BeepInterval == TimeSpan.Zero)
            {
                BeepInterval = TimeSpan.FromSeconds(1);
            }
        }

        public string ToSummaryString()
        {
            return
                 $"Summary:\nTimer will last for {Duration};\nwhen {BeepLast} remains, will beep each {BeepInterval}";
        }
    }
}
