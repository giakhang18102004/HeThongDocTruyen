namespace HeThongDocTruyen.UI.UserForm
{
    partial class ThongKeTruyen
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
            this.flowLayoutPanel_TopTruyen = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox_Load = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Load)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(589, 29);
            this.label1.TabIndex = 18;
            this.label1.Text = "THỐNG KÊ TOP TRUYỆN ĐƯỢC XEM NHIỀU NHẤT";
            // 
            // flowLayoutPanel_TopTruyen
            // 
            this.flowLayoutPanel_TopTruyen.AutoScroll = true;
            this.flowLayoutPanel_TopTruyen.Location = new System.Drawing.Point(29, 98);
            this.flowLayoutPanel_TopTruyen.Name = "flowLayoutPanel_TopTruyen";
            this.flowLayoutPanel_TopTruyen.Size = new System.Drawing.Size(1373, 847);
            this.flowLayoutPanel_TopTruyen.TabIndex = 19;
            // 
            // pictureBox_Load
            // 
            this.pictureBox_Load.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox_Load.Image = global::HeThongDocTruyen.Properties.Resources._6039040_removebg_preview;
            this.pictureBox_Load.Location = new System.Drawing.Point(1324, 0);
            this.pictureBox_Load.Name = "pictureBox_Load";
            this.pictureBox_Load.Size = new System.Drawing.Size(65, 63);
            this.pictureBox_Load.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Load.TabIndex = 20;
            this.pictureBox_Load.TabStop = false;
            this.pictureBox_Load.Click += new System.EventHandler(this.pictureBox_Load_Click);
            // 
            // ThongKeTruyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox_Load);
            this.Controls.Add(this.flowLayoutPanel_TopTruyen);
            this.Controls.Add(this.label1);
            this.Name = "ThongKeTruyen";
            this.Size = new System.Drawing.Size(1405, 969);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Load)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_TopTruyen;
        private System.Windows.Forms.PictureBox pictureBox_Load;
    }
}
