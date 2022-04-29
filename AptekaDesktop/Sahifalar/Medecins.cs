using AptekaDesktop.Data;
using AptekaDesktop.Formalar;
using System;
using System.Windows.Forms;

namespace AptekaDesktop.Sahifalar
{
    public partial class Medecins : UserControl
    {
        MedecinsDB medecins = null;
        string selectedId = "";
        public Medecins()
        {
            InitializeComponent();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            AddMedecin addMedecin = new AddMedecin();
            addMedecin.ShowDialog();
            Refresh();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            #region 
            //EditMedecin editMedecin = new EditMedecin();
            //editMedecin.Id = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            //editMedecin.Name = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            //editMedecin.Price = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            //editMedecin.Description = guna2DataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            //editMedecin.ExpDate = guna2DataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            //editMedecin.ShowDialog();
            #endregion

            EditMedecin edit = new EditMedecin( guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString(),
                                                guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString(),
                                                guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString(),
                                                guna2DataGridView1.SelectedRows[0].Cells[3].Value.ToString(),
                                                guna2DataGridView1.SelectedRows[0].Cells[4].Value.ToString() );
            edit.ShowDialog();
            Refresh();
        }

        private void Medecins_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            medecins = new MedecinsDB();
            guna2DataGridView1.DataSource = medecins.GetMedecins();
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedId = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (selectedId != "")
            {
                try
                {
                    DialogResult dialog = MessageBox.Show( "Are you sure delete this?","Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialog == DialogResult.Yes)
                    {
                        medecins = new MedecinsDB();
                        medecins.DeleteMedecin(selectedId);
                        MessageBox.Show("Successfully deleted!");
                        Refresh();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text != "")
            {
                medecins = new MedecinsDB();
                guna2DataGridView1.DataSource = medecins.GetMedecins(guna2TextBox1.Text);
            }
            else
            {
                Refresh();
            }
        }
    }
}
