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

        public static void DeleteUser(ref DataGridView dataGridViewUser)
        {
            try
            {
                string id = dataGridViewUser.SelectedCells[0].Value.ToString();
                DialogResult deleted = MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (deleted == DialogResult.Yes)
                {
                    string query = @"DELETE FROM Users WHERE users_id = '" + id + "'";

                    clsConnection.openConnection();
                    SqlCommand cmd = new SqlCommand(query, clsConnection.con);
                    cmd.ExecuteNonQuery();

                    clsConnection.closeConnection();
                    MessageBox.Show("This user has been deleted!");
                    loadDataGridViewUser(ref dataGridViewUser);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
