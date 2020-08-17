using PixelEngine;

namespace pixel_test
{
    public class TestProgram : Game
    {
        private static int screen_width = 100;
        private static int screen_height = 100;
        private static readonly int fps = 60;
        private static int pxl_width = 5;
        private static int pxl_height = 5;

        static void Main(string[] args)
        {
            // Create an instance
            TestProgram test = new TestProgram();

            // Construct the 100x100 game window with 5x5 pixels
            test.Construct(screen_width, screen_height, pxl_width, pxl_height, fps);

            // Start and show a window
            test.Start();
        }




        // Called once per frame, this is where the rendering happens
        public override void OnUpdate(float elapsed)
        {
            var pr = Pixel.RandomAlpha();


            var p1 = new Point(50,50);
            var p2 = new Point(80,50);
            var p3 = new Point(0, 50);

   
            Draw(50, 50, pr);
            DrawLine(p1, p2, pr);
            DrawCircle(p1,10,pr);
            DrawText(p3,"hello world", pr );
        }

    }
}
