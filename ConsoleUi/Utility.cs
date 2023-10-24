using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace ConsoleUi
{
    public class Utility
    {
        public static Point GetRandomSafePoint(Canvas canvas, params Point[] avoid)
        {
            Point point;
            do
            {
                var x = Random.Shared.Next(canvas.Inner.Left, canvas.Inner.Right - 1);    // Have to -1 +2 +1
                var y = Random.Shared.Next(canvas.Inner.Top + 2, canvas.Inner.Bottom + 1);  // Or the point would not safe
                point = new Point(x, y);

            } while (avoid.Contains(point));
            return point;
        }

        public static Point WrapPoint(Point point, Settings.Direction direction, Canvas canvas)
        {
            /*
            return (point.X, point.Y) switch
            {
                var (x, y) when direction == Settings.Direction.Up && y < canvas.Inner.Top => new(x, canvas.Inner.Bottom - 1),
                var (x, y) when direction == Settings.Direction.Down && y >= canvas.Inner.Bottom => new(x, canvas.Inner.Top),
                var (x, y) when direction == Settings.Direction.Left && x <= canvas.Inner.Left => new(canvas.Inner.Right, y),
                var (x, y) when direction == Settings.Direction.Right && x > canvas.Inner.Right => new(canvas.Inner.Left + 1, y),
                var (x, y) => point
            };
            */
            return point;
        }

        public static Point MovePoint(Point point, Settings.Direction direction) => direction switch
        {
            Settings.Direction.Up => new Point(point.X, point.Y - 1),
            Settings.Direction.Right => new Point(point.X + 1, point.Y),
            Settings.Direction.Down => new Point(point.X, point.Y + 1),
            Settings.Direction.Left => new Point(point.X - 1, point.Y),
            _ => point
        };

        public static void Write(string text, int x, int y, ConsoleColor? foreground = null, ConsoleColor? background = null)
        {
            Console.SetCursorPosition(left: x, top: y);
            Console.ForegroundColor = foreground ?? Console.ForegroundColor;
            Console.BackgroundColor = background ?? Console.BackgroundColor;
            Console.Write(text);
            Console.ResetColor();
        }

        public static char ConvertDirectionToChar(Settings.Direction direction)
        {
            return direction switch
            {
                Settings.Direction.Up => Settings.Snake.HeadUpChar,
                Settings.Direction.Right => Settings.Snake.HeadRightChar,
                Settings.Direction.Down => Settings.Snake.HeadDownChar,
                Settings.Direction.Left => Settings.Snake.HeadLeftChar,
                _ => Settings.Snake.HeadStopChar
            };
        }

        public static Settings.Direction ConvertDirectionFromKey(ConsoleKeyInfo keyInfo, Settings.Direction currentDirection)
        {
            // The key to control the direction
            var desiredDirection = keyInfo.Key switch
            {
                ConsoleKey.W => Settings.Direction.Up,  // WSAD key
                ConsoleKey.S => Settings.Direction.Down,
                ConsoleKey.A => Settings.Direction.Left,
                ConsoleKey.D => Settings.Direction.Right,

                ConsoleKey.LeftArrow => Settings.Direction.Left, // Arrow key
                ConsoleKey.RightArrow => Settings.Direction.Right,
                ConsoleKey.UpArrow => Settings.Direction.Up,
                ConsoleKey.DownArrow => Settings.Direction.Down,
                _ => currentDirection
            };

            if (ReverseDirection(currentDirection, desiredDirection))
            {
                return currentDirection;
            }
            else
            {
                return desiredDirection;
            }

            bool ReverseDirection(Settings.Direction currentDirection, Settings.Direction desiredDirection)
            {
                return (currentDirection == Settings.Direction.Up && desiredDirection == Settings.Direction.Down) ||
                       (currentDirection == Settings.Direction.Down && desiredDirection == Settings.Direction.Up) ||
                       (currentDirection == Settings.Direction.Left && desiredDirection == Settings.Direction.Right) ||
                       (currentDirection == Settings.Direction.Right && desiredDirection == Settings.Direction.Left);
            }
        }

        // To be continued
        public static void WaitFor(out ConsoleKey key, params ConsoleKey[] allowed)
        {
            while (!allowed.Contains(key = Console.ReadKey(true).Key))
            {
                // Wait for one of the specified keys to be pressed
            }
        }

        // Check whether snake is in the Canvas
        public static bool IsPointWithinCanvas(Point point, Rectangle canvas)
        {
            return point.X >= canvas.Left && point.X < canvas.Right &&
                   point.Y >= canvas.Top + 2 && point.Y <= canvas.Bottom + 1;
        }
    }
}
