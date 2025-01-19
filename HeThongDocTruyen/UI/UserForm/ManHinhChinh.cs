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
    public partial class ManHinhChinh : UserControl
    {
        //----------------------------------------------------------------------------------------------------------------------------------------

        // Kết nối Database
        Database db = new Database(); // Khởi tạo kết nối Database
        public ManHinhChinh()
        {
            InitializeComponent();
            LoadDanhMuc(); // Hàm load các danh mục 
            LoadComboBoxTheLoai(); // hàm load các combo thể loại 
        }


        //----------------------------------------------------------------------------------------------------------------------------------------
        // Hàm tải dữ liệu danh mục 

        private void LoadDanhMuc()
        {
            flowLayoutPanel_DanhMuc.Controls.Clear(); // Xóa nội dung cũ để load khi có nội dung mới 

            string connectionString = db.GetConnectionString(); // Lấy chuỗi kết nối từ Database

            using (SqlConnection connection = new SqlConnection(connectionString)) // Mở kết nối
            {
                connection.Open(); // Mở kết nối

                string query = "SELECT * FROM DanhMucTruyen"; // Lấy danh sách danh mục
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection); // Tạo adapter để lấy dữ liệu
                DataTable danhMucTable = new DataTable(); // Tạo bảng để chứa dữ liệu
                adapter.Fill(danhMucTable); // Đổ dữ liệu vào bảng

                foreach (DataRow row in danhMucTable.Rows) // Duyệt từng dòng trong bảng
                {
                    Panel panel = new Panel // Tạo panel để chứa danh sách truyện
                    {
                        Width = flowLayoutPanel_DanhMuc.Width - 10, 
                        Height = 400,                       
                        Padding = new Padding(10)
                    };

                    Label lblDanhMuc = new Label // Tạo label để hiển thị tên danh mục
                    {
                        Text = row["TenDanhMuc"].ToString(), // 
                        Font = new Font("Arial", 14, FontStyle.Bold),
                        Dock = DockStyle.Top,
                        Height = 30
                    };

                    FlowLayoutPanel flowLayoutPanel_Truyen = new FlowLayoutPanel // Tạo flowLayoutPanel để chứa truyện
                    {
                        Dock = DockStyle.Fill,
                        AutoScroll = true
                    };

                    int idDanhMuc = (int)row["IDDanhMuc"]; // Lấy ID danh mục
                    LoadTruyenByDanhMuc(flowLayoutPanel_Truyen, idDanhMuc); // Load truyện theo danh mục

                    panel.Controls.Add(flowLayoutPanel_Truyen); // Thêm flowLayoutPanel vào panel
                    panel.Controls.Add(lblDanhMuc); // Thêm label vào panel

                    flowLayoutPanel_DanhMuc.Controls.Add(panel); // Thêm panel vào flowLayoutPanel
                }
            }
        }


        //----------------------------------------------------------------------------------------------------------------------------------------
        // Hàm tải dữ liệu truyện theo danh mục 


        private void LoadTruyenByDanhMuc(FlowLayoutPanel flowLayoutPanel, int idDanhMuc) // Hàm load truyện theo danh mục
        {
            string connectionString = db.GetConnectionString(); // Lấy chuỗi kết nối từ Database
            using (SqlConnection connection = new SqlConnection(connectionString)) // Mở kết nối
            {
                string query = "SELECT * FROM Truyen WHERE IDDanhMuc = @IDDanhMuc ORDER BY NgayDang DESC"; // Lấy truyện theo danh mục
                SqlCommand command = new SqlCommand(query, connection); // Tạo command để thực thi truy vấn
                command.Parameters.AddWithValue("@IDDanhMuc", idDanhMuc); // Thêm tham số cho truy vấn

                connection.Open(); // Mở kết nối
                SqlDataReader reader = command.ExecuteReader(); // Thực thi truy vấn

                while (reader.Read()) // Duyệt từng dòng trong kết quả truy vấn
                {
                    Panel truyenPanel = new Panel // Tạo panel để chứa thông tin truyện
                    {
                        Width = 200,
                        Height = 300,
                        Margin = new Padding(10)
                    };

                    PictureBox pictureBox = new PictureBox // Tạo pictureBox để hiển thị ảnh truyện
                    {
                        Width = 200,
                        Height = 300,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Image = Image.FromFile(reader["AnhTruyen"].ToString()) 
                    };

                    Label lblTenTruyen = new Label // Tạo label để hiển thị tên truyện
                    {
                        Text = reader["TenTruyen"].ToString(),
                        Dock = DockStyle.Bottom,
                        Height = 30,
                        Font = new Font("Arial", 12 , FontStyle.Bold),
                        TextAlign = ContentAlignment.MiddleCenter
                    };

                    Button btnTruyen = new Button // Tạo button để xem chi tiết truyện
                    {
                        Text = "Xem chi tiết",
                        Dock = DockStyle.Bottom,
                        Height = 30,
                        Tag = reader["IDTruyen"],
                        FlatStyle = FlatStyle.Flat, 
                        ForeColor = Color.Black,
                        Font = new Font("Arial", 12),
                        BackColor = Color.Transparent 
                    };

                    btnTruyen.FlatAppearance.BorderSize = 1;  // Điều chỉnh viền nút
                    btnTruyen.FlatAppearance.BorderColor = Color.Black; // Điều chỉnh màu viền nút
                    btnTruyen.Click += BtnTruyen_Click; // Gắn sự kiện khi click vào nút

                    //Hiển thị dữ liệu +  Điều chỉnh vị trí hiện thông tin 
                    truyenPanel.Controls.Add(lblTenTruyen); // Thêm label vào panel
                    truyenPanel.Controls.Add(btnTruyen); // Thêm button vào panel
                    truyenPanel.Controls.Add(pictureBox); //    Thêm pictureBox vào panel

                    flowLayoutPanel.Controls.Add(truyenPanel); // Thêm truyện mới vào flowLayoutPanel
                }
            }
        }


        //----------------------------------------------------------------------------------------------------------------------------------------

        // NÚt xem chi tiết truyện và load + 1 lượt xem vào bảng "truyện" thông qua sự kiện Click 
        private void BtnTruyen_Click(object sender, EventArgs e) // Sự kiện khi click vào nút xem chi tiết truyện
        {
            Button btn = (Button)sender; // Lấy nút được click
            int idTruyen = (int)btn.Tag; // Lấy ID truyện từ Tag của nút
            IncrementSoLuotDoc(idTruyen); // Tăng số lượt đọc lên 1
         

            int idTaiKhoan = ThongTinSession.IDTaiKhoan; // Lấy ID tài khoản từ session
            ChiTietTruyen chiTietForm = new ChiTietTruyen(idTruyen, db.GetConnectionString(), idTaiKhoan); // Tạo form chi tiết truyện
            this.Controls.Clear();   // Xóa nội dung cũ
            this.Controls.Add(chiTietForm); // Thêm form chi tiết truyện vào form chính
            chiTietForm.Dock = DockStyle.Fill; // Điều chỉnh kích thước form chi tiết truyện

            AddLichSuDoc(idTaiKhoan, idTruyen); // Thêm lịch sử đọc truyện
        }

        //----------------------------------------------------------------------------------------------------------------------------------------

        // Hàm tăng lượt xem lên 1 và lưu vào bảng Truyện khi click nút xem chi tiết 
        private void IncrementSoLuotDoc(int idTruyen) // Hàm tăng số lượt đọc lên 1
        {
            string connectionString = db.GetConnectionString(); // Lấy chuỗi kết nối từ Database
            using (SqlConnection connection = new SqlConnection(connectionString)) // Mở kết nối
            {
                string query = "UPDATE Truyen SET SoLuotDoc = SoLuotDoc + 1 WHERE IDTruyen = @IDTruyen"; // Cập nhật số lượt đọc

                SqlCommand command = new SqlCommand(query, connection); // Tạo command để thực thi truy vấn
                command.Parameters.AddWithValue("@IDTruyen", idTruyen); // Thêm tham số cho truy vấn

                connection.Open(); // Mở kết nối
                command.ExecuteNonQuery(); // Thực thi truy vấn
            }
        }

        //----------------------------------------------------------------------------------------------------------------------------------------
        // Hàm lưu lại thông tin xem truyện và lưu vào bảng lịch sử đọc truyện 
        private void AddLichSuDoc(int idTaiKhoan, int idTruyen) // Hàm thêm lịch sử đọc truyện
        {
            try 
            {
                string connectionString = db.GetConnectionString(); // Lấy chuỗi kết nối từ Database

                using (SqlConnection connection = new SqlConnection(connectionString)) // Mở kết nối
                {
                    connection.Open(); // Mở kết nối
                    string query = @" 
                INSERT INTO LichSuDoc (IDTaiKhoan, IDTruyen, NgayDoc)
                VALUES (@IDTaiKhoan, @IDTruyen, @NgayDoc)"; // Thêm lịch sử đọc truyện

                    using (SqlCommand cmd = new SqlCommand(query, connection)) // Tạo command để thực thi truy vấn
                    {
                        cmd.Parameters.AddWithValue("@IDTaiKhoan", idTaiKhoan); // Thêm tham số ID tài khoản
                        cmd.Parameters.AddWithValue("@IDTruyen", idTruyen); // Thêm tham số ID truyện
                        cmd.Parameters.AddWithValue("@NgayDoc", DateTime.Now.Date); // Thêm tham số ngày đọc

                        cmd.ExecuteNonQuery(); // Thực thi truy vấn
                    }
                }
            }
            catch (Exception ex) // Bắt lỗi khi thêm lịch sử đọc truyện
            {
                MessageBox.Show("Lỗi khi thêm lịch sử đọc truyện: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); // Thông báo lỗi
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------------------

        private void pictureBox_Load_Click(object sender, EventArgs e) // Sự kiện khi click vào nút load
        {
            LoadDanhMuc(); // Load lại danh mục
        }


        //----------------------------------------------------------------------------------------------------------------------------------------

        // Hàm load dữ liệu vào comboBox các thể loại truyện 
        private void LoadComboBoxTheLoai() // Hàm load các thể loại truyện vào comboBox
        {
            string connectionString = db.GetConnectionString(); // Lấy chuỗi kết nối từ Database
            using (SqlConnection connection = new SqlConnection(connectionString)) // Mở kết nối
            {
                connection.Open(); // Mở kết nối

                string query = "SELECT IDTheLoai, TenTheLoai FROM TheLoaiTruyen"; // Lấy danh sách thể loại
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection); // Tạo adapter để lấy dữ liệu
                DataTable theLoaiTable = new DataTable(); // Tạo bảng để chứa dữ liệu
                adapter.Fill(theLoaiTable); // Đổ dữ liệu vào bảng

                DataRow allRow = theLoaiTable.NewRow();
                allRow["IDTheLoai"] = -1; // ID đặc biệt cho "Tất cả"
                allRow["TenTheLoai"] = "Tất cả"; // Tên đặc biệt cho "Tất cả"
                theLoaiTable.Rows.InsertAt(allRow, 0); // Thêm "Tất cả" vào đầu danh sách

                // Gán dữ liệu vào ComboBox
                comboBox_ChonTheLoai.DataSource = theLoaiTable; // Gán dữ liệu vào comboBox
                comboBox_ChonTheLoai.DisplayMember = "TenTheLoai"; // Hiển thị tên thể loại
                comboBox_ChonTheLoai.ValueMember = "IDTheLoai";   // Giá trị là ID thể loại

                // Gắn sự kiện khi người dùng chọn thể loại
                comboBox_ChonTheLoai.SelectedIndexChanged += comboBox_ChonTheLoai_SelectedIndexChanged; // Gắn sự kiện khi chọn thể loại (hàm lọc theo thể loại )
            }
        }


        //----------------------------------------------------------------------------------------------------------------------------------------
        // Hàm thực thị gọi dữ liệu theo mục đã chọn ở comboBox
        private void comboBox_ChonTheLoai_SelectedIndexChanged(object sender, EventArgs e) // Sự kiện khi chọn thể loại truyện
        {
            if (comboBox_ChonTheLoai.SelectedValue is int selectedTheLoaiId) // Lấy ID thể loại được chọn
            {
                if (selectedTheLoaiId == -1) // Nếu chọn "Tất cả"
                {
                    // Hiển thị tất cả truyện nếu chọn "Tất cả"
                    LoadDanhMuc();
                }
                else
                {
                    // Hiển thị danh sách truyện theo thể loại
                    ShowTruyenByTheLoai(selectedTheLoaiId);
                }
            }
        }

        //----------------------------------------------------------------------------------------------------------------------------------------
        // Hàm hiển thị truyện theo COmboBox
        private void ShowTruyenByTheLoai(int idTheLoai) // Hàm hiển thị truyện theo thể loại
        {
            flowLayoutPanel_DanhMuc.Controls.Clear(); // Xóa nội dung cũ

            string connectionString = db.GetConnectionString(); // Lấy chuỗi kết nối từ Database
            using (SqlConnection connection = new SqlConnection(connectionString)) // Mở kết nối
            {
                string query = "SELECT * FROM Truyen WHERE IDTheLoai = @IDTheLoai ORDER BY NgayDang DESC"; // Truyện thuộc thể loại
                SqlCommand command = new SqlCommand(query, connection); // Tạo command để thực thi truy vấn
                command.Parameters.AddWithValue("@IDTheLoai", idTheLoai); // Thêm tham số cho truy vấn

                connection.Open(); // Mở kết nối
                SqlDataReader reader = command.ExecuteReader(); // Thực thi truy vấn

                while (reader.Read()) // Duyệt từng dòng trong kết quả truy vấn
                {
                    Panel truyenPanel = new Panel // Tạo panel để chứa thông tin truyện
                    {
                        Width = 200,
                        Height = 300,
                        Margin = new Padding(10)
                    };

                    PictureBox pictureBox = new PictureBox // Tạo pictureBox để hiển thị ảnh truyện
                    {
                        Width = 200,
                        Height = 300,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Image = Image.FromFile(reader["AnhTruyen"].ToString())
                    };

                    Label lblTenTruyen = new Label // Tạo label để hiển thị tên truyện
                    {
                        Text = reader["TenTruyen"].ToString(),
                        Dock = DockStyle.Bottom,
                        Height = 30,
                        Font = new Font("Arial", 12, FontStyle.Bold),
                        TextAlign = ContentAlignment.MiddleCenter
                    };

                    Button btnTruyen = new Button // Tạo button để xem chi tiết truyện
                    {
                        Text = "Xem chi tiết",
                        Dock = DockStyle.Bottom,
                        Height = 30,
                        Tag = reader["IDTruyen"],
                        FlatStyle = FlatStyle.Flat,
                        ForeColor = Color.Black,
                        Font = new Font("Arial", 12),
                        BackColor = Color.Transparent
                    };
                    btnTruyen.FlatAppearance.BorderSize = 1; // Điều chỉnh viền nút
                    btnTruyen.FlatAppearance.BorderColor = Color.Black; // Điều chỉnh màu viền nút
                    btnTruyen.Click += BtnTruyen_Click; // Gắn sự kiện khi click vào nút

                    truyenPanel.Controls.Add(lblTenTruyen); // Thêm label vào panel
                    truyenPanel.Controls.Add(btnTruyen); // Thêm button vào panel
                    truyenPanel.Controls.Add(pictureBox); // Thêm pictureBox vào panel

                    flowLayoutPanel_DanhMuc.Controls.Add(truyenPanel); // Thêm truyện mới vào flowLayoutPanel
                }
            }
        }

        //----------------------------------------------------------------------------------------------------------------------------------------

    }
}
