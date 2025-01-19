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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace HeThongDocTruyen.UI
{
    public partial class FormDangKy : Form
    {
        Database db = new Database();
        public FormDangKy()
        {
            InitializeComponent();
        }

        // ----------------------------------------------------------------------------------------------------------------------------------
        private void checkBox_pass_CheckedChanged(object sender, EventArgs e)
        {
            textBox_MatKhau.PasswordChar = checkBox_pass.Checked ? '\0' : '*';
        }

        // ----------------------------------------------------------------------------------------------------------------------------------
        private void button_DangKy_Click(object sender, EventArgs e)
        {
            string tenThanhVien = textBox_Ten.Text.Trim();
            string email = textBox_email.Text.Trim();
            string matKhau = textBox_MatKhau.Text.Trim();
            string sdt = textBox_SoDienThoai.Text.Trim();

            // Kiểm tra dữ liệu hợp lệ
            if (string.IsNullOrWhiteSpace(tenThanhVien) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(matKhau) || string.IsNullOrWhiteSpace(sdt))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(sdt, @"^\d{10}$"))
            {
                MessageBox.Show("Số điện thoại không hợp lệ! Vui lòng nhập 10 chữ số.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Hash mật khẩu
              

                string connectionString = db.GetConnectionString();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        INSERT INTO TaiKhoan (TaiKhoan, Email, MatKhau, SDT, IDPhanQuyen,NgayTao)
                        VALUES (@TenTaiKhoan, @Email, @MatKhau, @SDT, @MaQuyen, @NgayTao)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TenTaiKhoan", tenThanhVien);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@MatKhau", matKhau);
                        cmd.Parameters.AddWithValue("@SDT", sdt);
                        cmd.Parameters.AddWithValue("@MaQuyen", 2);
                        cmd.Parameters.AddWithValue("@NgayTao", DateTime.Now);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Đăng ký thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                MessageBox.Show("Tài khoản đã tồn tại. Vui lòng chọn tài khoản khác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ----------------------------------------------------------------------------------------------------------------------------------
      
    }
}
