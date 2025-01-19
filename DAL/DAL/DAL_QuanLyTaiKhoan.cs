using HeThongDocTruyen.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongDocTruyen.DAL
{
    public class DAL_QuanLyTaiKhoan
    {
        private string connectionString;
       
        public DAL_QuanLyTaiKhoan(string Dbconnection)
        {
            connectionString = Dbconnection;
        }
        public DataTable getAllTaiKhoan()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string getQuery = @"
            SELECT 
                TaiKhoan.IDTaiKhoan,
                TaiKhoan.TaiKhoan,
                TaiKhoan.MatKhau,
                TaiKhoan.HoTen,
                TaiKhoan.Email,
                TaiKhoan.GioiTinh,
                TaiKhoan.SDT,
                TaiKhoan.IDPhanQuyen,
                TaiKhoan.NgayTao,              
                PhanQuyen.TenPhanQuyen
            FROM 
                TaiKhoan
            INNER JOIN 
                PhanQuyen ON TaiKhoan.IDPhanQuyen = PhanQuyen.IDPhanQuyen";

                SqlDataAdapter adapter = new SqlDataAdapter(getQuery, connection);
                adapter.Fill(dt);
            }
            return dt;
        }

        public bool checkEmail(string Email)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string checkQuery = "SELECT COUNT(*) FROM TaiKhoan WHERE Email = @Email";
                SqlCommand checkcommand = new SqlCommand(checkQuery, connection);
                checkcommand.Parameters.AddWithValue("@Email", Email);
                return (int)checkcommand.ExecuteScalar() > 0;
            }
        }

        public bool AddTaiKhoan(TaiKhoan taikhoan)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string AddQuery = @"INSERT INTO TaiKhoan (TaiKhoan, MatKhau, HoTen, Email, GioiTinh, SDT, IDPhanQuyen, NgayTao)
                                VALUES (@TaiKhoans, @MatKhau, @HoTen, @Email, @GioiTinh, @SDT, @IDPhanQuyen, @NgayTao)";
                    using (SqlCommand Addcommand = new SqlCommand(AddQuery, connection))
                    {
                        Addcommand.Parameters.AddWithValue(@"TaiKhoans" , taikhoan.TaiKhoanNguoiDung);
                        Addcommand.Parameters.AddWithValue(@"MatKhau" , taikhoan.MatKhau);
                        Addcommand.Parameters.AddWithValue(@"HoTen", taikhoan.HoTen);
                        Addcommand.Parameters.AddWithValue(@"Email" , taikhoan.Email);
                        Addcommand.Parameters.AddWithValue(@"GioiTinh" , taikhoan.GioiTinh);
                        Addcommand.Parameters.AddWithValue(@"SDT" , taikhoan.SDT);
                        Addcommand.Parameters.AddWithValue(@"IDPhanQuyen" , taikhoan.IDPhanQuyen);
                        Addcommand.Parameters.AddWithValue(@"NgayTao" , taikhoan.NgayTao);
                                           
                        return Addcommand.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Lỗi khi thêm sản phẩm: " + ex.Message);
            }
        }

        public bool UpdateTaiKhoan(TaiKhoan taikhoan)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string updateQuery = @"UPDATE TaiKhoan 
                                   SET TaiKhoan = @TaiKhoans, 
                                       MatKhau = @MatKhau, 
                                       HoTen = @HoTen, 
                                       Email = @Email, 
                                       GioiTinh = @GioiTinh,
                                       SDT = @SDT,
                                       IDPhanQuyen = @IDPhanQuyen,
                                       NgayTao = @NgayTao
                                   WHERE IDTaiKhoan = @MaTaiKhoan";
                    using (SqlCommand Addcommand = new SqlCommand(updateQuery, connection))
                    {
                        Addcommand.Parameters.AddWithValue(@"MaTaiKhoan", taikhoan.IDTaiKhoan);
                        Addcommand.Parameters.AddWithValue(@"TaiKhoans", taikhoan.TaiKhoanNguoiDung);
                        Addcommand.Parameters.AddWithValue(@"MatKhau", taikhoan.MatKhau);
                        Addcommand.Parameters.AddWithValue(@"HoTen", taikhoan.HoTen);
                        Addcommand.Parameters.AddWithValue(@"Email", taikhoan.Email);
                        Addcommand.Parameters.AddWithValue(@"GioiTinh", taikhoan.GioiTinh);
                        Addcommand.Parameters.AddWithValue(@"SDT", taikhoan.SDT);
                        Addcommand.Parameters.AddWithValue(@"IDPhanQuyen", taikhoan.IDPhanQuyen);
                        Addcommand.Parameters.AddWithValue(@"NgayTao", taikhoan.NgayTao);

                        return Addcommand.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Lỗi khi cập nhật truyện: " + ex.Message);
            }
        }



        public bool DeleteTaiKhoan(TaiKhoan taikhoan)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string DeleteQuery = "DELETE FROM TaiKhoan WHERE IDTaiKhoan = @MaTaiKhoan";
                SqlCommand deleteCommand = new SqlCommand(DeleteQuery, connection);
                deleteCommand.Parameters.AddWithValue("@MaTaiKhoan", taikhoan.IDTaiKhoan);
                return deleteCommand.ExecuteNonQuery() > 0;
            }
        }

        public DataTable SearchTaiKhoan(string keyword)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
        SELECT 
            TaiKhoan.IDTaiKhoan,
            TaiKhoan.NgayTao,
            TaiKhoan.IDPhanQuyen,
            PhanQuyen.TenPhanQuyen
            TaiKhoan.TaiKhoan,
            TaiKhoan.MatKhau,
            TaiKhoan.HoTen,
            TaiKhoan.Email,
            TaiKhoan.GioiTinh,
            TaiKhoan.SDT
        FROM 
            TaiKhoan
        INNER JOIN 
            PhanQuyen ON TaiKhoan.IDPhanQuyen = PhanQuyen.IDPhanQuyen
        WHERE 
            TaiKhoan.TaiKhoan LIKE @Keyword 
            OR TaiKhoan.IDPhanQuyen LIKE @Keyword
            OR TaiKhoan.IDTaiKhoan LIKE @Keyword
            OR TaiKhoan.NgayTao LIKE @Keyword
            OR TaiKhoan.MatKhau LIKE @Keyword
            OR TaiKhoan.HoTen LIKE @Keyword
            OR TaiKhoan.Email LIKE @Keyword
            OR TaiKhoan.GioiTinh LIKE @Keyword
            OR TaiKhoan.SDT LIKE @Keyword
            OR PhanQuyen.TenPhanQuyen LIKE @Keyword";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }



        public int CountTaiKhoan(string keyword)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT COUNT(*) FROM 
            TaiKhoan
        INNER JOIN 
            PhanQuyen ON TaiKhoan.IDPhanQuyen = PhanQuyen.IDPhanQuyen
        WHERE 
            TaiKhoan.TaiKhoan LIKE @Keyword 
            OR TaiKhoan.IDPhanQuyen LIKE @Keyword
            OR TaiKhoan.IDTaiKhoan LIKE @Keyword
            OR TaiKhoan.NgayTao LIKE @Keyword
            OR TaiKhoan.MatKhau LIKE @Keyword
            OR TaiKhoan.HoTen LIKE @Keyword
            OR TaiKhoan.Email LIKE @Keyword
            OR TaiKhoan.GioiTinh LIKE @Keyword
            OR TaiKhoan.SDT LIKE @Keyword
            OR PhanQuyen.TenPhanQuyen LIKE @Keyword";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                    return (int)command.ExecuteScalar();
                }
            }
        }



    }
}
