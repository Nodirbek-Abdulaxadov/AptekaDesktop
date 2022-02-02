using AptekaDesktop.Data;
using AptekaDesktop.Formalar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AptekaDesktop.Menyular
{
    public partial class Jadval : UserControl
    {
        DoriData doriData = new DoriData();
        int selectedId = 0;
        public Jadval()
        {
            InitializeComponent();
        }

        private void Jadval_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Add addform = new Add();
            addform.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedId = (int)dataGridView1.SelectedCells[0].Value;
            deleteBtn.Visible = true;
            updateBtn.Visible = true;
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Rostdan ham bu dorini o'chirmoqchisiz?", "Xabarnoma", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                doriData.DeleteDori(selectedId);
                Refresh();
            }
        }

        void Refresh()
        {
            dataGridView1.DataSource = doriData.GetDorilar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Edit edit = doriData.ShowEdit(selectedId);
            edit.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = doriData.SearchDorilar(searchT.Text);
        }
    }
}
