namespace CIE_XYZ
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.spectrumCanvas = new System.Windows.Forms.PictureBox();
            this.horseshoeCanvas = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.numOfPoints = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spectrumCanvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.horseshoeCanvas)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOfPoints)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.spectrumCanvas, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.horseshoeCanvas, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1300, 677);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // spectrumCanvas
            // 
            this.spectrumCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spectrumCanvas.Location = new System.Drawing.Point(3, 70);
            this.spectrumCanvas.Name = "spectrumCanvas";
            this.spectrumCanvas.Size = new System.Drawing.Size(644, 604);
            this.spectrumCanvas.TabIndex = 0;
            this.spectrumCanvas.TabStop = false;
            this.spectrumCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.spectrumCanvas_MouseDown);
            this.spectrumCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.spectrumCanvas_MouseMove);
            this.spectrumCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.spectrumCanvas_MouseUp);
            // 
            // horseshoeCanvas
            // 
            this.horseshoeCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.horseshoeCanvas.Location = new System.Drawing.Point(653, 70);
            this.horseshoeCanvas.Name = "horseshoeCanvas";
            this.horseshoeCanvas.Size = new System.Drawing.Size(644, 604);
            this.horseshoeCanvas.TabIndex = 1;
            this.horseshoeCanvas.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.numOfPoints);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(644, 61);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(405, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Number of points";
            // 
            // numOfPoints
            // 
            this.numOfPoints.Location = new System.Drawing.Point(541, 9);
            this.numOfPoints.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numOfPoints.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numOfPoints.Name = "numOfPoints";
            this.numOfPoints.Size = new System.Drawing.Size(103, 27);
            this.numOfPoints.TabIndex = 2;
            this.numOfPoints.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numOfPoints.ValueChanged += new System.EventHandler(this.numOfPoints_ValueChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 677);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CIE XYZ";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spectrumCanvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.horseshoeCanvas)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOfPoints)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox spectrumCanvas;
        private PictureBox horseshoeCanvas;
        private NumericUpDown numOfPoints;
        private Panel panel1;
        private Label label1;
    }
}