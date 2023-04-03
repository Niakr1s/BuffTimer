namespace buff_timer
{
    public class BeepOptions
    {
        public int Ticks { get; }
        public int BeepEveryTickAfter { get; }
        public int BeepEverySecondAfter { get; }
        public BeepOptions(int ticks, int everyTickBeepAfter, int everySecondBeepAfter)
        {
            Ticks = ticks;
            BeepEveryTickAfter = everyTickBeepAfter;
            BeepEverySecondAfter = everySecondBeepAfter;
        }

        public static BeepOptions Default()
        {
            return new BeepOptions(20, 5, 1);
        }
    }
}
