namespace Banxico
{
    partial class Graphic
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
            dtpStartDate = new DateTimePicker();
            dtpEndDate = new DateTimePicker();
            btnConsult = new Button();
            formsPlot1 = new ScottPlot.WinForms.FormsPlot();
            barPlot = new ScottPlot.WinForms.FormsPlot();
            dolarvsEuro = new ScottPlot.WinForms.FormsPlot();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // dtpStartDate
            // 
            dtpStartDate.Location = new Point(53, 68);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(200, 23);
            dtpStartDate.TabIndex = 0;
            // 
            // dtpEndDate
            // 
            dtpEndDate.Location = new Point(53, 142);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(200, 23);
            dtpEndDate.TabIndex = 1;
            // 
            // btnConsult
            // 
            btnConsult.Location = new Point(99, 189);
            btnConsult.Name = "btnConsult";
            btnConsult.Size = new Size(117, 44);
            btnConsult.TabIndex = 2;
            btnConsult.Text = "Consult";
            btnConsult.UseVisualStyleBackColor = true;
            btnConsult.Click += btnConsult_Click;
            // 
            // formsPlot1
            // 
            formsPlot1.DisplayScale = 1F;
            formsPlot1.Location = new Point(542, 45);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(383, 226);
            formsPlot1.TabIndex = 3;
            // 
            // barPlot
            // 
            barPlot.DisplayScale = 1F;
            barPlot.Location = new Point(29, 336);
            barPlot.Name = "barPlot";
            barPlot.Size = new Size(376, 240);
            barPlot.TabIndex = 4;
            // 
            // dolarvsEuro
            // 
            dolarvsEuro.DisplayScale = 1F;
            dolarvsEuro.Location = new Point(542, 336);
            dolarvsEuro.Name = "dolarvsEuro";
            dolarvsEuro.Size = new Size(368, 213);
            dolarvsEuro.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(53, 50);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 6;
            label1.Text = "Start Date:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(53, 124);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 7;
            label2.Text = "End Date:";
            // 
            // Graphic
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1008, 719);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dolarvsEuro);
            Controls.Add(barPlot);
            Controls.Add(formsPlot1);
            Controls.Add(btnConsult);
            Controls.Add(dtpEndDate);
            Controls.Add(dtpStartDate);
            Name = "Graphic";
            Text = "Graphic";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private Button btnConsult;
        private ScottPlot.WinForms.FormsPlot formsPlot1;
        private ScottPlot.WinForms.FormsPlot barPlot;
        private ScottPlot.WinForms.FormsPlot dolarvsEuro;
        private Label label1;
        private Label label2;
    }
}