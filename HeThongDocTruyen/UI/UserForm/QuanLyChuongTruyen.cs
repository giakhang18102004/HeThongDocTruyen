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
    public partial class QuanLyChuongTruyen : UserControl
    {
        Database db = new Database();

        private BLL_QuanLyChuongTruyen ChuongTruyenBLL;

        private Timer TruyenTimer;
        public QuanLyChuongTruyen()
        {
            InitializeComponent();

            ChuongTruyenBLL = new BLL_QuanLyChuongTruyen(new Database().GetConnectionString());

            LoadDataChuongTruyen();

            TruyenTimer = new Timer();
            TruyenTimer.Interval = 1000;
            TruyenTimer.Tick += (s, e) => LoadChonTruyen();
            TruyenTimer.Start();
        }

        private void LoadChonTruyen()
        {
            string connectionString = new Database().GetConnectionString();
            string query = "SELECT IDTruyen, TenTruyen FROM Truyen";

            // Lưu giá trị đã chọn trước đó
            var selectedValue = comboBox_ChonTruyen.SelectedValue;

            SqlDataAdapter da = new SqlDataAdapter(query, connectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);

            comboBox_ChonTruyen.DisplayMember = "TenTruyen";
            comboBox_ChonTruyen.ValueMember = "IDTruyen";
            comboBox_ChonTruyen.DataSource = dt;

            // Kiểm tra nếu DataTable có dữ liệu
            if (dt.Rows.Count > 0)
            {
                if (selectedValue != null && dt.AsEnumerable().Any(row => row["IDTruyen"].ToString() == selectedValue.ToString()))
                {
                    comboBox_ChonTruyen.SelectedValue = selectedValue;
                }
                else
                {
                    comboBox_ChonTruyen.SelectedIndex = 0;
                }
            }
            else
            {
                // Nếu không có dữ liệu, xóa DataSource để tránh lỗi
                comboBox_ChonTruyen.DataSource = null;
            }
        }


        public void LoadDataChuongTruyen()
        {
            try
            {
                data_main.DataSource = ChuongTruyenBLL.getListChuongTruyen();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);   
            }
        }

        private void pictureBox_Load_Click(object sender, EventArgs e)
        {
            LoadDataChuongTruyen();
        }

        public void clearData()
        {
            textBox_TenChuong.Clear();
            textBox_NoiDung.Clear();
            comboBox_ChonTruyen.SelectedValue = -1;
        }

        private void button_DonThongTin_Click(object sender, EventArgs e)
        {
            clearData();
        }

        private void button_Them_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox_ChonTruyen.SelectedValue == null )
                {
                    MessageBox.Show("Vui lòng chọn truyện hợp lệ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ChuongTruyen chuong = new ChuongTruyen
                {
                    TenChuong = textBox_TenChuong.Text,
                    NoiDung = textBox_NoiDung.Text,
                    IDTruyen = (int)comboBox_ChonTruyen.SelectedValue,
                };
                          
                ChuongTruyenBLL.AddNewChuong(chuong);

                LoadDataChuongTruyen();
                clearData();

                MessageBox.Show("Thêm chương truyện thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm chương truyện: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_CapNhat_Click(object sender, EventArgs e)
        {
            if (data_main.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn chương truyện trong bảng để cập nhật thay đổi !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try 
            {
                DialogResult resultUpdate = MessageBox.Show("Bạn có chắc chắn muốn cập nhật thông tin này ? ", "Thông báo ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultUpdate == DialogResult.Yes)
                {
                    ChuongTruyen chuong = new ChuongTruyen
                    {
                        IDChuong = Convert.ToInt32(data_main.CurrentRow.Cells["IDChuong"].Value),
                        TenChuong = textBox_TenChuong.Text,
                        NoiDung = textBox_NoiDung.Text,
                        IDTruyen = (int)comboBox_ChonTruyen.SelectedValue,
                    };

                    ChuongTruyenBLL.UpdateNewChuong(chuong);

                    LoadDataChuongTruyen();

                    clearData();

                    MessageBox.Show("Cập nhật thông tin chương truyện thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }           
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật chương truyện: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                textBox_TenChuong.Text = rowst.Cells["TenChuong"]?.Value?.ToString() ?? string.Empty;
            
                textBox_NoiDung.Text = rowst.Cells["NoiDung"]?.Value?.ToString() ?? string.Empty;
                            
                if (rowst.Cells["IDTruyen"]?.Value != null && rowst.Cells["IDTruyen"].Value != DBNull.Value)
                {
                    int manhomsp = Convert.ToInt32(rowst.Cells["IDTruyen"].Value);
                    comboBox_ChonTruyen.SelectedValue = manhomsp;
                }
                else
                {
                    comboBox_ChonTruyen.SelectedIndex = -1;
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
                MessageBox.Show("Vui lòng chọn chương truyện trong bảng để xóa !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DialogResult resultUpdate = MessageBox.Show("Bạn có chắc chắn muốn xóa thông tin này ? ", "Thông báo ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultUpdate == DialogResult.Yes)
                {
                    ChuongTruyen chuong = new ChuongTruyen
                    {
                        IDChuong = Convert.ToInt32(data_main.CurrentRow.Cells["IDChuong"].Value),
                    };

                    ChuongTruyenBLL.DeleteNowChuong(chuong);
                    MessageBox.Show("Xóa thông tin chương truyện thành công !", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataChuongTruyen();
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
                DataTable dataTable = ChuongTruyenBLL.SearchListChuong(keyword);
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


                int resultCount = ChuongTruyenBLL.CountListChuong(searchKeyword);
                MessageBox.Show($"Đã tìm thấy {resultCount} kết quả!", "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (resultCount > 0)
                {
                    // Hiển thị danh sách kết quả
                    DataTable dt = ChuongTruyenBLL.SearchListChuong(searchKeyword);
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
