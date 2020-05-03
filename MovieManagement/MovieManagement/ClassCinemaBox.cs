using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieManagement
{    
    class ClassCinemaBox
    {
        private DateTimePicker dateTimePickerDate;
        private ComboBox comboBoxMovie;
        private ComboBox comboBoxTime;
        private ComboBox comboBoxCinemaBox;
        private DataGridView dataGridViewCinemaBox;
        private GroupBox groupBoxPreview;
        private Button btnUpdateBox;

        public ClassCinemaBox(DateTimePicker dateTimePickerDate, ComboBox comboBoxMovie, ComboBox comboBoxTime, ComboBox comboBoxCinemaBox,
            DataGridView dataGridViewCinemaBox, GroupBox groupBoxPreview, Button btnUpdateBox)
        {
            this.dateTimePickerDate = dateTimePickerDate;
            this.comboBoxMovie = comboBoxMovie;
            this.comboBoxTime = comboBoxTime;
            this.comboBoxCinemaBox = comboBoxCinemaBox;
            this.dataGridViewCinemaBox = dataGridViewCinemaBox;
            this.groupBoxPreview = groupBoxPreview;
            this.btnUpdateBox = btnUpdateBox;
        }

        public void loadCinemaBoxTab()
        {
            clearData();
            loadComboBoxMovie();
            loadDataGridViewCinemaBox();
            if (dataGridViewCinemaBox.DataSource != null)
            {
                groupBoxPreview.Visible = true;
                dataGridViewCinemaBox.Visible = true;
                btnUpdateBox.Visible = true;
            }
        }
       
        public void clearData()
        {
            // clear DataGridViewCinemaBox
            dataGridViewCinemaBox.DataSource = null;
            dataGridViewCinemaBox.AutoGenerateColumns = false;
            dataGridViewCinemaBox.Refresh();
            //dataGridViewCinemaBox.Rows.Clear();

            // hide DataGridViewCinemaBox
            dataGridViewCinemaBox.Visible = false;

            // hide btnUpdateBox
            btnUpdateBox.Visible = false;

            // clear ComboBox
            comboBoxMovie.DataSource = null;
            comboBoxTime.DataSource = null;
            comboBoxCinemaBox.DataSource = null;

            // hide Preview
            groupBoxPreview.Visible = false;
        }

        public void loadComboBoxMovie()
        {
            try
            {
                clsConnection.openConnection();
                string query = @"select distinct movie_name
                                  from Schedule join Movie on Schedule.movie_id = Movie.movie_id
                                  where schedule_date = @date";
                SqlCommand cmd = new SqlCommand(query, clsConnection.con);
                SqlParameter date = new SqlParameter("@date", SqlDbType.DateTime);
                date.Value = dateTimePickerDate.Value.ToString("yyyy/MM/dd");
                cmd.Parameters.Add(date);
                cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    comboBoxMovie.DataSource = dt;
                    comboBoxMovie.ValueMember = "movie_name";
                    comboBoxMovie.DisplayMember = "movie_name";
                }

                // load time
                loadComboBoxTime();
                // load cinema box
                loadComboBoxCinemaBox();
                clsConnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void loadComboBoxTime()
        {
            try
            {
                clsConnection.openConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"select distinct schedule_time from Schedule
                                     join Movie on Schedule.movie_id = Movie.movie_id
                                     where movie_name = @mv_name ";
                cmd.Connection = clsConnection.con;

                SqlParameter movie_name = new SqlParameter("@mv_name", SqlDbType.NVarChar);
                movie_name.Value = comboBoxMovie.SelectedValue.ToString();
                cmd.Parameters.Add(movie_name);
                cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    comboBoxTime.DataSource = dt;
                    comboBoxTime.ValueMember = "schedule_time";
                    comboBoxTime.DisplayMember = "schedule_time";
                }

                clsConnection.closeConnection();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }


        public void loadComboBoxCinemaBox()
        {
            try
            {
                clsConnection.openConnection();
                string query = @"select cinemabox_name from Schedule 
                                 join Cinema_Box on Schedule.cinemabox_id = Cinema_Box.cinemabox_id
                                 join Movie on Schedule.movie_id = Movie.movie_id
                                 where schedule_time = @time and movie_name = @mv_name";
                SqlCommand cmd = new SqlCommand(query, clsConnection.con);
                SqlParameter time = new SqlParameter("@time", SqlDbType.NVarChar);
                SqlParameter movie_name = new SqlParameter("@mv_name", SqlDbType.NVarChar);

                movie_name.Value = comboBoxMovie.SelectedValue.ToString();
                time.Value = comboBoxTime.SelectedValue.ToString();

                cmd.Parameters.Add(movie_name);
                cmd.Parameters.Add(time);
                cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    comboBoxCinemaBox.DataSource = dt;
                    comboBoxCinemaBox.ValueMember = "cinemabox_name";
                    comboBoxCinemaBox.DisplayMember = "cinemabox_name";
                }
                clsConnection.closeConnection();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        public void loadDataGridViewCinemaBox()
        {
            dataGridViewCinemaBox.Refresh();
            try
            {
                clsConnection.openConnection();
                string query = @"select boxstatus_id, Box_Status.boxslot_id as Slot_id, Box_Slot.boxslot_name as Slot_name, Box_Status.boxstatus_status as Status
                                 from Box_Status 
                                 join Schedule on Box_Status.schedule_id = Schedule.schedule_id
                                 join Box_Slot on Box_Status.boxslot_id = Box_Slot.boxslot_id
                                 join Movie on Schedule.movie_id = Movie.movie_id
                                 join Cinema_Box on Schedule.cinemabox_id = Cinema_box.cinemabox_id
                                 where movie_name = @movie_name and schedule_time = @time and cinemabox_name = @cinemabox_name
                                 order by Slot_name";
                SqlCommand cmd = new SqlCommand(query, clsConnection.con);

                SqlParameter movie_name = new SqlParameter("@movie_name", SqlDbType.NVarChar);
                movie_name.Value = comboBoxMovie.SelectedValue.ToString();
                SqlParameter time = new SqlParameter("@time", SqlDbType.NVarChar);
                time.Value = comboBoxTime.SelectedValue.ToString();
                SqlParameter box_name = new SqlParameter("@cinemabox_name", SqlDbType.NVarChar);
                box_name.Value = comboBoxCinemaBox.SelectedValue.ToString();

                cmd.Parameters.Add(movie_name);
                cmd.Parameters.Add(time);
                cmd.Parameters.Add(box_name);
                cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    dataGridViewCinemaBox.DataSource = dt;
                }

                // load Box slot Preview
                changeSlotStateInPreview();
                clsConnection.closeConnection();
            }
            catch
            {

            }
        }


        public void editDataGridViewCinemaBoxStatus()
        {
            try
            {
                clsConnection.openConnection();
                DataGridViewRow dataRow = dataGridViewCinemaBox.CurrentRow;
                string query = @"update Box_Status 
                                set boxstatus_status = @status
                                where boxstatus_id = @boxstatus_id";
                SqlCommand cmd = new SqlCommand(query, clsConnection.con);
                SqlParameter boxstatus_id = new SqlParameter("@boxstatus_id", SqlDbType.NVarChar);
                boxstatus_id.Value = dataRow.Cells["txtBoxSlotId"].Value;
                SqlParameter status = new SqlParameter("@status", SqlDbType.Bit);
                if (dataRow.Cells["chkStatus"].Value != DBNull.Value && Convert.ToBoolean(dataRow.Cells["chkStatus"].Value) == true)
                {
                    // MessageBox.Show("1");
                    status.Value = 1;
                }
                else
                {
                    //MessageBox.Show("0");
                    status.Value = 0;
                }
                cmd.Parameters.Add(status);
                cmd.Parameters.Add(boxstatus_id);
                cmd.ExecuteNonQuery();
                loadDataGridViewCinemaBox();

                clsConnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void changeSlotStateInPreview()
        {
            try
            {
                foreach (DataGridViewRow dataGrow in dataGridViewCinemaBox.Rows)
                {
                    string slotName = dataGrow.Cells["txtSlotName"].Value.ToString();
                    bool slotState = Convert.ToBoolean(dataGrow.Cells["chkStatus"].Value);
                    foreach (Control control in groupBoxPreview.Controls)
                    {
                        Button slotButton = control as Button;
                        if (slotButton != null && slotButton.Name == slotName)
                        {
                            if (slotState == true)
                            {
                                slotButton.BackColor = SystemColors.ControlDarkDark;
                                slotButton.Enabled = false;
                            }
                            else
                            {
                                slotButton.BackColor = Color.White;
                                slotButton.Enabled = true;
                            }
                        }
                    }
                }
            }
            catch
            {
                //MessageBox.Show("in SlotStateChange" + ex.Message);
            }
        }

        public void updateStatusByPreview(string slotName)
        {
            try
            {
                clsConnection.openConnection();
                string query = @"update Box_Status 
                                set boxstatus_status = @status
                                where boxstatus_id = @boxstatus_id";
                SqlCommand cmd = new SqlCommand(query, clsConnection.con);
                SqlParameter status = new SqlParameter("@status", SqlDbType.Bit);
                status.Value = 1;
                SqlParameter boxstatus_id = new SqlParameter("@boxstatus_id", SqlDbType.NVarChar);
                foreach (DataGridViewRow row in dataGridViewCinemaBox.Rows)
                {
                    if (row.Cells["txtSlotName"].Value.ToString() == slotName)
                    {
                        boxstatus_id.Value = row.Cells["txtBoxSlotId"].Value.ToString();
                        Debug.WriteLine("id: " + boxstatus_id.Value);
                        cmd.Parameters.Add(status);
                        cmd.Parameters.Add(boxstatus_id);
                        cmd.ExecuteNonQuery();
                    }
                }
                clsConnection.closeConnection();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("updateStatusByView: " + ex.Message);
            }
        }
    }
}
