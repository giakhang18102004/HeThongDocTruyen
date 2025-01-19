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

namespace HeThongDocTruyen.UI
{
    public partial class ThongTinTaiKhoan : Form
    {
        Database db = new Database();


        private int idTaiKhoan;
        public ThongTinTaiKhoan(int idTaiKhoan)
        {
            InitializeComponent();
            this.idTaiKhoan = idTaiKhoan;
            LoadThongTinCaNhan();
        }

        private void LoadThongTinCaNhan()
        {
            try
            {
                string connectionString = db.GetConnectionString();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                SELECT TaiKhoan, MatKhau, GioiTinh, SDT, HoTen, Email, NgayTao, 
                       TaiKhoan.IDPhanQuyen, ISNULL(TenPhanQuyen, N'Chưa có quyền') AS TenPhanQuyen
                FROM TaiKhoan
                LEFT JOIN PhanQuyen ON TaiKhoan.IDPhanQuyen = PhanQuyen.IDPhanQuyen
                WHERE TaiKhoan.IDTaiKhoan = @idTaiKhoan";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@idTaiKhoan", idTaiKhoan);

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            txtTaiKhoan.Text = reader["TaiKhoan"].ToString();
                            txtMatKhau.Text = reader["MatKhau"].ToString();
                            txtGioiTinh.Text = reader["GioiTinh"].ToString();
                            txtSDT.Text = reader["SDT"].ToString();
                            txtHoTen.Text = reader["HoTen"].ToString();
                            txtEmail.Text = reader["Email"].ToString();
                            txtNgayTao.Text = reader["NgayTao"].ToString();
                            txtMaTruyCap.Text = reader["IDPhanQuyen"] == DBNull.Value ? "Chưa có" : reader["IDPhanQuyen"].ToString();
                            txtQuyen.Text = reader["TenPhanQuyen"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy thông tin cá nhân.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ThongTinTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadThongTinCaNhan();
        }

        private void button_QuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_ThayDoi_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = db.GetConnectionString();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                UPDATE TaiKhoan
                SET HoTen = @HoTen, GioiTinh = @GioiTinh, SDT = @SDT
                WHERE IDTaiKhoan = @IDTaiKhoan";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text);
                        cmd.Parameters.AddWithValue("@GioiTinh", txtGioiTinh.Text);
                        cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
                        cmd.Parameters.AddWithValue("@IDTaiKhoan", idTaiKhoan);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Không có thay đổi nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.Close();   
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật thông tin: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
