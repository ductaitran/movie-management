using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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
                loadCinemaBoxTab();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void loadCinemaBoxTab()
        {
            loadOnSelectData();
        }

        void loadComboBoxMovie()
        {
            try
            {
                clsConnection.openConnection();
                string query = @"select distinct movie_name
                                  from Schedule join Movie on Schedule.movie_id = Movie.movie_id ";
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

        void loadComboBoxTime()
        {
            try
            {
                clsConnection.openConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"select distinct time from Schedule
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
                    comboBoxTime.ValueMember = "time";
                    comboBoxTime.DisplayMember = "time";
                }

                clsConnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void loadComboBoxCinemaBox()
        {
            try
            {
                clsConnection.openConnection();
                string query = @"select cinemabox_name from Schedule 
                                join Cinema_Box on Schedule.cinema_box_id = Cinema_Box.cinemabox_id
                                join Movie on Schedule.movie_id = Movie.movie_id
                                where time = @time and movie_name = @mv_name";
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

        // load data to combo box in the Cinema Box tab
        void loadOnSelectData ()
        {
            // set Date value
            textBoxDate.Text = "2020-04-30";

            try
            {
                loadComboBoxMovie();
                /*loadComboBoxTime();
                loadComboBoxCinemaBox();*/
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
            loadComboBoxTime();
        }

        private void comboBoxTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadComboBoxCinemaBox();
        }
    }
}
