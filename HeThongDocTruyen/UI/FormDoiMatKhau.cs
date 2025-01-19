using HeThongDocTruyen.Model.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace HeThongDocTruyen.UI
{
    public partial class FormDoiMatKhau : Form
    {
        Database db = new Database();
        public FormDoiMatKhau()
        {
            InitializeComponent();
        }

        // ----------------------------------------------------------------------------------------------------------------------------------
        // Hàm check hiển thị và xem mật khẩu 
        private void checkBox_pass_CheckedChanged(object sender, EventArgs e)
        {
            txtmatkhau.PasswordChar = checkBox_pass.Checked ? '\0' : '*';
            txtXacNhan.PasswordChar = checkBox_pass.Checked ? '\0' : '*';
        }

        // ----------------------------------------------------------------------------------------------------------------------------------
        private void btn_XacNhan_Click(object sender, EventArgs e) // NÚt xác nhận thay đổi mật khẩu 
        {
            // các biến truy vấn 
            string InputtenThanhVien = textBox_email.Text.Trim();
            string InputMatKhauMoi = txtmatkhau.Text.Trim();
            string InputXacNhanMatKhau = txtXacNhan.Text.Trim();

            // Kiểm tra các trường nhập không rỗng 
            if (string.IsNullOrEmpty(InputtenThanhVien))
            {
                MessageBox.Show("Vui lòng nhập Email tài khoản !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(InputMatKhauMoi) || string.IsNullOrEmpty(InputXacNhanMatKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (InputMatKhauMoi != InputXacNhanMatKhau)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu không khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            // Biến mã hóa mật khẩu 
          

            string connectionString = db.GetConnectionString(); // Biến kết nối 

            string checkQuery = "SELECT COUNT(*) FROM TaiKhoan WHERE Email = @Email"; // Biến kiểm tra tài khoản đã có hay chưa 

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@Email", InputtenThanhVien);

                        int count = (int)checkCommand.ExecuteScalar();

                        if (count == 0)
                        {
                            MessageBox.Show("Không tìm thấy thành viên có Email của tài khoản này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Nếu thông tin tồn tại, thực hiện cập nhật mật khẩu

                    string updateQuery = "UPDATE TaiKhoan SET MatKhau = @MatKhau WHERE Email = @TenEmail";

                    using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                    {
                        updateCommand.Parameters.AddWithValue("@TenEmail", InputtenThanhVien);
                        updateCommand.Parameters.AddWithValue("@MatKhau", InputMatKhauMoi);

                        int rowsAffected = updateCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Không thể đổi mật khẩu! Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi đổi mật khẩu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        // ----------------------------------------------------------------------------------------------------------------------------------




        // ----------------------------------------------------------------------------------------------------------------------------------
    }
}
