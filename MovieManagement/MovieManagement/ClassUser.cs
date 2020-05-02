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

        public static void loadDataGridViewUser(ref DataGridView dataGridViewUser /*, ref DataGridViewComboBoxColumn ComboBoxAddUserType*/)
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

                /* clsConnection.openConnection();
                string query1 = @"SELECT * FROM Users_Type";
                SqlCommand cmd1 = new SqlCommand(query1, clsConnection.con);
                cmd1.ExecuteNonQuery();

                DataTable usersTypeTable = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd1);
                da.Fill(usersTypeTable);

                ComboBoxAddUserType.DataSource = usersTypeTable;
                ComboBoxAddUserType.ValueMember = "userstype_id";
                ComboBoxAddUserType.DisplayMember = "userstype_name";    

                /*foreach (DataGridViewRow item in dataGridViewUser.Rows)
                {
                    var cell = item.Cells[2] as Data;
                    cell. = listUsersTypeID[cell.RowIndex];
                } */

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
                DialogResult add = MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (add == DialogResult.Yes)
                {
                    string strInsert = "Insert Into Users Values(@users_id, @users_password, @users_name, @users_type)";
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

                    MessageBox.Show("User has been added!!");

                    clsConnection.closeConnection();
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
                string id = dataGridViewUser.SelectedCells[0].Value.ToString();
                TextBoxAddUserID.ReadOnly = true;
                TextBoxAddUserID.Text = id;
                TextBoxAddUserName.Text = dataGridViewUser.SelectedCells[1].Value.ToString();

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
                DialogResult update = MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (update == DialogResult.Yes)
                {
                    string id = TextBoxAddUserID.Text;
                    string newpassword = TextBoxAddUserPassword.Text;
                    string strInsert;

                    clsConnection.openConnection();

                    strInsert = @"UPDATE Users SET users_name = @users_name, users_type = @users_type WHERE users_id = @users_id";

                    SqlCommand com = new SqlCommand(strInsert, clsConnection.con);

                    if (newpassword != "")
                    {
                        strInsert = @"UPDATE Users SET users_password = @users_password, users_name = @users_name, users_type = @users_type WHERE users_id = @users_id";
                        com = new SqlCommand(strInsert, clsConnection.con);
                        SqlParameter p1 = new SqlParameter("@users_password", SqlDbType.NVarChar);
                        p1.Value = TextBoxAddUserPassword.Text;
                        com.Parameters.Add(p1);
                    }

                    SqlParameter p2 = new SqlParameter("@users_name", SqlDbType.NVarChar);
                    p2.Value = TextBoxAddUserName.Text;
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
