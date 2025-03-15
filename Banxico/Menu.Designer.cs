namespace Banxico
{
    partial class Menu
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
            btnDgv = new Button();
            btnGraphic = new Button();
            SuspendLayout();
            // 
            // btnDgv
            // 
            btnDgv.Location = new Point(69, 188);
            btnDgv.Name = "btnDgv";
            btnDgv.Size = new Size(172, 66);
            btnDgv.TabIndex = 0;
            btnDgv.Text = "Datagriedview";
            btnDgv.UseVisualStyleBackColor = true;
            btnDgv.Click += btnDgv_Click;
            // 
            // btnGraphic
            // 
            btnGraphic.Location = new Point(314, 192);
            btnGraphic.Name = "btnGraphic";
            btnGraphic.Size = new Size(172, 66);
            btnGraphic.TabIndex = 1;
            btnGraphic.Text = "Graphic";
            btnGraphic.UseVisualStyleBackColor = true;
            btnGraphic.Click += btnGraphic_Click;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnGraphic);
            Controls.Add(btnDgv);
            Name = "Menu";
            Text = "Menu";
            ResumeLayout(false);
        }

        #endregion

        private Button btnDgv;
        private Button btnGraphic;
    }
}