using System;

namespace Rogueish
{
    public class Thing : Noun
    {
        public ConsoleColor foreColor = ConsoleColor.Yellow;

        public Thing() : base(Characters.CHAR_POWER, 1)
        {
        }

        public override void OnDraw()
        {
            ConsoleColor holdColor = Console.ForegroundColor;
            Console.ForegroundColor = this.foreColor;
            base.OnDraw();
            Console.ForegroundColor = holdColor;
        }
    }
}