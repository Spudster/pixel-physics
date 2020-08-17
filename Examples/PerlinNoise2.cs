using PixelEngine;
using PixelEngine.Utilities;
using System.Threading.Tasks;

namespace Examples
{
    public class PerlinNoise2 : Game
    {

        private static int screen_width = 500;
        private static int screen_height = 500;
        private static Index[] index;
        private float time;
        private bool dir = true;

        static void Main(string[] args)
        {
            PerlinNoise2 pa = new PerlinNoise2();
            CreateIndex();
            pa.Construct(screen_width, screen_height, 1, 1);
            pa.Start();
        }
        public static void CreateIndex()
        {
            index = new Index[screen_width * screen_height];
            var last_end_index = 0;
            // create pixel index for faster draw
            for (int i = 0; i < screen_width; i++)
            {
                for (int j = 0; j < screen_height; j++)
                {

                    var elem = new Index
                    {
                        x = i,
                        y = j,
                        fx = (float)i / screen_width,
                        fy = (float)j / screen_width,

                    };

                    index[last_end_index] = elem;
                    last_end_index++;
                }
            }
        }
        public override void OnUpdate(float elapsed)
        {
            if (GetKey(Key.Enter).Pressed)
            {
                time = 0;
                dir = true;
                Noise.Seed();
            }

            time += 0.01f * (dir ? 1 : -1);

            if (time <= 0 || time >= 360)
                dir = !dir;


            for (int i = 0; i < index.Length; i++)
            {
                float noise = Noise.Calculate(index[i].fx, index[i].fy, time) / 2 + 1;
                Pixel p = Pixel.FromHsv(noise * time * 360, noise, noise * 0.8f);
                Draw(index[i].x, index[i].y, p);
            }

        }
    }

    public class Index
    {
        public int x { get; set; }
        public int y { get; set; }

        public float fx { get; set; }
        public float fy { get; set; }
    }
}