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
<<<<<<< HEAD
                con = new SqlConnection("Server=DESKTOP-NTFJ11I\\DUCTAITRANSQL; Database=MovieManagement; User Id=sa; Password=880883");
                //con = new SqlConnection("Server=HOANGMINH; Database=MovieManagement; uid=hoangminh; pwd=hoangminh");
||||||| 9288b40
                con = new SqlConnection("Server=HOANGMINH; Database=MovieManagement; uid=hoangminh; pwd=hoangminh");
=======
                con = new SqlConnection("Data Source=DESKTOP-61O1BP9\\MINH;Initial Catalog=MovieManagement;Integrated Security=True");
>>>>>>> 8e7e2b99d75a2274e205e90427a58ebcbebef98a
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
