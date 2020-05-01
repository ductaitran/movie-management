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
        static DataSet Users = new DataSet();

        public static void loadDataGridViewUser(ref DataGridView dataGridViewUser)
        {
            try
            {
                Users.Clear();
                clsConnection.openConnection();
                string query = @"SELECT Users.users_id, Users.users_name, Users_Type.userstype_name
                                  from Users INNER JOIN Users_Type ON Users.users_type = Users_Type.userstype_id ";
                SqlCommand cmd = new SqlCommand(query, clsConnection.con);
                cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(Users, "Users");

                dataGridViewUser.DataSource = Users.Tables["Users"];
                clsConnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void deleteUser(ref DataGridView dataGridViewUser)
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
                    //loadDataGridViewUser(ref dataGridViewUser);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void updateUser(DataSet ds)
        {
            clsConnection.openConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommandBuilder cmdbuilder = new SqlCommandBuilder(da);
            da.SelectCommand = new SqlCommand(@"SELECT Users.users_id, Users.users_name, Users_Type.userstype_name
                                  from Users INNER JOIN Users_Type ON Users.users_type = Users_Type.userstype_id", clsConnection.con);
            da.Update(ds.Tables["Users"]);
        }

        public static void updateUserOnCLick(ref DataGridView dataGridViewUser)
        {
            updateUser(Users);
        }

        public static void loadAddUserForm(ref DataGridView dataGridViewUser, ref ComboBox ComboBoxAddUserType)
        {
            try
            {
                clsConnection.openConnection();
                string query = @"SELECT * FROM Users_Type";
                SqlCommand cmd = new SqlCommand(query, clsConnection.con);
                cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                ComboBoxAddUserType.DataSource = dt;
                ComboBoxAddUserType.ValueMember = "userstype_id";
                ComboBoxAddUserType.DisplayMember = "userstype_name";

                clsConnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void addUser(ref DataGridView dataGridViewUser, ref TextBox TextBoxAddUserID, ref TextBox TextBoxAddUserName, ref TextBox TextBoxAddUserPassword, ref ComboBox ComboBoxAddUserType)
        {
            try
            {
                DialogResult add = MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (add == DialogResult.Yes)
                {
                    string strInsert = "Insert Into Users Values(@users_id, @users_name, @users_password, @users_type)";
                    clsConnection.openConnection();

                    SqlCommand com = new SqlCommand(strInsert, clsConnection.con);

                    SqlParameter p1 = new SqlParameter("@users_id", SqlDbType.NVarChar);
                    p1.Value = TextBoxAddUserID.Text;
                    SqlParameter p2 = new SqlParameter("@users_name", SqlDbType.NVarChar);
                    p2.Value = TextBoxAddUserName.Text;
                    SqlParameter p3 = new SqlParameter("@users_password", SqlDbType.NVarChar);
                    p3.Value = TextBoxAddUserPassword.Text;
                    SqlParameter p4 = new SqlParameter("@users_type", SqlDbType.NVarChar);
                    p4.Value = ComboBoxAddUserType.SelectedValue;

                    com.Parameters.Add(p1);
                    com.Parameters.Add(p2);
                    com.Parameters.Add(p3);
                    com.Parameters.Add(p4);
                    com.ExecuteNonQuery();

                    MessageBox.Show("User has been updated!!");

                    clsConnection.closeConnection();

                    //loadDataGridViewUser(ref dataGridViewUser);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
