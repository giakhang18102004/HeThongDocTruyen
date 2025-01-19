namespace HeThongDocTruyen.UI.UserForm
{
    partial class QuanLyDanhMuc
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.data_main = new System.Windows.Forms.DataGridView();
            this.textBox_TimKiem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox_Load = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_TenDanhMuc = new System.Windows.Forms.TextBox();
            this.textBox_MoTa = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button_Them = new System.Windows.Forms.Button();
            this.button_DonThongTin = new System.Windows.Forms.Button();
            this.button_Xoa = new System.Windows.Forms.Button();
            this.button_CapNhat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.data_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Load)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // data_main
            // 
            this.data_main.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.data_main.BackgroundColor = System.Drawing.Color.White;
            this.data_main.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5, 6, 5, 7);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.data_main.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.data_main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_main.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.data_main.DefaultCellStyle = dataGridViewCellStyle2;
            this.data_main.EnableHeadersVisualStyles = false;
            this.data_main.Location = new System.Drawing.Point(3, 402);
            this.data_main.Name = "data_main";
            this.data_main.RowHeadersWidth = 51;
            this.data_main.RowTemplate.Height = 24;
            this.data_main.Size = new System.Drawing.Size(1386, 564);
            this.data_main.TabIndex = 0;
            this.data_main.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.data_main_CellClick);
            this.data_main.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // textBox_TimKiem
            // 
            this.textBox_TimKiem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_TimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_TimKiem.Location = new System.Drawing.Point(68, 333);
            this.textBox_TimKiem.Multiline = true;
            this.textBox_TimKiem.Name = "textBox_TimKiem";
            this.textBox_TimKiem.Size = new System.Drawing.Size(450, 63);
            this.textBox_TimKiem.TabIndex = 1;
            this.textBox_TimKiem.TextChanged += new System.EventHandler(this.textBox_TimKiem_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "QUẢN LÝ DANH MỤC";
            // 
            // pictureBox_Load
            // 
            this.pictureBox_Load.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox_Load.Image = global::HeThongDocTruyen.Properties.Resources._6039040_removebg_preview;
            this.pictureBox_Load.Location = new System.Drawing.Point(1324, 3);
            this.pictureBox_Load.Name = "pictureBox_Load";
            this.pictureBox_Load.Size = new System.Drawing.Size(65, 63);
            this.pictureBox_Load.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Load.TabIndex = 5;
            this.pictureBox_Load.TabStop = false;
            this.pictureBox_Load.Click += new System.EventHandler(this.pictureBox_Load_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = global::HeThongDocTruyen.Properties.Resources.png_transparent_digital_marketing_web_search_engine_font_awesome_search_engine_optimization_google_search_email_blue_circle_removebg_preview;
            this.pictureBox1.Location = new System.Drawing.Point(3, 333);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(65, 63);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(377, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tên danh mục";
            // 
            // textBox_TenDanhMuc
            // 
            this.textBox_TenDanhMuc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_TenDanhMuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_TenDanhMuc.Location = new System.Drawing.Point(524, 92);
            this.textBox_TenDanhMuc.Multiline = true;
            this.textBox_TenDanhMuc.Name = "textBox_TenDanhMuc";
            this.textBox_TenDanhMuc.Size = new System.Drawing.Size(439, 58);
            this.textBox_TenDanhMuc.TabIndex = 7;
            // 
            // textBox_MoTa
            // 
            this.textBox_MoTa.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_MoTa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_MoTa.Location = new System.Drawing.Point(524, 187);
            this.textBox_MoTa.Multiline = true;
            this.textBox_MoTa.Name = "textBox_MoTa";
            this.textBox_MoTa.Size = new System.Drawing.Size(439, 120);
            this.textBox_MoTa.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(441, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Mô tả";
            // 
            // button_Them
            // 
            this.button_Them.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(55)))), ((int)(((byte)(92)))));
            this.button_Them.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Them.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Them.ForeColor = System.Drawing.Color.White;
            this.button_Them.Location = new System.Drawing.Point(524, 336);
            this.button_Them.Name = "button_Them";
            this.button_Them.Size = new System.Drawing.Size(224, 60);
            this.button_Them.TabIndex = 10;
            this.button_Them.Text = "Thêm mới";
            this.button_Them.UseVisualStyleBackColor = false;
            this.button_Them.Click += new System.EventHandler(this.button_Them_Click);
            // 
            // button_DonThongTin
            // 
            this.button_DonThongTin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(55)))), ((int)(((byte)(92)))));
            this.button_DonThongTin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_DonThongTin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_DonThongTin.ForeColor = System.Drawing.Color.White;
            this.button_DonThongTin.Location = new System.Drawing.Point(1173, 336);
            this.button_DonThongTin.Name = "button_DonThongTin";
            this.button_DonThongTin.Size = new System.Drawing.Size(216, 60);
            this.button_DonThongTin.TabIndex = 11;
            this.button_DonThongTin.Text = "Dọn thông tin";
            this.button_DonThongTin.UseVisualStyleBackColor = false;
            this.button_DonThongTin.Click += new System.EventHandler(this.button_DonThongTin_Click);
            // 
            // button_Xoa
            // 
            this.button_Xoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(55)))), ((int)(((byte)(92)))));
            this.button_Xoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Xoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Xoa.ForeColor = System.Drawing.Color.White;
            this.button_Xoa.Location = new System.Drawing.Point(969, 336);
            this.button_Xoa.Name = "button_Xoa";
            this.button_Xoa.Size = new System.Drawing.Size(198, 60);
            this.button_Xoa.TabIndex = 12;
            this.button_Xoa.Text = "Xóa ";
            this.button_Xoa.UseVisualStyleBackColor = false;
            this.button_Xoa.Click += new System.EventHandler(this.button_Xoa_Click);
            // 
            // button_CapNhat
            // 
            this.button_CapNhat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(55)))), ((int)(((byte)(92)))));
            this.button_CapNhat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_CapNhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_CapNhat.ForeColor = System.Drawing.Color.White;
            this.button_CapNhat.Location = new System.Drawing.Point(754, 336);
            this.button_CapNhat.Name = "button_CapNhat";
            this.button_CapNhat.Size = new System.Drawing.Size(209, 60);
            this.button_CapNhat.TabIndex = 13;
            this.button_CapNhat.Text = "Cập nhật";
            this.button_CapNhat.UseVisualStyleBackColor = false;
            this.button_CapNhat.Click += new System.EventHandler(this.button_CapNhat_Click);
            // 
            // QuanLyDanhMuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_CapNhat);
            this.Controls.Add(this.button_Xoa);
            this.Controls.Add(this.button_DonThongTin);
            this.Controls.Add(this.button_Them);
            this.Controls.Add(this.textBox_MoTa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_TenDanhMuc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox_Load);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox_TimKiem);
            this.Controls.Add(this.data_main);
            this.Name = "QuanLyDanhMuc";
            this.Size = new System.Drawing.Size(1405, 969);
            ((System.ComponentModel.ISupportInitialize)(this.data_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Load)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView data_main;
        private System.Windows.Forms.TextBox textBox_TimKiem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox_Load;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_TenDanhMuc;
        private System.Windows.Forms.TextBox textBox_MoTa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_Them;
        private System.Windows.Forms.Button button_DonThongTin;
        private System.Windows.Forms.Button button_Xoa;
        private System.Windows.Forms.Button button_CapNhat;
    }
}
