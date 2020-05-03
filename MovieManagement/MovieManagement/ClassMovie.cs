using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace MovieManagement
{
    class ClassMovie
    {
        static string newPicturePath = null;
        static string picDestinationPath;
        public static void updateCover(ref DataGridView dataGridViewMovie, ref PictureBox ptbPreview)
        {
            int selectedrowindex = dataGridViewMovie.SelectedCells[0].RowIndex;
            try
            {
                if (newPicturePath != null)
                {
                    /*picDestinationPath = Path.Combine(@"../../../source/img/", Path.GetFileName(newPicturePath));*/
                    picDestinationPath = Path.GetFileName(newPicturePath);
                    File.Copy(newPicturePath, picDestinationPath, true);
                    string strUpdate = "UPDATE Movie set movie_cover ='" + picDestinationPath + "' where movie_id = '" + Convert.ToString(dataGridViewMovie.Rows[selectedrowindex].Cells[0].Value) + "'";
                    clsConnection.openConnection();
                    SqlCommand com = new SqlCommand(strUpdate, clsConnection.con);
                    com.ExecuteNonQuery();
                    clsConnection.closeConnection();
                    newPicturePath = null;
                    loadDataGridViewMovie(ref dataGridViewMovie);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void setCover(ref DataGridView dataGridViewMovie, ref PictureBox ptbPreview)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp;)|*.jpg; *.jpeg; *.gif; *.bmp;";
            if (open.ShowDialog() == DialogResult.OK)
            {
                newPicturePath = open.FileName;
                ptbPreview.Image = new Bitmap(open.FileName);
            }
        }
        public static void EditorAdd(ref PictureBox ptbPreview, ref Label lblMovieName, ref TextBox txtMoviedesc, ref Label lblMovieLength, ref DataGridView dataGridViewMovie)
        {
            if (dataGridViewMovie.CurrentRow != null)
            {
                clsConnection.openConnection();
                DataGridViewRow dgvr = dataGridViewMovie.CurrentRow;
                SqlCommand com = new SqlCommand("MovieAddorEdit", clsConnection.con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@movie_id", dgvr.Cells["movie_id"].Value.ToString());
                com.Parameters.AddWithValue("@movie_name", dgvr.Cells["movie_name"].Value == DBNull.Value ? "" : dgvr.Cells["movie_name"].Value.ToString());
                com.Parameters.AddWithValue("@movie_length", Convert.ToInt32(dgvr.Cells["movie_length"].Value == DBNull.Value ? "0" : dgvr.Cells["movie_length"].Value.ToString()));
                com.Parameters.AddWithValue("@movie_desc", dgvr.Cells["movie_desc"].Value == DBNull.Value ? "" : dgvr.Cells["movie_desc"].Value.ToString());
                com.ExecuteNonQuery();
                loadDataGridViewMovie(ref dataGridViewMovie);
                loadMoviePreview(ref ptbPreview, ref lblMovieName, ref txtMoviedesc, ref lblMovieLength, ref dataGridViewMovie);
                clsConnection.closeConnection();
            }
        }
        public static void deleteMovie(ref PictureBox ptbPreview, ref Label lblMovieName, ref TextBox txtMoviedesc, ref Label lblMovieLength, ref DataGridView dataGridViewMovie)
        {
            int selectedrowindex = dataGridViewMovie.SelectedCells[0].RowIndex;
            try
            {
                clsConnection.openConnection();
                string query = @"DELETE from Movie where movie_id = '" + Convert.ToString(dataGridViewMovie.Rows[selectedrowindex].Cells[0].Value) + "'";
                SqlCommand cmd = new SqlCommand(query, clsConnection.con);
                cmd.ExecuteNonQuery();
                loadDataGridViewMovie(ref dataGridViewMovie);
                clsConnection.closeConnection();
                loadMoviePreview(ref ptbPreview, ref lblMovieName, ref txtMoviedesc, ref lblMovieLength, ref dataGridViewMovie);
            }
            catch
            {
                MessageBox.Show("This movie is on the schedule!");
            }
        }
        public static void loadDataGridViewMovie(ref DataGridView dataGridViewMovie)
        {
            clsConnection.openConnection();
            string query = @"SELECT movie_id, movie_name, movie_length, movie_desc from Movie";
            SqlCommand cmd = new SqlCommand(query, clsConnection.con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridViewMovie.DataSource = dt;
            clsConnection.closeConnection();
        }

        public static void loadMoviePreview(ref PictureBox ptbPreview, ref Label lblMovieName, ref TextBox txtMoviedesc, ref Label lblMovieLength, ref DataGridView dataGridViewMovie)
        {
            int selectedrowindex = dataGridViewMovie.SelectedCells[0].RowIndex;
            try
            {
                clsConnection.openConnection();
                string query = @"select movie_name, movie_cover, movie_length, movie_desc from Movie where movie_id ='" + Convert.ToString(dataGridViewMovie.Rows[selectedrowindex].Cells[0].Value) + "'";
                SqlCommand cmd = new SqlCommand(query, clsConnection.con);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                da.Dispose();
                string path = "../../../source/img/" + (String)dt.Rows[0][1];
                /*ptbPreview.Load((String)dt.Rows[0][1]);*/
                ptbPreview.Load(path);
                ptbPreview.SizeMode = PictureBoxSizeMode.StretchImage;
                lblMovieName.Text = "Title: " + (String)dt.Rows[0][0];
                txtMoviedesc.Text = (String)dt.Rows[0][3];
                lblMovieLength.Text = "Duration: " + Convert.ToString(dt.Rows[0][2]) + " mins";
                clsConnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
