using System;

namespace Rogueish
{

    public class Noun : IMovable
    {
        private string playerName;
        private int playerAge;
        private ObjectStatus.ActiveState state = ObjectStatus.ActiveState.Sleeping;
        protected ObjectStatus.RelativeSpeed speed = ObjectStatus.RelativeSpeed.Stopped;
        protected ScreenCell2D playerPoint = new ScreenCell2D();

        protected NavCalc calc = new NavCalc();

        public Noun()
        {
            this.playerName = "Default";
            this.playerAge = 1;
        }

        internal Noun(string playerName, int playerAge)
        {
            this.playerName = playerName;
            this.playerAge = playerAge;
        }

        public void GetStatus(ref ObjectStatus status)
        {
            status.state = this.state;
            status.speed = this.speed;
        }

        public int PlayerAge
        {
            get
            {
                return this.playerAge;
            }
            set
            {
                if (value >= 0)
                {
                    this.playerAge = value;
                }
            }
        }

        public string PlayerName
        {
            get
            {
                return this.playerName;
            }
            set
            {
                if (value.Length > 0)
                {
                    this.playerName = value;
                }
            }
        }

        public string GameName
        {
            get
            {
                return PlayerName;
            }
        }

        public string GameAge
        {
            get
            {
                return PlayerAge.ToString();
            }
        }

        virtual public void OnMove()
        {
            if (this.playerName == Characters.CHAR_PLAYER)
            {
                User.MoveRequest req = User.GetMoveRequest();
                switch(req)
                {
                    case User.MoveRequest.Left:
                        playerPoint.XPos -= 1;
                        break;
                    case User.MoveRequest.Right:
                        playerPoint.XPos += 1;
                        break;
                    case User.MoveRequest.Up:
                        playerPoint.YPos -= 1;
                        break;
                    case User.MoveRequest.Down:
                        playerPoint.YPos += 1;
                        break;
                }

                if(ScreenCell2D.IsOnScreen(this.playerPoint) == false)
                {
                    state = ObjectStatus.ActiveState.Dead;
                }
            }
        }

        virtual public void OnDraw()
        {
            if (ScreenCell2D.IsOnScreen(this.playerPoint) == true)
            {
                Console.SetCursorPosition(playerPoint.XPos, playerPoint.YPos);
                Console.Write(playerName);
            }
        }

        public bool GoTo(ScreenCell2D loc)
        {
            this.playerPoint.XPos = loc.XPos;
            this.playerPoint.YPos = loc.YPos;
            return true;
        }

        virtual public void DoInit()
        {
            state = ObjectStatus.ActiveState.Alive;
            speed = ObjectStatus.RelativeSpeed.Slow;
        }

        public void DoDeInit()
        {
            this.state = ObjectStatus.ActiveState.Dead;
            this.speed = ObjectStatus.RelativeSpeed.Stopped;
        }

        public static bool Create(string playerName, int playerAge, out Noun noun2)
        {
            noun2 = new Noun
            {
                PlayerName = playerName,
                PlayerAge = playerAge
            };
            if (noun2.PlayerName.Length == 0)
                return false;
            if (noun2.playerAge == 0)
                return false;
            return true;
        }

        public static void Set(Noun noun, ObjectStatus.ActiveState state)
        {
            noun.state = state;
        }

        public static void Set(Noun noun, ObjectStatus.RelativeSpeed speed)
        {
            noun.speed = speed;
        }

        public static ObjectStatus.ActiveState GetState(Noun noun)
        {
            return noun.state;
        }

        public static ObjectStatus.RelativeSpeed GetSpeed(Noun noun)
        {
            return noun.speed;
        }

        public bool PlotCourse(ScreenCell2D here, ScreenCell2D there)
        {
            this.calc.Plot(here, there);
            return true;
        }

        public ScreenCell2D GetLocation()
        {
            return this.playerPoint;
        }
    }
}