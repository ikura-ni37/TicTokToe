namespace MyTicTacToe
{
    partial class StartWindow
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
            this.comboBox_player1 = new System.Windows.Forms.ComboBox();
            this.Player1 = new System.Windows.Forms.GroupBox();
            this.comboBox_player1character = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ready_player1 = new System.Windows.Forms.Button();
            this.textBox_playername1 = new System.Windows.Forms.TextBox();
            this.label_player1name = new System.Windows.Forms.Label();
            this.label_player1 = new System.Windows.Forms.Label();
            this.Player2 = new System.Windows.Forms.GroupBox();
            this.comboBox_player2character = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ready_player2 = new System.Windows.Forms.Button();
            this.textBox_playername2 = new System.Windows.Forms.TextBox();
            this.label_player2name = new System.Windows.Forms.Label();
            this.label_player2 = new System.Windows.Forms.Label();
            this.comboBox_player2 = new System.Windows.Forms.ComboBox();
            this.botton_Start = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.label_round = new System.Windows.Forms.Label();
            this.numericUpDown_round = new System.Windows.Forms.NumericUpDown();
            this.pictureBox_player1character = new System.Windows.Forms.PictureBox();
            this.pictureBox_player2character = new System.Windows.Forms.PictureBox();
            this.Player1.SuspendLayout();
            this.Player2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_round)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_player1character)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_player2character)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox_player1
            // 
            this.comboBox_player1.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_player1.FormattingEnabled = true;
            this.comboBox_player1.Location = new System.Drawing.Point(45, 74);
            this.comboBox_player1.Name = "comboBox_player1";
            this.comboBox_player1.Size = new System.Drawing.Size(208, 32);
            this.comboBox_player1.TabIndex = 0;
            // 
            // Player1
            // 
            this.Player1.Controls.Add(this.comboBox_player1character);
            this.Player1.Controls.Add(this.label1);
            this.Player1.Controls.Add(this.ready_player1);
            this.Player1.Controls.Add(this.textBox_playername1);
            this.Player1.Controls.Add(this.label_player1name);
            this.Player1.Controls.Add(this.label_player1);
            this.Player1.Controls.Add(this.comboBox_player1);
            this.Player1.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player1.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.Player1.Location = new System.Drawing.Point(58, 311);
            this.Player1.Name = "Player1";
            this.Player1.Size = new System.Drawing.Size(284, 346);
            this.Player1.TabIndex = 4;
            this.Player1.TabStop = false;
            this.Player1.Text = "1P";
            // 
            // comboBox_player1character
            // 
            this.comboBox_player1character.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_player1character.FormattingEnabled = true;
            this.comboBox_player1character.Items.AddRange(new object[] {
            "Anthony",
            "Betty",
            "Cathy",
            "Donald",
            "Ed",
            "Fresnel"});
            this.comboBox_player1character.Location = new System.Drawing.Point(45, 229);
            this.comboBox_player1character.Name = "comboBox_player1character";
            this.comboBox_player1character.Size = new System.Drawing.Size(208, 32);
            this.comboBox_player1character.TabIndex = 8;
            this.comboBox_player1character.SelectedIndexChanged += new System.EventHandler(this.ComboBox_player1character_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 28);
            this.label1.TabIndex = 7;
            this.label1.Text = "Character";
            // 
            // ready_player1
            // 
            this.ready_player1.Location = new System.Drawing.Point(45, 280);
            this.ready_player1.Name = "ready_player1";
            this.ready_player1.Size = new System.Drawing.Size(206, 48);
            this.ready_player1.TabIndex = 6;
            this.ready_player1.Text = "GetReady";
            this.ready_player1.UseVisualStyleBackColor = true;
            this.ready_player1.Click += new System.EventHandler(this.Ready_player1_Click);
            // 
            // textBox_playername1
            // 
            this.textBox_playername1.Font = new System.Drawing.Font("Comic Sans MS", 12F);
            this.textBox_playername1.Location = new System.Drawing.Point(45, 149);
            this.textBox_playername1.Name = "textBox_playername1";
            this.textBox_playername1.Size = new System.Drawing.Size(206, 35);
            this.textBox_playername1.TabIndex = 5;
            this.textBox_playername1.Text = "1P";
            // 
            // label_player1name
            // 
            this.label_player1name.AutoSize = true;
            this.label_player1name.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_player1name.Location = new System.Drawing.Point(40, 117);
            this.label_player1name.Name = "label_player1name";
            this.label_player1name.Size = new System.Drawing.Size(120, 28);
            this.label_player1name.TabIndex = 4;
            this.label_player1name.Text = "Player name";
            // 
            // label_player1
            // 
            this.label_player1.AutoSize = true;
            this.label_player1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_player1.Location = new System.Drawing.Point(38, 44);
            this.label_player1.Name = "label_player1";
            this.label_player1.Size = new System.Drawing.Size(68, 28);
            this.label_player1.TabIndex = 1;
            this.label_player1.Text = "Player";
            // 
            // Player2
            // 
            this.Player2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Player2.Controls.Add(this.comboBox_player2character);
            this.Player2.Controls.Add(this.label2);
            this.Player2.Controls.Add(this.ready_player2);
            this.Player2.Controls.Add(this.textBox_playername2);
            this.Player2.Controls.Add(this.label_player2name);
            this.Player2.Controls.Add(this.label_player2);
            this.Player2.Controls.Add(this.comboBox_player2);
            this.Player2.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player2.ForeColor = System.Drawing.Color.Firebrick;
            this.Player2.Location = new System.Drawing.Point(914, 311);
            this.Player2.Name = "Player2";
            this.Player2.Size = new System.Drawing.Size(284, 346);
            this.Player2.TabIndex = 5;
            this.Player2.TabStop = false;
            this.Player2.Text = "2P";
            // 
            // comboBox_player2character
            // 
            this.comboBox_player2character.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_player2character.FormattingEnabled = true;
            this.comboBox_player2character.Items.AddRange(new object[] {
            "Anthony",
            "Betty",
            "Cathy",
            "Donald",
            "Ed",
            "Fresnel"});
            this.comboBox_player2character.Location = new System.Drawing.Point(41, 232);
            this.comboBox_player2character.Name = "comboBox_player2character";
            this.comboBox_player2character.Size = new System.Drawing.Size(208, 32);
            this.comboBox_player2character.TabIndex = 9;
            this.comboBox_player2character.SelectedIndexChanged += new System.EventHandler(this.ComboBox_player2character_SelectedIndexChanged_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 201);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 28);
            this.label2.TabIndex = 8;
            this.label2.Text = "Character";
            // 
            // ready_player2
            // 
            this.ready_player2.Location = new System.Drawing.Point(41, 284);
            this.ready_player2.Name = "ready_player2";
            this.ready_player2.Size = new System.Drawing.Size(206, 48);
            this.ready_player2.TabIndex = 7;
            this.ready_player2.Text = "GetReady";
            this.ready_player2.UseVisualStyleBackColor = true;
            this.ready_player2.Click += new System.EventHandler(this.Ready_player2_Click);
            // 
            // textBox_playername2
            // 
            this.textBox_playername2.Font = new System.Drawing.Font("Comic Sans MS", 12F);
            this.textBox_playername2.Location = new System.Drawing.Point(41, 153);
            this.textBox_playername2.Name = "textBox_playername2";
            this.textBox_playername2.Size = new System.Drawing.Size(206, 35);
            this.textBox_playername2.TabIndex = 6;
            this.textBox_playername2.Text = "2P";
            // 
            // label_player2name
            // 
            this.label_player2name.AutoSize = true;
            this.label_player2name.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_player2name.Location = new System.Drawing.Point(36, 121);
            this.label_player2name.Name = "label_player2name";
            this.label_player2name.Size = new System.Drawing.Size(120, 28);
            this.label_player2name.TabIndex = 5;
            this.label_player2name.Text = "Player name";
            // 
            // label_player2
            // 
            this.label_player2.AutoSize = true;
            this.label_player2.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_player2.Location = new System.Drawing.Point(36, 45);
            this.label_player2.Name = "label_player2";
            this.label_player2.Size = new System.Drawing.Size(68, 28);
            this.label_player2.TabIndex = 2;
            this.label_player2.Text = "Player";
            // 
            // comboBox_player2
            // 
            this.comboBox_player2.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_player2.FormattingEnabled = true;
            this.comboBox_player2.Location = new System.Drawing.Point(41, 77);
            this.comboBox_player2.Name = "comboBox_player2";
            this.comboBox_player2.Size = new System.Drawing.Size(210, 32);
            this.comboBox_player2.TabIndex = 0;
            // 
            // botton_Start
            // 
            this.botton_Start.BackColor = System.Drawing.Color.AliceBlue;
            this.botton_Start.Enabled = false;
            this.botton_Start.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.botton_Start.Font = new System.Drawing.Font("Comic Sans MS", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botton_Start.Location = new System.Drawing.Point(470, 515);
            this.botton_Start.Name = "botton_Start";
            this.botton_Start.Size = new System.Drawing.Size(357, 131);
            this.botton_Start.TabIndex = 6;
            this.botton_Start.Text = "Start";
            this.botton_Start.UseVisualStyleBackColor = false;
            this.botton_Start.Click += new System.EventHandler(this.Botton_Start_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.LightGray;
            this.label5.Font = new System.Drawing.Font("Comic Sans MS", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(291, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(674, 168);
            this.label5.TabIndex = 4;
            this.label5.Text = "TicTacToe";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 668);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1256, 25);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(60, 20);
            this.toolStripStatusLabel1.Text = "loading";
            // 
            // label_round
            // 
            this.label_round.AutoSize = true;
            this.label_round.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_round.Location = new System.Drawing.Point(485, 343);
            this.label_round.Name = "label_round";
            this.label_round.Size = new System.Drawing.Size(68, 28);
            this.label_round.TabIndex = 10;
            this.label_round.Text = "Round";
            // 
            // numericUpDown_round
            // 
            this.numericUpDown_round.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown_round.Location = new System.Drawing.Point(489, 375);
            this.numericUpDown_round.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown_round.Name = "numericUpDown_round";
            this.numericUpDown_round.Size = new System.Drawing.Size(120, 35);
            this.numericUpDown_round.TabIndex = 11;
            this.numericUpDown_round.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // pictureBox_player1character
            // 
            this.pictureBox_player1character.Location = new System.Drawing.Point(58, 61);
            this.pictureBox_player1character.Name = "pictureBox_player1character";
            this.pictureBox_player1character.Size = new System.Drawing.Size(175, 214);
            this.pictureBox_player1character.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_player1character.TabIndex = 12;
            this.pictureBox_player1character.TabStop = false;
            // 
            // pictureBox_player2character
            // 
            this.pictureBox_player2character.Location = new System.Drawing.Point(1023, 61);
            this.pictureBox_player2character.Name = "pictureBox_player2character";
            this.pictureBox_player2character.Size = new System.Drawing.Size(175, 214);
            this.pictureBox_player2character.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_player2character.TabIndex = 13;
            this.pictureBox_player2character.TabStop = false;
            // 
            // StartWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1256, 693);
            this.Controls.Add(this.pictureBox_player2character);
            this.Controls.Add(this.pictureBox_player1character);
            this.Controls.Add(this.numericUpDown_round);
            this.Controls.Add(this.label_round);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.botton_Start);
            this.Controls.Add(this.Player2);
            this.Controls.Add(this.Player1);
            this.Name = "StartWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StartMenu";
            this.Load += new System.EventHandler(this.StartWindow_Load);
            this.Player1.ResumeLayout(false);
            this.Player1.PerformLayout();
            this.Player2.ResumeLayout(false);
            this.Player2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_round)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_player1character)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_player2character)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox Player1;
        private System.Windows.Forms.GroupBox Player2;
        private System.Windows.Forms.Label label_player1;
        private System.Windows.Forms.Label label_player2;
        private System.Windows.Forms.Button botton_Start;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label label_player1name;
        private System.Windows.Forms.Label label_player2name;
        private System.Windows.Forms.Label label_round;
        private System.Windows.Forms.PictureBox pictureBox_player1character;
        private System.Windows.Forms.PictureBox pictureBox_player2character;
        private System.Windows.Forms.Button ready_player1;
        private System.Windows.Forms.Button ready_player2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        public System.Windows.Forms.ComboBox comboBox_player1;
        public System.Windows.Forms.ComboBox comboBox_player2;
        public System.Windows.Forms.TextBox textBox_playername1;
        public System.Windows.Forms.TextBox textBox_playername2;
        public System.Windows.Forms.NumericUpDown numericUpDown_round;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox comboBox_player1character;
        public System.Windows.Forms.ComboBox comboBox_player2character;
    }
}