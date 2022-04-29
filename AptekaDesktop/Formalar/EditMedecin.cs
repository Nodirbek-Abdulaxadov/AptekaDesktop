using AptekaDesktop.Data;
using AptekaDesktop.Models;
using System;
using System.Windows.Forms;

namespace AptekaDesktop.Formalar
{
    public partial class EditMedecin : Form
    {
        public EditMedecin()
        {
            InitializeComponent();
        }

        public EditMedecin(string Id, string Name, string Price, string Desc, string Date)
        {
            InitializeComponent();
            id = Id;
            nameBox.Text = Name;
            priceBOx.Text = Price;
            descBox.Text = Desc;
            dateBox.Text = Date;
        }

        private string id { get; set; }

        #region 1-usul
        //private string name { get; set; }
        //private string price { get; set; }
        //private string expDate { get; set; }
        //private string description { get; set; }


        //public string Id
        //{
        //    get { return id; }
        //    set { id = value; }
        //}

        //public string Name
        //{
        //    get { return name; }
        //    set { name = value; nameBox.Text = name; }
        //}

        //public string Price
        //{
        //    get { return price; }
        //    set { price = value; priceBOx.Text = price; }
        //}

        //public string Description
        //{
        //    get { return description; }
        //    set { description = value; descBox.Text = description; }
        //}

        //public string ExpDate
        //{
        //    get { return expDate; }
        //    set { expDate = value; dateBox.Text = expDate; }
        //}
        #endregion



        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                MedecinsDB db = new MedecinsDB();
                MedecinModel model = new MedecinModel()
                {
                    Id = int.Parse(id),
                    Name = nameBox.Text,
                    Price = priceBOx.Text,
                    Description = descBox.Text,
                    ExpDate = dateBox.Text
                };

                db.EditMedecin(model);
                MessageBox.Show("Successfully updated!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
