using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement
{
    class clsConnection
    {
        public static SqlConnection con;
        public static bool openConnection()
        {
            try
            {
                con = new SqlConnection("Data Source=DESKTOP-61O1BP9\\MINH;Initial Catalog=MovieManagement;Integrated Security=True");
                con.Open();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public static bool closeConnection()
        {
            try
            {
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
