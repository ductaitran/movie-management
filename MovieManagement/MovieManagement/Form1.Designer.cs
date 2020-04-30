namespace MovieManagement
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.lblMoviePrice = new System.Windows.Forms.Label();
            this.lblMovieLength = new System.Windows.Forms.Label();
            this.lblMovieDescription = new System.Windows.Forms.Label();
            this.lblMovieName = new System.Windows.Forms.Label();
            this.ptbPreview = new System.Windows.Forms.PictureBox();
            this.btnRemoveMovie = new System.Windows.Forms.Button();
            this.btnUpdateMovie = new System.Windows.Forms.Button();
            this.btnAddMoive = new System.Windows.Forms.Button();
            this.btnSelectMovie = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button24 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button23 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button22 = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnUpdateBox = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.metroTabPage3 = new MetroFramework.Controls.MetroTabPage();
            this.button25 = new System.Windows.Forms.Button();
            this.button26 = new System.Windows.Forms.Button();
            this.button27 = new System.Windows.Forms.Button();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.metroTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.metroTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1040, 47);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(1, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "ONLINE BOOKING";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.DimGray;
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(992, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(48, 47);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.metroTabPage1);
            this.metroTabControl1.Controls.Add(this.metroTabPage2);
            this.metroTabControl1.Controls.Add(this.metroTabPage3);
            this.metroTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabControl1.Location = new System.Drawing.Point(0, 47);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(1040, 465);
            this.metroTabControl1.TabIndex = 1;
            this.metroTabControl1.UseSelectable = true;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.Controls.Add(this.lblMoviePrice);
            this.metroTabPage1.Controls.Add(this.lblMovieLength);
            this.metroTabPage1.Controls.Add(this.lblMovieDescription);
            this.metroTabPage1.Controls.Add(this.lblMovieName);
            this.metroTabPage1.Controls.Add(this.ptbPreview);
            this.metroTabPage1.Controls.Add(this.btnRemoveMovie);
            this.metroTabPage1.Controls.Add(this.btnUpdateMovie);
            this.metroTabPage1.Controls.Add(this.btnAddMoive);
            this.metroTabPage1.Controls.Add(this.btnSelectMovie);
            this.metroTabPage1.Controls.Add(this.dataGridView1);
            this.metroTabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 10;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(1032, 423);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "Movie";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 10;
            // 
            // lblMoviePrice
            // 
            this.lblMoviePrice.AutoSize = true;
            this.lblMoviePrice.Location = new System.Drawing.Point(865, 255);
            this.lblMoviePrice.Name = "lblMoviePrice";
            this.lblMoviePrice.Size = new System.Drawing.Size(63, 15);
            this.lblMoviePrice.TabIndex = 7;
            this.lblMoviePrice.Text = "Price here";
            // 
            // lblMovieLength
            // 
            this.lblMovieLength.AutoSize = true;
            this.lblMovieLength.Location = new System.Drawing.Point(865, 179);
            this.lblMovieLength.Name = "lblMovieLength";
            this.lblMovieLength.Size = new System.Drawing.Size(105, 15);
            this.lblMovieLength.TabIndex = 7;
            this.lblMovieLength.Text = "Movie length here";
            // 
            // lblMovieDescription
            // 
            this.lblMovieDescription.AutoSize = true;
            this.lblMovieDescription.Location = new System.Drawing.Point(865, 74);
            this.lblMovieDescription.Name = "lblMovieDescription";
            this.lblMovieDescription.Size = new System.Drawing.Size(97, 15);
            this.lblMovieDescription.TabIndex = 7;
            this.lblMovieDescription.Text = "Description here";
            // 
            // lblMovieName
            // 
            this.lblMovieName.AutoSize = true;
            this.lblMovieName.Location = new System.Drawing.Point(865, 24);
            this.lblMovieName.Name = "lblMovieName";
            this.lblMovieName.Size = new System.Drawing.Size(106, 15);
            this.lblMovieName.TabIndex = 6;
            this.lblMovieName.Text = "Movie name here!";
            // 
            // ptbPreview
            // 
            this.ptbPreview.Location = new System.Drawing.Point(641, 24);
            this.ptbPreview.Name = "ptbPreview";
            this.ptbPreview.Size = new System.Drawing.Size(160, 246);
            this.ptbPreview.TabIndex = 4;
            this.ptbPreview.TabStop = false;
            // 
            // btnRemoveMovie
            // 
            this.btnRemoveMovie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveMovie.Location = new System.Drawing.Point(480, 289);
            this.btnRemoveMovie.Name = "btnRemoveMovie";
            this.btnRemoveMovie.Size = new System.Drawing.Size(86, 33);
            this.btnRemoveMovie.TabIndex = 3;
            this.btnRemoveMovie.Text = "Remove";
            this.btnRemoveMovie.UseVisualStyleBackColor = true;
            // 
            // btnUpdateMovie
            // 
            this.btnUpdateMovie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateMovie.Location = new System.Drawing.Point(380, 289);
            this.btnUpdateMovie.Name = "btnUpdateMovie";
            this.btnUpdateMovie.Size = new System.Drawing.Size(86, 33);
            this.btnUpdateMovie.TabIndex = 3;
            this.btnUpdateMovie.Text = "Update";
            this.btnUpdateMovie.UseVisualStyleBackColor = true;
            // 
            // btnAddMoive
            // 
            this.btnAddMoive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddMoive.Location = new System.Drawing.Point(279, 289);
            this.btnAddMoive.Name = "btnAddMoive";
            this.btnAddMoive.Size = new System.Drawing.Size(86, 33);
            this.btnAddMoive.TabIndex = 3;
            this.btnAddMoive.Text = "Add";
            this.btnAddMoive.UseVisualStyleBackColor = true;
            // 
            // btnSelectMovie
            // 
            this.btnSelectMovie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectMovie.Location = new System.Drawing.Point(12, 289);
            this.btnSelectMovie.Name = "btnSelectMovie";
            this.btnSelectMovie.Size = new System.Drawing.Size(86, 33);
            this.btnSelectMovie.TabIndex = 3;
            this.btnSelectMovie.Text = "Select";
            this.btnSelectMovie.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(554, 246);
            this.dataGridView1.TabIndex = 2;
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.Controls.Add(this.panel2);
            this.metroTabPage2.Controls.Add(this.button24);
            this.metroTabPage2.Controls.Add(this.button20);
            this.metroTabPage2.Controls.Add(this.button16);
            this.metroTabPage2.Controls.Add(this.button12);
            this.metroTabPage2.Controls.Add(this.button8);
            this.metroTabPage2.Controls.Add(this.button4);
            this.metroTabPage2.Controls.Add(this.button23);
            this.metroTabPage2.Controls.Add(this.button19);
            this.metroTabPage2.Controls.Add(this.button15);
            this.metroTabPage2.Controls.Add(this.button11);
            this.metroTabPage2.Controls.Add(this.button7);
            this.metroTabPage2.Controls.Add(this.button3);
            this.metroTabPage2.Controls.Add(this.button22);
            this.metroTabPage2.Controls.Add(this.button21);
            this.metroTabPage2.Controls.Add(this.button18);
            this.metroTabPage2.Controls.Add(this.button17);
            this.metroTabPage2.Controls.Add(this.button14);
            this.metroTabPage2.Controls.Add(this.button13);
            this.metroTabPage2.Controls.Add(this.button10);
            this.metroTabPage2.Controls.Add(this.button9);
            this.metroTabPage2.Controls.Add(this.button6);
            this.metroTabPage2.Controls.Add(this.button5);
            this.metroTabPage2.Controls.Add(this.button2);
            this.metroTabPage2.Controls.Add(this.button1);
            this.metroTabPage2.Controls.Add(this.btnUpdateBox);
            this.metroTabPage2.Controls.Add(this.dataGridView2);
            this.metroTabPage2.Controls.Add(this.comboBox1);
            this.metroTabPage2.Controls.Add(this.label1);
            this.metroTabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.HorizontalScrollbarSize = 10;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(1035, 423);
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "Cinema Box";
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            this.metroTabPage2.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.VerticalScrollbarSize = 10;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(559, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(441, 33);
            this.panel2.TabIndex = 6;
            // 
            // button24
            // 
            this.button24.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button24.Location = new System.Drawing.Point(942, 291);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(58, 55);
            this.button24.TabIndex = 5;
            this.button24.Text = "D6";
            this.button24.UseVisualStyleBackColor = true;
            // 
            // button20
            // 
            this.button20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button20.Location = new System.Drawing.Point(866, 291);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(58, 55);
            this.button20.TabIndex = 5;
            this.button20.Text = "D5";
            this.button20.UseVisualStyleBackColor = true;
            // 
            // button16
            // 
            this.button16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button16.Location = new System.Drawing.Point(790, 291);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(58, 55);
            this.button16.TabIndex = 5;
            this.button16.Text = "D4";
            this.button16.UseVisualStyleBackColor = true;
            // 
            // button12
            // 
            this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button12.Location = new System.Drawing.Point(715, 291);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(58, 55);
            this.button12.TabIndex = 5;
            this.button12.Text = "D3";
            this.button12.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Location = new System.Drawing.Point(637, 291);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(58, 55);
            this.button8.TabIndex = 5;
            this.button8.Text = "D2";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(559, 291);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(58, 55);
            this.button4.TabIndex = 5;
            this.button4.Text = "D1";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button23
            // 
            this.button23.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button23.Location = new System.Drawing.Point(942, 221);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(58, 55);
            this.button23.TabIndex = 5;
            this.button23.Text = "C6";
            this.button23.UseVisualStyleBackColor = true;
            // 
            // button19
            // 
            this.button19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button19.Location = new System.Drawing.Point(866, 221);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(58, 55);
            this.button19.TabIndex = 5;
            this.button19.Text = "C5";
            this.button19.UseVisualStyleBackColor = true;
            // 
            // button15
            // 
            this.button15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button15.Location = new System.Drawing.Point(790, 221);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(58, 55);
            this.button15.TabIndex = 5;
            this.button15.Text = "C4";
            this.button15.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.Location = new System.Drawing.Point(715, 221);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(58, 55);
            this.button11.TabIndex = 5;
            this.button11.Text = "C3";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Location = new System.Drawing.Point(637, 221);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(58, 55);
            this.button7.TabIndex = 5;
            this.button7.Text = "C2";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(559, 221);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(58, 55);
            this.button3.TabIndex = 5;
            this.button3.Text = "C1";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button22
            // 
            this.button22.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button22.Location = new System.Drawing.Point(942, 150);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(58, 55);
            this.button22.TabIndex = 5;
            this.button22.Text = "B6";
            this.button22.UseVisualStyleBackColor = true;
            // 
            // button21
            // 
            this.button21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button21.Location = new System.Drawing.Point(942, 77);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(58, 55);
            this.button21.TabIndex = 5;
            this.button21.Text = "A6";
            this.button21.UseVisualStyleBackColor = true;
            // 
            // button18
            // 
            this.button18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button18.Location = new System.Drawing.Point(866, 150);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(58, 55);
            this.button18.TabIndex = 5;
            this.button18.Text = "B5";
            this.button18.UseVisualStyleBackColor = true;
            // 
            // button17
            // 
            this.button17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button17.Location = new System.Drawing.Point(866, 77);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(58, 55);
            this.button17.TabIndex = 5;
            this.button17.Text = "A5";
            this.button17.UseVisualStyleBackColor = true;
            // 
            // button14
            // 
            this.button14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button14.Location = new System.Drawing.Point(790, 150);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(58, 55);
            this.button14.TabIndex = 5;
            this.button14.Text = "B4";
            this.button14.UseVisualStyleBackColor = true;
            // 
            // button13
            // 
            this.button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button13.Location = new System.Drawing.Point(790, 77);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(58, 55);
            this.button13.TabIndex = 5;
            this.button13.Text = "A4";
            this.button13.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Location = new System.Drawing.Point(715, 150);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(58, 55);
            this.button10.TabIndex = 5;
            this.button10.Text = "B3";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Location = new System.Drawing.Point(715, 77);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(58, 55);
            this.button9.TabIndex = 5;
            this.button9.Text = "A3";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Location = new System.Drawing.Point(637, 150);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(58, 55);
            this.button6.TabIndex = 5;
            this.button6.Text = "B2";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(637, 77);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(58, 55);
            this.button5.TabIndex = 5;
            this.button5.Text = "A2";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(559, 150);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(58, 55);
            this.button2.TabIndex = 5;
            this.button2.Text = "B1";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(559, 77);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 55);
            this.button1.TabIndex = 5;
            this.button1.Text = "A1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnUpdateBox
            // 
            this.btnUpdateBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateBox.Location = new System.Drawing.Point(11, 324);
            this.btnUpdateBox.Name = "btnUpdateBox";
            this.btnUpdateBox.Size = new System.Drawing.Size(86, 33);
            this.btnUpdateBox.TabIndex = 5;
            this.btnUpdateBox.Text = "Update";
            this.btnUpdateBox.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(11, 77);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.Size = new System.Drawing.Size(504, 221);
            this.dataGridView2.TabIndex = 4;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(107, 23);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(127, 23);
            this.comboBox1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cinema Box:";
            // 
            // metroTabPage3
            // 
            this.metroTabPage3.Controls.Add(this.button25);
            this.metroTabPage3.Controls.Add(this.button26);
            this.metroTabPage3.Controls.Add(this.button27);
            this.metroTabPage3.Controls.Add(this.dataGridView3);
            this.metroTabPage3.HorizontalScrollbarBarColor = true;
            this.metroTabPage3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.HorizontalScrollbarSize = 10;
            this.metroTabPage3.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage3.Name = "metroTabPage3";
            this.metroTabPage3.Size = new System.Drawing.Size(1035, 423);
            this.metroTabPage3.TabIndex = 2;
            this.metroTabPage3.Text = "User";
            this.metroTabPage3.VerticalScrollbarBarColor = true;
            this.metroTabPage3.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.VerticalScrollbarSize = 10;
            // 
            // button25
            // 
            this.button25.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button25.Location = new System.Drawing.Point(561, 253);
            this.button25.Name = "button25";
            this.button25.Size = new System.Drawing.Size(86, 33);
            this.button25.TabIndex = 4;
            this.button25.Text = "Remove";
            this.button25.UseVisualStyleBackColor = true;
            // 
            // button26
            // 
            this.button26.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button26.Location = new System.Drawing.Point(461, 253);
            this.button26.Name = "button26";
            this.button26.Size = new System.Drawing.Size(86, 33);
            this.button26.TabIndex = 5;
            this.button26.Text = "Update";
            this.button26.UseVisualStyleBackColor = true;
            // 
            // button27
            // 
            this.button27.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button27.Location = new System.Drawing.Point(11, 253);
            this.button27.Name = "button27";
            this.button27.Size = new System.Drawing.Size(86, 33);
            this.button27.TabIndex = 6;
            this.button27.Text = "Select";
            this.button27.UseVisualStyleBackColor = true;
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(11, 28);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersWidth = 51;
            this.dataGridView3.Size = new System.Drawing.Size(636, 200);
            this.dataGridView3.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 512);
            this.ControlBox = false;
            this.Controls.Add(this.metroTabControl1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.metroTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.metroTabPage2.ResumeLayout(false);
            this.metroTabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.metroTabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExit;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private MetroFramework.Controls.MetroTabPage metroTabPage3;
        private System.Windows.Forms.Button btnUpdateMovie;
        private System.Windows.Forms.Button btnSelectMovie;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnRemoveMovie;
        private System.Windows.Forms.Label lblMoviePrice;
        private System.Windows.Forms.Label lblMovieLength;
        private System.Windows.Forms.Label lblMovieDescription;
        private System.Windows.Forms.Label lblMovieName;
        private System.Windows.Forms.PictureBox ptbPreview;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnUpdateBox;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button24;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button23;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button22;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnAddMoive;
        private System.Windows.Forms.Button button25;
        private System.Windows.Forms.Button button26;
        private System.Windows.Forms.Button button27;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Label label2;
    }
}

