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
    public partial class ChiTietTruyen : UserControl
    {
        Database db = new Database(); // tạo đối tượng Database

        private int idTruyen; // khai báo biến idTruyen
        private string connectionString; // khai báo biến connectionString
        private int idTaiKhoan; // khai báo biến idTaiKhoan
        public ChiTietTruyen(int idTruyen, string connectionString, int idTaiKhoan) // tạo hàm khởi tạo
        {
            InitializeComponent(); // khởi tạo các thành phần giao diện
            this.idTruyen = idTruyen; // gán giá trị idTruyen
            this.connectionString = connectionString; // gán giá trị connectionString
            this.idTaiKhoan = idTaiKhoan; // gán giá trị idTaiKhoan
            LoadChiTietTruyen(); // gọi hàm LoadChiTietTruyen
            LoadChuongTruyen(); // gọi hàm LoadChuongTruyen
            SetupBinhLuanControls(); // gọi hàm SetupBinhLuanControls
            LoadDanhSachBinhLuan(); // gọi hàm LoadDanhSachBinhLuan
        }
        private void LoadChiTietTruyen() // Tạo hàm load chi tiết thông tin truyện
        {
            using (SqlConnection connection = new SqlConnection(connectionString)) // Tạo kết nối qua SqlConnection
            {
                string query = "SELECT * FROM Truyen WHERE IDTruyen = @IDTruyen"; // Tạo câu lệnh truy vấn
                SqlCommand command = new SqlCommand(query, connection); // Tạo đối tượng SqlCommand
                command.Parameters.AddWithValue("@IDTruyen", idTruyen); // Thêm tham số @IDTruyen

                connection.Open(); // Mở kết nối
                SqlDataReader reader = command.ExecuteReader(); // Thực thi câu lệnh truy vấn
                if (reader.Read()) // Nếu có dữ liệu 
                {
                    // HIển thị ra các thông tin truyện như bên dưới 

                    lblTenTruyen.Text = reader["TenTruyen"].ToString(); // Hiển thị tên truyện
                    lblTacGia.Text = "Tác giả: " + reader["TacGia"].ToString(); // Hiển thị tác giả
                    lblMoTa.Text = "Mô tả: " + reader["MoTa"].ToString(); // Hiển thị mô tả
                    lblMoTa.MaximumSize = new Size(flowLayoutPanel_MoTa.Width - 20, 0); // Đặt kích thước tối đa
                    lblMoTa.AutoSize = true; // Cho phép tự động xuống dòng
                    pictureBoxTruyen.Image = Image.FromFile(reader["AnhTruyen"].ToString()); // Hiển thị ảnh truyện
                }
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------------------
        private void LoadChuongTruyen() // Hảm tải các chương truyện 
        {
          
            flowLayoutPanel_Chuong.Controls.Clear(); // Xóa các control trong flowLayoutPanel_Chuong

         
            flowLayoutPanel_Chuong.FlowDirection = FlowDirection.LeftToRight; // Đặt hướng của flowLayoutPanel_Chuong
            flowLayoutPanel_Chuong.WrapContents = true; // Cho phép tự động xuống dòng
            flowLayoutPanel_Chuong.AutoScroll = true; // Cho phép cuộn

            using (SqlConnection connection = new SqlConnection(connectionString)) // Tạo kết nối qua SqlConnection
            {
                string query = "SELECT * FROM ChuongTruyen WHERE IDTruyen = @IDTruyen ORDER BY IDChuong ASC"; // Tạo câu lệnh truy vấn
                SqlCommand command = new SqlCommand(query, connection); // Tạo đối tượng SqlCommand
                command.Parameters.AddWithValue("@IDTruyen", idTruyen); // Thêm tham số @IDTruyen

                connection.Open(); // Mở kết nối
                SqlDataReader reader = command.ExecuteReader(); // Thực thi câu lệnh truy vấn
                while (reader.Read()) // Nếu có dữ liệu thì hiển thị nút chương truyện bên dưới 
                {
                    // Nút chương truyện 
                    Button btnChuong = new Button // Tạo nút chương truyện
                    {
                        Text = reader["TenChuong"].ToString(), // Hiển thị tên chương
                        Tag = reader["IDChuong"], // Gán tag là IDChuong
                        Height = 30, // Đặt chiều cao
                        Width = 100, // Đặt chiều rộng
                        TextAlign = ContentAlignment.MiddleCenter, // Đặt vị trí chữ
                        FlatStyle = FlatStyle.Flat, // Đặt kiểu nút
                        Font = new Font("Arial", 10), // Đặt font chữ
                        BackColor = Color.MidnightBlue, // Đặt màu nền
                        ForeColor = Color.White, // Đặt màu chữ
                        AutoSize = true, // Cho phép tự động điều chỉnh kích thước
                        FlatAppearance = // Đặt kiểu nút
                        {
                            BorderSize = 0 // Đặt kích thước viền
                        }
                    };
                    btnChuong.Click += BtnChuong_Click; // Gán sự kiện click cho nút chương truyện

                   
                    flowLayoutPanel_Chuong.Controls.Add(btnChuong); // Thêm nút chương vào flowLayoutPanel_Chuong
                }
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------------------

        private void BtnChuong_Click(object sender, EventArgs e) // Hàm xử lý sự kiện click vào nút chương truyện
        {
            Button btn = (Button)sender; // Lấy ra nút chương truyện
            int idChuong = (int)btn.Tag; // Lấy ra IDChuong

            using (SqlConnection connection = new SqlConnection(connectionString)) // Tạo kết nối qua SqlConnection
            {
                string query = "SELECT TenChuong, NoiDung FROM ChuongTruyen WHERE IDChuong = @IDChuong"; // Tạo câu lệnh truy vấn
                SqlCommand command = new SqlCommand(query, connection); // Tạo đối tượng SqlCommand
                command.Parameters.AddWithValue("@IDChuong", idChuong); // Thêm tham số @IDChuong

                connection.Open(); // Mở kết nối
                SqlDataReader reader = command.ExecuteReader(); // Thực thi câu lệnh truy vấn
                if (reader.Read()) // Nếu có dữ liệu thì hiển thị nội dung chương truyện
                {
                    string tenChuong = reader["TenChuong"].ToString();
                    string noiDung = reader["NoiDung"].ToString();

                
                   NoiDungChuongTruyen noiDungChuongForm = new NoiDungChuongTruyen(idTruyen,tenChuong, noiDung); // Chạy qua form nội dung của chương truyện 
                   this.Controls.Clear(); // Xóa các control trong form
                    this.Controls.Add(noiDungChuongForm); // Thêm form nội dung chương truyện vào form
                    noiDungChuongForm.Dock = DockStyle.Fill; // Đặt form nội dung chương truyện full
                }
            }
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------------------
        // NÚt quay lại form cũ 
        private void button_QuayLai_Click(object sender, EventArgs e) // Hàm xử lý sự kiện click vào nút quay lại
        {
            this.Controls.Clear(); // Xóa các control trong form
                                          
            ManHinhChinh userForm = new ManHinhChinh(); // Quay lại form màn hình chính 
            this.Controls.Add(userForm); // 
            userForm.Dock = DockStyle.Fill;
        }
        //---------------
        //---------------------------------------------------------------------------------------------------------------------------------------------------------
        private void SetupBinhLuanControls() // Hàm thiết lập các control bình luận
        {
            flowLayoutPanel_BinhLuan.Controls.Clear(); // Xóa các control trong flowLayoutPanel_BinhLuan

            TextBox txtBinhLuan = new TextBox // Tạo textbox bình luận
            {
                Multiline = true, // Cho phép nhập nhiều dòng
                Width = 300, // Đặt chiều rộng
                Height = 150, // Đặt chiều cao
                Font = new Font("Arial", 10) // Đặt font chữ
            };
            flowLayoutPanel_BinhLuan.Controls.Add(txtBinhLuan); // Thêm textbox vào flowLayoutPanel_BinhLuan

            ComboBox cbSoSao = new ComboBox // Tạo combobox số sao
            {
                Width = 100, // Đặt chiều rộng
                DropDownStyle = ComboBoxStyle.DropDownList // Đặt kiểu combobox
            };
            cbSoSao.Items.AddRange(new object[] { 1, 2, 3, 4, 5 }); // Thêm các số sao vào combobox
            cbSoSao.SelectedIndex = 4; // Đặt số sao mặc định
            flowLayoutPanel_BinhLuan.Controls.Add(cbSoSao); // Thêm combobox vào flowLayoutPanel_BinhLuan

            Button btnGuiBinhLuan = new Button // Tạo nút gửi bình luận
            {
                Text = "Gửi bình luận", // Hiển thị nội dung
                FlatStyle = FlatStyle.Flat, // Đặt kiểu nút
                Font = new Font("Arial", 10), // Đặt font chữ
                BackColor = Color.FromArgb(16, 55, 92), // Đặt màu nền
                Width = 300, // Đặt chiều rộng
                ForeColor = Color.White, // Đặt màu chữ
                Height = 30, // Đặt chiều cao
                FlatAppearance = // Đặt kiểu nút
                {
                    BorderSize = 0 // Đặt kích thước viền
                }
            };
            btnGuiBinhLuan.Click += (sender, e) => // Gán sự kiện click cho nút gửi bình luận
            {
                string noiDung = txtBinhLuan.Text.Trim(); // Lấy nội dung bình luận
                if (cbSoSao.SelectedItem == null) // Nếu chưa chọn số sao
                {
                    MessageBox.Show("Vui lòng chọn số sao.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int soSao = (int)cbSoSao.SelectedItem; // Lấy số sao

                if (string.IsNullOrEmpty(noiDung)) // Nếu nội dung bình luận rỗng
                {
                    MessageBox.Show("Vui lòng nhập nội dung bình luận.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SaveBinhLuan(noiDung, soSao); // Lưu bình luận
                txtBinhLuan.Clear(); // Xóa nội dung bình luận
            };
            flowLayoutPanel_BinhLuan.Controls.Add(btnGuiBinhLuan); // Thêm nút gửi bình luận vào form
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------------------

        private void SaveBinhLuan(string noiDung, int soSao) // Hàm lưu bình luận
        {
            using (SqlConnection connection = new SqlConnection(connectionString)) // Tạo kết nối qua SqlConnection
            {
                string checkTaiKhoanQuery = "SELECT COUNT(1) FROM TaiKhoan WHERE IDTaiKhoan = @IDTaiKhoan"; // Tạo câu lệnh truy vấn
                SqlCommand checkCommand = new SqlCommand(checkTaiKhoanQuery, connection); // Tạo đối tượng SqlCommand
                checkCommand.Parameters.AddWithValue("@IDTaiKhoan", idTaiKhoan); // Thêm tham số @IDTaiKhoan

                connection.Open(); // Mở kết nối
                int exists = (int)checkCommand.ExecuteScalar(); // Thực thi câu lệnh truy vấn

                if (exists == 0) // Nếu tài khoản không tồn tại
                {
                    MessageBox.Show("Tài khoản không tồn tại."); // Thông báo
                    return;
                }

                string query = @"INSERT INTO BinhLuanDanhGia (NoiDung, NgayBinhLuan, IDTaiKhoan, IDTruyen, SoSao)
                         VALUES (@NoiDung, @NgayBinhLuan, @IDTaiKhoan, @IDTruyen, @SoSao)"; // Tạo câu lệnh truy vấn
                SqlCommand command = new SqlCommand(query, connection); // Tạo đối tượng SqlCommand
                command.Parameters.AddWithValue("@NoiDung", noiDung); // Thêm tham số @NoiDung
                command.Parameters.AddWithValue("@NgayBinhLuan", DateTime.Now); // Thêm tham số @NgayBinhLuan
                command.Parameters.AddWithValue("@IDTaiKhoan", idTaiKhoan); // Thêm tham số @IDTaiKhoan
                command.Parameters.AddWithValue("@IDTruyen", idTruyen); // Thêm tham số @IDTruyen
                command.Parameters.AddWithValue("@SoSao", soSao);// Thêm tham số @SoSao

                int rowsAffected = command.ExecuteNonQuery(); // Thực thi câu lệnh truy vấn
                if (rowsAffected > 0) // Nếu thêm thành công
                {
                    MessageBox.Show("Bình luận đã được gửi thành công." , "Thông báo " , MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachBinhLuan();  // Tải lại danh sách bình luận
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra. Vui lòng thử lại.");
                }
            }
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------------------
        private void LoadDanhSachBinhLuan() // Hàm tải danh sách bình luận 
        {
            flowLayoutPanel_DanhSachBinhLuan.Controls.Clear(); // Xóa các control trong flowLayoutPanel_DanhSachBinhLuan

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString)) // Tạo kết nối qua SqlConnection
                {
                    string query = @"SELECT b.NoiDung, b.NgayBinhLuan, b.SoSao, t.TaiKhoan
                             FROM BinhLuanDanhGia b
                             INNER JOIN TaiKhoan t ON b.IDTaiKhoan = t.IDTaiKhoan
                             WHERE b.IDTruyen = @IDTruyen
                             ORDER BY b.NgayBinhLuan DESC"; // Tạo câu lệnh truy vấn
                    SqlCommand command = new SqlCommand(query, connection); // Tạo đối tượng SqlCommand
                    command.Parameters.AddWithValue("@IDTruyen", idTruyen); // Thêm tham số @IDTruyen

                    connection.Open(); // Mở kết nối
                    SqlDataReader reader = command.ExecuteReader(); // Thực thi câu lệnh truy vấn

                    while (reader.Read()) // Nếu có dữ liệu thì hiển thị danh sách bình luận
                    {
                        string tenDangNhap = reader["TaiKhoan"]?.ToString() ?? "Ẩn danh"; // Lấy tên đăng nhập
                        string noiDung = reader["NoiDung"]?.ToString() ?? "Không có nội dung"; // Lấy nội dung
                        int soSao = reader["SoSao"] != DBNull.Value ? Convert.ToInt32(reader["SoSao"]) : 0; // Lấy số sao
                        DateTime ngayBinhLuan = reader["NgayBinhLuan"] != DBNull.Value // Lấy ngày bình luận
                            ? Convert.ToDateTime(reader["NgayBinhLuan"]) // Nếu có thì lấy
                            : DateTime.MinValue; // Nếu không thì lấy giá trị mặc định

                        Panel panelBinhLuan = new Panel // Tạo panel bình luận
                        {
                            Width = flowLayoutPanel_DanhSachBinhLuan.Width - 20,
                            Height = 100,
                            BackColor = Color.White,
                        };

                        Label lblTenDangNhap = new Label // Tạo label tên đăng nhập
                        {
                            Text = $"Tài khoản: {tenDangNhap}",
                            AutoSize = true,
                            Font = new Font("Arial", 11, FontStyle.Bold)
                        };
                        panelBinhLuan.Controls.Add(lblTenDangNhap);

                        Label lblSoSao = new Label // Tạo label số sao
                        {
                            Text = $"Số sao: {soSao}/5",
                            AutoSize = true,
                            Top = lblTenDangNhap.Bottom + 5,
                            Font = new Font("Arial", 10)
                        };
                        panelBinhLuan.Controls.Add(lblSoSao);

                        Label lblNoiDung = new Label // Tạo label nội dung
                        {
                            Text = $"Nội dung : {noiDung} ",
                            AutoSize = true,
                            Top = lblSoSao.Bottom + 5,
                            MaximumSize = new Size(panelBinhLuan.Width - 10, 0),
                            Font = new Font("Arial", 10)
                        };
                        panelBinhLuan.Controls.Add(lblNoiDung);

                        Label lblNgayBinhLuan = new Label // Tạo label ngày bình luận
                        {
                            Text = $"Ngày: {ngayBinhLuan:dd/MM/yyyy}",
                            AutoSize = true,
                            Top = lblNoiDung.Bottom + 5
                        };
                        panelBinhLuan.Controls.Add(lblNgayBinhLuan);

                        flowLayoutPanel_DanhSachBinhLuan.Controls.Add(panelBinhLuan); // Thêm panel bình luận vào FORM
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách bình luận: {ex.Message}");
            }
        }


        //----------
    }
}
