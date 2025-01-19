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
    public class DAL_QuanLyDanhMuc
    {
        private string connectionString;

        public DAL_QuanLyDanhMuc(string DbConnection)
        {
            connectionString = DbConnection;
        }

        public DataTable getAllDanhMuc()
        {
            DataTable dt = new DataTable();
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string getQuery = "SELECT * FROM DanhMucTruyen";
                SqlDataAdapter adapter = new SqlDataAdapter(getQuery,connection);
                adapter.Fill(dt);
            }
            return dt;
        }

        // Kiểm tra tham số riêng biệt sai kiểu dữ liệu thay vì class
        public bool CheckDanhMuc(string tenDanhMuc)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string checkQuery = "SELECT COUNT(*) FROM DanhMucTruyen WHERE TenDanhMuc = @TenDanhMuc";
                SqlCommand checkcommand = new SqlCommand(checkQuery, connection);
                checkcommand.Parameters.AddWithValue("@TenDanhMuc", tenDanhMuc);
                return (int)checkcommand.ExecuteScalar() > 0;
            }
        }



        public bool AddDanhMuc(DanhMucTruyen danhmuc)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string AddQuery = "INSERT INTO DanhMucTruyen (TenDanhMuc , MoTa) VALUES (@TenDanhMuc , @MoTa)";
                SqlCommand AddCommand = new SqlCommand(AddQuery, connection);
                AddCommand.Parameters.AddWithValue("@TenDanhMuc", danhmuc.TenDanhMuc);
                AddCommand.Parameters.AddWithValue("@MoTa", danhmuc.MoTa);
                return AddCommand.ExecuteNonQuery() > 0;
            }
        }
       
        public bool UpdateDanhMuc(DanhMucTruyen danhmuc)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string UpdateQuery = "UPDATE DanhMucTruyen SET TenDanhMuc = @TenDanhMuc , MoTa = @MoTa WHERE IDDanhMuc = @MaDanhMuc";
                SqlCommand AddCommand = new SqlCommand(UpdateQuery, connection);
                AddCommand.Parameters.AddWithValue("@MaDanhMuc", danhmuc.IDDanhMuc);
                AddCommand.Parameters.AddWithValue("@TenDanhMuc", danhmuc.TenDanhMuc);
                AddCommand.Parameters.AddWithValue("@MoTa", danhmuc.MoTa);
                return AddCommand.ExecuteNonQuery() > 0;
            }
        }


        public bool deleteDanhMuc(DanhMucTruyen danhmuc)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string DeleteQuery = "DELETE FROM DanhMucTruyen WHERE IDDanhMuc = @MaDanhMuc";
                SqlCommand AddCommand = new SqlCommand(DeleteQuery, connection);
                AddCommand.Parameters.AddWithValue("@MaDanhMuc", danhmuc.IDDanhMuc);
                return AddCommand.ExecuteNonQuery() > 0;
            }
        }

        public DataTable SearchDanhMuc(string keyword)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT * FROM DanhMucTruyen WHERE TenDanhMuc LIKE @Keyword OR MoTa LIKE @Keyword";

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

        public int CountDanhMuc(string keyword)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*)FROM DanhMucTruyen WHERE TenDanhMuc LIKE @Keyword OR MoTa LIKE @Keyword";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                    return (int)command.ExecuteScalar();
                }
            }
        }



    }
}
