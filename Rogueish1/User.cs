using System;

namespace Rogueish
{
    public struct User
    {
        public enum MoveRequest
        {
            Left, Right, Up, Down,
            NONE
        }

        static MoveRequest moveRequest = new MoveRequest();

        public static MoveRequest GetMoveRequest()
        {
            ConsoleKeyInfo zKey = Console.ReadKey(true);
            switch (zKey.Key)
            {
                case ConsoleKey.UpArrow:
                    moveRequest = MoveRequest.Up;
                    return moveRequest;
                case ConsoleKey.DownArrow:
                    moveRequest = MoveRequest.Down;
                    return moveRequest;
                case ConsoleKey.LeftArrow:
                    moveRequest = MoveRequest.Left;
                    return moveRequest;
                case ConsoleKey.RightArrow:
                    moveRequest = MoveRequest.Right;
                    return moveRequest;
                default:
                    break;
            }
            switch (zKey.KeyChar)
            {
                case 'e':
                    moveRequest = MoveRequest.Up;
                    return User.moveRequest;
                case 'd':
                    moveRequest = MoveRequest.Down;
                    return User.moveRequest;
                case 's':
                    moveRequest = MoveRequest.Left;
                    return User.moveRequest;
                case 'f':
                    moveRequest = MoveRequest.Right;
                    return User.moveRequest;
                default:
                    moveRequest = MoveRequest.NONE;
                    break;
            }
            moveRequest = MoveRequest.NONE;
            return moveRequest;
        }
    }
}
