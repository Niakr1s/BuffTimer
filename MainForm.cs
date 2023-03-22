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
        private BuffTimerType _buffTimerType = BuffTimerType.Dance;

        private readonly NotifyIcon _trayIcon;

        public BuffTimerType BuffTimerType
        {
            get => _buffTimerType;
            set
            {
                if (_buffTimerType == value)
                {
                    return;
                }

                _buffTimerType = value;
                TimerRestart();
            }
        }

        public MainForm()
        {
            InitializeComponent();

            AppContextMenu contextMenu = new AppContextMenu(_buffTimerType);
            contextMenu.ExitRequested += ContextMenu_ExitRequested;
            contextMenu.SelectedBuffTimerChanged += ContextMenu_SelectedBuffTimerChanged;

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

        private void ContextMenu_SelectedBuffTimerChanged(object? sender, BuffTimerType e)
        {
            BuffTimerType = e;
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

            _buffTimer = new(BuffTimerType);
            _buffTimer.Tick += Timer_Tick;

            UpdateTimerInfo(_buffTimer.TimeLeft);

            _buffTimer.Start();
        }

        private void Timer_Tick(object? sender, BuffTimerTickEventArgs e)
        {
            Invoke(UpdateTimerInfo, e.TimeLeft);
        }

        private void UpdateTimerInfo(TimeSpan timeLeft)
        {
            timerLabel.Text = timeLeft.ToString(@"mm\:ss");
        }
    }
}