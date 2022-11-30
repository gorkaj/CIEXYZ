namespace CIE_XYZ
{
    public partial class Main : Form
    {
        private Plot spectralPlot;
        private Plot horseshoePlot;
        private List<Data> dataPoints;
        private BezierCurve bezier;

        private string DATA_PATH = "../../../data.txt";
        public static int CANVAS_WIDTH = 644;
        public static int CANVAS_HEIGHT = 600;

        public Main()
        {
            InitializeComponent();
            spectralPlot = new Plot(this.spectrumCanvas, new Bitmap(CANVAS_WIDTH, CANVAS_HEIGHT), 340, 860, 0, 2.15, 12, 0, 1);
            horseshoePlot = new Plot(this.horseshoeCanvas, new Bitmap(CANVAS_WIDTH, CANVAS_HEIGHT), -0.1, 1.0, -0.1, 1.0, 12, 1, 1);
            spectralPlot.DrawAxis();
            horseshoePlot.DrawAxis();
            dataPoints = Data.ReadData(DATA_PATH);

            foreach(var dpoint in dataPoints)
            {
                dpoint.PlotDataPoint(horseshoePlot, false);
            }

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
            bezier.Draw();
            var pointFromSpectrum = bezier.FindRelatedPoint(dataPoints);
            pointFromSpectrum.PlotDataPoint(horseshoePlot, true);
        }
    }
}