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
    public class DAL_QuanLyTruyen
    {
        private string connectionString;
        public DAL_QuanLyTruyen(string Dbconnection)
        {
            connectionString = Dbconnection;
        }

        public DataTable getallTruyen()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
             
                string getQuery = @"
            SELECT 
                Truyen.IDTruyen,
                Truyen.IDDanhMuc,
                Truyen.IDTheLoai,
                Truyen.TenTruyen,
                Truyen.AnhTruyen,
                Truyen.TacGia,
                Truyen.MoTa,
                Truyen.NgayDang,
                Truyen.SoLuotDoc,
                DanhMucTruyen.TenDanhMuc,
                TheLoaiTruyen.TenTheLoai
            FROM 
                Truyen
            INNER JOIN 
                DanhMucTruyen ON Truyen.IDDanhMuc = DanhMucTruyen.IDDanhMuc
            INNER JOIN 
                TheLoaiTruyen ON Truyen.IDTheLoai = TheLoaiTruyen.IDTheLoai;
        ";

             
                SqlDataAdapter adapter = new SqlDataAdapter(getQuery, connection);
                adapter.Fill(dataTable);
            }
            return dataTable;
        }

        public bool CheckTruyen(string TenTruyen)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string checkQuery = "SELECT COUNT(*) FROM Truyen WHERE TenTruyen = @TenTruyen";
                SqlCommand checkcommand = new SqlCommand(checkQuery, connection);
                checkcommand.Parameters.AddWithValue("@TenTruyen", TenTruyen);
                return (int)checkcommand.ExecuteScalar() > 0;
            }
        }

        public bool CheckDanhMuc(int idDanhMuc)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM DanhMucTruyen WHERE IDDanhMuc = @IDDanhMuc";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IDDanhMuc", idDanhMuc);
                    return (int)command.ExecuteScalar() > 0;
                }
            }
        }

        public bool CheckTheLoai(int idTheLoai)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM TheLoaiTruyen WHERE IDTheLoai = @IDTheLoai";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IDTheLoai", idTheLoai);
                    return (int)command.ExecuteScalar() > 0;
                }
            }
        }

        public bool AddTruyen(Truyen truyen)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string AddQuery = @"INSERT INTO Truyen (TenTruyen, AnhTruyen, TacGia, Mota, NgayDang, IDDanhMuc, IDTheLoai, SoLuotDoc)
                                VALUES (@TenTruyen, @AnhTruyen, @TacGia, @MoTa, @NgayDang, @IDDanhMuc, @IDTheLoai, @SoLuotDoc)";
                    using (SqlCommand Addcommand = new SqlCommand(AddQuery, connection))
                    {
                        Addcommand.Parameters.AddWithValue("@TenTruyen", truyen.TenTruyen);
                        Addcommand.Parameters.AddWithValue("@AnhTruyen", truyen.AnhTruyen);
                        Addcommand.Parameters.AddWithValue("@TacGia", truyen.TacGia);
                        Addcommand.Parameters.AddWithValue("@MoTa", truyen.MoTa);
                        Addcommand.Parameters.AddWithValue("@NgayDang", truyen.NgayDang);
                        Addcommand.Parameters.AddWithValue("@IDDanhMuc", truyen.IDDanhMuc);
                        Addcommand.Parameters.AddWithValue("@IDTheLoai", truyen.IDTheLoai);
                        Addcommand.Parameters.AddWithValue("@SoLuotDoc", truyen.SoLuotDoc);
                        return Addcommand.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Lỗi khi thêm sản phẩm: " + ex.Message);
            }
        }

        public bool UpdateTruyen(Truyen truyen)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string updateQuery = @"UPDATE Truyen 
                                   SET TenTruyen = @TenTruyen, 
                                       AnhTruyen = @AnhTruyen, 
                                       TacGia = @TacGia, 
                                       MoTa = @MoTa, 
                                       NgayDang = @NgayDang,
                                       IDDanhMuc = @MaDanhMuc,
                                       IDTheLoai = @MaTheLoai,
                                       SoLuotDoc = @SoLuotDoc
                                   WHERE IDTruyen = @MaTruyen";
                    using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                    {
                        updateCommand.Parameters.AddWithValue("@MaTruyen", truyen.IDTruyen); 
                        updateCommand.Parameters.AddWithValue("@TenTruyen", truyen.TenTruyen);
                        updateCommand.Parameters.AddWithValue("@AnhTruyen", truyen.AnhTruyen);
                        updateCommand.Parameters.AddWithValue("@TacGia", truyen.TacGia);
                        updateCommand.Parameters.AddWithValue("@MoTa", truyen.MoTa);
                        updateCommand.Parameters.AddWithValue("@NgayDang", truyen.NgayDang);
                        updateCommand.Parameters.AddWithValue("@MaDanhMuc", truyen.IDDanhMuc);
                        updateCommand.Parameters.AddWithValue("@MaTheLoai", truyen.IDTheLoai);
                        updateCommand.Parameters.AddWithValue("@SoLuotDoc", truyen.SoLuotDoc);

                        return updateCommand.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Lỗi khi cập nhật truyện: " + ex.Message);
            }
        }



        public bool DeleteTruyen(int maTruyen)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string DeleteQuery = "DELETE FROM Truyen WHERE IDTruyen = @maTruyen";
                SqlCommand deleteCommand = new SqlCommand(DeleteQuery, connection);
                deleteCommand.Parameters.AddWithValue("@maTruyen", maTruyen);
                return deleteCommand.ExecuteNonQuery() > 0;
            }
        }

        public DataTable SearchTruyen(string keyword)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
                SELECT 
                Truyen.IDTruyen,
                Truyen.IDDanhMuc,
                Truyen.IDTheLoai,
                Truyen.TenTruyen,
                Truyen.AnhTruyen,
                Truyen.TacGia,
                Truyen.MoTa,
                Truyen.NgayDang,
                Truyen.SoLuotDoc,
                DanhMucTruyen.TenDanhMuc,
                TheLoaiTruyen.TenTheLoai
            FROM 
                Truyen
            INNER JOIN 
                DanhMucTruyen ON Truyen.IDDanhMuc = DanhMucTruyen.IDDanhMuc
            INNER JOIN 
                TheLoaiTruyen ON Truyen.IDTheLoai = TheLoaiTruyen.IDTheLoai
                WHERE Truyen.IDTruyen LIKE @Keyword 
                OR Truyen.IDDanhMuc LIKE @Keyword
                OR Truyen.TenTruyen LIKE @Keyword 
                 OR Truyen.AnhTruyen LIKE @Keyword 
                OR Truyen.TacGia LIKE @Keyword 
                OR Truyen.MoTa LIKE @Keyword 
                OR Truyen.NgayDang LIKE @Keyword 
                OR Truyen.SoLuotDoc LIKE @Keyword 
                OR DanhMucTruyen.TenDanhMuc LIKE @Keyword 
                OR TheLoaiTruyen.TenTheLoai LIKE @Keyword 
                OR Truyen.IDTheLoai LIKE @Keyword";

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


        public int CountTruyen(string keyword)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT COUNT(*) FROM 
                Truyen
            INNER JOIN 
                DanhMucTruyen ON Truyen.IDDanhMuc = DanhMucTruyen.IDDanhMuc
            INNER JOIN 
                TheLoaiTruyen ON Truyen.IDTheLoai = TheLoaiTruyen.IDTheLoai
                WHERE Truyen.IDTruyen LIKE @Keyword 
                OR Truyen.IDDanhMuc LIKE @Keyword
                OR Truyen.TenTruyen LIKE @Keyword 
                 OR Truyen.AnhTruyen LIKE @Keyword 
                OR Truyen.TacGia LIKE @Keyword 
                OR Truyen.MoTa LIKE @Keyword 
                OR Truyen.NgayDang LIKE @Keyword 
                OR Truyen.SoLuotDoc LIKE @Keyword 
                OR DanhMucTruyen.TenDanhMuc LIKE @Keyword 
                OR TheLoaiTruyen.TenTheLoai LIKE @Keyword 
                OR Truyen.IDTheLoai LIKE @Keyword";


                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                    return (int)command.ExecuteScalar();
                }
            }
        }


    }
}
