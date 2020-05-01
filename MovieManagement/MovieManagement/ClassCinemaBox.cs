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
        public static void loadCinemaBoxTab(ref TextBox textBoxDate, ref ComboBox comboBoxMovie, ref ComboBox comboBoxTime, ref ComboBox comboBoxCinemaBox)
        {
            loadOnSelectData(ref textBoxDate, ref comboBoxMovie, ref comboBoxTime, ref comboBoxCinemaBox);
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

        public static void loadDataGridViewCinemaBox()
        {
            try
            {
                clsConnection.openConnection();
                string query = @"select ";
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
    }
}
