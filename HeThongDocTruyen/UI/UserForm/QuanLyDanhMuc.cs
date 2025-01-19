using HeThongDocTruyen.BLL;
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

namespace HeThongDocTruyen.UI.UserForm
{
    public partial class QuanLyDanhMuc : UserControl
    {
        Database db = new Database();

        private BLL_QuanLyDanhMuc DanhMucBLL;
        public QuanLyDanhMuc()
        {
            InitializeComponent();

            DanhMucBLL = new BLL_QuanLyDanhMuc(new Database().GetConnectionString());

            LoadDataDanhMuc();
        }

        public void LoadDataDanhMuc()
        {
            try
            {

                data_main.DataSource = DanhMucBLL.getListDanhMuc();

            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error" , MessageBoxButtons.OK, MessageBoxIcon.Error);  
            }
        }

        public void ClearData()
        {
            textBox_TenDanhMuc.Clear();
            textBox_MoTa.Clear();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button_DonThongTin_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void button_Them_Click(object sender, EventArgs e)
        {
            try
            {
                DanhMucTruyen danhmuc = new DanhMucTruyen
                {
                    TenDanhMuc = textBox_TenDanhMuc.Text.Trim(),
                    MoTa = textBox_MoTa.Text.Trim()
                };

                DanhMucBLL.AddNewDanhMuc(danhmuc);
                MessageBox.Show("Thêm danh mục mới thành công !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataDanhMuc();
                ClearData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_CapNhat_Click(object sender, EventArgs e)
        {
            if (data_main.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn danh mục trong bảng !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                DialogResult resultDelete = MessageBox.Show("Bạn có chắc chắn muốn thay đổi thông tin này ! ", "Thông báo ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultDelete == DialogResult.Yes)
                {

                }
                DanhMucTruyen danhmuc = new DanhMucTruyen
                {
                    IDDanhMuc = Convert.ToInt32(data_main.CurrentRow.Cells["IDDanhMuc"].Value),
                    TenDanhMuc = textBox_TenDanhMuc.Text.Trim(),
                    MoTa = textBox_MoTa.Text.Trim()
                };           
                DanhMucBLL.UpdateNewDanhMuc(danhmuc);
                MessageBox.Show("Cập nhật thông tin danh mục thành công !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataDanhMuc();
                ClearData();

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
                MessageBox.Show("Vui lòng chọn mục thay đổi trong bảng danh mục !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataGridViewRow selectedRow = data_main.Rows[e.RowIndex];


                if (selectedRow.Cells[1]?.Value == null || selectedRow.Cells[1].Value == DBNull.Value)
                {
                    textBox_TenDanhMuc.Text = string.Empty;
                }
                else
                {
                    textBox_TenDanhMuc.Text = selectedRow.Cells[1].Value.ToString();
                }


                if (selectedRow.Cells[2]?.Value == null || selectedRow.Cells[2].Value == DBNull.Value)
                {
                    textBox_MoTa.Text = string.Empty;
                }
                else
                {
                    textBox_MoTa.Text = selectedRow.Cells[2].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_Xoa_Click(object sender, EventArgs e)
        {
            if (data_main.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn khu vực!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                DialogResult resultDelete = MessageBox.Show("Bạn có chắc chắn muốn xóa thông tin này ! ", "Thông báo ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultDelete == DialogResult.Yes)
                {

                DanhMucTruyen danhmuc = new DanhMucTruyen
                {
                    IDDanhMuc = Convert.ToInt32(data_main.CurrentRow.Cells["IDDanhMuc"].Value),                    
                };
              
                DanhMucBLL.DeleteDanhMuc(danhmuc);
                MessageBox.Show("Xóa thông tin danh mục trong bảng thành công !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataDanhMuc();
                ClearData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox_Load_Click(object sender, EventArgs e)
        {
            LoadDataDanhMuc();
            MessageBox.Show("Đã tải lại dữ liệu thành công ! ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void textBox_TimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string keyword = textBox_TimKiem.Text.Trim();
                DataTable dataTable = DanhMucBLL.searchListDanhMuc(keyword);
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


                int resultCount = DanhMucBLL.CountListDanhMuc(searchKeyword);
                MessageBox.Show($"Đã tìm thấy {resultCount} kết quả!", "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (resultCount > 0)
                {
                    // Hiển thị danh sách kết quả
                    DataTable dt = DanhMucBLL.searchListDanhMuc(searchKeyword);
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
    }
}
