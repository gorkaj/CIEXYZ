using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace CIE_XYZ
{
    public partial class Main : Form
    {
        private Plot spectralPlot;
        private Plot horseshoePlot;
        private List<Data> dataPoints;
        private BezierCurve bezier;
        private int movingVertex;

        private string DATA_PATH = "../../../data.txt";
        public static string IMG_PATH = "../../../background.jpg";
        public static int CANVAS_WIDTH = 644;
        public static int CANVAS_HEIGHT = 677;

        public Main()
        {
            InitializeComponent();
            Bitmap background = new Bitmap(Main.IMG_PATH);
            background = new Bitmap(background, new Size((int)(Main.CANVAS_WIDTH * 0.7), (int)(Main.CANVAS_HEIGHT * 0.79)));
            spectralPlot = new Plot(this.spectrumCanvas, new Bitmap(CANVAS_WIDTH, CANVAS_HEIGHT), 340, 860, 0.0, 6.0, 12, 0, 1, null);
            horseshoePlot = new Plot(this.horseshoeCanvas, new Bitmap(CANVAS_WIDTH, CANVAS_HEIGHT), -0.1, 1.0, -0.1, 1.0, 12, 1, 1, background);
            dataPoints = Data.ReadData(DATA_PATH);
            movingVertex = -1;
            colorPanel.BackColor = SystemColors.Control;

            List<Point> pts = new()
            {
                spectralPlot.MapPointToGraph(BezierCurve.MIN_VAL, 3.5),
                spectralPlot.MapPointToGraph(510, 0.2),
                spectralPlot.MapPointToGraph(590, 1.2),
                spectralPlot.MapPointToGraph(BezierCurve.MAX_VAL, 0.4)
            };
            bezier = new(pts, spectralPlot);
            Redraw();
        }

        public void Redraw()
        {
            spectralPlot.DrawAxis();
            horseshoePlot.DrawAxis();
            horseshoePlot.PlotDataPoints(dataPoints);
            if(!showFuncCheckbox.Checked)
            {
                bezier.Draw();
            }
            else
            {
                spectralPlot.DrawFunctions(dataPoints);
            }
            var pointFromSpectrum = bezier.FindRelatedPoint(dataPoints);
            colorPanel.BackColor = pointFromSpectrum.Color;
            pointFromSpectrum.PlotDataPoint(horseshoePlot, true);
        }

        private void numOfPoints_ValueChanged(object sender, EventArgs e)
        {
            int N = bezier.ControlPoints.Count;
            int M = (int)numOfPoints.Value;

            if (M < N)
            {
                while(M < bezier.ControlPoints.Count)
                    bezier.ControlPoints.RemoveAt(bezier.ControlPoints.Count - 2);
            }
            else
            {
                Random r = new();
                while (M > bezier.ControlPoints.Count)
                {
                    var prev = bezier.ControlPoints[bezier.ControlPoints.Count - 2];
                    var next = bezier.ControlPoints[bezier.ControlPoints.Count - 1];
                    bezier.ControlPoints.Insert(bezier.ControlPoints.Count - 1, new Point(r.Next(prev.X, next.X), r.Next(50, CANVAS_HEIGHT - 50)));
                }
            }
                   
            Redraw();
        }

        private void spectrumCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            movingVertex = bezier.Snap(e.Location);
        }

        private void spectrumCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (movingVertex == -1)
                return;
            var prev = movingVertex - 1;
            var next = movingVertex + 1;

            if(movingVertex == 0)
            {
                if (bezier.ControlPoints[next].X > e.X)
                {
                    bezier.ControlPoints[movingVertex] = new Point(e.X, e.Y);
                    Redraw();
                }
                return;
            }

            if(movingVertex == bezier.ControlPoints.Count - 1)
            {
                if (bezier.ControlPoints[prev].X < e.X)
                {
                    bezier.ControlPoints[movingVertex] = new Point(e.X, e.Y);
                    Redraw();
                }
                return;
            }

            if (bezier.ControlPoints[prev].X < e.X && bezier.ControlPoints[next].X > e.X)
            {
                bezier.ControlPoints[movingVertex] = new Point(e.X, e.Y);
                Redraw();
            }

        }

        private void spectrumCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            movingVertex = -1;
        }

        private void backgroundBox_CheckedChanged(object sender, EventArgs e)
        {
            if(backgroundBox.Checked)
            {
                Bitmap background = new Bitmap(Main.IMG_PATH);
                background = new Bitmap(background, new Size((int)(Main.CANVAS_WIDTH * 0.7), (int)(Main.CANVAS_HEIGHT * 0.79)));
                horseshoePlot = new Plot(this.horseshoeCanvas, new Bitmap(CANVAS_WIDTH, CANVAS_HEIGHT), -0.1, 1.0, -0.1, 1.0, 12, 1, 1, background);
            }
            else
            {
                horseshoePlot = new Plot(this.horseshoeCanvas, new Bitmap(CANVAS_WIDTH, CANVAS_HEIGHT), -0.1, 1.0, -0.1, 1.0, 12, 1, 1, null);
            }
            Redraw();
        }

        private void evenSpectrumBtn_Click(object sender, EventArgs e)
        {
            bezier.ControlPoints = new List<Point>() { spectralPlot.MapPointToGraph(BezierCurve.MIN_VAL, 4.0),
                                                       spectralPlot.MapPointToGraph(BezierCurve.MAX_VAL, 4.0) };
            numOfPoints.Value = 2;
            Redraw();
        }

        private void showFuncCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            spectralPlot.Bmap = new Bitmap(CANVAS_WIDTH, CANVAS_HEIGHT);
            Redraw();
        }

        private void loadBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "DAT files|*.dat";
            dialog.Title = "Load spectrum";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var lines = System.IO.File.ReadLines(dialog.FileName);
                bezier.ControlPoints = new List<Point>();
                foreach(var line in lines)
                {
                    var spl = line.Split(" ");
                    bezier.ControlPoints.Add(new Point(int.Parse(spl[0]), int.Parse(spl[1])));
                }
            }
            Redraw();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "DAT files|*.dat";
            dialog.Title = "Save spectrum";
            dialog.ShowDialog();

            if (dialog.FileName != "")
            {
                TextWriter fs = new StreamWriter(dialog.FileName);

                foreach (var pt in bezier.ControlPoints)
                {
                    fs.Write(pt.X.ToString() + " " + pt.Y.ToString() + "\n");
                }

                fs.Close();
            }
        }
    }
}