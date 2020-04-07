namespace Rogueish
{
    public struct ObjectStatus
    {
        public enum ActiveState
        {
            Alive,
            Awake,
            Sleeping,
            Dead,
        }

        public enum RelativeSpeed
        {
            Slow,
            Fast,
            Stopped,
        }

        public ActiveState state;
        public RelativeSpeed speed;

        public ObjectStatus(ActiveState state, RelativeSpeed speed)
        {
            this.state = state; this.speed = speed;
        }

        public static readonly ObjectStatus Default =
            new ObjectStatus(ActiveState.Sleeping, RelativeSpeed.Stopped);
    }
}
