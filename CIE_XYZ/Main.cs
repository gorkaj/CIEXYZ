namespace CIE_XYZ
{
    public partial class Main : Form
    {
        private Plot spectralPlot;
        private Plot horseshoePlot;
        private List<Data> dataPoints;

        private string DATA_PATH = "../../../data.txt";
        public static int CANVAS_WIDTH = 644;
        public static int CANVAS_HEIGHT = 600;

        public Main()
        {
            InitializeComponent();
            spectralPlot = new Plot(this.spectrumCanvas, new Bitmap(CANVAS_WIDTH, CANVAS_HEIGHT), 340, 800, 0, 1.8, 11, 0, 1);
            horseshoePlot = new Plot(this.horseshoeCanvas, new Bitmap(CANVAS_WIDTH, CANVAS_HEIGHT), -0.1, 1.0, -0.1, 1.0, 12, 1, 1);
            spectralPlot.DrawAxis();
            horseshoePlot.DrawAxis();
            dataPoints = Data.ReadData(DATA_PATH);

            foreach(var dpoint in dataPoints)
            {
                dpoint.PlotDataPoint(horseshoePlot);
            }

            List<Point> pts = new();
            pts.Add(new Point(50, 80));
            pts.Add(new Point(100, 30));
            pts.Add(new Point(300, 120));
            BezierCurve bezier = new(pts, spectralPlot);
            bezier.Draw();
        }

    }
}