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
                con = new SqlConnection("Server=HOANGMINH; Database=MovieManagement; uid=hoangminh; pwd=hoangminh");
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
