using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace ConsoleUi
{
    public class Snake
    {
        public Point Head { get; private set; }
        public Point[] Tail { get; private set; } = Array.Empty<Point>();
        public Point[] Points => Tail.Prepend(Head).ToArray();
        public bool ReachEdge { get; set; } = false;    // the flag that snake touch the edge
        public Settings.Direction Direction { get; set; } = Settings.Direction.Default;


        public void Initialize(Canvas canvas)
        {
            // Erase all points if the user re-start the game
            foreach (var point in Points)
            {
                canvas.Erase(point);
            }

            Tail = Array.Empty<Point>();
            Direction = Settings.Direction.Default;
            Head = Utility.GetRandomSafePoint(canvas);
            DrawHead();
            ReachEdge = false;
        }

        public void Move(Canvas canvas, bool increase, Point preFruit)
        {
            if (Direction == Settings.Direction.Default)
            {
                return;
            }

            var prevHead = Head;
            Head = Utility.MovePoint(Head, Direction);
            Head = Utility.WrapPoint(Head, Direction, canvas);


            // touch the edge, game over
            if (!Utility.IsPointWithinCanvas(Head, canvas.Inner))
            {
                ReachEdge = true;
                return;
            }

            bool isFruitLocation = Head == preFruit;

            if (Tail.Length == 0 && !increase)
            {
                DrawHead();
                // Solve the problem of empty display
                if (!isFruitLocation)
                {
                    canvas.Erase(prevHead); // If the snake doesn't on the original fruit location
                }                           // Draw the moving as usual
                else
                {
                    DrawTail(prevHead); // fill the empty location
                }
            }
            else if (!increase)
            {
                DrawHead();
                DrawTail(prevHead);
                canvas.Erase(Tail[^1]);
                Tail = Tail.Prepend(prevHead).ToArray()[..^1];
            }
            else if (increase)
            {
                DrawHead();
                DrawTail(prevHead);
                Tail = Tail.Prepend(prevHead).ToArray();
            }
        }

        private void DrawTail(params Point[] points)
        {
            foreach (var point in points)
            {
                Utility.Write(Settings.Snake.TailChar.ToString(), point.X, point.Y, Settings.Snake.TailForeground, Settings.Snake.TailBackground);
            }
        }

        private void DrawHead()
        {
            var headSymbol = Utility.ConvertDirectionToChar(Direction).ToString();
            Utility.Write(headSymbol, Head.X, Head.Y, Settings.Snake.HeadForeground, Settings.Snake.HeadBackground);
        }
    }
}
