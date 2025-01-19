using HeThongDocTruyen.Model;
using HeThongDocTruyen.Model.Database;
using HeThongDocTruyen.UI.UserForm;
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
    public partial class TrangChinhHeThong : Form
    {
        
        public TrangChinhHeThong()
        {
            InitializeComponent();
            LoadTenTaiKhoan();
        }

        private void LoadTenTaiKhoan()
        {
          
            string currentUser = ThongTinSession.TaiKhoan;             
            lbl_TenTaiKhoan.Text = currentUser;
        }


        // Hàm đổi màu khi chọn nút 
        private Button _currentButton = null;

        private void HighlightButton(Button selectedButton)
        {
            if (_currentButton != null)
            {
               
                _currentButton.BackColor = Color.FromArgb(252, 245, 150);
                _currentButton.ForeColor = Color.Black;
                _currentButton.FlatAppearance.BorderSize = 0;
            }        
            selectedButton.BackColor = Color.FromArgb(235, 91, 0);
            selectedButton.ForeColor = Color.White;          
            _currentButton = selectedButton;
        }

        private void Logout_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox_Thoat_Click(object sender, EventArgs e)
        {
           
        }
          
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }         
        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void manhinhchinh_Click(object sender, EventArgs e)
        {
            manHinhChinh1.Visible = true;
            quanLyDanhMuc2.Visible = false;
            quanLyTheLoai2.Visible = false;
            quanLyChuongTruyen2.Visible = false;
            quanLyDanhGia2.Visible = false;
            quanLyPhanQuyen2.Visible = false;
            quanLyTaiKhoan2.Visible = false;
            thongKeTruyen2.Visible = false;
            quanLyTruyen2.Visible = false;
            HighlightButton((Button)sender);
        }

        private void quanlydanhmuc_Click(object sender, EventArgs e)
        {

            manHinhChinh1.Visible = false;
            quanLyDanhMuc2.Visible = true;
            quanLyTheLoai2.Visible = false;
            quanLyChuongTruyen2.Visible = false;
            quanLyDanhGia2.Visible = false;
            quanLyPhanQuyen2.Visible = false;
            quanLyTaiKhoan2.Visible = false;
            thongKeTruyen2.Visible = false;
            quanLyTruyen2.Visible = false;
            HighlightButton((Button)sender);
        }

        private void quanlytheloai_Click(object sender, EventArgs e)
        {
            manHinhChinh1.Visible = false;
            quanLyDanhMuc2.Visible = false;
            quanLyTheLoai2.Visible = true;
            quanLyChuongTruyen2.Visible = false;
            quanLyDanhGia2.Visible = false;
            quanLyPhanQuyen2.Visible = false;
            quanLyTaiKhoan2.Visible = false;
            thongKeTruyen2.Visible = false;
            quanLyTruyen2.Visible = false;
            HighlightButton((Button)sender);
        }

        private void quanlytruyen_Click(object sender, EventArgs e)
        {
            manHinhChinh1.Visible = false;
            quanLyDanhMuc2.Visible = false;
            quanLyTheLoai2.Visible = false;
            quanLyChuongTruyen2.Visible = false;
            quanLyDanhGia2.Visible = false;
            quanLyPhanQuyen2.Visible = false;
            quanLyTaiKhoan2.Visible = false;
            thongKeTruyen2.Visible = false;
            quanLyTruyen2.Visible = true;
            HighlightButton((Button)sender);
        }

        private void quanlychuongtruyen_Click(object sender, EventArgs e)
        {
            manHinhChinh1.Visible = false;
            quanLyDanhMuc2.Visible = false;
            quanLyTheLoai2.Visible = false;
            quanLyChuongTruyen2.Visible = true;
            quanLyDanhGia2.Visible = false;
            quanLyPhanQuyen2.Visible = false;
            quanLyTaiKhoan2.Visible = false;
            thongKeTruyen2.Visible = false;
            quanLyTruyen2.Visible = false;
            HighlightButton((Button)sender);
        }

        private void quanlydanhgia_Click(object sender, EventArgs e)
        {
            manHinhChinh1.Visible = false;
            quanLyDanhMuc2.Visible = false;
            quanLyTheLoai2.Visible = false;
            quanLyChuongTruyen2.Visible = false;
            quanLyDanhGia2.Visible = true;
            quanLyPhanQuyen2.Visible = false;
            quanLyTaiKhoan2.Visible = false;
            thongKeTruyen2.Visible = false;
            quanLyTruyen2.Visible = false;
            HighlightButton((Button)sender);
        }

        private void quanlyphanquyen_Click(object sender, EventArgs e)
        {
            manHinhChinh1.Visible = false;
            quanLyDanhMuc2.Visible = false;
            quanLyTheLoai2.Visible = false;
            quanLyChuongTruyen2.Visible = false;
            quanLyDanhGia2.Visible = false;
            quanLyPhanQuyen2.Visible = true;
            quanLyTaiKhoan2.Visible = false;
            thongKeTruyen2.Visible = false;
            quanLyTruyen2.Visible = false;
            HighlightButton((Button)sender);

        }

        private void quanlytaikhoan_Click(object sender, EventArgs e)
        {
            manHinhChinh1.Visible = false;
            quanLyDanhMuc2.Visible = false;
            quanLyTheLoai2.Visible = false;
            quanLyChuongTruyen2.Visible = false;
            quanLyDanhGia2.Visible = false;
            quanLyPhanQuyen2.Visible = false;
            quanLyTaiKhoan2.Visible = true;
            thongKeTruyen2.Visible = false;
            quanLyTruyen2.Visible = false;
            HighlightButton((Button)sender);
        }

        private void thongketrongtuan_Click(object sender, EventArgs e)
        {

            manHinhChinh1.Visible = false;
            quanLyDanhMuc2.Visible = false;
            quanLyTheLoai2.Visible = false;
            quanLyChuongTruyen2.Visible = false;
            quanLyDanhGia2.Visible = false;
            quanLyPhanQuyen2.Visible = false;
            quanLyTaiKhoan2.Visible = false;
            thongKeTruyen2.Visible = true;
            quanLyTruyen2.Visible = false;
            HighlightButton((Button)sender);
        }

        private void thongtincanhan_Click(object sender, EventArgs e)
        {
            ThongTinTaiKhoan taikhoan = new ThongTinTaiKhoan(ThongTinSession.IDTaiKhoan);
            taikhoan.ShowDialog();
        }

        private void pictureBox_ThoatForm_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có muốn thoát ? ", "Confirmation Message ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                FormDangNhap loginForm = new FormDangNhap();
                loginForm.Show();
                this.Hide();
            }
        }

        private void label_ThoatForm_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có muốn thoát ? ", "Confirmation Message ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                FormDangNhap loginForm = new FormDangNhap();
                loginForm.Show();
                this.Hide();
            }
        }

        private void btn_ThayDoiMatKhau_Click(object sender, EventArgs e)
        {
            FormDoiMatKhau doiMatKhau = new FormDoiMatKhau();
            doiMatKhau.ShowDialog();    
        }
    }
}
