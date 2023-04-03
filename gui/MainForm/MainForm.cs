using buff_timer.gui.BeepOptionForm;
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

        private Options _options;
        public Options Options
        {
            get => _options;
            set
            {
                bool durationChanged = _options.Duration != value.Duration;

                if (_options != value)
                {
                    _options = value;
                    Config.Options = value;
                }

                if (durationChanged)
                {
                    TimerRestart();
                }
            }
        }

        private readonly Beeper _beeper;


        public MainForm()
        {
            InitializeComponent();
            _beeper = new DefaultBeeper();
            _options = Config.Options;
            UpdateTimerToolTip();

            AppContextMenu contextMenu = new AppContextMenu();
            contextMenu.ExitRequested += ContextMenu_ExitRequested;
            contextMenu.BeepOptionsRequested += ContextMenu_OptionsRequested;

            ContextMenuStrip = contextMenu;

            _keyHook = Hook.GlobalEvents();
            _keyActions = new Dictionary<BuffTimerActions, Keys>()
            {
                [BuffTimerActions.Restart] = Keys.F12,
                [BuffTimerActions.Stop] = Keys.F11,
            };
            BindKeyboard();

            TimerRestart();
        }

        private void ContextMenu_OptionsRequested(object? sender, EventArgs e)
        {
            OptionsForm optionsForm = new(Options);
            optionsForm.ShowDialog();
            Options = optionsForm.Options;
        }

        private void ContextMenu_ExitRequested(object? sender, EventArgs e)
        {
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

            _buffTimer = new(_options.Duration);
            _buffTimer.Tick += Timer_Tick;

            UpdateTimerInfo(_buffTimer.TimeLeft);

            _buffTimer.Start();
        }

        private void Timer_Tick(object? sender, BuffTimerTickEventArgs e)
        {
            Invoke(UpdateTimerInfo, e.TimeLeft);
            Invoke(UpdateTimerToolTip);

            if (ShouldBeep(e.TimeLeft))
            {
                _beeper.Beep();
            }
        }

        private bool ShouldBeep(TimeSpan timeLeft)
        {
            TimeSpan timeDiff = Options.BeepLast - timeLeft;
            return
                timeLeft == Options.BeepLast ||
                timeLeft == TimeSpan.Zero ||
                (timeLeft < Options.BeepLast && (timeDiff.TotalSeconds % Options.BeepInterval.TotalSeconds == 0));
        }

        private void UpdateTimerInfo(TimeSpan timeLeft)
        {
            timerLabel.Text = timeLeft.ToMMSSString();
        }

        private void UpdateTimerToolTip()
        {
            summaryTooltip.SetToolTip(timerLabel, Options.ToSummaryString());
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