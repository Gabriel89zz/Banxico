namespace Banxico
{
    partial class Dgv
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
            dgvResults = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvResults).BeginInit();
            SuspendLayout();
            // 
            // dtpStartDate
            // 
            dtpStartDate.Location = new Point(32, 40);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(200, 23);
            dtpStartDate.TabIndex = 0;
            // 
            // dtpEndDate
            // 
            dtpEndDate.Location = new Point(32, 98);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(200, 23);
            dtpEndDate.TabIndex = 1;
            // 
            // btnConsult
            // 
            btnConsult.Location = new Point(66, 150);
            btnConsult.Name = "btnConsult";
            btnConsult.Size = new Size(116, 44);
            btnConsult.TabIndex = 2;
            btnConsult.Text = "button1";
            btnConsult.UseVisualStyleBackColor = true;
            btnConsult.Click += btnConsult_Click;
            // 
            // dgvResults
            // 
            dgvResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResults.Location = new Point(268, 25);
            dgvResults.Name = "dgvResults";
            dgvResults.Size = new Size(368, 251);
            dgvResults.TabIndex = 3;
            // 
            // Dgv
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvResults);
            Controls.Add(btnConsult);
            Controls.Add(dtpEndDate);
            Controls.Add(dtpStartDate);
            Name = "Dgv";
            Text = "Dgv";
            ((System.ComponentModel.ISupportInitialize)dgvResults).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private Button btnConsult;
        private DataGridView dgvResults;
    }
}