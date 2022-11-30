using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CIE_XYZ
{
    public class BezierCurve    
    {
        private static double[] factorials = new double[]
        {
            1.0,
            1.0,
            2.0,
            6.0,
            24.0,
            120.0,
            720.0,
            5040.0,
            40320.0,
            362880.0,
            3628800.0,
            39916800.0,
            479001600.0,
            6227020800.0,
            87178291200.0,
            1307674368000.0,
            20922789888000.0,
        };
        private List<Point> controlPoints;
        private Plot plot;

        public BezierCurve(List<Point> controlPoints, Plot plot)
        {
            this.controlPoints = controlPoints;
            this.plot = plot;
        }

        public void Draw()
        {
            plot.DrawCurve(this.GetCurve());
            foreach (var pt in controlPoints)
            {
                plot.DrawRawPoint(pt, Color.Magenta);
            }
        }

        public List<Point> GetCurve(double interval = 0.001)
        {
            int N = controlPoints.Count - 1;
            if (N > 16)
            {
                throw new ArgumentException();
            }

            List<Point> points = new List<Point>();
            for (double t = 0.0; t <= 1.0 + interval - 0.0001; t += interval)
            {
                var p = GetPoint(t);
                points.Add(p);
            }

            return points;
        }

        public Point GetPoint(double t)
        {
            int N = controlPoints.Count - 1;
            if (N > 16)
            {
                throw new ArgumentException();
            }
            if (t <= 0) return controlPoints[0];
            if (t >= 1) return controlPoints[^1];

            Point p = new Point();

            for (int i = 0; i < controlPoints.Count; ++i)
            {
                Point bn = controlPoints[i];
                bn.X = (int)(bn.X * bernstein(N, i, t));
                bn.Y = (int)(bn.Y * bernstein(N, i, t));
                p.X += bn.X;
                p.Y += bn.Y;
            }

            return p;
        }

        private static double binomial(int n, int i)
        {
            double ni;
            double a1 = factorials[n];
            double a2 = factorials[i];
            double a3 = factorials[n - i];
            ni = a1 / (a2 * a3);
            return ni;
        }

        private static double bernstein(int n, int i, double t)
        {
            double t_i = Math.Pow(t, i);
            double t_n_minus_i = Math.Pow((1 - t), (n - i));

            double basis = binomial(n, i) * t_i * t_n_minus_i;
            return basis;
        }
    }
}
