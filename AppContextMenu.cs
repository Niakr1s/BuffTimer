namespace buff_timer
{
    public class AppContextMenu : ContextMenuStrip
    {
        private BuffTimerType _selectedBuffTimerType;
        public BuffTimerType SelectedBuffTimerType
        {
            get => _selectedBuffTimerType;
            private set
            {
                if (_selectedBuffTimerType == value)
                {
                    return;
                }

                _selectedBuffTimerType = value;
                UpdateBuffTimerMenuItems();
                SelectedBuffTimerChanged?.Invoke(this, value);
            }
        }

        private readonly Dictionary<BuffTimerType, ToolStripMenuItem> _buffTimerMenuItems = new();

        public event EventHandler<BuffTimerType>? SelectedBuffTimerChanged;
        public event EventHandler? ExitRequested;

        public AppContextMenu(BuffTimerType selectedBuffTimerType = BuffTimerType.Buff) : base()
        {
            _selectedBuffTimerType = selectedBuffTimerType;

            foreach (var buffTimerType in Enum.GetValues<BuffTimerType>())
            {
                ToolStripMenuItem item = new ToolStripMenuItem
                    (
                    buffTimerType.ToContextMenuString(), null,
                    (object? sender, EventArgs e) => SelectedBuffTimerType = buffTimerType
                    );
                _buffTimerMenuItems[buffTimerType] = item;
                this.Items.Add(item);
            }
            UpdateBuffTimerMenuItems();

            this.Items.Add(new ToolStripSeparator());
            this.Items.Add(new ToolStripMenuItem("Exit", null, OnExitClick));
        }

        private void OnExitClick(object? sender, EventArgs e)
        {
            ExitRequested?.Invoke(this, new());
        }

        private void UpdateBuffTimerMenuItems()
        {
            foreach (var item in _buffTimerMenuItems.Values)
            {
                item.Checked = false;
            }
            _buffTimerMenuItems[SelectedBuffTimerType].Checked = true;
        }
    }
}
