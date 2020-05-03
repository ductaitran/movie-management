namespace MovieManagement
{
    partial class FormLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxUserPassword = new System.Windows.Forms.TextBox();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(110, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 32);
            this.label1.TabIndex = 11;
            this.label1.Text = "Log in";
            // 
            // textBoxUserPassword
            // 
            this.textBoxUserPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxUserPassword.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.textBoxUserPassword.Location = new System.Drawing.Point(105, 155);
            this.textBoxUserPassword.Name = "textBoxUserPassword";
            this.textBoxUserPassword.Size = new System.Drawing.Size(161, 16);
            this.textBoxUserPassword.TabIndex = 2;
            this.textBoxUserPassword.TabStop = false;
            this.textBoxUserPassword.Text = "Password";
            this.textBoxUserPassword.Click += new System.EventHandler(this.textBoxUserPassword_Click);
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxUserName.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.textBoxUserName.Location = new System.Drawing.Point(105, 108);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(161, 16);
            this.textBoxUserName.TabIndex = 1;
            this.textBoxUserName.TabStop = false;
            this.textBoxUserName.Text = "User ID";
            this.textBoxUserName.Click += new System.EventHandler(this.textBoxUserName_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(105, 177);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(160, 2);
            this.panel2.TabIndex = 16;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(104, 130);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(160, 2);
            this.panel1.TabIndex = 17;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(54, 151);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(43, 33);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(54, 102);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(43, 34);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 14;
            this.pictureBox3.TabStop = false;
            // 
            // buttonLogin
            // 
            this.buttonLogin.BackColor = System.Drawing.Color.White;
            this.buttonLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLogin.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonLogin.FlatAppearance.BorderSize = 2;
            this.buttonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogin.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogin.Location = new System.Drawing.Point(52, 230);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(212, 31);
            this.buttonLogin.TabIndex = 3;
            this.buttonLogin.Text = "Sign in";
            this.buttonLogin.UseVisualStyleBackColor = false;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.Location = new System.Drawing.Point(287, -1);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(29, 30);
            this.btnExit.TabIndex = 19;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            this.btnExit.MouseEnter += new System.EventHandler(this.btnExit_MouseEnter);
            this.btnExit.MouseLeave += new System.EventHandler(this.btnExit_MouseLeave);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(316, 294);
            this.ControlBox = false;
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.textBoxUserPassword);
            this.Controls.Add(this.textBoxUserName);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form2_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxUserPassword;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Button btnExit;
    }
}