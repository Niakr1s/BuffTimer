namespace buff_timer
{
    public class BuffTimerTickEventArgs
    {
        public TimeSpan TimeLeft { get; }
        public BuffTimerTickEventArgs(TimeSpan timeLeft)
        {
            TimeLeft = timeLeft;
        }
    }

    public class BuffTimer
    {
        private readonly System.Timers.Timer _timer;
        private static readonly TimeSpan _timerTick = TimeSpan.FromSeconds(1);

        public bool Enabled { get => _timer.Enabled; }


        private TimeSpan _timeLeft; // in private methods use TimeLeft prop instead of this
        public TimeSpan TimeLeft
        {
            get => _timeLeft;
            private set
            {
                if (_timeLeft == value)
                {
                    return;
                }
                _timeLeft = value;

                if (_timeLeft == TimeSpan.Zero)
                {
                    _timer.Stop();
                }
                Tick?.Invoke(this, new(TimeLeft));
            }
        }


        public event EventHandler<BuffTimerTickEventArgs>? Tick;

        public BuffTimer(TimeSpan duration)
        {
            _timeLeft = duration;
            _timer = new(_timerTick)
            {
                AutoReset = true
            };
            _timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            TimeLeft = TimeLeft.Subtract(_timerTick);
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            TimeLeft = TimeSpan.Zero;
        }
    }
}
