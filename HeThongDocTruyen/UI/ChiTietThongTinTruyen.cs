using HeThongDocTruyen.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThongDocTruyen.UI
{
    public partial class ChiTietThongTinTruyen : Form
    {
        public ChiTietThongTinTruyen()
        {
            InitializeComponent();
        }

        public void SetTruyenDetails(string tenTruyen, string tacGia, string moTa, string luotDoc, string danhMuc, string theLoai, Image anhTruyen)
        {
            textBox_TenTruyen.Text = tenTruyen;
            textBox_TacGia.Text = tacGia;
            textBox_NgayDang.Text = DateTime.Now.ToString("dd/MM/yyyy"); 
            textBox_MaDanhMuc.Text = danhMuc;
            textBox_MaTheLoai.Text = theLoai;
            label_MoTa.Text = moTa;
            textBox_LuotDoc.Text = luotDoc;
            pictureBox_AnhTruyen.Image = anhTruyen;
        }


        private void button_QuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label_MoTa_Click(object sender, EventArgs e)
        {
            label_MoTa.MaximumSize = new Size(flowLayoutPanel_MoTa.Width - 20, 0);
            label_MoTa.AutoSize = true; 
        }
    }
}
