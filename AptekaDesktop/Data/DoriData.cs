using AptekaDesktop.Formalar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AptekaDesktop.Data
{
    public class DoriData
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\DARS 2\AptekaDesktop\AptekaDesktop\Baza\AptekaDB.mdf;Integrated Security=True";
        SqlConnection connection = null;
        SqlDataAdapter dataAdapter = null;
        SqlCommand command = null;
        DataTable table = null;

        public DoriData()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        public DataTable GetDorilar()
        {
            try
            {
                dataAdapter = new SqlDataAdapter(SqlQueries.readQuery, connection);
                table = new DataTable();
                dataAdapter.Fill(table);

                return table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Xabarnoma", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return table;
            }
        }

        public void AddDori(string nomi, string turi, string narxi, string muddati, string miqdori)
        {
            try
            {
                string query = SqlQueries.addQuery + $"('{nomi}', '{turi}', '{narxi}', '{muddati}', '{miqdori}')";
                command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Muvofaqqiyatli qo'shildi!", "Xabarnoma", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Xabarnoma", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeleteDori(int id)
        {
            try
            {
                string query = SqlQueries.deleteQuery + $"'{id}'";
                command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Muvofaqqiyatli o'chirildi!", "Xabarnoma", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Xabarnoma", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Edit ShowEdit(int id)
        {
            Edit edit = new Edit();
            try
            {
                string query = SqlQueries.selectOne + $"'{id}'";
                command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                edit.Id = reader[0].ToString() ;
                edit.Name = reader[1].ToString();
                edit.Type = reader[2].ToString();
                edit.Price = reader[3].ToString();
                edit.Date = reader[4].ToString();
                edit.Count = reader[5].ToString();
                reader.Close();
                return edit;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Xabarnoma", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return edit;
            }
        }

        public void EditDori(string nomi, string turi, string narxi, string muddati, string miqdori, string id)
        {
            try
            {
                string query = SqlQueries.updateQuery + $"Nomi='{nomi}', Turi='{turi}', Narxi='{narxi}', YaroqlilikMuddati='{muddati}', MavjudMiqdor='{miqdori}' WHERE Id='{id}'";
                command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Muvofaqqiyatli yangilandi!", "Xabarnoma", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Xabarnoma", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable SearchDorilar(string text)
        {
            try
            {
                string query = SqlQueries.searchQuery + $"'%{text}%'";
                dataAdapter = new SqlDataAdapter(query, connection);
                table = new DataTable();
                dataAdapter.Fill(table);

                return table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Xabarnoma", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return table;
            }
        }
    }
}
