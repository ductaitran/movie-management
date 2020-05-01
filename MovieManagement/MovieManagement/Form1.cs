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
                ClassCinemaBox.loadCinemaBoxTab(ref textBoxDate, ref comboBoxMovie, ref comboBoxTime, ref comboBoxCinemaBox, ref dataGridViewCinemaBox);
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
            ClassCinemaBox.loadDataGridViewCinemaBox(ref comboBoxMovie, ref comboBoxTime, ref comboBoxCinemaBox, ref dataGridViewCinemaBox);
        }

        private void comboBoxTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClassCinemaBox.loadComboBoxCinemaBox(ref comboBoxMovie, ref comboBoxTime, ref comboBoxCinemaBox);
            ClassCinemaBox.loadDataGridViewCinemaBox(ref comboBoxMovie, ref comboBoxTime, ref comboBoxCinemaBox, ref dataGridViewCinemaBox);
        }

 

        private void buttonRemoveUser_Click(object sender, EventArgs e)
        {
            ClassUser.deleteUser(ref dataGridViewUser);
            ClassUser.loadDataGridViewUser(ref dataGridViewUser);
            //dataGridViewUser.Update();
            //dataGridViewUser.Refresh();
        }

        private void buttonUpdateUser_Click(object sender, EventArgs e)
        {
            ClassUser.updateUserOnCLick(ref dataGridViewUser);
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
        }

        private void ButtonFormAddUser_Click(object sender, EventArgs e)
        {
            ClassUser.addUser(ref dataGridViewUser, ref TextBoxAddUserID, ref TextBoxAddUserName, ref TextBoxAddUserPassword, ref ComboBoxAddUserType);
            GroupBoxAddUser.Visible = false;
            ComboBoxAddUserType.SelectedIndex = -1;
            TextBoxAddUserID.Text = "";
            TextBoxAddUserName.Text = "";
            TextBoxAddUserPassword.Text = "";
            //dataGridViewUser.Controls.Clear();
            ClassUser.loadDataGridViewUser(ref dataGridViewUser);
            
        }

        private void comboBoxCinemaBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClassCinemaBox.loadDataGridViewCinemaBox(ref comboBoxMovie, ref comboBoxTime, ref comboBoxCinemaBox, ref dataGridViewCinemaBox);
        }

        private void dataGridViewCinemaBox_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewCinemaBox.CurrentRow != null)
            {
                ClassCinemaBox.editDataGridViewCinemaBoxStatus(ref dataGridViewCinemaBox, ref comboBoxMovie, ref comboBoxTime, ref comboBoxCinemaBox);
            }
        }
        private void btnSelectMovie_Click(object sender, EventArgs e)
        {
            ClassMovie.loadMoviePreview(ref ptbPreview, ref lblMovieName, ref txtMoviedesc, ref lblMovieLength, ref dataGridViewMovie);
        }


        private void btnRemoveMovie_Click(object sender, EventArgs e)
        {
            ClassMovie.deleteMovie(ref dataGridViewMovie);
        }

        private void btnUpdateMovie_Click(object sender, EventArgs e)
        {
            ClassMovie.updateCover(ref dataGridViewMovie, ref ptbPreview);
            ClassMovie.EditorAdd(ref dataGridViewMovie);
        }

        private void dataGridViewMovie_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            ClassMovie.EditorAdd(ref dataGridViewMovie);
        }

        private void ptbPreview_Click(object sender, EventArgs e)
        {
            ClassMovie.setCover(ref dataGridViewMovie, ref ptbPreview);
        }

        private void btnAddMoive_Click(object sender, EventArgs e)
        {
            ClassMovie.EditorAdd(ref dataGridViewMovie);
        }
    }
}
