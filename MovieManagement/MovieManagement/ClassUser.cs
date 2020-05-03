using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieManagement
{
    class ClassUser
    {
        static DataSet Users = new DataSet();
        static string user_id;
        static string user_type;

        public static string userID
        {
            get
            {
                return user_id;
            }
        }

        public static string userType
        {
            get
            {
                return user_type;
            }
        }

        public static void loadDataGridViewUser(ref DataGridView dataGridViewUser)
        {
            try
            {
                Users.Clear();

                clsConnection.openConnection();
                List<string> listUsersTypeID = new List<string>();
                string query = @"SELECT Users.users_id, Users.users_name, Users_Type.userstype_id, Users_Type.userstype_name
                                  from Users INNER JOIN Users_Type ON Users.users_type = Users_Type.userstype_id";

                SqlCommand com = new SqlCommand(query, clsConnection.con);
                SqlDataReader dataReader = com.ExecuteReader();
                DataTable usersTable = new DataTable();
                DataColumn usersIDCol = new DataColumn("users_id");
                DataColumn usersNameCol = new DataColumn("users_name");
                DataColumn usersTypeNameCol = new DataColumn("userstype_name");
                usersTable.Columns.Add(usersIDCol);
                usersTable.Columns.Add(usersNameCol);
                usersTable.Columns.Add(usersTypeNameCol);

                while (dataReader.Read())
                {
                    usersTable.Rows.Add(dataReader[0].ToString(), dataReader[1].ToString(), dataReader[3].ToString());
                    listUsersTypeID.Add(dataReader[2].ToString());
                }
                dataReader.Close();

                dataGridViewUser.DataSource = usersTable;

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
                int selectedrowindex = dataGridViewUser.SelectedCells[0].RowIndex;
                string id = dataGridViewUser.Rows[selectedrowindex].Cells[0].Value.ToString();
                DialogResult deleted = MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (deleted == DialogResult.Yes)
                {
                    string query = @"DELETE FROM Users WHERE users_id = '" + id + "'";

                    clsConnection.openConnection();
                    SqlCommand cmd = new SqlCommand(query, clsConnection.con);
                    cmd.ExecuteNonQuery();

                    clsConnection.closeConnection();
                    MessageBox.Show("This user has been deleted!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                int available;
                string query = @"SELECT COUNT(users_name) FROM Users WHERE users_name = @users_name";
                clsConnection.openConnection();
                SqlCommand com1 = new SqlCommand(query, clsConnection.con);
                SqlParameter param1 = new SqlParameter("@users_name", SqlDbType.NVarChar);
                param1.Value = TextBoxAddUserName.Text.Trim();
                com1.Parameters.Add(param1);
                available = Convert.ToInt32(com1.ExecuteScalar());
                clsConnection.closeConnection();

                if (available >= 1)
                {
                    MessageBox.Show("Username is not available! Please choose another name.");
                }

                else
                {
                    DialogResult add = MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (add == DialogResult.Yes)
                    {
                        string strInsert = @"Insert Into Users Values(@users_id, @users_password, @users_name, @users_type)";
                        clsConnection.openConnection();

                        SqlCommand com = new SqlCommand(strInsert, clsConnection.con);

                        SqlParameter p1 = new SqlParameter("@users_id", SqlDbType.NVarChar);
                        p1.Value = TextBoxAddUserID.Text.Trim();
                        SqlParameter p2 = new SqlParameter("@users_name", SqlDbType.NVarChar);
                        p2.Value = TextBoxAddUserName.Text.Trim();
                        SqlParameter p3 = new SqlParameter("@users_password", SqlDbType.NVarChar);
                        p3.Value = TextBoxAddUserPassword.Text.Trim();
                        SqlParameter p4 = new SqlParameter("@users_type", SqlDbType.NVarChar);
                        p4.Value = ComboBoxAddUserType.SelectedValue;

                        com.Parameters.Add(p1);
                        com.Parameters.Add(p2);
                        com.Parameters.Add(p3);
                        com.Parameters.Add(p4);
                        com.ExecuteNonQuery();

                        MessageBox.Show("User has been added!!");

                        clsConnection.closeConnection();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void loadEditUserForm(ref DataGridView dataGridViewUser, ref TextBox TextBoxAddUserID, ref TextBox TextBoxAddUserName, ref ComboBox ComboBoxAddUserType)
        {
            try
            {
                int selectedrowindex = dataGridViewUser.SelectedCells[0].RowIndex;
                string id = dataGridViewUser.Rows[selectedrowindex].Cells[0].Value.ToString();
                TextBoxAddUserID.ReadOnly = true;
                TextBoxAddUserID.Enabled = false;
                TextBoxAddUserID.Text = id;
                TextBoxAddUserName.Text = dataGridViewUser.Rows[selectedrowindex].Cells[1].Value.ToString();

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


        public static void updateUser(ref DataGridView dataGridViewUser, ref TextBox TextBoxAddUserID, ref TextBox TextBoxAddUserName, ref TextBox TextBoxAddUserPassword, ref ComboBox ComboBoxAddUserType)
        {
            try
            {
                int available;
                string query = @"SELECT COUNT(users_name) FROM Users WHERE users_name = @users_name";
                clsConnection.openConnection();
                SqlCommand com1 = new SqlCommand(query, clsConnection.con);
                SqlParameter param1 = new SqlParameter("@users_name", SqlDbType.NVarChar);
                param1.Value = TextBoxAddUserName.Text.Trim();
                com1.Parameters.Add(param1);
                available = Convert.ToInt32(com1.ExecuteScalar());
                clsConnection.closeConnection();

                if (available >= 1)
                {
                    MessageBox.Show("Username is not available! Please choose another name.");
                }

                else
                {
                    DialogResult update = MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (update == DialogResult.Yes)
                    {
                        string id = TextBoxAddUserID.Text;
                        string newpassword = TextBoxAddUserPassword.Text.Trim();
                        string strInsert;

                        clsConnection.openConnection();

                        strInsert = @"UPDATE Users SET users_name = @users_name, users_type = @users_type WHERE users_id = @users_id";

                        SqlCommand com = new SqlCommand(strInsert, clsConnection.con);

                        if (newpassword != "")
                        {
                            strInsert = @"UPDATE Users SET users_password = @users_password, users_name = @users_name, users_type = @users_type WHERE users_id = @users_id";
                            com = new SqlCommand(strInsert, clsConnection.con);
                            SqlParameter p1 = new SqlParameter("@users_password", SqlDbType.NVarChar);
                            p1.Value = TextBoxAddUserPassword.Text.Trim();
                            com.Parameters.Add(p1);
                        }

                        SqlParameter p2 = new SqlParameter("@users_name", SqlDbType.NVarChar);
                        p2.Value = TextBoxAddUserName.Text.Trim();
                        SqlParameter p3 = new SqlParameter("@users_type", SqlDbType.NVarChar);
                        p3.Value = ComboBoxAddUserType.SelectedValue;
                        SqlParameter p4 = new SqlParameter("@users_id", SqlDbType.NVarChar);
                        p4.Value = id;

                        com.Parameters.Add(p2);
                        com.Parameters.Add(p3);
                        com.Parameters.Add(p4);
                        com.ExecuteNonQuery();

                        MessageBox.Show("User has been updated!!");

                        clsConnection.closeConnection();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static int userLogin(ref TextBox textBoxUserName, ref TextBox textBoxUserPassword)
        {
            try
            {
                string id;
                string query = "Select users_id From Users Where users_name = @users_name AND users_password = @users_password";
                clsConnection.openConnection();
                SqlCommand com = new SqlCommand(query, clsConnection.con);
                SqlParameter p1 = new SqlParameter("@users_name", SqlDbType.NVarChar);
                p1.Value = textBoxUserName.Text.Trim();
                SqlParameter p2 = new SqlParameter("@users_password", SqlDbType.NVarChar);
                p2.Value = textBoxUserPassword.Text.Trim();
                com.Parameters.Add(p1);
                com.Parameters.Add(p2);
                user_id = com.ExecuteScalar().ToString();
                clsConnection.closeConnection();

                if (user_id == "")
                {
                    return 0;
                }
                return 1;

            }
            catch (Exception ex)
            {
                int result = 0;
                Debug.WriteLine(ex.Message);
                MessageBox.Show("Username or password is wrong! Check it again!!");
                return result;
            }
        }

        public static int checkUserType()
        {
            try
            {
                string query = @"Select Users_Type.userstype_name From Users INNER JOIN Users_Type ON Users.users_type = Users_Type.userstype_id Where users_id = @users_id";
                clsConnection.openConnection();
                SqlCommand com = new SqlCommand(query, clsConnection.con);
                SqlParameter p1 = new SqlParameter("@users_id", SqlDbType.NVarChar);
                p1.Value = userID.Trim();
                com.Parameters.Add(p1);
                user_type = com.ExecuteScalar().ToString();
                clsConnection.closeConnection();

                if (user_type == "Admin")
                {
                    return 1;
                }
                return 0;
            }
            catch (Exception ex)
            {
                int result = 0;
                MessageBox.Show(ex.Message);
                return result;
            }
        }

        public static string getUserName()
        {
            try
            {
                string user_name;
                string query = @"SELECT users_name FROM Users WHERE users_id = @users_id";
                clsConnection.openConnection();
                SqlCommand com = new SqlCommand(query, clsConnection.con);
                SqlParameter p1 = new SqlParameter("@users_id", SqlDbType.NVarChar);
                p1.Value = userID.Trim();
                com.Parameters.Add(p1);
                user_name = com.ExecuteScalar().ToString();
                clsConnection.closeConnection();
                return user_name;
            }
            catch (Exception ex)
            {
                string user_name = "";
                MessageBox.Show(ex.Message);
                return user_name;
            }
        }
    }
}
