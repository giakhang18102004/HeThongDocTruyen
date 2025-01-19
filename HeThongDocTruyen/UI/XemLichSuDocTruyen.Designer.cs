namespace HeThongDocTruyen.UI
{
    partial class XemLichSuDocTruyen
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
            this.pictureBox_Load = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanelLichSuDoc = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Load)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_Load
            // 
            this.pictureBox_Load.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox_Load.Image = global::HeThongDocTruyen.Properties.Resources._6039040_removebg_preview;
            this.pictureBox_Load.Location = new System.Drawing.Point(1297, 12);
            this.pictureBox_Load.Name = "pictureBox_Load";
            this.pictureBox_Load.Size = new System.Drawing.Size(78, 73);
            this.pictureBox_Load.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Load.TabIndex = 38;
            this.pictureBox_Load.TabStop = false;
            // 
            // flowLayoutPanelLichSuDoc
            // 
            this.flowLayoutPanelLichSuDoc.AutoScroll = true;
            this.flowLayoutPanelLichSuDoc.Location = new System.Drawing.Point(1, 105);
            this.flowLayoutPanelLichSuDoc.Name = "flowLayoutPanelLichSuDoc";
            this.flowLayoutPanelLichSuDoc.Size = new System.Drawing.Size(1385, 814);
            this.flowLayoutPanelLichSuDoc.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(363, 29);
            this.label1.TabIndex = 36;
            this.label1.Text = "LỊCH SỬ CÁC TRUYỆN ĐÃ XEM";
            // 
            // XemLichSuDocTruyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1387, 922);
            this.Controls.Add(this.pictureBox_Load);
            this.Controls.Add(this.flowLayoutPanelLichSuDoc);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "XemLichSuDocTruyen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xem lịch sử đọc truyện gần đây";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Load)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_Load;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelLichSuDoc;
        private System.Windows.Forms.Label label1;
    }
}