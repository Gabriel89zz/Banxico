namespace Banxico
{
    partial class PiePlot
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnGenerate = new Button();
            PieWithPercentLabels = new ScottPlot.WinForms.FormsPlot();
            PieChartFromSlices = new ScottPlot.WinForms.FormsPlot();
            NormalPieChart = new ScottPlot.WinForms.FormsPlot();
            Donut = new ScottPlot.WinForms.FormsPlot();
            SuspendLayout();
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(24, 31);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(123, 43);
            btnGenerate.TabIndex = 0;
            btnGenerate.Text = "Generate Numbers";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // PieWithPercentLabels
            // 
            PieWithPercentLabels.DisplayScale = 1F;
            PieWithPercentLabels.Location = new Point(582, 299);
            PieWithPercentLabels.Name = "PieWithPercentLabels";
            PieWithPercentLabels.Size = new Size(290, 205);
            PieWithPercentLabels.TabIndex = 1;
            // 
            // PieChartFromSlices
            // 
            PieChartFromSlices.DisplayScale = 1F;
            PieChartFromSlices.Location = new Point(216, 299);
            PieChartFromSlices.Name = "PieChartFromSlices";
            PieChartFromSlices.Size = new Size(290, 205);
            PieChartFromSlices.TabIndex = 2;
            // 
            // NormalPieChart
            // 
            NormalPieChart.DisplayScale = 1F;
            NormalPieChart.Location = new Point(216, 31);
            NormalPieChart.Name = "NormalPieChart";
            NormalPieChart.Size = new Size(290, 205);
            NormalPieChart.TabIndex = 4;
            // 
            // Donut
            // 
            Donut.DisplayScale = 1F;
            Donut.Location = new Point(582, 31);
            Donut.Name = "Donut";
            Donut.Size = new Size(290, 205);
            Donut.TabIndex = 3;
            // 
            // PiePlot
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(992, 612);
            Controls.Add(NormalPieChart);
            Controls.Add(Donut);
            Controls.Add(PieChartFromSlices);
            Controls.Add(PieWithPercentLabels);
            Controls.Add(btnGenerate);
            Name = "PiePlot";
            Text = "PiePlot";
            ResumeLayout(false);
        }

        #endregion

        private Button btnGenerate;
        private ScottPlot.WinForms.FormsPlot PieWithPercentLabels;
        private ScottPlot.WinForms.FormsPlot PieChartFromSlices;
        private ScottPlot.WinForms.FormsPlot NormalPieChart;
        private ScottPlot.WinForms.FormsPlot Donut;
    }
}