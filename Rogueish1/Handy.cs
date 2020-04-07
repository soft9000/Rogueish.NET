using System;

namespace Handy
{
    class Misc
    {
        private static readonly Random rnd = new Random(System.DateTime.Now.Millisecond);

        public static int GetRandom(int low = 1, int high = 4)
        {
            if (low > high)
            {
                Misc.Swap<int>(ref low, ref high);
            }
            return rnd.Next(low, high);
        }

        public static void Swap<T>(ref T zLeft, ref T zRight)
        {
            T zTemp = zRight;
            zRight = zLeft;
            zLeft = zTemp;
        }
    }
}
