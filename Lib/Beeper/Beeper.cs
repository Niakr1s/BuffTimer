using System.Media;

namespace buff_timer
{
    public abstract class Beeper
    {
        public abstract void Beep();
    }

    public class DefaultBeeper : Beeper
    {
        public override void Beep()
        {
            SystemSounds.Beep.Play();
        }
    }
}
