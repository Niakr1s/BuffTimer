namespace buff_timer
{
    public enum BuffTimerType
    {
        Buff,
        Dance,
    }

    public static class BuffTimerTypeExtensions
    {
        public static TimeSpan Duration(this BuffTimerType buffTimerType)
        {
            return buffTimerType switch
            {
                BuffTimerType.Buff => TimeSpan.FromMinutes(20),
                BuffTimerType.Dance => TimeSpan.FromMinutes(2),
            };
        }

        public static string ToContextMenuString(this BuffTimerType buffTimerType)
        {
            return buffTimerType switch
            {
                BuffTimerType.Buff => "Buff (20m)",
                BuffTimerType.Dance => "Dance (2m)",
            };
        }
    }
}
