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
    public partial class QuanLyDanhGia : UserControl
    {
        Database db = new Database();
        private BLL_QuanLyBinhLuan BinhLuanBLL;    
        public QuanLyDanhGia()
        {
            InitializeComponent();
            BinhLuanBLL = new BLL_QuanLyBinhLuan(new Database().GetConnectionString());
            LoadBinhLuan();
        }
        private void LoadBinhLuan()
        {
            flowLayoutPanel_BinhLuan.Controls.Clear();
            string connectionString = db.GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
                   SELECT BinhLuanDanhGia.IDBinhLuan, BinhLuanDanhGia.NoiDung, 
                   BinhLuanDanhGia.NgayBinhLuan, TaiKhoan.TaiKhoan, 
                   BinhLuanDanhGia.SoSao, Truyen.TenTruyen
            FROM BinhLuanDanhGia
            INNER JOIN TaiKhoan ON BinhLuanDanhGia.IDTaiKhoan = TaiKhoan.IDTaiKhoan
            INNER JOIN Truyen ON BinhLuanDanhGia.IDTruyen = Truyen.IDTruyen
            ORDER BY BinhLuanDanhGia.NgayBinhLuan DESC";

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                  
                    Panel panel = new Panel
                    {
                        Width = 1200,
                        Height = 120,
                        Padding = new Padding(5),
                        Margin = new Padding(5),
                        BackColor = Color.White,
                        Tag = reader["IDBinhLuan"].ToString()
                    };

                  
                    Label lblTenTruyen = new Label
                    {
                        Text = "Tên truyện: " + reader["TenTruyen"].ToString(),
                        Font = new Font("Arial", 10, FontStyle.Italic),
                        Dock = DockStyle.Top,
                        Height = 20
                    };
                    lblTenTruyen.Click += (s, e) => Panel_Click(panel);

                 
                    Label lblTenTaiKhoan = new Label
                    {
                        Text = reader["TaiKhoan"].ToString(),
                        Font = new Font("Arial", 10, FontStyle.Bold),
                        Dock = DockStyle.Top,
                        Height = 20
                    };
                    lblTenTaiKhoan.Click += (s, e) => Panel_Click(panel);

                    
                    Label lblNoiDung = new Label
                    {
                        Text = "Nội dung bình luận: " + reader["NoiDung"].ToString(),
                        Font = new Font("Arial", 9),
                        Dock = DockStyle.Fill
                    };
                    lblNoiDung.Click += (s, e) => Panel_Click(panel);

                    DateTime ngayBinhLuan = Convert.ToDateTime(reader["NgayBinhLuan"]);
                    string ngayBinhLuanFormat = ngayBinhLuan.ToString("dd/MM/yyyy");

                  
                    Label lblNgayBinhLuan = new Label
                    {
                        Text = "Ngày bình luận: " + ngayBinhLuanFormat,
                        Font = new Font("Arial", 9),
                        Dock = DockStyle.Bottom,
                        Height = 20
                    };
                    lblNgayBinhLuan.Click += (s, e) => Panel_Click(panel);

                  
                    Label lblSoSao = new Label
                    {
                        Text = $"Số sao: {reader["SoSao"]}/5",
                        Font = new Font("Arial", 9),
                        Dock = DockStyle.Bottom,
                        Height = 20
                    };
                    lblSoSao.Click += (s, e) => Panel_Click(panel);

                   
                    panel.Controls.Add(lblNoiDung);
                    panel.Controls.Add(lblSoSao);
                    panel.Controls.Add(lblNgayBinhLuan);
                    panel.Controls.Add(lblTenTaiKhoan);
                    panel.Controls.Add(lblTenTruyen);
                 
                    panel.Click += (s, e) => Panel_Click(panel);                  
                    flowLayoutPanel_BinhLuan.Controls.Add(panel);
                }
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------
        private void Panel_Click(Panel clickedPanel)
        {          
            foreach (Panel panel in flowLayoutPanel_BinhLuan.Controls)
            {
                panel.BackColor = Color.White;
            }         
            if (clickedPanel != null)
            {
                clickedPanel.BackColor = Color.FromArgb(255, 131, 131);
            }
        }
        
        //----------------------------------------------------------------------------------------------------------------------------
        // NÚT XÓA BÌNH LUẬN 
        private void button_Xoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu không có bình luận nào được chọn
            if (flowLayoutPanel_BinhLuan.Controls.Count == 0)
            {
                MessageBox.Show("Không có bình luận để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }         
            Panel selectedPanel = flowLayoutPanel_BinhLuan.Controls.OfType<Panel>().FirstOrDefault(panel => panel.BackColor == Color.FromArgb(255, 131, 131));

            if (selectedPanel == null)
            {
                MessageBox.Show("Vui lòng chọn bình luận để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hiển thị thông báo xác nhận
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa bình luận này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {              
                string idBinhLuan = selectedPanel.Tag?.ToString(); 

                if (!string.IsNullOrEmpty(idBinhLuan))
                {
                    string connectionString = db.GetConnectionString();
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string query = "DELETE FROM BinhLuanDanhGia WHERE IDBinhLuan = @IDBinhLuan";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@IDBinhLuan", idBinhLuan);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {                           
                            flowLayoutPanel_BinhLuan.Controls.Remove(selectedPanel);
                            MessageBox.Show("Xóa bình luận thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa bình luận. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------
        private void textBox_TimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = textBox_TimKiem.Text.ToLower(); 

            flowLayoutPanel_BinhLuan.Controls.Clear();

            string connectionString = db.GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

              
                string query = @"
                SELECT BinhLuanDanhGia.IDBinhLuan, BinhLuanDanhGia.NoiDung, 
                BinhLuanDanhGia.NgayBinhLuan, TaiKhoan.TaiKhoan, 
                BinhLuanDanhGia.SoSao, Truyen.TenTruyen
                FROM BinhLuanDanhGia
                INNER JOIN TaiKhoan ON BinhLuanDanhGia.IDTaiKhoan = TaiKhoan.IDTaiKhoan
                INNER JOIN Truyen ON BinhLuanDanhGia.IDTruyen = Truyen.IDTruyen
                WHERE LOWER(BinhLuanDanhGia.NoiDung) LIKE @Keyword
                OR LOWER(TaiKhoan.TaiKhoan) LIKE @Keyword
                OR LOWER(Truyen.TenTruyen) LIKE @Keyword
                ORDER BY BinhLuanDanhGia.NgayBinhLuan DESC";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Keyword", $"%{keyword}%");

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                   
                    Panel panel = new Panel
                    {
                        Width = 1200,
                        Height = 120,
                        Padding = new Padding(5),
                        Margin = new Padding(5),
                        BackColor = Color.White,
                        Tag = reader["IDBinhLuan"].ToString() 
                    };

                 
                    Label lblTenTruyen = new Label
                    {
                        Text = "Tên truyện: " + reader["TenTruyen"].ToString(),
                        Font = new Font("Arial", 10, FontStyle.Italic),
                        Dock = DockStyle.Top,
                        Height = 20
                    };
                    lblTenTruyen.Click += (s, es) => Panel_Click(panel);

                    
                    Label lblTenTaiKhoan = new Label
                    {
                        Text = reader["TaiKhoan"].ToString(),
                        Font = new Font("Arial", 10, FontStyle.Bold),
                        Dock = DockStyle.Top,
                        Height = 20
                    };
                    lblTenTaiKhoan.Click += (s, es) => Panel_Click(panel);

                  
                    Label lblNoiDung = new Label
                    {
                        Text = "Nội dung bình luận: " + reader["NoiDung"].ToString(),
                        Font = new Font("Arial", 9),
                        Dock = DockStyle.Fill
                    };
                    lblNoiDung.Click += (s, es) => Panel_Click(panel);

                    DateTime ngayBinhLuan = Convert.ToDateTime(reader["NgayBinhLuan"]);
                    string ngayBinhLuanFormat = ngayBinhLuan.ToString("dd/MM/yyyy");

                    Label lblNgayBinhLuan = new Label
                    {
                        Text = "Ngày bình luận: " + ngayBinhLuanFormat,
                        Font = new Font("Arial", 9),
                        Dock = DockStyle.Bottom,
                        Height = 20
                    };
                    lblNgayBinhLuan.Click += (s, es) => Panel_Click(panel);

                 
                    Label lblSoSao = new Label
                    {
                        Text = $"Số sao: {reader["SoSao"]}/5",
                        Font = new Font("Arial", 9),
                        Dock = DockStyle.Bottom,
                        Height = 20
                    };
                    lblSoSao.Click += (s, es) => Panel_Click(panel);

                 
                    panel.Controls.Add(lblNoiDung);
                    panel.Controls.Add(lblSoSao);
                    panel.Controls.Add(lblNgayBinhLuan);
                    panel.Controls.Add(lblTenTaiKhoan);
                    panel.Controls.Add(lblTenTruyen);
                  
                    panel.Click += (s, es) => Panel_Click(panel);

                
                    flowLayoutPanel_BinhLuan.Controls.Add(panel);
                }
            }
        }

        //----------------------------------------------------------------------------------------------------------------------------
        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

     

        private void pictureBox_Load_Click(object sender, EventArgs e)
        {
            LoadBinhLuan();
            MessageBox.Show("Đã tải lại dữ liệu thành công ! ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //----------------------------------------------------------------------------------------------------------------------------
    }
}
