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
    public partial class ThongKeTruyen : UserControl
    {
        Database db = new Database();
        public ThongKeTruyen()
        {
            InitializeComponent();
            LoadTopTruyen();
        }
      
        private void LoadTopTruyen()
        {
            string connectionString = db.GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT IDTruyen, TenTruyen, AnhTruyen, SoLuotDoc FROM Truyen ORDER BY SoLuotDoc DESC"; 
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

              
                flowLayoutPanel_TopTruyen.Controls.Clear();

                while (reader.Read())
                {
                    Panel truyenPanel = new Panel
                    {
                        Width = 200,
                        Height = 300,
                        Margin = new Padding(5)
                    };

                    PictureBox pictureBox = new PictureBox
                    {
                        Width = 200,
                        Height = 200,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Image = Image.FromFile(reader["AnhTruyen"].ToString()) 
                    };

                    Label lblTenTruyen = new Label
                    {
                        Text = reader["TenTruyen"].ToString(),
                        Dock = DockStyle.Bottom,
                        Height = 30,
                        Font = new Font("Arial", 12, FontStyle.Bold),
                        TextAlign = ContentAlignment.MiddleCenter
                    };

                    Label lblSoLuotDoc = new Label
                    {
                        Text = $"Lượt đọc: {reader["SoLuotDoc"]}",
                        Dock = DockStyle.Bottom,
                        Height = 20,
                        Font = new Font("Arial", 10),
                        TextAlign = ContentAlignment.MiddleCenter
                    };                                                    
                    truyenPanel.Controls.Add(lblSoLuotDoc);
                    truyenPanel.Controls.Add(lblTenTruyen);                  
                    truyenPanel.Controls.Add(pictureBox);

                    flowLayoutPanel_TopTruyen.Controls.Add(truyenPanel); 
                }
            }
        }

        private void pictureBox_Load_Click(object sender, EventArgs e)
        {
            LoadTopTruyen();
            MessageBox.Show("Đã tải lại dữ liệu danh sách thành công ! ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
