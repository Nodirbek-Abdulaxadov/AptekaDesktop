using AptekaDesktop.Models;
using System.Data;
using System.Data.SqlClient;

namespace AptekaDesktop.Data
{
    internal class MedecinsDB
    {
        SqlConnection sqlConnection = null;
        SqlCommand sqlCommand = null;
        SqlDataAdapter sqlDataAdapter = null;
        DataTable table = null;

        string conString = "Server=(localdb)\\mssqllocaldb;Database=AptekaDB;Trusted_Connection=True;MultipleActiveResultSets=true";

        public MedecinsDB()
        {
            sqlConnection = new SqlConnection(conString);
            sqlConnection.Open();
        }

        public DataTable GetMedecins()
        {
            sqlDataAdapter = new SqlDataAdapter(SqlQueries.readQuery, sqlConnection);
            table = new DataTable();
            sqlDataAdapter.Fill(table);

            return table;
        }

        public void AddMedecin(MedecinModel medecin)
        {
            string sql = SqlQueries.addQuery + $"('{medecin.Name}', '{medecin.Price}', '{medecin.Description}', '{medecin.ExpDate}');";
            sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.ExecuteNonQuery();
        }

        public void DeleteMedecin(string id)
        {
            string sql = SqlQueries.deleteQuery + id;
            sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.ExecuteNonQuery();
        }
    }
}
