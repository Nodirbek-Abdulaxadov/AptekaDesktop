using AptekaDesktop.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AptekaDesktop.Formalar
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            MedecinsDB medecinsDB = new MedecinsDB();
            if (medecinsDB.IsExist(email.Text, password.Text))
            {
                SaveCache();
                Form1 form1 = new Form1();
                form1.Show();
                this.Hide();
            }
            else
            {
                label4.Visible = true;
            }
        }

        private void email_TextChanged(object sender, EventArgs e)
        {
            label4.Visible = false;
        }

        private void SaveCache()
        {
            StreamWriter writer = new StreamWriter("login.txt");
            writer.WriteLine(email.Text);
            writer.WriteLine(password.Text);
            writer.Flush();
        }
    }
}
