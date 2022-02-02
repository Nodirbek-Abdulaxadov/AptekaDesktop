using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptekaDesktop.Data
{
    public static class SqlQueries
    {
        public static string readQuery = "SELECT * FROM Dorilar";
        public static string addQuery = "INSERT INTO Dorilar (Nomi, Turi, Narxi, YaroqlilikMuddati, MavjudMiqdor) VALUES ";
        public static string selectOne = "SELECT * FROM Dorilar WHERE Id=";
        public static string updateQuery = "UPDATE Dorilar SET ";
        public static string deleteQuery = "DELETE FROM Dorilar WHERE Id=";
        public static string searchQuery = "SELECT * FROM Dorilar WHERE Nomi LIKE ";
    }
}
