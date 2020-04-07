using System;

namespace Rogueish
{
    public class ScreenCell2D
    {
        private int xPos, yPos;
        private static ScreenCell2D maxPoint = new ScreenCell2D(79, 24);

        public ScreenCell2D()
        {
            this.xPos = -1;
            this.yPos = -1;
        }

        public ScreenCell2D(int xPos, int yPos)
        {
            this.xPos = xPos; this.yPos = yPos;
        }

        public int XPos { get => xPos; set => xPos = value; }
        public int YPos { get => yPos; set => yPos = value; }

        public ScreenCell2D(ScreenCell2D obj) // NEW 
        {
            this.xPos = obj.xPos; this.yPos = obj.yPos;
        }

        public override bool Equals(Object obj) // NEW 
        {
            // Modern C#
            if ((obj == null) || !(obj is ScreenCell2D))
            {
                return false;
            }
            else
            {
                ScreenCell2D p = obj as ScreenCell2D;
                return (xPos == p.xPos) && (yPos == p.yPos);
            }
        }

        public override int GetHashCode() // NEW 
        {
            return (xPos << 2) ^ yPos;
        }

        public override string ToString() // NEW 
        {
            return $"ScreenCell2D({xPos}, {yPos})";
        }

        public static ScreenCell2D GetRandomPoint()
        {
            return new ScreenCell2D()
            {
                XPos = Handy.Misc.GetRandom(0, maxPoint.XPos - 1),
                YPos = Handy.Misc.GetRandom(0, maxPoint.YPos - 1),
            };
        }

        public static bool IsOnScreen(ScreenCell2D playerPoint)
        {
            if ((playerPoint.YPos > maxPoint.YPos) ||
                (playerPoint.XPos > maxPoint.XPos) ||
                    (playerPoint.YPos < 0) ||
                    (playerPoint.XPos < 0))
            {
                return false;
            }
            return true;
        }

        public static ScreenCell2D GetMaxPoint()
        {
            return new ScreenCell2D(maxPoint);
        }

        public static void SetMaxPoint(ScreenCell2D maxPoint)
        {
            ScreenCell2D.maxPoint = new ScreenCell2D(maxPoint);
        }
    }
}
