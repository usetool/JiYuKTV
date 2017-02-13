namespace Server
{
    partial class FrmEditSong
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
            this.txtSongName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numCount = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSinger = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSongPath = new System.Windows.Forms.TextBox();
            this.btnBroswe = new System.Windows.Forms.Button();
            this.s = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numCount)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSongName
            // 
            this.txtSongName.Location = new System.Drawing.Point(110, 25);
            this.txtSongName.Name = "txtSongName";
            this.txtSongName.Size = new System.Drawing.Size(169, 21);
            this.txtSongName.TabIndex = 0;
            this.txtSongName.TextChanged += new System.EventHandler(this.txtSongName_TextChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(123, 348);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "歌曲名称";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "歌曲简拼";
            // 
            // txtAb
            // 
            this.txtAb.Location = new System.Drawing.Point(110, 78);
            this.txtAb.Name = "txtAb";
            this.txtAb.Size = new System.Drawing.Size(169, 21);
            this.txtAb.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "播放次数";
            // 
            // numCount
            // 
            this.numCount.Location = new System.Drawing.Point(110, 141);
            this.numCount.Name = "numCount";
            this.numCount.Size = new System.Drawing.Size(169, 21);
            this.numCount.TabIndex = 6;
            this.numCount.ValueChanged += new System.EventHandler(this.numCount_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "歌曲类型";
            // 
            // cboType
            // 
            this.cboType.FormattingEnabled = true;
            this.cboType.Location = new System.Drawing.Point(110, 186);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(169, 20);
            this.cboType.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 239);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "选择歌手";
            // 
            // txtSinger
            // 
            this.txtSinger.Location = new System.Drawing.Point(110, 239);
            this.txtSinger.Name = "txtSinger";
            this.txtSinger.ReadOnly = true;
            this.txtSinger.Size = new System.Drawing.Size(169, 21);
            this.txtSinger.TabIndex = 10;
            this.txtSinger.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtSinger_MouseClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 290);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "选择歌曲";
            // 
            // txtSongPath
            // 
            this.txtSongPath.Location = new System.Drawing.Point(110, 290);
            this.txtSongPath.Name = "txtSongPath";
            this.txtSongPath.ReadOnly = true;
            this.txtSongPath.Size = new System.Drawing.Size(169, 21);
            this.txtSongPath.TabIndex = 12;
            // 
            // btnBroswe
            // 
            this.btnBroswe.Location = new System.Drawing.Point(36, 326);
            this.btnBroswe.Name = "btnBroswe";
            this.btnBroswe.Size = new System.Drawing.Size(75, 23);
            this.btnBroswe.TabIndex = 13;
            this.btnBroswe.Text = "浏览...";
            this.btnBroswe.UseVisualStyleBackColor = true;
            this.btnBroswe.Click += new System.EventHandler(this.btnBroswe_Click);
            // 
            // s
            // 
            this.s.Location = new System.Drawing.Point(204, 348);
            this.s.Name = "s";
            this.s.Size = new System.Drawing.Size(75, 23);
            this.s.TabIndex = 14;
            this.s.Text = "取消";
            this.s.UseVisualStyleBackColor = true;
            this.s.Click += new System.EventHandler(this.s_Click);
            // 
            // FrmEditSong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 383);
            this.Controls.Add(this.s);
            this.Controls.Add(this.btnBroswe);
            this.Controls.Add(this.txtSongPath);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSinger);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtSongName);
            this.MaximizeBox = false;
            this.Name = "FrmEditSong";
            this.Text = "添加歌曲";
            this.Load += new System.EventHandler(this.FrmEditSong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSongName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtSinger;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSongPath;
        private System.Windows.Forms.Button btnBroswe;
        private System.Windows.Forms.Button s;
    }
}