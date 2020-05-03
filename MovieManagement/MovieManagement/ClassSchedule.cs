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
    public class ClassSchedule
    {
        //static MetroFramework.Controls.MetroTabPage ScheduleTab;
        private DataGridView DataGridViewSchedule;
        private Button ButtonSaveSchedule;
        private Button ButtonUpdateSchedule;
        private Button ButtonRemoveSchedule;
        private MonthCalendar MonthCalendarSchedule;

        static DataTable ScheduleSource;
        static DataTable dtCinemaBox;
        static DataTable dtMovie;
        public ClassSchedule( DataGridView DataGridViewSchedule,
            Button ButtonSaveSchedule,Button ButtonUpdateSchedule,
            Button ButtonRemoveSchedule,MonthCalendar MonthCalendarSchedule)
        {
            this.DataGridViewSchedule = DataGridViewSchedule;
            this.ButtonSaveSchedule = ButtonSaveSchedule;
            this.ButtonUpdateSchedule = ButtonUpdateSchedule;
            this.ButtonRemoveSchedule = ButtonRemoveSchedule;
            this.MonthCalendarSchedule = MonthCalendarSchedule;
        }
        public void LoadScheduleTab()
        {
            InitilizeDataGridView(MonthCalendarSchedule.SelectionRange.Start);
            DataGridViewSchedule.CellValueChanged += new DataGridViewCellEventHandler(DataGridViewSchedule_CellValueChanged);
            ButtonSaveSchedule.Enabled = false;
        }
        private void DataGridViewSchedule_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Debug.WriteLine("khoi dong tu class");
            ButtonSaveSchedule.Enabled = true;
        }
        public DataTable GetSchedule(DateTime ShowDate)
        {
            DataTable dt = new DataTable();
            
            dt.Columns.Add("Schedule ID", typeof(Int32));
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
                row["Schedule ID"] = reader.GetInt32(0);
                row["Cinema Box ID"] = reader.GetString(1);
                row["Movie ID"] = reader.GetString(2);
                row["Show Date"] = reader.GetDateTime(3).ToShortDateString();
                row["Show Time"] = reader.GetString(4);
                dt.Rows.Add(row);
            }
            dt.Columns[0].ReadOnly = true;
            return dt;
        }
        public void InitilizeDataGridView(DateTime ShowDate)
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

        }
        
        
        public bool RemoveData()
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
        public bool UpdateData(DateTime ShowDate)
        {
            DataGridViewSchedule.Controls.Clear();
            InitilizeDataGridView(ShowDate);
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
        public bool SaveData()
        {
            int result;
            foreach (DataGridViewRow DataGridViewRow in DataGridViewSchedule.Rows)
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
                                return false;
                            }
                        }
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show("Input is invalid: " + err.Message);
                    clsConnection.closeConnection();
                    return false;
                }
            }
            
            ButtonUpdateSchedule.PerformClick();
            clsConnection.closeConnection();
            return true;
        }
        public static bool InsertData(string cinemabox_id, string movie_id, DateTime schedule_date, string schedule_time, string schedule_id)
        {
            int result;
            try
            {
                clsConnection.openConnection();
                SqlCommand command = new SqlCommand("INSERT INTO schedule values(@cinemabox_id,@movie_id,@schedule_date,@schedule_time);", clsConnection.con);
                command.Parameters.AddWithValue("@cinemabox_id", cinemabox_id);
                command.Parameters.AddWithValue("@movie_id", movie_id);
                command.Parameters.AddWithValue("@schedule_date", schedule_date);
                command.Parameters.AddWithValue("@schedule_time", schedule_time);
                /*command.Parameters.AddWithValue("@schedule_id", schedule_id);*/
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
