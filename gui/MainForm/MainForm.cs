using Gma.System.MouseKeyHook;

namespace buff_timer
{
    internal enum BuffTimerActions
    {
        Restart,
        Stop,
    }

    public partial class MainForm : Form
    {
        private readonly IKeyboardMouseEvents _keyHook;
        private readonly Dictionary<BuffTimerActions, Keys> _keyActions;

        private BuffTimer? _buffTimer;
        private TimeSpan _buffTimerDuration = TimeSpan.FromMinutes(20);

        private readonly NotifyIcon _trayIcon;

        private BeepOptions _beepOptions;
        public BeepOptions BeepOptions
        {
            get => _beepOptions;
            set
            {
                if (_beepOptions == value)
                {
                    return;
                }

                _beepOptions = value;
                Config.BeepOptions = value;
            }
        }

        private readonly Beeper _beeper;


        public MainForm()
        {
            InitializeComponent();
            _beeper = new DefaultBeeper();
            _beepOptions = Config.BeepOptions;

            AppContextMenu contextMenu = new AppContextMenu();
            contextMenu.ExitRequested += ContextMenu_ExitRequested;
            contextMenu.BeepOptionsRequested += ContextMenu_BeepOptionsRequested;

            ContextMenuStrip = contextMenu;
            _trayIcon = InitializeTrayIcon(contextMenu);

            _keyHook = Hook.GlobalEvents();
            _keyActions = new Dictionary<BuffTimerActions, Keys>()
            {
                [BuffTimerActions.Restart] = Keys.F12,
                [BuffTimerActions.Stop] = Keys.F11,
            };
            BindKeyboard();

            TimerRestart();
        }

        private void ContextMenu_BeepOptionsRequested(object? sender, EventArgs e)
        {
            BeepOptionsForm beepOptionsForm = new(BeepOptions);
            beepOptionsForm.ShowDialog();
            BeepOptions = beepOptionsForm.BeepOptions;
        }

        private void ContextMenu_ExitRequested(object? sender, EventArgs e)
        {
            _trayIcon.Dispose();
            this.Close();
        }

        private NotifyIcon InitializeTrayIcon(ContextMenuStrip contextMenu)
        {
            NotifyIcon trayIcon = new()
            {
                Icon = Icon,
                ContextMenuStrip = contextMenu,
                Visible = true
            };
            return trayIcon;
        }

        private void BindKeyboard()
        {
            _keyHook.OnCombination(new Dictionary<Combination, Action>() {
                { Combination.TriggeredBy(_keyActions[BuffTimerActions.Stop]), TimerStop },
                { Combination.TriggeredBy(_keyActions[BuffTimerActions.Restart]), TimerRestart },
            });
        }

        private void TimerStop()
        {
            if (_buffTimer != null)
            {
                _buffTimer.Stop();
                _buffTimer.Tick -= Timer_Tick;
                _buffTimer = null;
            }
        }

        private void TimerRestart()
        {
            TimerStop();

            _buffTimer = new(_buffTimerDuration);
            _buffTimer.Tick += Timer_Tick;

            UpdateTimerInfo(_buffTimer.TimeLeft);

            _buffTimer.Start();
        }

        private void Timer_Tick(object? sender, BuffTimerTickEventArgs e)
        {
            Invoke(UpdateTimerInfo, e.TimeLeft);

            if (ShouldBeep(e.TimeLeft))
            {
                _beeper.Beep();
            }
        }

        private bool ShouldBeep(TimeSpan timeLeft)
        {
            if (timeLeft <= _buffTimerDuration.Duration() / BeepOptions.Ticks * BeepOptions.BeepEverySecondAfter)
            {
                return true;
            }
            else
            {
                for (int i = 0; i <= BeepOptions.BeepEveryTickAfter; i++)
                {
                    if (_buffTimerDuration.Duration() / BeepOptions.Ticks * i == timeLeft)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void UpdateTimerInfo(TimeSpan timeLeft)
        {
            timerLabel.Text = timeLeft.ToMMSSString();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            _trayIcon.Dispose();
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}