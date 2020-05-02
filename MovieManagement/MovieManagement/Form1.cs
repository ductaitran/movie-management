﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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
        private List<string> SlotnameList = new List<string>();
        private ClassCinemaBox CinemaBox;
        public Form1()
        {
            InitializeComponent();
            // create an new object of ClassCinemaBox, bind references
            CinemaBox = new ClassCinemaBox(dateTimePickerDate, comboBoxMovie, comboBoxTime, comboBoxCinemaBox, 
                dataGridViewCinemaBox, metroTabCinemaBox);
            try
            {
                CinemaBox.loadCinemaBoxTab();
                CinemaBox.changeSlotStateInPreview();
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

        // on Movie tab events
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

        private void btnSelectMovie_Click(object sender, EventArgs e)
        {
            ClassMovie.loadMoviePreview(ref ptbPreview, ref lblMovieName, ref txtMoviedesc, ref lblMovieLength, ref dataGridViewMovie);
        }


        // on Cinema Box tab events   
        private void dateTimePickerDate_ValueChanged(object sender, EventArgs e)
        {
            CinemaBox.loadComboBoxMovie();
            CinemaBox.loadDataGridViewCinemaBox();
        }

        private void comboBoxMovie_SelectedIndexChanged(object sender, EventArgs e)
        {
            CinemaBox.loadComboBoxTime();
            CinemaBox.loadDataGridViewCinemaBox();
        }

        private void comboBoxTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            CinemaBox.loadComboBoxCinemaBox();
            CinemaBox.loadDataGridViewCinemaBox();
        }

        private void comboBoxCinemaBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CinemaBox.loadDataGridViewCinemaBox();
        }

        private void dataGridViewCinemaBox_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridViewCinemaBox.CurrentRow != null)
                {
                    CinemaBox.editDataGridViewCinemaBoxStatus();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("on CellValueChanged event: " + ex.Message);
            }

        }

        private void btnUpdateBox_Click(object sender, EventArgs e)
        {
            CinemaBox.editDataGridViewCinemaBoxStatus();
        }

        private void buttonBoxSlot_click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.BackColor == Color.Red)
            {
                btn.BackColor = SystemColors.Control;
            }
            else
            {
                btn.BackColor = Color.Red;
            }

            // if slot is chosed, add slot name to List
            // if slot is unchosed, remove slot name from List
            if (btn.BackColor == Color.Red)
            {
                SlotnameList.Add(btn.Name);
            }
            if (btn.BackColor == SystemColors.Control)
            {
                SlotnameList.Remove(btn.Name);
            }
        }

        private void buttonOKCB_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("=======");
            foreach (string slotName in SlotnameList)
            {
                Debug.WriteLine(slotName);
                CinemaBox.updateStatusByPreview(slotName);
            }
            CinemaBox.loadDataGridViewCinemaBox();
        }


        // on User tab envents
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
