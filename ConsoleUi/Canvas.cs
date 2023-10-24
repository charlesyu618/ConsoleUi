using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.InteropServices;

namespace ConsoleUi
{
    public class Canvas
    {
        private Rectangle Border { get; set; }

        public Rectangle Inner => new(Border.X + 1, Border.Y - 1, Border.Width - 2, Border.Height - 2);

        public void Erase(Point point)
        {
            Utility.Write(Settings.Canvas.FillChar.ToString(), point.X, point.Y, null, Settings.Canvas.CanvasBackground);
        }

        public void Draw()
        {

            FormatConsole();

            Console.Clear();

            Border = Settings.Canvas.Size;

            string topRow = Settings.Canvas.TopLeftChar + new string(Settings.Canvas.HorizontalChar, Border.Width - 2) + Settings.Canvas.TopRightChar;
            string middleRows = new string(Settings.Canvas.FillChar, Border.Width - 2);
            string bottomRow = Settings.Canvas.BottomLeftChar + new string(Settings.Canvas.HorizontalChar, Border.Width - 2) + Settings.Canvas.BottomRightChar;

            // Write the top row
            Utility.Write(topRow, Border.Left, Border.Top, Settings.Canvas.BorderForeground, Settings.Canvas.BorderBackground);

            // Write the middle rows
            for (int y = Border.Top + 1; y < Border.Top + Border.Height - 1; y++)
            {
                Utility.Write(Settings.Canvas.VerticalChar.ToString(), Border.Left, y, Settings.Canvas.BorderForeground, Settings.Canvas.BorderBackground);
                Utility.Write(middleRows, Border.Left + 1, y, null, Settings.Canvas.CanvasBackground);
                Utility.Write(Settings.Canvas.VerticalChar.ToString(), Border.Left + Border.Width - 1, y, Settings.Canvas.BorderForeground, Settings.Canvas.BorderBackground);
            }

            // Write the bottom row
            Utility.Write(bottomRow, Border.Left, Border.Top + Border.Height - 1, Settings.Canvas.BorderForeground, Settings.Canvas.BorderBackground);

            void FormatConsole()
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    Console.SetWindowSize(Settings.Canvas.Size.Right, Settings.Canvas.Size.Bottom);
                    Console.SetBufferSize(Settings.Canvas.Size.Right, Settings.Canvas.Size.Bottom);
                }
                Console.CursorVisible = false;


            }
        }
    }
}
