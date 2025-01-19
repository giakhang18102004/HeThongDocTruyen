namespace HeThongDocTruyen.UI.UserForm
{
    partial class NoiDungChuongTruyen
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
            this.lblTenChuong = new System.Windows.Forms.Label();
            this.button_QuayLai = new System.Windows.Forms.Button();
            this.flowLayoutPanel_Chuong = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_NoiDung = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblTenChuong
            // 
            this.lblTenChuong.AutoSize = true;
            this.lblTenChuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenChuong.Location = new System.Drawing.Point(22, 255);
            this.lblTenChuong.Name = "lblTenChuong";
            this.lblTenChuong.Size = new System.Drawing.Size(79, 29);
            this.lblTenChuong.TabIndex = 33;
            this.lblTenChuong.Text = "label2";
            // 
            // button_QuayLai
            // 
            this.button_QuayLai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(55)))), ((int)(((byte)(92)))));
            this.button_QuayLai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_QuayLai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_QuayLai.ForeColor = System.Drawing.Color.White;
            this.button_QuayLai.Location = new System.Drawing.Point(18, 15);
            this.button_QuayLai.Name = "button_QuayLai";
            this.button_QuayLai.Size = new System.Drawing.Size(156, 42);
            this.button_QuayLai.TabIndex = 37;
            this.button_QuayLai.Text = "Quay lại";
            this.button_QuayLai.UseVisualStyleBackColor = false;
            this.button_QuayLai.Click += new System.EventHandler(this.button_QuayLai_Click);
            // 
            // flowLayoutPanel_Chuong
            // 
            this.flowLayoutPanel_Chuong.Location = new System.Drawing.Point(27, 140);
            this.flowLayoutPanel_Chuong.Name = "flowLayoutPanel_Chuong";
            this.flowLayoutPanel_Chuong.Size = new System.Drawing.Size(1361, 89);
            this.flowLayoutPanel_Chuong.TabIndex = 40;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 29);
            this.label1.TabIndex = 41;
            this.label1.Text = "CÁC CHƯƠNG KHÁC";
            // 
            // textBox_NoiDung
            // 
            this.textBox_NoiDung.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_NoiDung.Enabled = false;
            this.textBox_NoiDung.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_NoiDung.Location = new System.Drawing.Point(27, 299);
            this.textBox_NoiDung.Multiline = true;
            this.textBox_NoiDung.Name = "textBox_NoiDung";
            this.textBox_NoiDung.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_NoiDung.Size = new System.Drawing.Size(1361, 656);
            this.textBox_NoiDung.TabIndex = 42;
            // 
            // NoiDungChuongTruyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.textBox_NoiDung);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flowLayoutPanel_Chuong);
            this.Controls.Add(this.button_QuayLai);
            this.Controls.Add(this.lblTenChuong);
            this.Name = "NoiDungChuongTruyen";
            this.Size = new System.Drawing.Size(1405, 969);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTenChuong;
        private System.Windows.Forms.Button button_QuayLai;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_Chuong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_NoiDung;
    }
}
