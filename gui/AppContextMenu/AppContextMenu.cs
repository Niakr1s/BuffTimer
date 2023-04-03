namespace buff_timer
{
    public class AppContextMenu : ContextMenuStrip
    {
        public event EventHandler? ExitRequested;
        public event EventHandler? BeepOptionsRequested;

        public AppContextMenu() : base()
        {
            this.Items.Add(new ToolStripSeparator());
            this.Items.Add(new ToolStripMenuItem("Options", null, OnBeepOptionsClick));

            this.Items.Add(new ToolStripSeparator());
            this.Items.Add(new ToolStripMenuItem("Exit", null, OnExitClick));
        }

        private void OnBeepOptionsClick(object? sender, EventArgs e)
        {
            BeepOptionsRequested?.Invoke(this, new());
        }

        private void OnExitClick(object? sender, EventArgs e)
        {
            ExitRequested?.Invoke(this, new());
        }
    }
}
