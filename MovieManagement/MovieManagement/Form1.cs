using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            try
            {
                ClassCinemaBox.loadCinemaBoxTab(ref textBoxDate, ref comboBoxMovie, ref comboBoxTime, ref comboBoxCinemaBox);
                ClassUser.loadDataGridViewUser(ref dataGridViewUser);
                ClassMovie.loadDataGridViewMovie(ref dataGridViewMovie);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBoxMovie_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClassCinemaBox.loadComboBoxTime(ref comboBoxMovie, ref comboBoxTime );
        }

        private void comboBoxTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClassCinemaBox.loadComboBoxCinemaBox(ref comboBoxMovie, ref comboBoxTime, ref comboBoxCinemaBox);
        }

        private void btnSelectMovie_Click(object sender, EventArgs e)
        {
            ClassMovie.loadMoviePreview(ref ptbPreview, ref lblMovieName, ref txtMoviedesc, ref lblMovieLength, ref dataGridViewMovie);
        }

        private void buttonRemoveUser_Click(object sender, EventArgs e)
        {
            ClassUser.deleteUser(ref dataGridViewUser);
            ClassUser.loadDataGridViewUser(ref dataGridViewUser);
        }

        private void buttonUpdateUser_Click(object sender, EventArgs e)
        {
            ClassUser.updateUser(ref dataGridViewUser, ref TextBoxAddUserID, ref TextBoxAddUserName, ref TextBoxAddUserPassword, ref ComboBoxAddUserType);
            GroupBoxAddUser.Visible = false;
            ComboBoxAddUserType.SelectedIndex = -1;
            TextBoxAddUserID.Text = "";
            TextBoxAddUserName.Text = "";
            TextBoxAddUserPassword.Text = "";
            buttonUpdateUser.Enabled = false;
            ClassUser.loadDataGridViewUser(ref dataGridViewUser);
        }

        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            ClassUser.loadAddUserForm(ref dataGridViewUser, ref ComboBoxAddUserType);
            GroupBoxAddUser.Visible = true;

        }

        private void ButtonFormCancelUser_Click(object sender, EventArgs e)
        {
            GroupBoxAddUser.Visible = false;
            ComboBoxAddUserType.SelectedIndex = -1;
            TextBoxAddUserID.Text = "";
            TextBoxAddUserName.Text = "";
            TextBoxAddUserPassword.Text = "";
            buttonUpdateUser.Enabled = false;
        }

        private void ButtonFormAddUser_Click(object sender, EventArgs e)
        {
            ClassUser.addUser(ref dataGridViewUser, ref TextBoxAddUserID, ref TextBoxAddUserName, ref TextBoxAddUserPassword, ref ComboBoxAddUserType);
            GroupBoxAddUser.Visible = false;
            ComboBoxAddUserType.SelectedIndex = -1;
            TextBoxAddUserID.Text = "";
            TextBoxAddUserName.Text = "";
            TextBoxAddUserPassword.Text = "";
            ClassUser.loadDataGridViewUser(ref dataGridViewUser);
            
        }

        private void dataGridViewUser_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            ClassUser.deleteUser(ref dataGridViewUser);
            ClassUser.loadDataGridViewUser(ref dataGridViewUser);
        }

        private void buttonEditUser_Click(object sender, EventArgs e)
        {
            ClassUser.loadEditUserForm(ref dataGridViewUser, ref TextBoxAddUserID, ref TextBoxAddUserName, ref ComboBoxAddUserType);
            ButtonFormAddUser.Visible = false;
            GroupBoxAddUser.Visible = true;
            buttonUpdateUser.Enabled = true;
        }
    }
}
