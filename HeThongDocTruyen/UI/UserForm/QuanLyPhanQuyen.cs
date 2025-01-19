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
    public partial class QuanLyPhanQuyen : UserControl
    {
        Database db = new Database();

        private BLL_QuanLyPhanQuyen  PhanQuyenBLL;
        public QuanLyPhanQuyen()
        {
            InitializeComponent();

            PhanQuyenBLL = new BLL_QuanLyPhanQuyen(new Database().GetConnectionString());

            LoadDataPhanQuyen();
        }

        public void LoadDataPhanQuyen()
        {
            try
            {
                data_main.DataSource = PhanQuyenBLL.getListPhanQuyen();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error" , MessageBoxButtons.OK, MessageBoxIcon.Error);  
            }
        }
        private void button_CapNhat_Click(object sender, EventArgs e)
        {
            if (data_main.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn phân quyền trong bảng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                DialogResult resultDelete = MessageBox.Show("Bạn có chắc chắn muốn thay đổi thông tin này ! ", "Thông báo ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultDelete == DialogResult.Yes)
                {

                }
                PhanQuyen quyen = new PhanQuyen
                {
                    IDPhanQuyen = Convert.ToInt32(data_main.CurrentRow.Cells["IDPhanQuyen"].Value),
                    TenPhanQuyen = textBox_TenPhanQuyen.Text.Trim(),
                    MoTa = textBox_MoTa.Text.Trim()
                };
                PhanQuyenBLL.UpdateNewPhanQuyen(quyen);
                MessageBox.Show("Cập nhật thông tin phân quyền thành công !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataPhanQuyen();
                clearData();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_Them_Click(object sender, EventArgs e)
        {
            try
            {
                PhanQuyen quyen = new PhanQuyen
                {
                   
                    TenPhanQuyen = textBox_TenPhanQuyen.Text.Trim(),
                    MoTa = textBox_MoTa.Text.Trim()
                };

                PhanQuyenBLL.AddNewPhanQuyen(quyen);
                MessageBox.Show("Thêm phân quyền mới thành công !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataPhanQuyen();
                clearData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void clearData()
        {
            textBox_TenPhanQuyen.Clear();
            textBox_MoTa.Clear();
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
                textBox_TenPhanQuyen.Text = rowst.Cells["TenPhanQuyen"]?.Value?.ToString() ?? string.Empty;
                textBox_MoTa.Text = rowst.Cells["MoTa"]?.Value?.ToString() ?? string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_DonThongTin_Click(object sender, EventArgs e)
        {
            clearData();    
        }

        private void button_Xoa_Click(object sender, EventArgs e)
        {
            if (data_main.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn phân quyền trong bảng !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                DialogResult resultDelete = MessageBox.Show("Bạn có chắc chắn muốn xóa thông tin này ! ", "Thông báo ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultDelete == DialogResult.Yes)
                {

                    PhanQuyen quyen = new PhanQuyen
                    {
                        IDPhanQuyen = Convert.ToInt32(data_main.CurrentRow.Cells["IDPhanQuyen"].Value),
                      
                    };

                    PhanQuyenBLL.DeletePhanQuyen(quyen);
                    MessageBox.Show("Xóa thông tin phân quyền trong bảng thành công !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataPhanQuyen();
                    clearData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox_TimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string keyword = textBox_TimKiem.Text.Trim();
                DataTable dataTable = PhanQuyenBLL.searchListPhanQuyen(keyword);
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


                int resultCount = PhanQuyenBLL.CountListPhanQuyen(searchKeyword);
                MessageBox.Show($"Đã tìm thấy {resultCount} kết quả!", "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (resultCount > 0)
                {
                    // Hiển thị danh sách kết quả
                    DataTable dt = PhanQuyenBLL.searchListPhanQuyen(searchKeyword);
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

        private void pictureBox_Load_Click(object sender, EventArgs e)
        {
            LoadDataPhanQuyen();
            MessageBox.Show("Đã tải lại dữ liệu thành công ! ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
