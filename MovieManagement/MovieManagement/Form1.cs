using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        public Form1()
        {
            InitializeComponent();
            try
            {
                ClassCinemaBox.loadCinemaBoxTab(ref textBoxDate, ref comboBoxMovie, ref comboBoxTime, ref comboBoxCinemaBox, ref dataGridViewCinemaBox);
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

        private void comboBoxMovie_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClassCinemaBox.loadComboBoxTime(ref comboBoxMovie, ref comboBoxTime );
            ClassCinemaBox.loadDataGridViewCinemaBox(ref comboBoxMovie, ref comboBoxTime, ref comboBoxCinemaBox, ref dataGridViewCinemaBox);
        }

        private void comboBoxTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClassCinemaBox.loadComboBoxCinemaBox(ref comboBoxMovie, ref comboBoxTime, ref comboBoxCinemaBox);
            ClassCinemaBox.loadDataGridViewCinemaBox(ref comboBoxMovie, ref comboBoxTime, ref comboBoxCinemaBox, ref dataGridViewCinemaBox);
        }

        private void btnSelectMovie_Click(object sender, EventArgs e)
        {
            ClassMovie.loadMoviePreview(ref ptbPreview, ref lblMovieName, ref txtMoviedesc, ref lblMovieLength, ref dataGridViewMovie);
        }

        private void buttonRemoveUser_Click(object sender, EventArgs e)
        {
            ClassUser.DeleteUser(ref dataGridViewUser);
        }

        private void comboBoxCinemaBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClassCinemaBox.loadDataGridViewCinemaBox(ref comboBoxMovie, ref comboBoxTime, ref comboBoxCinemaBox, ref dataGridViewCinemaBox);
        }

        private void dataGridViewCinemaBox_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewCinemaBox.CurrentRow != null)
            {
                ClassCinemaBox.editDataGridViewCinemaBoxStatus(ref dataGridViewCinemaBox, ref comboBoxMovie, ref comboBoxTime, ref comboBoxCinemaBox);
            }
        }
    }
}
