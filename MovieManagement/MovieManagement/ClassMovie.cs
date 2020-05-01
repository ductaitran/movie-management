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
    class ClassMovie
    {
        public static void loadDataGridViewMovie(ref DataGridView dataGridViewMovie)
        {
            clsConnection.openConnection();
            string query = @"SELECT movie_name from Movie";
            SqlCommand cmd = new SqlCommand(query, clsConnection.con);
            cmd.ExecuteNonQuery();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "Movie Name");
            dataGridViewMovie.DataSource = ds.Tables["Movie Name"];
            clsConnection.closeConnection();
        }

        public static void loadMoviePreview(ref PictureBox ptbPreview, ref Label lblMovieName, ref TextBox txtMoviedesc, ref Label lblMovieLength, ref DataGridView dataGridViewMovie)
        {
            try
            {
                clsConnection.openConnection();
                string query = @"select movie_name, movie_cover, movie_length, movie_desc from Movie where movie_name ='" + Convert.ToString(dataGridViewMovie.SelectedCells[0].Value) + "'";
                SqlCommand cmd = new SqlCommand(query, clsConnection.con);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                da.Dispose();
                ptbPreview.Load((String)dt.Rows[0][1]);
                ptbPreview.SizeMode = PictureBoxSizeMode.StretchImage;
                lblMovieName.Text = (String)dt.Rows[0][0];
                txtMoviedesc.Text = (String)dt.Rows[0][3];
                lblMovieLength.Text = Convert.ToString(dt.Rows[0][2]);
                clsConnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
