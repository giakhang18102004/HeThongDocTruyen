using HeThongDocTruyen.BLL;
using HeThongDocTruyen.Model;
using HeThongDocTruyen.Model.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThongDocTruyen.UI.UserForm
{
    public partial class QuanLyTaiKhoan : UserControl
    {
        Database db = new Database();

        private BLL_QuanLyTaiKhoan TaiKhoanBLL;

        private Timer PhanQuyenTimer;
        public QuanLyTaiKhoan()
        {
            InitializeComponent();

            TaiKhoanBLL = new BLL_QuanLyTaiKhoan(new Database().GetConnectionString());

            PhanQuyenTimer = new Timer();
            PhanQuyenTimer.Interval = 1000;
            PhanQuyenTimer.Tick += (s, e) => LoadChonPhanQuyen();
            PhanQuyenTimer.Start();

            LoadDataTaikhoan();
        }

        private void LoadChonPhanQuyen()
        {
            string connectionString = new Database().GetConnectionString();
            string query = "SELECT IDPhanQuyen, TenPhanQuyen FROM PhanQuyen";


            var selectedValue = comboBox_PhanQuyen.SelectedValue;

            SqlDataAdapter da = new SqlDataAdapter(query, connectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);

            comboBox_PhanQuyen.DisplayMember = "TenPhanQuyen";
            comboBox_PhanQuyen.ValueMember = "IDPhanQuyen";
            comboBox_PhanQuyen.DataSource = dt;


            if (selectedValue != null && dt.AsEnumerable().Any(row => row["IDPhanQuyen"].ToString() == selectedValue.ToString()))
            {
                comboBox_PhanQuyen.SelectedValue = selectedValue;
            }
            else
            {

                comboBox_PhanQuyen.SelectedIndex = 0;
            }
        }


        public void LoadDataTaikhoan()
        {
            try
            {
                data_main.DataSource = TaiKhoanBLL.getListTaiKhoan();

            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error" , MessageBoxButtons.OK, MessageBoxIcon.Error);  
            }
        }

        public void ClearData()
        {
            textBox_HoTen.Clear();
            textBox_MatKhau.Clear();
            textBox_SDT.Clear();
            textBox_TentaiKhoan.Clear();
            textBox_Email.Clear();
            comboBox_GioiTinh.SelectedValue = -1;
            comboBox_PhanQuyen.SelectedValue = -1;
            dateTimePicker_Ngaytao.Value = DateTime.Now;
        }
        private void button_CapNhat_Click(object sender, EventArgs e)
        {
            if (data_main.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn tài khoản trong bảng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                DialogResult resultDelete = MessageBox.Show("Bạn có chắc chắn muốn thay đổi thông tin này ! ", "Thông báo ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultDelete == DialogResult.Yes)
                {

                }
                TaiKhoan taikhoan = new TaiKhoan
                {
                    IDTaiKhoan = Convert.ToInt32(data_main.CurrentRow.Cells["IDTaiKhoan"].Value),
                    TaiKhoanNguoiDung = textBox_TentaiKhoan.Text,
                    MatKhau = textBox_MatKhau.Text,
                    HoTen = textBox_HoTen.Text,
                    Email = textBox_Email.Text,
                    GioiTinh = comboBox_GioiTinh.Text,
                    IDPhanQuyen = (int)comboBox_PhanQuyen.SelectedValue,
                    NgayTao = dateTimePicker_Ngaytao.Value,
                    SDT = textBox_SDT.Text,

                };
                TaiKhoanBLL.UpdateNewTaiKhoan(taikhoan);
                MessageBox.Show("Cập nhật thông tin tài khoản thành công !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataTaikhoan();
                ClearData();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_DonThongTin_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void button_Xoa_Click(object sender, EventArgs e)
        {
            if (data_main.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn tài khoản trong bảng !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                DialogResult resultDelete = MessageBox.Show("Bạn có chắc chắn muốn xóa thông tin này ! ", "Thông báo ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultDelete == DialogResult.Yes)
                {

                    TaiKhoan taikhoan = new TaiKhoan
                    {
                        IDTaiKhoan = Convert.ToInt32(data_main.CurrentRow.Cells["IDTaiKhoan"].Value),

                    };

                    TaiKhoanBLL.DeleteTaiKhoanNow(taikhoan);
                    MessageBox.Show("Xóa thông tin tài khoản trong bảng thành công !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataTaikhoan();
                    ClearData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void data_main_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || data_main.Rows[e.RowIndex] == null)
            {
                MessageBox.Show("Vui lòng chọn mục thay đổi thông tin !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataGridViewRow rowst = data_main.Rows[e.RowIndex];

                textBox_Email.Text = rowst.Cells["Email"]?.Value?.ToString() ?? string.Empty;
                textBox_HoTen.Text = rowst.Cells["HoTen"]?.Value?.ToString() ?? string.Empty;
                textBox_TentaiKhoan.Text = rowst.Cells["TaiKhoan"]?.Value?.ToString() ?? string.Empty;
                textBox_MatKhau.Text = rowst.Cells["MatKhau"]?.Value?.ToString() ?? string.Empty;
                comboBox_GioiTinh.Text = rowst.Cells["GioiTinh"]?.Value?.ToString() ?? string.Empty;
                textBox_SDT.Text = rowst.Cells["SDT"]?.Value?.ToString() ?? string.Empty;




                if (rowst.Cells["NgayTao"]?.Value != null && rowst.Cells["NgayTao"].Value != DBNull.Value)
                {
                    dateTimePicker_Ngaytao.Value = Convert.ToDateTime(rowst.Cells["NgayTao"].Value);
                }
                else
                {
                    dateTimePicker_Ngaytao.Value = DateTime.Now;
                }


                if (rowst.Cells["IDPhanQuyen"]?.Value != null && rowst.Cells["IDPhanQuyen"].Value != DBNull.Value)
                {
                    int manhomsp = Convert.ToInt32(rowst.Cells["IDPhanQuyen"].Value);
                    comboBox_PhanQuyen.SelectedValue = manhomsp;
                }
                else
                {
                    comboBox_PhanQuyen.SelectedIndex = -1;
                }


               

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox_TimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string keyword = textBox_TimKiem.Text.Trim();
                DataTable dataTable = TaiKhoanBLL.SearchListTaiKhoan(keyword);
                data_main.DataSource = dataTable;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                string searchKeyword = textBox_TimKiem.Text.Trim();

                if (string.IsNullOrEmpty(searchKeyword))
                {
                    MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                int resultCount = TaiKhoanBLL.CountListTaiKhoan(searchKeyword);
                MessageBox.Show($"Đã tìm thấy {resultCount} kết quả!", "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (resultCount > 0)
                {
                    // Hiển thị danh sách kết quả
                    DataTable dt = TaiKhoanBLL.SearchListTaiKhoan(searchKeyword);
                    data_main.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Không có kết quả tìm kiếm phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    data_main.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_Them_Click(object sender, EventArgs e)
        {
            try
            {
                TaiKhoan taikhoan = new TaiKhoan
                {
                   TaiKhoanNguoiDung = textBox_TentaiKhoan.Text,
                   MatKhau = textBox_MatKhau.Text,
                   HoTen = textBox_HoTen.Text,
                   Email = textBox_Email.Text,
                   GioiTinh = comboBox_GioiTinh.Text,   
                   IDPhanQuyen = (int)comboBox_PhanQuyen.SelectedValue,
                   NgayTao = dateTimePicker_Ngaytao.Value,
                   SDT = textBox_SDT.Text,

                };

                TaiKhoanBLL.AddNewTaiKhoan(taikhoan);
                MessageBox.Show("Thêm tài khoản mới thành công !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataTaikhoan();
                ClearData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox_Load_Click(object sender, EventArgs e)
        {
            LoadDataTaikhoan();
            MessageBox.Show("Đã tải lại dữ liệu thành công ! ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
