using AptekaDesktop.Data;
using AptekaDesktop.Models;
using System;
using System.Windows.Forms;

namespace AptekaDesktop.Formalar
{
    public partial class AddMedecin : Form
    {
        MedecinsDB medecins = null;

        public AddMedecin()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (name.Text != "" && price.Text != "" && description.Text != "")
            {
                try
                {
                    MedecinModel model = new MedecinModel()
                    {
                        Name = name.Text,
                        Price = price.Text,
                        Description = description.Text,
                        ExpDate = expdate.Text
                    };
                    medecins = new MedecinsDB();
                    medecins.AddMedecin(model);

                    MessageBox.Show("Successfully added!");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Some fields empty!");
            }
        }
    }
}
