using System;
using System.Collections.Generic;
using Rogueish;

namespace Rogueish1
{
    public partial class MainTUI
    {
        internal static List<IMovable> MyNouns = new List<IMovable>();

        public static void Main(string[] args)
        {
            Noun zPlayer = new Player();
            MyNouns.Add(zPlayer);
            var zObj = new Thing();
            ScreenCell2D loc = new ScreenCell2D(10, 5);
            zObj.GoTo(loc);
            MyNouns.Add(zObj);
            MyNouns.Add(new Alien());
            DoInit(MyNouns);
            ObjectStatus status = new ObjectStatus();
            while (status.state != ObjectStatus.ActiveState.Dead)
            {
                foreach (IMovable item in MyNouns)
                {
                    item.OnMove();
                    item.OnDraw();
                }
                zPlayer.GetStatus(ref status);
            }
            DoDeInit(MyNouns);

        }

        internal static Boolean CheckLocation(ScreenCell2D location, List<IMovable> results)
        {
            bool bGots = false;
            foreach (var mover in MyNouns)
            {
                if (mover.GetLocation().Equals(location))
                {
                    bGots = true;
                    results.Add(mover);
                }
            }
            return bGots;
        }

        private static void DoInit(List<IMovable> myNouns)
        {
            foreach (IMovable item in myNouns)
            {
                item.DoInit();
            }
        }

        private static void DoDeInit(List<IMovable> myNouns)
        {
            foreach (IMovable item in myNouns)
            {
                item.DoDeInit();
            }
        }
    }
}
