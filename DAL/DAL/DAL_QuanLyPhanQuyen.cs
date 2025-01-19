using HeThongDocTruyen.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongDocTruyen.DAL
{
    public class DAL_QuanLyPhanQuyen
    {
        private string connectionString;

        public DAL_QuanLyPhanQuyen(string Dbconnection)
        {
            connectionString = Dbconnection;    
        }

        public DataTable getAllPhanQuyen()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string getQuery = "SELECT * FROM PhanQuyen";
                SqlDataAdapter adapter = new SqlDataAdapter(getQuery, connection);
                adapter.Fill(dt);
            }
            return dt;
        }

        // Kiểm tra tham số riêng biệt sai kiểu dữ liệu thay vì class
        public bool CheckPhanQuyen(string tenDanhMuc)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string checkQuery = "SELECT COUNT(*) FROM PhanQuyen WHERE TenPhanQuyen = @TenQuyen";
                SqlCommand checkcommand = new SqlCommand(checkQuery, connection);
                checkcommand.Parameters.AddWithValue("@TenQuyen", tenDanhMuc);
                return (int)checkcommand.ExecuteScalar() > 0;
            }
        }



        public bool AddPhanQuyen(PhanQuyen quyen)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string AddQuery = "INSERT INTO PhanQuyen (TenPhanQuyen , MoTa) VALUES (@TenQuyen , @MoTa)";
                SqlCommand AddCommand = new SqlCommand(AddQuery, connection);
                AddCommand.Parameters.AddWithValue("@TenQuyen", quyen.TenPhanQuyen);
                AddCommand.Parameters.AddWithValue("@MoTa", quyen.MoTa);
                return AddCommand.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdatePhanQuyen(PhanQuyen quyen)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string UpdateQuery = "UPDATE PhanQuyen SET TenPhanQuyen = @TenQuyen , MoTa = @MoTa WHERE IDPhanQuyen = @maQuyen";
                SqlCommand AddCommand = new SqlCommand(UpdateQuery, connection);
                AddCommand.Parameters.AddWithValue("@maQuyen", quyen.IDPhanQuyen);
                AddCommand.Parameters.AddWithValue("@TenQuyen", quyen.TenPhanQuyen);
                AddCommand.Parameters.AddWithValue("@MoTa", quyen.MoTa);
                return AddCommand.ExecuteNonQuery() > 0;
            }
        }


        public bool deletePhanQuyen(PhanQuyen quyen)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string DeleteQuery = "DELETE FROM PhanQuyen WHERE IDPhanQuyen = @maQuyen";
                SqlCommand AddCommand = new SqlCommand(DeleteQuery, connection);
                AddCommand.Parameters.AddWithValue("@maQuyen", quyen.IDPhanQuyen);
                return AddCommand.ExecuteNonQuery() > 0;
            }
        }

        public DataTable SearchQuyen(string keyword)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT * FROM PhanQuyen WHERE TenPhanQuyen LIKE @Keyword OR MoTa LIKE @Keyword";

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

        public int CountQuyen(string keyword)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*)FROM PhanQuyen WHERE TenPhanQuyen LIKE @Keyword OR MoTa LIKE @Keyword";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                    return (int)command.ExecuteScalar();
                }
            }
        }

    }
}
