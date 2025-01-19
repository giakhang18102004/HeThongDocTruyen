namespace HeThongDocTruyen.UI.UserForm
{
    partial class ManHinhChinh
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
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel_DanhMuc = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox_Load = new System.Windows.Forms.PictureBox();
            this.comboBox_ChonTheLoai = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Load)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 29);
            this.label1.TabIndex = 30;
            this.label1.Text = "DANH MỤC TRUYỆN";
            // 
            // flowLayoutPanel_DanhMuc
            // 
            this.flowLayoutPanel_DanhMuc.AutoScroll = true;
            this.flowLayoutPanel_DanhMuc.Location = new System.Drawing.Point(21, 85);
            this.flowLayoutPanel_DanhMuc.Name = "flowLayoutPanel_DanhMuc";
            this.flowLayoutPanel_DanhMuc.Size = new System.Drawing.Size(1381, 865);
            this.flowLayoutPanel_DanhMuc.TabIndex = 31;
            // 
            // pictureBox_Load
            // 
            this.pictureBox_Load.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox_Load.Image = global::HeThongDocTruyen.Properties.Resources._6039040_removebg_preview;
            this.pictureBox_Load.Location = new System.Drawing.Point(1311, 3);
            this.pictureBox_Load.Name = "pictureBox_Load";
            this.pictureBox_Load.Size = new System.Drawing.Size(78, 73);
            this.pictureBox_Load.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Load.TabIndex = 32;
            this.pictureBox_Load.TabStop = false;
            this.pictureBox_Load.Click += new System.EventHandler(this.pictureBox_Load_Click);
            // 
            // comboBox_ChonTheLoai
            // 
            this.comboBox_ChonTheLoai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox_ChonTheLoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_ChonTheLoai.FormattingEnabled = true;
            this.comboBox_ChonTheLoai.Location = new System.Drawing.Point(317, 20);
            this.comboBox_ChonTheLoai.Name = "comboBox_ChonTheLoai";
            this.comboBox_ChonTheLoai.Size = new System.Drawing.Size(440, 30);
            this.comboBox_ChonTheLoai.TabIndex = 33;
            this.comboBox_ChonTheLoai.SelectedIndexChanged += new System.EventHandler(this.comboBox_ChonTheLoai_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(245)))), ((int)(((byte)(150)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comboBox_ChonTheLoai);
            this.panel1.Location = new System.Drawing.Point(526, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(779, 73);
            this.panel1.TabIndex = 33;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(105, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 20);
            this.label2.TabIndex = 34;
            this.label2.Text = "Chọn thể loại truyện ";
            // 
            // ManHinhChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox_Load);
            this.Controls.Add(this.flowLayoutPanel_DanhMuc);
            this.Controls.Add(this.label1);
            this.Name = "ManHinhChinh";
            this.Size = new System.Drawing.Size(1405, 969);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Load)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_DanhMuc;
        private System.Windows.Forms.PictureBox pictureBox_Load;
        private System.Windows.Forms.ComboBox comboBox_ChonTheLoai;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
    }
}
