using System;
using System.Collections.Generic;
using System.Text;

namespace Rogueish
{
    class Player : Noun
    {
        public Player() : base(Characters.CHAR_PLAYER, 0)
        {
        }

        public override void DoInit()
        {
            var sPoint = ScreenCell2D.GetMaxPoint();
            playerPoint.XPos = sPoint.XPos / 2;
            playerPoint.YPos = sPoint.YPos / 2;
        }
    }
}
