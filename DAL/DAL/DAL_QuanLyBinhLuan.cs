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
    public class DAL_QuanLyBinhLuan
    {
        private string connectionString;

        public DAL_QuanLyBinhLuan(string Dbconnection)
        {
            connectionString = Dbconnection;    
        }

        // tải dữ liệu 
        public DataTable getAllBinhLuan()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string getQuery = @"
            SELECT 
                bl.IDBinhLuan,
                bl.NoiDung,
                bl.NgayBinhLuan,
                bl.IDTaiKhoan,
                bl.IDTruyen,
                bl.SoSao,
                t.TaiKhoan,  
                t.Email,     
                tr.TenTruyen 
            FROM 
                BinhLuanDanhGia bl
            JOIN 
                TaiKhoan t ON bl.IDTaiKhoan = t.IDTaiKhoan
            JOIN 
                Truyen tr ON bl.IDTruyen = tr.IDTruyen";
                SqlDataAdapter adapter = new SqlDataAdapter(getQuery, connection);
                adapter.Fill(dataTable);
            }
            return dataTable;
        }

        // hàm xoá 
        public bool DeleteDanhGia(BinhLuanDanhGia binhluan)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string DeleteQuery = "DELETE FROM BinhLuanDanhGia WHERE IDBinhLuan = @MaBinhLuan";
                SqlCommand AddCommand = new SqlCommand(DeleteQuery, connection);
                AddCommand.Parameters.AddWithValue("@MaBinhLuan",binhluan.IDBinhLuan);
                return AddCommand.ExecuteNonQuery() > 0;
            }
        }

        // tìm kiếm 
        public DataTable SearchDanhGia(string keyword)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
            SELECT 
                bl.IDBinhLuan,
                bl.NoiDung,
                bl.NgayBinhLuan,
                bl.IDTaiKhoan,
                bl.IDTruyen,
                bl.SoSao,
                t.TaiKhoan,  
                t.Email,     
                tr.TenTruyen 
            FROM 
                BinhLuanDanhGia bl
            JOIN 
                TaiKhoan t ON bl.IDTaiKhoan = t.IDTaiKhoan
            JOIN 
                Truyen tr ON bl.IDTruyen = tr.IDTruyen
            WHERE 
                bl.IDBinhLuan LIKE @Keyword OR 
                bl.NoiDung LIKE @Keyword OR 
                bl.NgayBinhLuan LIKE @Keyword OR 
                bl.IDTaiKhoan LIKE @Keyword OR 
                bl.IDTruyen LIKE @Keyword OR 
                bl.SoSao LIKE @Keyword OR 
                t.TaiKhoan LIKE @Keyword OR 
                t.Email LIKE @Keyword OR               
                tr.TenTruyen LIKE @Keyword
        ";

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


        public int CountDanhGia(string keyword)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query =  @"SELECT COUNT(*) FROM 
                BinhLuanDanhGia bl
            JOIN
                TaiKhoan t ON bl.IDTaiKhoan = t.IDTaiKhoan
            JOIN
                Truyen tr ON bl.IDTruyen = tr.IDTruyen
            WHERE
                bl.IDBinhLuan LIKE @Keyword OR
                bl.NoiDung LIKE @Keyword OR
                bl.NgayBinhLuan LIKE @Keyword OR
                bl.IDTaiKhoan LIKE @Keyword OR
                bl.IDTruyen LIKE @Keyword OR
                bl.SoSao LIKE @Keyword OR
                t.TaiKhoan LIKE @Keyword OR
                t.Email LIKE @Keyword OR
                tr.TenTruyen LIKE @Keyword";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                    return (int)command.ExecuteScalar();
                }
            }
        }



    }
}
