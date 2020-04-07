using System;

namespace Rogueish
{
    public class NavCalc
    {
        private ScreenCell2D here = new ScreenCell2D();
        private ScreenCell2D there = new ScreenCell2D();
        internal ScreenCell2D course = new ScreenCell2D();

        internal Random rnd;

        public NavCalc()
        {
            rnd = new Random(DateTime.Now.Millisecond);
        }

        public void Plot(ScreenCell2D here, ScreenCell2D there)
        {
            this.here = new ScreenCell2D(here);
            this.there = new ScreenCell2D(there);
        }

        public bool Next(ObjectStatus.RelativeSpeed speed, out ScreenCell2D next)
        {
            next = this.here;
            if (next.Equals(there))
                return true;

            course.XPos = this.there.XPos - this.here.XPos;
            course.YPos = this.there.YPos - this.here.YPos;
            switch (rnd.Next(1, 3))
            {
                case 1:
                    next.XPos = Inc(speed, course.XPos, next.XPos);
                    break;
                case 2:
                    next.YPos = Inc(speed, course.YPos, next.YPos);
                    break;
                case 3:
                    next.XPos = Inc(speed, course.XPos, next.XPos);
                    next.YPos = Inc(speed, course.YPos, next.YPos);
                    break;
            }

            return false;
        }

        private int Inc(ObjectStatus.RelativeSpeed speed, int posoneg, int location)
        {
            int inc;
            switch(speed)
            {
                case (ObjectStatus.RelativeSpeed.Fast):
                    inc = 2;
                    break;
                case ObjectStatus.RelativeSpeed.Slow:
                    inc = 1;
                    break;
                case ObjectStatus.RelativeSpeed.Stopped:
                default:
                    return location;
            }
            if (posoneg > 0)
                return (location + inc);
            if (posoneg < 0)
                return location - inc;
            return (location);
        }
    }
}