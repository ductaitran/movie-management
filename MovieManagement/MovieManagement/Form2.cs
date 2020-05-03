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
    }
}
