namespace HeThongDocTruyen.UI.UserForm
{
    partial class QuanLyDanhGia
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
            this.button_Xoa = new System.Windows.Forms.Button();
            this.pictureBox_Load = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox_TimKiem = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel_BinhLuan = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Load)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Xoa
            // 
            this.button_Xoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(55)))), ((int)(((byte)(92)))));
            this.button_Xoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Xoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Xoa.ForeColor = System.Drawing.Color.White;
            this.button_Xoa.Location = new System.Drawing.Point(1189, 100);
            this.button_Xoa.Name = "button_Xoa";
            this.button_Xoa.Size = new System.Drawing.Size(198, 60);
            this.button_Xoa.TabIndex = 25;
            this.button_Xoa.Text = "Xóa ";
            this.button_Xoa.UseVisualStyleBackColor = false;
            this.button_Xoa.Click += new System.EventHandler(this.button_Xoa_Click);
            // 
            // pictureBox_Load
            // 
            this.pictureBox_Load.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox_Load.Image = global::HeThongDocTruyen.Properties.Resources._6039040_removebg_preview;
            this.pictureBox_Load.Location = new System.Drawing.Point(1330, 3);
            this.pictureBox_Load.Name = "pictureBox_Load";
            this.pictureBox_Load.Size = new System.Drawing.Size(65, 63);
            this.pictureBox_Load.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Load.TabIndex = 18;
            this.pictureBox_Load.TabStop = false;
            this.pictureBox_Load.Click += new System.EventHandler(this.pictureBox_Load_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(380, 29);
            this.label1.TabIndex = 17;
            this.label1.Text = "QUẢN LÝ BÌNH LUẬN / ĐÁNH GIÁ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = global::HeThongDocTruyen.Properties.Resources.png_transparent_digital_marketing_web_search_engine_font_awesome_search_engine_optimization_google_search_email_blue_circle_removebg_preview;
            this.pictureBox1.Location = new System.Drawing.Point(11, 97);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(65, 63);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // textBox_TimKiem
            // 
            this.textBox_TimKiem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_TimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_TimKiem.Location = new System.Drawing.Point(76, 100);
            this.textBox_TimKiem.Multiline = true;
            this.textBox_TimKiem.Name = "textBox_TimKiem";
            this.textBox_TimKiem.Size = new System.Drawing.Size(1107, 60);
            this.textBox_TimKiem.TabIndex = 15;
            this.textBox_TimKiem.TextChanged += new System.EventHandler(this.textBox_TimKiem_TextChanged);
            // 
            // flowLayoutPanel_BinhLuan
            // 
            this.flowLayoutPanel_BinhLuan.AutoScroll = true;
            this.flowLayoutPanel_BinhLuan.Location = new System.Drawing.Point(11, 166);
            this.flowLayoutPanel_BinhLuan.Name = "flowLayoutPanel_BinhLuan";
            this.flowLayoutPanel_BinhLuan.Size = new System.Drawing.Size(1376, 800);
            this.flowLayoutPanel_BinhLuan.TabIndex = 26;
            // 
            // QuanLyDanhGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel_BinhLuan);
            this.Controls.Add(this.button_Xoa);
            this.Controls.Add(this.pictureBox_Load);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox_TimKiem);
            this.Name = "QuanLyDanhGia";
            this.Size = new System.Drawing.Size(1405, 969);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Load)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_Xoa;
        private System.Windows.Forms.PictureBox pictureBox_Load;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox_TimKiem;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_BinhLuan;
    }
}
