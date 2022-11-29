using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIE_XYZ
{
    public class Data
    {
        private int waveLength;
        private double X;
        private double Y;
        private double Z;

        public Data(int waveLength, double x, double y, double z)
        {
            this.waveLength = waveLength;
            X = x;
            Y = y;
            Z = z;
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

        public void PlotDataPoint(Plot plot)
        {
            try
            {
                plot.DrawPoint(X / (X + Y + Z), Y / (X + Y + Z), Color.Aquamarine);
            }
            catch (Exception) { }
        }

        public Color GetPointColor()
        {
            int R = (int)Math.Round(Adj(3.2404542 * X - 1.5371385 * Y - 0.4985314 * Z), 0);
            int G = (int)Math.Round(Adj(-0.969266 * X + 1.8760108 * Y + 0.0415560 * Z), 0);
            int B = (int)Math.Round(Adj(0.0556434 * X - 0.2040259 * Y + 1.0572252 * Z), 0);
            return Color.FromArgb(Math.Max(R, 255), Math.Max(G, 255), Math.Max(B, 255));
        }

        private double Adj(double C)
        {
            if (Math.Abs(C) < 0.0031308)
            {
                return 12.92 * C;
            }
            return 1.055 * Math.Pow(C, 0.41666) - 0.055;
        }
    }
}
