using PixelEngine;
using System;

namespace pixel_test
{
    public class TestProgram : Game
    {
        private static int screen_width = 1000;
        private static int screen_height = 500;
        private static readonly int fps = 300;

        private static int pxl_width = 2;
        private static int pxl_height = 2;
        private static Random random;
        static void Main(string[] args)
        {
            // Create an instance
            TestProgram test = new TestProgram();
            random = new Random();

            // Construct the 100x100 game window with 5x5 pixels
            test.Construct(screen_width, screen_height, pxl_width, pxl_height, fps);

            // Start and show a window
            test.Start();
        }

        // Called once per frame, this is where the rendering happens
        public override void OnUpdate(float elapsed)
        {
            // var pr = Pixel.RandomAlpha();

            // int x = random.Next(0, screen_width); //for ints
            // int y = random.Next(0, screen_height); //for ints


            // var p1 = new Point(50, 50);
            // var p2 = new Point(80, 50);
            // var p3 = new Point(x, y);


            // Draw(50, 50, pr);
            // //DrawLine(p1, p2, pr);
            // //DrawCircle(p1, 10, pr);
            // DrawText(p3, "hello world", pr);
            // DrawTextHr(p3, "hello world", pr);

            Fun();
        }

        private void Fun()
        {
            var pxl = Pixel.Random();

            for (var i = 0; i < 3; i++)
            {
                DrawCross();
            }

        }

        private Point random_point()
        {
            int x = random.Next(0, screen_width); //for ints
            int y = random.Next(0, screen_height); //for ints
            return new Point(x, y);
        }

        private void DrawCross()
        {
            var pxl = Pixel.Presets.White;
            var middle = random_point();
            var top = new Point(middle.X, middle.Y - 1);
            var bottom = new Point(middle.X, middle.Y + 1);
            var left = new Point(middle.X - 1, middle.Y);
            var right = new Point(middle.X + 1, middle.Y);

            DrawPxl(middle, pxl);
            DrawPxl(top, pxl);
            DrawPxl(bottom, pxl);
            DrawPxl(left, pxl);
            DrawPxl(right, pxl);
        }

        private void DrawPxl(Point pt,Pixel pxl )
        {
            Draw(pt.X, pt.Y, pxl);
        }

    }


}
