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
            this.showFuncCheckbox = new System.Windows.Forms.CheckBox();
            this.evenSpectrumBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numOfPoints = new System.Windows.Forms.NumericUpDown();
            this.panel2 = new System.Windows.Forms.Panel();
            this.backgroundBox = new System.Windows.Forms.CheckBox();
            this.colorPanel = new System.Windows.Forms.Panel();
            this.loadBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spectrumCanvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.horseshoeCanvas)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOfPoints)).BeginInit();
            this.panel2.SuspendLayout();
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
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1300, 758);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // spectrumCanvas
            // 
            this.spectrumCanvas.BackColor = System.Drawing.Color.White;
            this.spectrumCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spectrumCanvas.Location = new System.Drawing.Point(3, 78);
            this.spectrumCanvas.Name = "spectrumCanvas";
            this.spectrumCanvas.Size = new System.Drawing.Size(644, 677);
            this.spectrumCanvas.TabIndex = 0;
            this.spectrumCanvas.TabStop = false;
            this.spectrumCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.spectrumCanvas_MouseDown);
            this.spectrumCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.spectrumCanvas_MouseMove);
            this.spectrumCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.spectrumCanvas_MouseUp);
            // 
            // horseshoeCanvas
            // 
            this.horseshoeCanvas.BackColor = System.Drawing.Color.White;
            this.horseshoeCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.horseshoeCanvas.Location = new System.Drawing.Point(653, 78);
            this.horseshoeCanvas.Name = "horseshoeCanvas";
            this.horseshoeCanvas.Size = new System.Drawing.Size(644, 677);
            this.horseshoeCanvas.TabIndex = 1;
            this.horseshoeCanvas.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.showFuncCheckbox);
            this.panel1.Controls.Add(this.evenSpectrumBtn);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.numOfPoints);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(644, 69);
            this.panel1.TabIndex = 3;
            // 
            // showFuncCheckbox
            // 
            this.showFuncCheckbox.AutoSize = true;
            this.showFuncCheckbox.Location = new System.Drawing.Point(155, 23);
            this.showFuncCheckbox.Name = "showFuncCheckbox";
            this.showFuncCheckbox.Size = new System.Drawing.Size(131, 24);
            this.showFuncCheckbox.TabIndex = 5;
            this.showFuncCheckbox.Text = "Show functions";
            this.showFuncCheckbox.UseVisualStyleBackColor = true;
            this.showFuncCheckbox.CheckedChanged += new System.EventHandler(this.showFuncCheckbox_CheckedChanged);
            // 
            // evenSpectrumBtn
            // 
            this.evenSpectrumBtn.Location = new System.Drawing.Point(15, 16);
            this.evenSpectrumBtn.Name = "evenSpectrumBtn";
            this.evenSpectrumBtn.Size = new System.Drawing.Size(117, 37);
            this.evenSpectrumBtn.TabIndex = 4;
            this.evenSpectrumBtn.Text = "Even spectrum";
            this.evenSpectrumBtn.UseVisualStyleBackColor = true;
            this.evenSpectrumBtn.Click += new System.EventHandler(this.evenSpectrumBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(394, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Number of points";
            // 
            // numOfPoints
            // 
            this.numOfPoints.Location = new System.Drawing.Point(530, 19);
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
            // panel2
            // 
            this.panel2.Controls.Add(this.saveBtn);
            this.panel2.Controls.Add(this.loadBtn);
            this.panel2.Controls.Add(this.backgroundBox);
            this.panel2.Controls.Add(this.colorPanel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(653, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(644, 69);
            this.panel2.TabIndex = 4;
            // 
            // backgroundBox
            // 
            this.backgroundBox.AutoSize = true;
            this.backgroundBox.Checked = true;
            this.backgroundBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.backgroundBox.Location = new System.Drawing.Point(15, 20);
            this.backgroundBox.Name = "backgroundBox";
            this.backgroundBox.Size = new System.Drawing.Size(150, 24);
            this.backgroundBox.TabIndex = 5;
            this.backgroundBox.Text = "Show background";
            this.backgroundBox.UseVisualStyleBackColor = true;
            this.backgroundBox.CheckedChanged += new System.EventHandler(this.backgroundBox_CheckedChanged);
            // 
            // colorPanel
            // 
            this.colorPanel.Location = new System.Drawing.Point(573, 3);
            this.colorPanel.Name = "colorPanel";
            this.colorPanel.Size = new System.Drawing.Size(62, 69);
            this.colorPanel.TabIndex = 4;
            // 
            // loadBtn
            // 
            this.loadBtn.Location = new System.Drawing.Point(238, 17);
            this.loadBtn.Name = "loadBtn";
            this.loadBtn.Size = new System.Drawing.Size(115, 36);
            this.loadBtn.TabIndex = 6;
            this.loadBtn.Text = "Load spectrum";
            this.loadBtn.UseVisualStyleBackColor = true;
            this.loadBtn.Click += new System.EventHandler(this.loadBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(359, 17);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(115, 36);
            this.saveBtn.TabIndex = 7;
            this.saveBtn.Text = "Save spectrum";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 758);
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
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox spectrumCanvas;
        private PictureBox horseshoeCanvas;
        private NumericUpDown numOfPoints;
        private Panel panel1;
        private Label label1;
        private Panel colorPanel;
        private Panel panel2;
        private CheckBox backgroundBox;
        private Button evenSpectrumBtn;
        private CheckBox showFuncCheckbox;
        private Button saveBtn;
        private Button loadBtn;
    }
}