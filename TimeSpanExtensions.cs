namespace buff_timer
{
    public static class TimeSpanExtensions
    {
        public static string ToMMSSString(this TimeSpan value)
        {
            return value.ToString(@"mm\:ss");
        }
    }
}
