using FontAwesome.Sharp;
using System;
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

        private void iconButton1_MouseHover(object sender, EventArgs e)
        {
            ButtonHoverEnable(sender);
        }

        private void iconButton1_MouseLeave(object sender, EventArgs e)
        {
            ButtonHoverDisable(sender);
        }

        private void ButtonHoverEnable(object sender)
        {
            //Button button = (Button)sender;
            IconButton button = sender as IconButton;
            button.ForeColor = button.IconColor = Color.FromArgb(26, 116, 239);
        }

        private void ButtonHoverDisable(object sender)
        {
            IconButton button = sender as IconButton;
            button.ForeColor = button.IconColor = Color.White;
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {

        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            medecins1.Visible = false;
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            medecins1.Visible = true;
        }
    }
}
