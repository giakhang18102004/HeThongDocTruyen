using HeThongDocTruyen.Model;
using HeThongDocTruyen.Model.Database;
using HeThongDocTruyen.UI.UserForm;
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

namespace HeThongDocTruyen.UI
{
    public partial class XemLichSuDocTruyen : Form
    {
        Database db = new Database();

        private int idTaiKhoan;

        private List<int> displayedTruyenIds = new List<int>();

        public XemLichSuDocTruyen(int idTaiKhoan = 0)
        {
            InitializeComponent();

            this.idTaiKhoan = idTaiKhoan == 0 ? ThongTinSession.IDTaiKhoan : idTaiKhoan;

            LoadLichSuDoc();
        }
        private void LoadLichSuDoc()
        {
            try
            {
                string connectionString = db.GetConnectionString();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                        SELECT Truyen.IDTruyen, Truyen.TenTruyen, Truyen.AnhTruyen
                        FROM LichSuDoc
                        INNER JOIN Truyen ON LichSuDoc.IDTruyen = Truyen.IDTruyen
                        WHERE LichSuDoc.IDTaiKhoan = @IDTaiKhoan
                        ORDER BY LichSuDoc.NgayDoc DESC";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@IDTaiKhoan", idTaiKhoan);

                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            int idTruyen = (int)reader["IDTruyen"];


                            if (displayedTruyenIds.Contains(idTruyen))
                            {
                                continue;
                            }


                            displayedTruyenIds.Add(idTruyen);


                            Panel panel = new Panel
                            {
                                Width = 200,
                                Height = 300,
                                Margin = new Padding(10)
                            };


                            PictureBox pictureBox = new PictureBox
                            {
                                ImageLocation = reader["AnhTruyen"].ToString(),
                                SizeMode = PictureBoxSizeMode.StretchImage,
                                Width = 180,
                                Height = 180,
                                Margin = new Padding(5)
                            };


                            Label labelTenTruyen = new Label
                            {
                                Text = reader["TenTruyen"].ToString(),
                                Width = 180,
                                Height = 30,
                                TextAlign = ContentAlignment.MiddleCenter,
                                Font = new Font("Arial", 12, FontStyle.Bold),
                                Margin = new Padding(5)
                            };


                            Button btnXemTiep = new Button
                            {
                                Text = "Xem tiếp",
                                Dock = DockStyle.Bottom,
                                Height = 30,
                                Tag = reader["IDTruyen"],
                                FlatStyle = FlatStyle.Flat,
                                ForeColor = Color.Black,
                                Font = new Font("Arial", 12),
                                BackColor = Color.Transparent
                            };


                            btnXemTiep.Click += BtnXemTiep_Click;


                            FlowLayoutPanel flowPanel = new FlowLayoutPanel
                            {
                                Dock = DockStyle.Fill,
                                FlowDirection = FlowDirection.TopDown,
                                Padding = new Padding(0)
                            };


                            flowPanel.Controls.Add(pictureBox);
                            flowPanel.Controls.Add(labelTenTruyen);
                            flowPanel.Controls.Add(btnXemTiep);


                            panel.Controls.Add(flowPanel);


                            flowLayoutPanelLichSuDoc.Controls.Add(panel);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải lịch sử đọc: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnXemTiep_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int idTruyen = (int)btn.Tag;

          
            IncrementSoLuotDoc(idTruyen);

          
            int idTaiKhoan = ThongTinSession.IDTaiKhoan;
            ChiTietTruyen chiTietForm = new ChiTietTruyen(idTruyen, db.GetConnectionString(), idTaiKhoan);
            chiTietForm.Show();

           
            this.Close(); 
        }

        //----------------------------------------------------------------------------------------------------------------------------------------

        // Hàm tăng lượt xem lên 1 và lưu vào bảng Truyện khi click nút xem chi tiết 
        private void IncrementSoLuotDoc(int idTruyen)
        {
            string connectionString = db.GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Truyen SET SoLuotDoc = SoLuotDoc + 1 WHERE IDTruyen = @IDTruyen";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IDTruyen", idTruyen);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        //----------------------------------------------------------------------------------------------------------------------------------------

        private void pictureBox_Load_Click(object sender, EventArgs e)
        {
            LoadLichSuDoc();
            MessageBox.Show("Đã tải lại dữ liệu thành công ! ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
