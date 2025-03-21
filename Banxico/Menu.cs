﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banxico
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnDgv_Click(object sender, EventArgs e)
        {
            Dgv dgv = new Dgv();
            dgv.Show();

        }

        private void btnGraphic_Click(object sender, EventArgs e)
        {
            Graphic graphic = new Graphic();
            graphic.Show();
        }

        private void btnPiePlot_Click(object sender, EventArgs e)
        {
            PiePlot piePlot = new PiePlot();
            piePlot.Show();
        }

        private void Menu_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
