namespace Rogueish
{
    public class Alien : Noun
    {

        public Alien() : base(Characters.CHAR_ALIEN, 2)
        {
        }

        public override void OnMove()
        {
            if(calc.Next(this.speed, out ScreenCell2D next))
            {
                calc.Plot(this.playerPoint, ScreenCell2D.GetRandomPoint());
            }
            playerPoint = next;
        }
    }
}
