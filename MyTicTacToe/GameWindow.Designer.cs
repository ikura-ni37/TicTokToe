namespace MyTicTacToe
{
    partial class GameWindow
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_player1name = new System.Windows.Forms.Label();
            this.label_player2name = new System.Windows.Forms.Label();
            this.result = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label_losNum1 = new System.Windows.Forms.Label();
            this.label_winNum1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label1_winNum2 = new System.Windows.Forms.Label();
            this.label_losNum2 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label_roundNum = new System.Windows.Forms.Label();
            this.timer_player1 = new System.Windows.Forms.Timer(this.components);
            this.timer_player2 = new System.Windows.Forms.Timer(this.components);
            this.button_start = new System.Windows.Forms.Button();
            this.comboBox_timelimit = new System.Windows.Forms.ComboBox();
            this.label_timelimit = new System.Windows.Forms.Label();
            this.checkBox_beginner = new System.Windows.Forms.CheckBox();
            this.pictureBox_player2 = new System.Windows.Forms.PictureBox();
            this.pictureBox_player1 = new System.Windows.Forms.PictureBox();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_player2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_player1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 707);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1182, 25);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(60, 20);
            this.toolStripStatusLabel1.Text = "loading";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label1.Location = new System.Drawing.Point(70, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 60);
            this.label1.TabIndex = 2;
            this.label1.Text = "Player1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Firebrick;
            this.label2.Location = new System.Drawing.Point(943, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 60);
            this.label2.TabIndex = 3;
            this.label2.Text = "Player2";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_player1name
            // 
            this.label_player1name.AutoSize = true;
            this.label_player1name.Font = new System.Drawing.Font("Comic Sans MS", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_player1name.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label_player1name.Location = new System.Drawing.Point(104, 165);
            this.label_player1name.Name = "label_player1name";
            this.label_player1name.Size = new System.Drawing.Size(99, 45);
            this.label_player1name.TabIndex = 4;
            this.label_player1name.Text = "name";
            // 
            // label_player2name
            // 
            this.label_player2name.AutoSize = true;
            this.label_player2name.Font = new System.Drawing.Font("Comic Sans MS", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_player2name.ForeColor = System.Drawing.Color.Firebrick;
            this.label_player2name.Location = new System.Drawing.Point(986, 165);
            this.label_player2name.Name = "label_player2name";
            this.label_player2name.Size = new System.Drawing.Size(99, 45);
            this.label_player2name.TabIndex = 5;
            this.label_player2name.Text = "name";
            // 
            // result
            // 
            this.result.AutoSize = true;
            this.result.Font = new System.Drawing.Font("Comic Sans MS", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.result.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.result.Location = new System.Drawing.Point(308, 609);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(211, 84);
            this.result.TabIndex = 6;
            this.result.Text = "Result";
            this.result.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(355, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 41);
            this.label5.TabIndex = 7;
            this.label5.Text = "Round";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Comic Sans MS", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label6.Location = new System.Drawing.Point(95, 572);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 45);
            this.label6.TabIndex = 10;
            this.label6.Text = "W";
            // 
            // label_losNum1
            // 
            this.label_losNum1.AutoSize = true;
            this.label_losNum1.Font = new System.Drawing.Font("Comic Sans MS", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_losNum1.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label_losNum1.Location = new System.Drawing.Point(176, 572);
            this.label_losNum1.Name = "label_losNum1";
            this.label_losNum1.Size = new System.Drawing.Size(40, 45);
            this.label_losNum1.TabIndex = 11;
            this.label_losNum1.Text = "0";
            // 
            // label_winNum1
            // 
            this.label_winNum1.AutoSize = true;
            this.label_winNum1.Font = new System.Drawing.Font("Comic Sans MS", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_winNum1.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label_winNum1.Location = new System.Drawing.Point(54, 572);
            this.label_winNum1.Name = "label_winNum1";
            this.label_winNum1.Size = new System.Drawing.Size(40, 45);
            this.label_winNum1.TabIndex = 12;
            this.label_winNum1.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Comic Sans MS", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label9.Location = new System.Drawing.Point(217, 572);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 45);
            this.label9.TabIndex = 13;
            this.label9.Text = "L";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Comic Sans MS", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Firebrick;
            this.label10.Location = new System.Drawing.Point(1108, 572);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 45);
            this.label10.TabIndex = 17;
            this.label10.Text = "L";
            // 
            // label1_winNum2
            // 
            this.label1_winNum2.AutoSize = true;
            this.label1_winNum2.Font = new System.Drawing.Font("Comic Sans MS", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1_winNum2.ForeColor = System.Drawing.Color.Firebrick;
            this.label1_winNum2.Location = new System.Drawing.Point(948, 572);
            this.label1_winNum2.Name = "label1_winNum2";
            this.label1_winNum2.Size = new System.Drawing.Size(40, 45);
            this.label1_winNum2.TabIndex = 16;
            this.label1_winNum2.Text = "0";
            // 
            // label_losNum2
            // 
            this.label_losNum2.AutoSize = true;
            this.label_losNum2.Font = new System.Drawing.Font("Comic Sans MS", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_losNum2.ForeColor = System.Drawing.Color.Firebrick;
            this.label_losNum2.Location = new System.Drawing.Point(1067, 572);
            this.label_losNum2.Name = "label_losNum2";
            this.label_losNum2.Size = new System.Drawing.Size(40, 45);
            this.label_losNum2.TabIndex = 15;
            this.label_losNum2.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Comic Sans MS", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Firebrick;
            this.label13.Location = new System.Drawing.Point(986, 572);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 45);
            this.label13.TabIndex = 14;
            this.label13.Text = "W";
            // 
            // label_roundNum
            // 
            this.label_roundNum.AutoSize = true;
            this.label_roundNum.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_roundNum.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label_roundNum.Location = new System.Drawing.Point(480, 18);
            this.label_roundNum.Name = "label_roundNum";
            this.label_roundNum.Size = new System.Drawing.Size(122, 41);
            this.label_roundNum.TabIndex = 18;
            this.label_roundNum.Text = "number";
            // 
            // button_start
            // 
            this.button_start.Font = new System.Drawing.Font("Comic Sans MS", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_start.Location = new System.Drawing.Point(683, 18);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(103, 46);
            this.button_start.TabIndex = 19;
            this.button_start.Text = "Start";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.Button_start_Click);
            // 
            // comboBox_timelimit
            // 
            this.comboBox_timelimit.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_timelimit.FormattingEnabled = true;
            this.comboBox_timelimit.Items.AddRange(new object[] {
            "60",
            "90",
            "120",
            "∞"});
            this.comboBox_timelimit.Location = new System.Drawing.Point(411, 542);
            this.comboBox_timelimit.Name = "comboBox_timelimit";
            this.comboBox_timelimit.Size = new System.Drawing.Size(126, 32);
            this.comboBox_timelimit.TabIndex = 21;
            // 
            // label_timelimit
            // 
            this.label_timelimit.AutoSize = true;
            this.label_timelimit.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_timelimit.Location = new System.Drawing.Point(406, 511);
            this.label_timelimit.Name = "label_timelimit";
            this.label_timelimit.Size = new System.Drawing.Size(104, 28);
            this.label_timelimit.TabIndex = 20;
            this.label_timelimit.Text = "TimeLimit";
            // 
            // checkBox_beginner
            // 
            this.checkBox_beginner.AutoSize = true;
            this.checkBox_beginner.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_beginner.Location = new System.Drawing.Point(640, 511);
            this.checkBox_beginner.Name = "checkBox_beginner";
            this.checkBox_beginner.Size = new System.Drawing.Size(168, 32);
            this.checkBox_beginner.TabIndex = 22;
            this.checkBox_beginner.Text = "BeginnerMode";
            this.checkBox_beginner.UseVisualStyleBackColor = true;
            this.checkBox_beginner.CheckedChanged += new System.EventHandler(this.CheckBox_beginner_CheckedChanged);
            // 
            // pictureBox_player2
            // 
            this.pictureBox_player2.Location = new System.Drawing.Point(942, 244);
            this.pictureBox_player2.Name = "pictureBox_player2";
            this.pictureBox_player2.Size = new System.Drawing.Size(197, 275);
            this.pictureBox_player2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_player2.TabIndex = 9;
            this.pictureBox_player2.TabStop = false;
            // 
            // pictureBox_player1
            // 
            this.pictureBox_player1.Location = new System.Drawing.Point(52, 244);
            this.pictureBox_player1.Name = "pictureBox_player1";
            this.pictureBox_player1.Size = new System.Drawing.Size(197, 275);
            this.pictureBox_player1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_player1.TabIndex = 8;
            this.pictureBox_player1.TabStop = false;
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 732);
            this.Controls.Add(this.checkBox_beginner);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_timelimit);
            this.Controls.Add(this.label_timelimit);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.label_roundNum);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label1_winNum2);
            this.Controls.Add(this.label_losNum2);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label_winNum1);
            this.Controls.Add(this.label_losNum1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox_player2);
            this.Controls.Add(this.pictureBox_player1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.result);
            this.Controls.Add(this.label_player2name);
            this.Controls.Add(this.label_player1name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.DoubleBuffered = true;
            this.Name = "GameWindow";
            this.Text = "TicTakToe";
            this.Load += new System.EventHandler(this.GameWindow_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_player2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_player1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_player2name;
        public System.Windows.Forms.Label label_player1name;
        public System.Windows.Forms.Label result;
        private System.Windows.Forms.PictureBox pictureBox_player1;
        private System.Windows.Forms.PictureBox pictureBox_player2;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label label_losNum1;
        public System.Windows.Forms.Label label_winNum1;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.Label label1_winNum2;
        public System.Windows.Forms.Label label_losNum2;
        public System.Windows.Forms.Label label13;
        public System.Windows.Forms.Label label_roundNum;
        private System.Windows.Forms.Timer timer_player1;
        private System.Windows.Forms.Timer timer_player2;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        public System.Windows.Forms.ComboBox comboBox_timelimit;
        private System.Windows.Forms.Label label_timelimit;
        public System.Windows.Forms.CheckBox checkBox_beginner;
        private System.Windows.Forms.Label label5;
    }
}

