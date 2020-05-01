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
    class ClassCinemaBox
    {
        public static void loadCinemaBoxTab(ref TextBox textBoxDate, ref ComboBox comboBoxMovie, ref ComboBox comboBoxTime, ref ComboBox comboBoxCinemaBox, ref DataGridView dataGridViewCinemaBox)
        {
            loadOnSelectData(ref textBoxDate, ref comboBoxMovie, ref comboBoxTime, ref comboBoxCinemaBox);
            loadDataGridViewCinemaBox(ref comboBoxMovie, ref comboBoxTime, ref comboBoxCinemaBox, ref dataGridViewCinemaBox);
        }

        public static void loadComboBoxMovie(ref ComboBox comboBoxMovie, ref ComboBox comboBoxTime, ref ComboBox comboBoxCinemaBox)
        {
            try
            {
                clsConnection.openConnection();
                string query = @"select distinct movie_name
                                  from Schedule join Movie on Schedule.movie_id = Movie.movie_id";
                SqlCommand cmd = new SqlCommand(query, clsConnection.con);
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
                loadComboBoxTime(ref comboBoxMovie, ref comboBoxTime);
                // load cinema box
                loadComboBoxCinemaBox(ref comboBoxMovie, ref comboBoxTime, ref comboBoxCinemaBox);
                clsConnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void loadComboBoxTime(ref ComboBox comboBoxMovie, ref ComboBox comboBoxTime)
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
                MessageBox.Show(ex.Message);
            }
        }

        public static void loadComboBoxCinemaBox(ref ComboBox comboBoxMovie, ref ComboBox comboBoxTime, ref ComboBox comboBoxCinemaBox)
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
                MessageBox.Show(ex.Message);
            }
        }

        public static void loadDataGridViewCinemaBox(ref ComboBox comboBoxMovie, ref ComboBox comboBoxTime, ref ComboBox comboBoxCinemaBox, ref DataGridView dataGridViewCinemaBox)
        {
            try
            {
                clsConnection.openConnection();
                string query = @"select boxstatus_id, Box_Status.boxslot_id as Slot_id, Box_Slot.boxslot_name as Slot_name, Box_Status.boxstatus_status as Status
                                 from Box_Status 
                                 join Schedule on Box_Status.schedule_id = Schedule.schedule_id
                                 join Box_Slot on Box_Status.boxslot_id = Box_Slot.boxslot_id
                                 join Movie on Schedule.movie_id = Movie.movie_id
                                 join Cinema_Box on Schedule.cinemabox_id = Cinema_box.cinemabox_id
                                 where movie_name = @movie_name and schedule_time = @time and cinemabox_name = @cinemabox_name";
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
                
                if (dt.Rows.Count > 0 )
                {
                    dataGridViewCinemaBox.DataSource = dt;
                }                

                clsConnection.closeConnection();
            }
            catch
            {

            }
        }

        // load data to combo box in the Cinema Box tab
        public static void loadOnSelectData(ref TextBox textBoxDate, ref ComboBox comboBoxMovie, ref ComboBox comboBoxTime, ref ComboBox comboBoxCinemaBox)
        {
            // set Date value
            textBoxDate.Text = "2020-04-30";

            try
            {
                loadComboBoxMovie(ref comboBoxMovie, ref comboBoxTime, ref comboBoxCinemaBox);
                /*loadComboBoxTime();
                loadComboBoxCinemaBox();*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void editDataGridViewCinemaBoxStatus(ref DataGridView dataGridViewCinemaBox, ref ComboBox comboBoxMovie, 
            ref ComboBox comboBoxTime, ref ComboBox comboBoxCinemaBox)
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
                    MessageBox.Show("1");
                    status.Value = 1;
                }
                else
                {
                    MessageBox.Show("0");
                    status.Value = 0;
                }
                cmd.Parameters.Add(status);
                cmd.Parameters.Add(boxstatus_id);
                cmd.ExecuteNonQuery();
                loadDataGridViewCinemaBox(ref comboBoxMovie, ref comboBoxTime, ref comboBoxCinemaBox, ref dataGridViewCinemaBox);
                
                clsConnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
