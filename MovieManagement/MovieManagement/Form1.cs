using System;
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
				LoadScheduleTab();

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
        private void LoadScheduleTab()
        {
            ClassSchedule.InitilizeDataGridView(ref dataGridViewSchedule, monthCalendar1.SelectionRange.Start);
            dataGridViewSchedule.CellValueChanged += new DataGridViewCellEventHandler(dataGridViewSchedule_CellValueChanged);
            buttonSaveSchedule.Enabled = false;
        }

        private void dataGridViewSchedule_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            buttonSaveSchedule.Enabled = true;
        }

        private void buttonUpdateSchedule_Click(object sender, EventArgs e)
        {
            if (ClassSchedule.UpdateData(ref dataGridViewSchedule, monthCalendar1.SelectionRange.Start))
            {
                Debug.WriteLine("Updated");
                buttonSaveSchedule.Enabled = false;
            }
            else Debug.WriteLine("Update Fail");
        }

        private void buttonRemoveSchedule_Click(object sender, EventArgs e)
        {
            if (ClassSchedule.RemoveData(ref dataGridViewSchedule))
            {
                Debug.WriteLine("Removed");
                buttonSaveSchedule.Enabled = false;
                buttonUpdateSchedule.PerformClick();
            }
            else
            {
                MessageBox.Show("Select a valid row and try again");
                Debug.WriteLine("Remove Fail");
            }
        }

        private void buttonSaveSchedule_Click(object sender, EventArgs e)
        {
            buttonSaveSchedule.Enabled = false;
            int result;
            foreach (DataGridViewRow DataGridViewRow in dataGridViewSchedule.Rows)
            {
                try
                {
                    if (Convert.ToString(DataGridViewRow.Cells[1].Value) != "")// du lieu rong la hang cuoi cung datagridview tu tao
                    {
                        Debug.WriteLine("cinema box after update: " + Convert.ToString(DataGridViewRow.Cells[1].Value));
                        Debug.WriteLine("0: " + Convert.ToString(DataGridViewRow.Cells[0].Value) + " 1: " + Convert.ToString(DataGridViewRow.Cells[1].Value) + " 2: " + Convert.ToString(DataGridViewRow.Cells[2].Value) + " 3: " + Convert.ToString(DataGridViewRow.Cells[3].Value) + " 4: " + Convert.ToString(DataGridViewRow.Cells[4].Value) + " 5: " + Convert.ToString(DataGridViewRow.Cells[5].Value));
                        Debug.WriteLine("inserting...");
                        string query = @"UPDATE Schedule SET 
                                cinemabox_id = @cinemabox_id,
                                movie_id = @movie_id,
                                schedule_date = @schedule_date,
                                schedule_time = @schedule_time
                                WHERE schedule_id = @schedule_id";
                        clsConnection.openConnection();
                        SqlCommand command = new SqlCommand(query, clsConnection.con);
                        Debug.WriteLine("0: " + Convert.ToString(DataGridViewRow.Cells[0].Value) + " 1: " + Convert.ToString(DataGridViewRow.Cells[1].Value) + " 2: " + Convert.ToString(DataGridViewRow.Cells[2].Value) + " 5: " + Convert.ToString(DataGridViewRow.Cells[5].Value) + " 6: " + Convert.ToString(DataGridViewRow.Cells[6].Value));
                        command.Parameters.AddWithValue("@cinemabox_id", Convert.ToString(DataGridViewRow.Cells[1].Value));
                        command.Parameters.AddWithValue("@movie_id", Convert.ToString(DataGridViewRow.Cells[2].Value));
                        command.Parameters.AddWithValue("@schedule_date", Convert.ToDateTime(DataGridViewRow.Cells[5].Value));
                        command.Parameters.AddWithValue("@schedule_time", Convert.ToString(DataGridViewRow.Cells[6].Value));
                        command.Parameters.AddWithValue("@schedule_id", Convert.ToString(DataGridViewRow.Cells[0].Value));
                        result = command.ExecuteNonQuery();
                        Debug.WriteLine("Result: " + result);
                        if (result == 0)
                        {
                            if (!ClassSchedule.InsertData(Convert.ToString(DataGridViewRow.Cells[1].Value),
                                Convert.ToString(DataGridViewRow.Cells[2].Value),
                                Convert.ToDateTime(DataGridViewRow.Cells[5].Value),
                                Convert.ToString(DataGridViewRow.Cells[6].Value),
                                Convert.ToString(DataGridViewRow.Cells[0].Value)
                                ))
                            {
                                MessageBox.Show("Insert fail, please check again!");
                            }
                        }
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show("Input is invalid: " + err.Message);
                    clsConnection.closeConnection();
                }
            }
            buttonUpdateSchedule.PerformClick();
            clsConnection.closeConnection();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            dateTimePickerSchedule.Value = monthCalendar1.SelectionRange.Start;
            LoadScheduleTab();
        }

        private void dataGridViewSchedule_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridViewSchedule.CurrentCell.ColumnIndex == 1 || dataGridViewSchedule.CurrentCell.ColumnIndex == 3 && e.Control is ComboBox)
            {
                ComboBox comboBox = e.Control as ComboBox;
                if (comboBox != null)
                {
                    comboBox.SelectedIndexChanged -= new EventHandler(comboBox_SeletedIndexChanged);
                    comboBox.SelectedIndexChanged += new EventHandler(comboBox_SeletedIndexChanged);
                }
            }
        }
        private void comboBox_SeletedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            buttonSaveSchedule.Enabled = true;
        }

        private void buttonSaveSchedule_EnabledChanged(object sender, EventArgs e)
        {
            if (((Button)sender).Enabled)
            {
                buttonSaveSchedule.BackColor = Color.CornflowerBlue;
                buttonSaveSchedule.ForeColor = Color.White;
            }
            else
            {
                buttonSaveSchedule.BackColor = Color.Transparent;
                buttonSaveSchedule.ForeColor = Color.CornflowerBlue;
            }
        }
    }
}
