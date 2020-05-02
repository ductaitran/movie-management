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
    static class ClassSchedule
    {
        //static MetroFramework.Controls.MetroTabPage ScheduleTab;
        
        static DataTable ScheduleSource;
        static DataTable dtCinemaBox;
        static DataTable dtMovie;
        public static DataTable GetSchedule(DateTime ShowDate)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Schedule ID", typeof(string));
            dt.Columns.Add("Cinema Box ID", typeof(string));
            dt.Columns.Add("Movie ID", typeof(string));
            dt.Columns.Add("Show Date", typeof(string));
            dt.Columns.Add("Show Time", typeof(string));
            string query = @"select s.schedule_id, s.cinemabox_id, m.movie_id, s.schedule_date, s.schedule_time from Schedule s
                                join Cinema_Box c on s.cinemabox_id = c.cinemabox_id
                                join Movie m on s.movie_id = m.movie_id
								where s.schedule_date = @schedule_date;";
            clsConnection.openConnection();
            SqlCommand command = new SqlCommand(query, clsConnection.con);
            command.Parameters.AddWithValue("@schedule_date", ShowDate.ToShortDateString());
            SqlDataReader reader = command.ExecuteReader();
            DataRow row;
            while (reader.Read())
            {
                row = dt.NewRow();
                row["Schedule ID"] = reader.GetString(0);
                row["Cinema Box ID"] = reader.GetString(1);
                row["Movie ID"] = reader.GetString(2);
                row["Show Date"] = reader.GetDateTime(3).ToShortDateString();
                row["Show Time"] = reader.GetString(4);
                dt.Rows.Add(row);
            }
            return dt;
        }
        public static void InitilizeDataGridView(ref DataGridView DataGridViewSchedule, DateTime ShowDate)
        {
            //lam sach du lieu cu
            DataGridViewSchedule.DataSource = null;
            DataGridViewSchedule.Rows.Clear();
            DataGridViewSchedule.Columns.Clear();
            //tao data source
            ScheduleSource = GetSchedule(ShowDate);
            dtCinemaBox = GetAllCinemaBox();
            dtMovie = GetAllMovie();
            
            //set up for comboboxcolumn
            DataGridViewComboBoxColumn ComboBoxColumnCinema = new DataGridViewComboBoxColumn();
            DataGridViewComboBoxColumn ComboBoxColumnMovie = new DataGridViewComboBoxColumn();
            ComboBoxColumnCinema.HeaderText = "Cinema Box";
            ComboBoxColumnMovie.HeaderText = "Movie";
            dtCinemaBox = GetAllCinemaBox();
            dtMovie = GetAllMovie();
            ComboBoxColumnCinema.ValueMember = "CINEMABOX_ID";
            ComboBoxColumnCinema.DisplayMember = "CINEMABOX_NAME";
            ComboBoxColumnCinema.FlatStyle = FlatStyle.Flat;
            ComboBoxColumnCinema.DataSource = dtCinemaBox;
            ComboBoxColumnMovie.ValueMember = "MOVIE_ID";
            ComboBoxColumnMovie.DisplayMember = "MOVIE_NAME";
            ComboBoxColumnMovie.FlatStyle = FlatStyle.Flat;
            ComboBoxColumnMovie.DataSource = dtMovie;
            
            DataGridViewSchedule.DataSource = new BindingSource(ScheduleSource, null);
            DataGridViewSchedule.Columns["Cinema Box ID"].Visible = false;
            DataGridViewSchedule.Columns["Movie ID"].Visible = false;
            DataGridViewSchedule.Columns.Insert(1, ComboBoxColumnCinema);//1 la cell cua comboBox cinema
            DataGridViewSchedule.Columns.Insert(2, ComboBoxColumnMovie);//1 la cell cua comboBox movie

            //set default value for combobox column
            foreach (DataGridViewRow DataGridViewRow in DataGridViewSchedule.Rows)
            {
                DataGridViewRow.Cells[1].Value = Convert.ToString(DataGridViewRow.Cells[3].Value);//3 cell chua id cinemabox
                DataGridViewRow.Cells[2].Value = Convert.ToString(DataGridViewRow.Cells[4].Value);//4 cell chua id cinemabox
            }
            //DataGridViewSchedule.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            /*
            DataGridViewSchedule.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DataGridViewSchedule.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DataGridViewSchedule.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            DataGridViewSchedule.Columns[3].Width = 150;
            DataGridViewSchedule.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            DataGridViewSchedule.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DataGridViewSchedule.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            */
            //DataGridViewSchedule.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //DataGridViewSchedule.AlternatingRowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;

        }
        
        //button update
        public static bool SaveData(ref DataGridView DataGridViewSchedule)
        {
            ScheduleSource.AcceptChanges();
            
            foreach (DataGridViewRow DataGridViewRow in DataGridViewSchedule.Rows)
            {
                
                //DataGridViewRow.Cells[1].Value = Convert.ToString(DataGridViewRow.Cells[2].Value);
                Debug.WriteLine("0: "+Convert.ToString(DataGridViewRow.Cells[0].Value)+"1: "+ Convert.ToString(DataGridViewRow.Cells[1].Value) + "2: " + Convert.ToString(DataGridViewRow.Cells[2].Value) + "3: " + Convert.ToString(DataGridViewRow.Cells[3].Value) + "4: " + Convert.ToString(DataGridViewRow.Cells[4].Value) + "5: " + Convert.ToString(DataGridViewRow.Cells[5].Value));
            }
            return true;
        }
        public static bool RemoveData(ref DataGridView DataGridViewSchedule)
        {
            clsConnection.openConnection();
            try
            {
                if (DataGridViewSchedule.CurrentRow.Selected != false)
                    foreach (DataGridViewRow row in DataGridViewSchedule.SelectedRows)
                    {
                        string schedule_id = Convert.ToString(row.Cells[0].Value);
                        SqlCommand command;
                        try
                        {
                            command = new SqlCommand("DELETE FROM box_status WHERE schedule_id=@schedule_id", clsConnection.con);
                            command.Parameters.AddWithValue("@schedule_id", schedule_id);
                            command.ExecuteNonQuery();
                            command.Dispose();
                            try
                            {
                                string query = @"DELETE FROM schedule WHERE schedule_id=@schedule_id";
                                command = new SqlCommand(query, clsConnection.con);
                                command.Parameters.AddWithValue("@schedule_id", schedule_id);
                                command.ExecuteNonQuery();
                                command.Dispose();
                            }
                            catch (Exception err)
                            {
                                Debug.WriteLine("delete schedule fail: " + err.Message);
                                clsConnection.closeConnection();
                                return false;
                            }
                        }
                        catch (Exception err)
                        {
                            Debug.WriteLine("delete boxstatus fail: " + err.Message);
                            return false;
                        }
                    }
                return true;
            }
            catch(Exception err)
            {
                clsConnection.closeConnection();
                return false;
            }
        }
        public static bool UpdateData(ref DataGridView DataGridViewSchedule, DateTime ShowDate)
        {
            DataGridViewSchedule.Controls.Clear();
            InitilizeDataGridView(ref  DataGridViewSchedule, ShowDate);
            return true;
        }
        public static string GetCinemaBoxID(string cinemabox_name)
        {
            clsConnection.openConnection();
            SqlCommand command = new SqlCommand("Select cinemabox_id from cinema_box where cinemabox_name = @cinemabox_name", clsConnection.con);
            command.Parameters.AddWithValue("@cinemabox_name", cinemabox_name);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            string cinemabox_id = reader.GetString(0);
            reader.Close();
            clsConnection.closeConnection();
            return cinemabox_id;
        }
        public static string GetMovieID(string movie_name)
        {
            clsConnection.openConnection();
            SqlCommand command = new SqlCommand("Select movie_id from movie where movie_name = @movie_name", clsConnection.con);
            command.Parameters.AddWithValue("@movie_name", movie_name);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            string movie_id = reader.GetString(0);
            reader.Close();
            clsConnection.closeConnection();
            return movie_id;
        }
        private static DataTable GetAllCinemaBox()
        {
            clsConnection.openConnection();
            DataTable dt = new DataTable();
            SqlCommand command = new SqlCommand("Select cinemabox_id, cinemabox_name from cinema_box", clsConnection.con);
            SqlDataReader reader = command.ExecuteReader();
            dt.Columns.Add("CINEMABOX_ID");
            dt.Columns.Add("CINEMABOX_NAME");
            while (reader.Read())
            {
                DataRow dr = dt.NewRow();
                dr["CINEMABOX_ID"] = reader.GetString(0);
                dr["CINEMABOX_NAME"] = reader.GetString(1);
                dt.Rows.Add(dr);
            }
            reader.Close();
            clsConnection.closeConnection();
            return dt;
        }
        private static DataTable GetAllMovie()
        {
            clsConnection.openConnection();
            DataTable dt = new DataTable();
            SqlCommand command = new SqlCommand("Select movie_id, movie_name from movie", clsConnection.con);
            SqlDataReader reader = command.ExecuteReader();
            dt.Columns.Add("MOVIE_ID");
            dt.Columns.Add("MOVIE_NAME");
            while (reader.Read())
            {
                DataRow dr = dt.NewRow();
                dr["MOVIE_ID"] = reader.GetString(0);
                dr["MOVIE_NAME"] = reader.GetString(1);
                dt.Rows.Add(dr);
            }
            reader.Close();
            clsConnection.closeConnection();
            return dt;
        }
        public static bool InsertData(string cinemabox_id, string movie_id, DateTime schedule_date, string schedule_time, string schedule_id)
        {
            int result;
            try
            {
                clsConnection.openConnection();
                SqlCommand command = new SqlCommand("INSERT INTO schedule values(@schedule_id,@cinemabox_id,@movie_id,@schedule_date,@schedule_time);", clsConnection.con);
                command.Parameters.AddWithValue("@cinemabox_id", cinemabox_id);
                command.Parameters.AddWithValue("@movie_id", movie_id);
                command.Parameters.AddWithValue("@schedule_date", schedule_date);
                command.Parameters.AddWithValue("@schedule_time", schedule_time);
                command.Parameters.AddWithValue("@schedule_id", schedule_id);
                result = command.ExecuteNonQuery();
            }
            catch(Exception err)
            {
                Debug.WriteLine("Insert failed: " + err.Message);
                clsConnection.closeConnection();
                return false;
            }
            clsConnection.closeConnection();
            return true;
        }
    }
}
