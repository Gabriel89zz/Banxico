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
            SuspendLayout();
            // 
            // dtpStartDate
            // 
            dtpStartDate.Location = new Point(53, 45);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(200, 23);
            dtpStartDate.TabIndex = 0;
            // 
            // dtpEndDate
            // 
            dtpEndDate.Location = new Point(53, 101);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(200, 23);
            dtpEndDate.TabIndex = 1;
            // 
            // btnConsult
            // 
            btnConsult.Location = new Point(96, 149);
            btnConsult.Name = "btnConsult";
            btnConsult.Size = new Size(117, 44);
            btnConsult.TabIndex = 2;
            btnConsult.Text = "button1";
            btnConsult.UseVisualStyleBackColor = true;
            btnConsult.Click += btnConsult_Click;
            // 
            // formsPlot1
            // 
            formsPlot1.DisplayScale = 1F;
            formsPlot1.Location = new Point(338, 74);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(383, 226);
            formsPlot1.TabIndex = 3;
            // 
            // Graphic
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(formsPlot1);
            Controls.Add(btnConsult);
            Controls.Add(dtpEndDate);
            Controls.Add(dtpStartDate);
            Name = "Graphic";
            Text = "Graphic";
            ResumeLayout(false);
        }

        #endregion

        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private Button btnConsult;
        private ScottPlot.WinForms.FormsPlot formsPlot1;
    }
}