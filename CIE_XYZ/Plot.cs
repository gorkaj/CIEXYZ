﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CIE_XYZ
{
    public class Plot
    {
        private static int CANVAS_WIDTH = Main.CANVAS_WIDTH;
        private static int CANVAS_HEIGHT = Main.CANVAS_HEIGHT;

        private PictureBox canvas;
        private Bitmap bmap;
        private double xmin, xmax, ymin, ymax;
        private int k;
        private int x_precision;
        private int y_precision;
        private Bitmap? background;

        private int axis_start = 20;
        private int radius = 8;
        private int bullet_radius = 14;
        Pen pen = new Pen(Color.Black, 2);
        SolidBrush brush = new SolidBrush(Color.Black);

        public Bitmap Bmap { get => bmap; set => bmap = value; }
        public PictureBox Canvas { get => canvas; set => canvas = value; }

        public Plot(PictureBox canvas, Bitmap bmap, double xmin, double xmax, double ymin, double ymax, int k, int precision, int y_precision, Bitmap? background)
        {
            this.canvas = canvas;
            this.bmap = bmap;
            this.xmin = xmin;
            this.xmax = xmax;
            this.ymin = ymin;
            this.ymax = ymax;
            this.k = k;
            this.x_precision = precision;
            this.y_precision = y_precision;
            this.background = background;
        }

        public void DrawAxis()
        {
            this.bmap = new Bitmap(bmap.Width, bmap.Height);
            if (background != null)
            {
                using (Graphics g = Graphics.FromImage(Bmap))
                {
                    g.DrawImage(background, new Point(90, 45));
                }   
            }

            using (Graphics g = Graphics.FromImage(bmap))
            {
                // axis
                g.DrawLine(pen, new Point(2 * axis_start, CANVAS_HEIGHT - axis_start),
                    new Point(2 * axis_start, axis_start));
                g.DrawLine(pen, new Point(axis_start, CANVAS_HEIGHT - 2 * axis_start),
                    new Point(CANVAS_WIDTH - axis_start, CANVAS_HEIGHT - 2 * axis_start));
                // ends
                g.DrawLine(pen, new Point(2 * axis_start, axis_start), new Point(2 * axis_start - 10, axis_start + 10));
                g.DrawLine(pen, new Point(2 * axis_start, axis_start), new Point(2 * axis_start + 10, axis_start + 10));
                g.DrawLine(pen, new Point(CANVAS_WIDTH - axis_start, CANVAS_HEIGHT - 2 * axis_start), new Point(CANVAS_WIDTH - axis_start - 10, CANVAS_HEIGHT - 2 * axis_start - 10));
                g.DrawLine(pen, new Point(CANVAS_WIDTH - axis_start, CANVAS_HEIGHT - 2 * axis_start), new Point(CANVAS_WIDTH - axis_start - 10, CANVAS_HEIGHT - 2 * axis_start + 10));
                // division
                for (int i = 1; i < k - 2; ++i)
                {
                    var pt = MapPointToGraph(xmin + i * (xmax - xmin) / (k - 1), ymin);
                    g.DrawLine(pen, new Point(pt.X, pt.Y - 8), new Point(pt.X, pt.Y + 8));

                    Font f = new("Calibri", 10, FontStyle.Regular);
                    StringFormat sf = new() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                    g.DrawString(Math.Round(xmin + i * (xmax - xmin) / (k - 1), x_precision).ToString(), f, brush, new Point(pt.X, pt.Y + 15), sf);
                }
                for (int i = 1; i < k - 2; ++i)
                {
                    var pt = MapPointToGraph(xmin, ymin + i * (ymax - ymin) / (k - 1));
                    g.DrawLine(pen, new Point(pt.X - 8, pt.Y), new Point(pt.X + 8, pt.Y));

                    Font f = new("Calibri", 10, FontStyle.Regular);
                    StringFormat sf = new() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                    g.DrawString(Math.Round(ymin + i * (ymax - ymin) / (k - 1), y_precision).ToString(), f, brush, new Point(pt.X - 20, pt.Y), sf);
                }
            }

            canvas.Image = bmap;
        }

        public void PlotDataPoints(List<Data> dataPoints)
        {
            foreach (var dpoint in dataPoints)
            {
                dpoint.PlotDataPoint(this, false);
            }
        }

        public void DrawPoint(double ptx, double pty, Color color, bool useBigPoint)
        {
            int local_radius = useBigPoint ? bullet_radius : radius;
            using (Graphics g = Graphics.FromImage(bmap))
            {
                var pt = MapPointToGraph(ptx, pty);
                g.FillEllipse(new SolidBrush(color), pt.X - local_radius, pt.Y - local_radius, local_radius, local_radius);
                if(useBigPoint)
                {
                    Font f = new("Calibri", 10, FontStyle.Regular);
                    StringFormat sf = new() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                    g.DrawString("(" + Math.Round(ptx, 2).ToString() + ", " + Math.Round(pty, 2).ToString()  +")", f, brush, new Point(pt.X + 10, pt.Y + 10), sf);
                }
            }
            canvas.Image = bmap;
        }

        public void DrawRawPoint(Point pt, Color color)
        {
            using (Graphics g = Graphics.FromImage(bmap))
            {
                g.FillEllipse(new SolidBrush(color), pt.X - bullet_radius, pt.Y - bullet_radius, bullet_radius, bullet_radius);
            }
            canvas.Image = bmap;
        }

        public void DrawRawLine(List<Point> pts, Color color)
        {
            using (Graphics g = Graphics.FromImage(bmap))
            {
                for (int i = 0; i < pts.Count - 1; ++i)
                {
                    g.DrawLine(new Pen(color, 1),
                        new Point(pts[i].X - radius, pts[i].Y - radius),
                        new Point(pts[i + 1].X - radius, pts[i + 1].Y - radius));
                }
            }
            canvas.Image = bmap;
        }

        public void DrawCurve(List<Point> points)
        {
            using (Graphics g = Graphics.FromImage(bmap))
            {
                for (int i = 0; i < points.Count - 1; ++i)
                {
                    g.DrawLine(new Pen(Color.Black, 2),
                        new Point(points[i].X - radius, points[i].Y - radius),
                        new Point(points[i + 1].X - radius, points[i + 1].Y - radius));
                }
            }
            canvas.Image = bmap;
        }

        public void DrawFunctions(List<Data> dataPoints)
        {
            var redPen = new Pen(Color.Red, 2);
            var greenPen = new Pen(Color.Green, 2);
            var bluePen = new Pen(Color.Blue, 2);

            using (Graphics g = Graphics.FromImage(bmap))
            {
                for (int i = 0; i < dataPoints.Count - 1; ++i)
                {
                    g.DrawLine(redPen,
                        MapPointToGraph(dataPoints[i].WaveLength, dataPoints[i].X),
                        MapPointToGraph(dataPoints[i + 1].WaveLength, dataPoints[i + 1].X));
                    g.DrawLine(greenPen,
                        MapPointToGraph(dataPoints[i].WaveLength, dataPoints[i].Y),
                        MapPointToGraph(dataPoints[i + 1].WaveLength, dataPoints[i + 1].Y));
                    g.DrawLine(bluePen,
                        MapPointToGraph(dataPoints[i].WaveLength, dataPoints[i].Z),
                        MapPointToGraph(dataPoints[i + 1].WaveLength, dataPoints[i + 1].Z));
                }
            }
            canvas.Image = bmap;
        }

        public Point MapPointToGraph(double ptx, double pty)
        {
            int mappedX = (int)((ptx - xmin) / (xmax - xmin) * CANVAS_WIDTH);
            int mappedY = CANVAS_HEIGHT - (int)((pty - ymin) / (ymax - ymin) * CANVAS_HEIGHT);
            return new Point(2 * axis_start + mappedX, mappedY - 2 * axis_start);
        }

        public (double x, double y) MapGraphPointToPoint(Point pt)
        {
            double realX = (xmax - xmin) / CANVAS_WIDTH * ((double)pt.X - 2 * axis_start) + xmin;
            double realY = (ymax - ymin) * (CANVAS_HEIGHT - 2 * axis_start - (double)pt.Y) / CANVAS_HEIGHT + ymin;
            return (realX, realY);
        }
    }
}
