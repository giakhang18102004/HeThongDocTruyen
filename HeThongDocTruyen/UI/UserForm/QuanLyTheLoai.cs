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
    public partial class QuanLyTheLoai : UserControl
    {
        Database db = new Database();

        private BLL_QuanLyTheLoai TheLoaiBLL;

        public QuanLyTheLoai()
        {
            InitializeComponent();

            TheLoaiBLL = new BLL_QuanLyTheLoai(new Database().GetConnectionString());

            LoadDataTheLoai();
        }

        public void LoadDataTheLoai()
        {
            try
            {
                data_main.DataSource = TheLoaiBLL.getListTHeLoai();

            } catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button_Them_Click(object sender, EventArgs e)
        {
            try
            {
                TheLoaiTruyen theLoai = new TheLoaiTruyen
                {
                    TenTheLoai = textBox_TenTheLoai.Text.Trim(),
                  
                };

                TheLoaiBLL.AddNewTheLoai(theLoai);
                MessageBox.Show("Thêm thể loại mới thành công !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataTheLoai();
                ClearData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ClearData()
        {
            textBox_TenTheLoai.Text = "";
        }
        private void button_CapNhat_Click(object sender, EventArgs e)
        {
            if (data_main.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn thể loại trong bảng !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                DialogResult resultDelete = MessageBox.Show("Bạn có chắc chắn muốn thay đổi thông tin này ! ", "Thông báo ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultDelete == DialogResult.Yes)
                {

                TheLoaiTruyen theLoai = new TheLoaiTruyen
                {
                    IDTheLoai = Convert.ToInt32(data_main.CurrentRow.Cells["IDTheLoai"].Value),
                    TenTheLoai = textBox_TenTheLoai.Text.Trim(),

                };

                TheLoaiBLL.UpdateNewTheLoai(theLoai);

                MessageBox.Show("Cập nhật thông tin thể loại thành công !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataTheLoai();
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
            try
            {
                DataGridViewRow rowst = data_main.Rows[e.RowIndex];


                textBox_TenTheLoai.Text = rowst.Cells["TenTheLoai"]?.Value != DBNull.Value ? rowst.Cells["TenTheLoai"].Value.ToString() : "";

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

                TheLoaiTruyen theLoai = new TheLoaiTruyen
                {
                    IDTheLoai = Convert.ToInt32(data_main.CurrentRow.Cells["IDTheLoai"].Value),
                    
                };

                TheLoaiBLL.DeleteTheLoai(theLoai);
                MessageBox.Show("Xóa thông tin thể loại trong bảng thành công !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataTheLoai();
                ClearData();
                }
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

        private void pictureBox_Load_Click(object sender, EventArgs e)
        {
            LoadDataTheLoai();
            MessageBox.Show("Đã tải lại dữ liệu thành công ! ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void textBox_TimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string keyword = textBox_TimKiem.Text.Trim();
                DataTable dataTable = TheLoaiBLL.SearchListTheLoai(keyword);
                data_main.DataSource = dataTable;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox_TimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string searchKeyword = textBox_TimKiem.Text.Trim();

                if (string.IsNullOrEmpty(searchKeyword))
                {
                    MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                int resultCount = TheLoaiBLL.CountListTheLoai(searchKeyword);
                MessageBox.Show($"Đã tìm thấy {resultCount} kết quả!", "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (resultCount > 0)
                {
                    // Hiển thị danh sách kết quả
                    DataTable dt = TheLoaiBLL.SearchListTheLoai(searchKeyword);
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
