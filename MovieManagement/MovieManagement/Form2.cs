using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieManagement
{
    public partial class FormLogin : Form
    {

        public FormLogin()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                int exist = ClassUser.userLogin(ref textBoxUserName, ref textBoxUserPassword);

                if (exist == 1)
                {
                    this.Visible = false;
                    Form1 mainForm = new Form1();
                    mainForm.ShowDialog();
                    if (mainForm.IsDisposed)
                    {
                        textBoxUserName.Text = "";
                        textBoxUserPassword.Text = "";
                        this.Visible = true;
                    }
                }
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

        // styling
        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
            btnExit.BackColor = Color.FromArgb(234, 32, 39);
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            btnExit.BackColor = this.BackColor;
        }

        //make form movable
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form2_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void textBoxUserName_Click(object sender, EventArgs e)
        {
            textBoxUserName.Clear();
        }

        private void textBoxUserPassword_Click(object sender, EventArgs e)
        {
            textBoxUserPassword.Clear();
            textBoxUserPassword.PasswordChar = '*';
        }
    }
}
