using HeThongDocTruyen.Model;
using HeThongDocTruyen.Model.Database;
using HeThongDocTruyen.UI.ThanhVien;
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
    public partial class FormDangNhap : Form
    {
        Database db = new Database();
        public FormDangNhap()
        {
            InitializeComponent();
        }



        // ----------------------------------------------------------------------------------------------------------------------------------
        // NÚT ĐĂNG KÝ 
        private void button1_Click(object sender, EventArgs e)
        {
            FormDangKy dangKy = new FormDangKy();   
            dangKy.ShowDialog();
        }

        // ----------------------------------------------------------------------------------------------------------------------------------
        private void forgot_password_Click(object sender, EventArgs e)
        {
            FormDoiMatKhau doiMatKhau = new FormDoiMatKhau();
            doiMatKhau.ShowDialog();
        }

        // ----------------------------------------------------------------------------------------------------------------------------------
        private void checkBox_pass_CheckedChanged(object sender, EventArgs e)
        {
            textBox_MatKhau.PasswordChar = checkBox_pass.Checked ? '\0' : '*';
        }

        // ----------------------------------------------------------------------------------------------------------------------------------
        private void button_DangNhap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_Email.Text) || string.IsNullOrWhiteSpace(textBox_MatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập thông tin để đăng nhập!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string connectionString = db.GetConnectionString();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Hash mật khẩu người dùng nhập
                  

                    string selectData = "SELECT * FROM TaiKhoan WHERE Email = @Email AND MatKhau = @matkhau";

                    using (SqlCommand cmd = new SqlCommand(selectData, connection))
                    {
                        cmd.Parameters.AddWithValue("@Email", textBox_Email.Text.Trim());
                        cmd.Parameters.AddWithValue("@matkhau", textBox_MatKhau.Text.Trim());

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        if (table.Rows.Count == 1)
                        {
                            ThongTinSession.TaiKhoan = textBox_Email.Text.Trim();
                            ThongTinSession.IDTaiKhoan = Convert.ToInt32(table.Rows[0]["IDTaiKhoan"]);
                            int maPQ = Convert.ToInt32(table.Rows[0]["IDPhanQuyen"]);

                            if (maPQ == 1)
                            {
                                MessageBox.Show("Đăng nhập thành công!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                TrangChinhHeThong mainForm = new TrangChinhHeThong();
                                mainForm.Show();
                            }
                            else if (maPQ == 2)
                            {
                                MessageBox.Show("Đăng nhập thành công!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                TrangChinhThanhVien mainForm = new TrangChinhThanhVien();
                                mainForm.Show();
                            }
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Đăng nhập thất bại: Sai tên tài khoản hoặc mật khẩu!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Connecting Database: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // ----------------------------------------------------------------------------------------------------------------------------------
      
        // ----------------------------------------------------------------------------------------------------------------------------------
        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // ----------------------------------------------------------------------------------------------------------------------------------
    }
}
