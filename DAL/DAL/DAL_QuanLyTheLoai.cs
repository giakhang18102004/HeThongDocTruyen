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
    public class DAL_QuanLyTheLoai
    {
        private string connectionString;

        public DAL_QuanLyTheLoai(string Dbconnection)
        {
            connectionString = Dbconnection;
        }

        public DataTable getAllTheLoai()
        {
            DataTable dt = new DataTable();
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string getQuery = "SELECT * FROM TheLoaiTruyen";
                SqlDataAdapter adapter = new SqlDataAdapter(getQuery, connection);
                adapter.Fill(dt);
            }
            return dt;
        }

        public bool CheckTheLoai(string Tentheloai)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string checkQuery = "SELECT COUNT(*) FROM TheLoaiTruyen WHERE TenTheLoai = @TenTheLoai";
                SqlCommand checkcommand = new SqlCommand(checkQuery, connection);
                checkcommand.Parameters.AddWithValue("@TenTheLoai", Tentheloai);
                return (int)checkcommand.ExecuteScalar() > 0;
            }
        }

        public bool AddTheLoai(TheLoaiTruyen theLoai)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string AddQuery = "INSERT INTO TheLoaiTruyen (TenTheLoai) VALUES (@TenTheLoai)";
                SqlCommand AddCommand = new SqlCommand(AddQuery, connection);
                AddCommand.Parameters.AddWithValue("@TenTheLoai", theLoai.TenTheLoai);
             
                return AddCommand.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateTheLoai(TheLoaiTruyen theLoai)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string UpdateQuery = "UPDATE TheLoaiTruyen SET TenTheLoai = @TenTheLoai  WHERE IDTheLoai = @MaTheLoai";
                SqlCommand AddCommand = new SqlCommand(UpdateQuery, connection);
                AddCommand.Parameters.AddWithValue("@MaTheLoai", theLoai.IDTheLoai);
                AddCommand.Parameters.AddWithValue("@TenTheLoai", theLoai.TenTheLoai);
              
                return AddCommand.ExecuteNonQuery() > 0;
            }
        }


        public bool DeleteTheLoai(TheLoaiTruyen theLoai)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string DeleteQuery = "DELETE FROM TheLoaiTruyen WHERE IDTheLoai = @MaTheLoai";
                SqlCommand AddCommand = new SqlCommand(DeleteQuery, connection);
                AddCommand.Parameters.AddWithValue("@MaTheLoai", theLoai.IDTheLoai);
                return AddCommand.ExecuteNonQuery() > 0;
            }
        }

        public DataTable SearchTheLoai(string keyword)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT * FROM TheLoaiTruyen WHERE TenTheLoai LIKE @Keyword";

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

        public int CountTheLoai(string keyword)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM TheLoaiTruyen WHERE TenTheLoai LIKE @Keyword";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                    return (int)command.ExecuteScalar();
                }
            }
        }




    }
}
