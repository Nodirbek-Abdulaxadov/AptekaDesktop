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
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            EditMedecin editMedecin = new EditMedecin();
            editMedecin.ShowDialog();
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
    }
}
