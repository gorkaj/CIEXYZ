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
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spectrumCanvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.horseshoeCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.spectrumCanvas, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.horseshoeCanvas, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1300, 606);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // spectrumCanvas
            // 
            this.spectrumCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spectrumCanvas.Location = new System.Drawing.Point(3, 3);
            this.spectrumCanvas.Name = "spectrumCanvas";
            this.spectrumCanvas.Size = new System.Drawing.Size(644, 600);
            this.spectrumCanvas.TabIndex = 0;
            this.spectrumCanvas.TabStop = false;
            // 
            // horseshoeCanvas
            // 
            this.horseshoeCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.horseshoeCanvas.Location = new System.Drawing.Point(653, 3);
            this.horseshoeCanvas.Name = "horseshoeCanvas";
            this.horseshoeCanvas.Size = new System.Drawing.Size(644, 600);
            this.horseshoeCanvas.TabIndex = 1;
            this.horseshoeCanvas.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 606);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CIE XYZ";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spectrumCanvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.horseshoeCanvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox spectrumCanvas;
        private PictureBox horseshoeCanvas;
    }
}