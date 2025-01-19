using HeThongDocTruyen.Model;
using HeThongDocTruyen.Model.Database;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace HeThongDocTruyen.UI.UserForm
{
    public partial class NoiDungChuongTruyen : UserControl
    {

        //-----------------------------------------------------------------------------------------------------------------------------------
        // Khai báo đóng gói các biến truy vấn 
        private readonly Database db = new Database(); 
        private readonly int idTruyen; // biến xác định truyện đang chọn
        private readonly string connectionString; 

        //-----------------------------------------------------------------------------------------------------------------------------------
        // 
        public NoiDungChuongTruyen(int idTruyen, string tenChuong, string noiDung) 
        {
            InitializeComponent();
            this.idTruyen = idTruyen;
            this.connectionString = db.GetConnectionString(); // Đảm bảo connectionString được khởi tạo
            lblTenChuong.Text = tenChuong ?? "Chương chưa đặt tên";
            textBox_NoiDung.Text = noiDung ?? "Nội dung trống.";
            LoadChuongTruyen(); // Hàm load thông tin chương truyện trong Form Nội dung
        }
        //-----------------------------------------------------------------------------------------------------------------------------------
        private void LoadChuongTruyen() // Hàm load thông tin các chương truyện 
        {
            flowLayoutPanel_Chuong.Controls.Clear(); // Chỉ xóa các button của chương

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString)) // Kết nối thông qua Sqlconnection 
                {
                    connection.Open();
                    string query = "SELECT IDChuong, TenChuong FROM ChuongTruyen WHERE IDTruyen = @IDTruyen ORDER BY IDChuong ASC"; // Lệnh truy vấn lấy thông tin chương truyện 
                    using (SqlCommand command = new SqlCommand(query, connection)) // Thực hiện truy vấn thông qua Sqlcommand
                    {
                        command.Parameters.AddWithValue("@IDTruyen", idTruyen); // Lấy tham số mã truyện thông qua ID truyện 
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read()) // Nếu có dữ liệu 
                            {
                                // HIển thị ra thông tin các chương bên dưới 
                                Button btnChuong = new Button 
                                {
                                    Text = reader["TenChuong"]?.ToString() ?? "Chương không tên",
                                    Tag = reader["IDChuong"],
                                    Height = 40,
                                    Width = 150,
                                    TextAlign = ContentAlignment.MiddleCenter,
                                    FlatStyle = FlatStyle.Flat,
                                    Font = new Font("Arial", 10),
                                    BackColor = Color.MidnightBlue,
                                    ForeColor = Color.White,
                                    FlatAppearance = { BorderSize = 0 }
                                };
                                btnChuong.Click += BtnChuong_Click; // Nối với hàm hiển thị nội dung trong chương 
                                flowLayoutPanel_Chuong.Controls.Add(btnChuong);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách chương: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //-----------------------------------------------------------------------------------------------------------------------------------

        private void ClearOldControls()
        {
            foreach (Control control in flowLayoutPanel_Chuong.Controls)
            {
                control.Dispose(); // Xóa các button chương đã không còn sử dụng
            }
            flowLayoutPanel_Chuong.Controls.Clear();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        private void BtnChuong_Click(object sender, EventArgs e) // Hàm hiển thị nội dung chương truyện 
        {
            Button btn = (Button)sender; 
            int idChuong = Convert.ToInt32(btn.Tag);

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT TenChuong, NoiDung FROM ChuongTruyen WHERE IDChuong = @IDChuong";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IDChuong", idChuong);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Cập nhật nội dung chương lại 
                                lblTenChuong.Text = reader["TenChuong"]?.ToString() ?? "Chương không tên";
                                textBox_NoiDung.Text = reader["NoiDung"]?.ToString() ?? "Nội dung trống.";
                               
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy nội dung chương.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải nội dung chương: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //-----------------------------------------------------------------------------------------------------------------------------------
        //hàm xử lí nút quay lại 

        private void button_QuayLai_Click(object sender, EventArgs e)
        {
            try
            {
                this.Controls.Clear();
                ManHinhChinh userForm = new ManHinhChinh();
                this.Controls.Add(userForm);
                userForm.Dock = DockStyle.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi quay lại màn hình chính: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      

        //-----------------------------------------------------------------------------------------------------------------------------------


    }
}
