using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptekaDesktop.Data
{
    internal static class SqlQueries
    {
        public static string readQuery = "SELECT * FROM Medecins;";
        public static string addQuery = "INSERT INTO Medecins VALUES";
        public static string deleteQuery = "DELETE FROM Medecins WHERE Id = ";
    }
}
