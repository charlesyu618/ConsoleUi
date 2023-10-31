using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace ConsoleUi
{
    public static class Settings
    {
        public enum Direction { Left, Right, Up, Down, Default }    // Special is stop
        public static readonly int HeartBeatMilliseconds = 400;     // Fresh rate

        // public static readonly string DatabaseConnectionString = Environment.GetEnvironmentVariable("SnakeDatabaseConnectionString") ?? throw new Exception("SnakeDatabaseConnectionString environment variable is missing.");

        public struct Canvas
        {
            public static readonly Rectangle Size = new(0, 0, 50, 25);
            public static readonly char HorizontalChar = '─';
            public static readonly char VerticalChar = '│';
            public static readonly char TopLeftChar = '┌';
            public static readonly char TopRightChar = '┐';
            public static readonly char BottomLeftChar = '└';
            public static readonly char BottomRightChar = '┘';
            public static readonly char FillChar = ' ';

            public static readonly ConsoleColor BorderBackground = ConsoleColor.White;
            public static readonly ConsoleColor BorderForeground = ConsoleColor.Blue;
            public static readonly ConsoleColor CanvasBackground = ConsoleColor.Gray;
        }

        public struct Snake
        {
            public static readonly char HeadRightChar = '>'; // Use Unicode format
            public static readonly char HeadLeftChar = '<'; // Windows default: ANSI?
            public static readonly char HeadUpChar = 'A';
            public static readonly char HeadDownChar = 'V';
            public static readonly char HeadStopChar = '■';
            public static readonly char TailChar = ' ';

            public static readonly ConsoleColor HeadBackground = ConsoleColor.Gray;
            public static readonly ConsoleColor HeadForeground = ConsoleColor.Blue;
            public static readonly ConsoleColor TailBackground = ConsoleColor.Blue;
            public static readonly ConsoleColor TailForeground = ConsoleColor.Gray;
        }

        public struct Fruit
        {
            public static readonly ConsoleColor Background = ConsoleColor.Gray;
            public static readonly ConsoleColor Foreground = ConsoleColor.Blue;
        }
    }
}
