using HeThongDocTruyen.Model;
using HeThongDocTruyen.Model.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThongDocTruyen.UI.ThanhVien
{
    public partial class TrangChinhThanhVien : Form
    {
        Database db = new Database();

        public TrangChinhThanhVien()
        {
            InitializeComponent();
            LoadTenTaiKhoan();
        }
        private void LoadTenTaiKhoan()
        {

            string currentUser = ThongTinSession.TaiKhoan;
            lbl_TenTaiKhoan.Text = currentUser;
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

        private void thongtincanhan_Click(object sender, EventArgs e)
        {
            ThongTinTaiKhoan taikhoan = new ThongTinTaiKhoan(ThongTinSession.IDTaiKhoan);
            taikhoan.ShowDialog();
        }

        private void btn_ThayDoiMatKhau_Click(object sender, EventArgs e)
        {
            FormDoiMatKhau doiMatKhau = new FormDoiMatKhau();
            doiMatKhau.ShowDialog();
        }

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


        private void manhinhchinh_Click(object sender, EventArgs e)
        {
            manHinhChinh1.Visible = true;
         
            HighlightButton((Button)sender);
        }

        private void TrangChinhThanhVien_Load(object sender, EventArgs e)
        {

        }

        private void quanlytheloai_Click(object sender, EventArgs e)
        {
            XemLichSuDocTruyen lichsuDoc = new XemLichSuDocTruyen(ThongTinSession.IDTaiKhoan);
            lichsuDoc.ShowDialog();
        }
    }
}
