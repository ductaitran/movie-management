using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieManagement
{
    class ClassUser
    {
        public static void loadDataGridViewUser(ref DataGridView dataGridViewUser)
        {
            try
            {
                clsConnection.openConnection();
                string query = @"SELECT Users.users_id, Users.users_name, Users_Type.userstype_name
                                  from Users INNER JOIN Users_Type ON Users.users_type = Users_Type.userstype_id ";
                SqlCommand cmd = new SqlCommand(query, clsConnection.con);
                cmd.ExecuteNonQuery();

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Users");

                dataGridViewUser.DataSource = ds.Tables["Users"];
                clsConnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
