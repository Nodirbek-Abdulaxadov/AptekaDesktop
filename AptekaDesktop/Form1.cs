﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AptekaDesktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HideAll();
            jadval1.Visible = true;
        }

        void HideAll()
        {
            jadval1.Visible = false;
            home1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HideAll();
            home1.Visible = true;
        }
    }
}