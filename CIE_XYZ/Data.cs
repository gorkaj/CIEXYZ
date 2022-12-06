using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIE_XYZ
{
    public class Data
    {
        private int waveLength;
        private double x;
        private double y;
        private double z;
        private Color color;

        public static int epsilon = 10;

        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }
        public double Z { get => z; set => z = value; }
        public Color Color { get => color; set => color = value; }
        public int WaveLength { get => waveLength; set => waveLength = value; }

        public Data(int waveLength, double x, double y, double z)
        {
            this.waveLength = waveLength;
            this.x = x;
            this.y = y;
            this.z = z;
            this.color = GetPointColor();
        }

        public static List<Data> ReadData(string filename)
        {
            List<Data> data = new List<Data>();
            var lines = System.IO.File.ReadAllLines(filename);
            foreach(var line in lines)
            {
                var divisions = line.Split("\t");
                data.Add(new Data(Int32.Parse(divisions[0]), Double.Parse(divisions[1]), Double.Parse(divisions[2]), Double.Parse(divisions[3])));
            }

            return data;
        }

        public void PlotDataPoint(Plot plot, bool useFixedColor)
        {
            try
            {
                if(useFixedColor)
                {
                    plot.DrawPoint(x / (x + y + z), y / (x + y + z), Color.Black, true);
                    return;
                }
                
                if (color.R <= epsilon && color.G <= epsilon && color.B <= epsilon)
                    return;
                plot.DrawPoint(x / (x + y + z), y / (x + y + z), this.color, false);
            }
            catch (Exception) { }
        }

        public Color GetPointColor()
        {
            int R = (int)Math.Max(Math.Round((3.2404542 * x - 1.5371385 * y - 0.4985314 * z) * 255, 0), 0);
            int G = (int)Math.Max(Math.Round((-0.969266 * x + 1.8760108 * y + 0.0415560 * z) * 255, 0), 0);
            int B = (int)Math.Max(Math.Round((0.0556434 * x - 0.2040259 * y + 1.0572252 * z) * 255, 0), 0);
            return Color.FromArgb(Math.Min(R, 255), Math.Min(G, 255), Math.Min(B, 255));
        }

    }
}
