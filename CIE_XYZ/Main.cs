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
        public static int CANVAS_WIDTH = 644;
        public static int CANVAS_HEIGHT = 604;

        public Main()
        {
            InitializeComponent();
            spectralPlot = new Plot(this.spectrumCanvas, new Bitmap(CANVAS_WIDTH, CANVAS_HEIGHT), 340, 860, 0, 2.15, 12, 0, 1);
            horseshoePlot = new Plot(this.horseshoeCanvas, new Bitmap(CANVAS_WIDTH, CANVAS_HEIGHT), -0.1, 1.0, -0.1, 1.0, 12, 1, 1);
            dataPoints = Data.ReadData(DATA_PATH);
            movingVertex = -1;


            List<Point> pts = new()
            {
                spectralPlot.MapPointToGraph(BezierCurve.MIN_VAL, 1.5),
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
            bezier.Draw();
            var pointFromSpectrum = bezier.FindRelatedPoint(dataPoints);
            pointFromSpectrum.PlotDataPoint(horseshoePlot, true);
        }

        private void numOfPoints_ValueChanged(object sender, EventArgs e)
        {
            int N = bezier.ControlPoints.Count;
            int M = (int)numOfPoints.Value;

            if (M < N)
            {
                bezier.ControlPoints.RemoveAt(N - 2);
            }
            else
            {
                Random r = new();
                bezier.ControlPoints.Insert(N - 1, new Point(r.Next(50, CANVAS_WIDTH - 50), r.Next(50, CANVAS_HEIGHT - 50)));
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
            bezier.ControlPoints[movingVertex] = new Point(e.X, e.Y);
            Redraw();
        }

        private void spectrumCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            movingVertex = -1;
        }
    }
}