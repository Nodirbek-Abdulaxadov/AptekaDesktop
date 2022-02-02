using AptekaDesktop.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AptekaDesktop.Formalar
{
    public partial class Edit : Form
    {
        public Edit()
        {
            InitializeComponent();
        }

        private string id;
        public string Id
        { 
            get { return id; }
            set { id = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; nomi.Text = name; }
        }

        private string type;
        public string Type
        {
            get { return type; }
            set { type = value; turi.Text = type; }
        }

        private string price;
        public string Price
        {
            get { return price; }
            set { price = value; narxi.Text = price; }
        }

        private string date;
        public string Date
        {
            get { return date; }
            set { date = value; muddati.Text = date; }
        }

        private string count;
        public string Count
        {
            get { return count; }
            set { count = value; miqdori.Text = count; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DoriData doriData = new DoriData();
            doriData.EditDori(nomi.Text, turi.Text, narxi.Text, muddati.Text, miqdori.Text, id);
            this.Close();
        }
    }
}
