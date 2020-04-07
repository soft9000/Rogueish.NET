namespace Rogueish
{
    internal interface IMovable
    {
        void DoInit();
        string GameName { get; }
        string GameAge { get; }

        bool GoTo(ScreenCell2D loc);

        void OnMove();
        void OnDraw();
        void DoDeInit();

        bool PlotCourse(ScreenCell2D here, ScreenCell2D there);
        ScreenCell2D GetLocation();
    }
}
