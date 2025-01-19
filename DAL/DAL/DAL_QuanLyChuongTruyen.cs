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
    public class DAL_QuanLyChuongTruyen
    {
        private string connectionString;

        public DAL_QuanLyChuongTruyen(string Dbconnection)
        {
            connectionString = Dbconnection;
        }

        public DataTable getAllChuong()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string getQuery = @"
            SELECT 
                ChuongTruyen.IDChuong,
                ChuongTruyen.TenChuong,
                ChuongTruyen.NoiDung,
                ChuongTruyen.IDTruyen,
                Truyen.TenTruyen
            FROM 
                ChuongTruyen          
            INNER JOIN 
                Truyen ON ChuongTruyen.IDTruyen = Truyen.IDTruyen;
        ";
                SqlDataAdapter adapter = new SqlDataAdapter(getQuery, connection);
                adapter.Fill(dt);
            }
            return dt;
        }

      
        public bool AddChuongTruyen(ChuongTruyen chuong)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string AddQuery = @"INSERT INTO ChuongTruyen (TenChuong, NoiDung, IDTruyen)
                                VALUES (@TenChuong, @NoiDung, @MaTruyen)";
                    using (SqlCommand Addcommand = new SqlCommand(AddQuery, connection))
                    {
                        Addcommand.Parameters.AddWithValue("@TenChuong", chuong.TenChuong);
                        Addcommand.Parameters.AddWithValue("@NoiDung", chuong.NoiDung);
                        Addcommand.Parameters.AddWithValue("@MaTruyen", chuong.IDTruyen);
                       
                        return Addcommand.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Lỗi khi thêm sản phẩm: " + ex.Message);
            }
        }

        public bool UpdateChuongTruyen(ChuongTruyen chuong)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string updateQuery = @"UPDATE ChuongTruyen 
                                   SET TenChuong = @TenChuong, 
                                       NoiDung = @NoiDung, 
                                       IDTruyen = @MaTruyen                                 
                                   WHERE IDChuong = @MaChuong";
                    using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                    {
                        updateCommand.Parameters.AddWithValue("@MaChuong", chuong.IDChuong);
                        updateCommand.Parameters.AddWithValue("@MaTruyen", chuong.IDTruyen);
                        updateCommand.Parameters.AddWithValue("@NoiDung", chuong.NoiDung);
                        updateCommand.Parameters.AddWithValue("@TenChuong", chuong.TenChuong);
                       

                        return updateCommand.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Lỗi khi cập nhật truyện: " + ex.Message);
            }
        }
        public bool DeleteChuongTruyen(ChuongTruyen chuong)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string DeleteQuery = "DELETE FROM ChuongTruyen WHERE IDChuong = @MaChuong";
                SqlCommand deleteCommand = new SqlCommand(DeleteQuery, connection);
                deleteCommand.Parameters.AddWithValue("@MaChuong", chuong.IDChuong);
                return deleteCommand.ExecuteNonQuery() > 0;
            }
        }
        public DataTable SearchChuongTruyen(string keyword)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
                SELECT 
                ChuongTruyen.IDChuong,
                ChuongTruyen.TenChuong,
                ChuongTruyen.NoiDung,
                ChuongTruyen.IDTruyen,
                Truyen.TenTruyen
            FROM 
                ChuongTruyen          
            INNER JOIN 
                Truyen ON ChuongTruyen.IDTruyen = Truyen.IDTruyen
                WHERE ChuongTruyen.IDChuong LIKE @Keyword               
                OR ChuongTruyen.TenChuong LIKE @Keyword 
                OR ChuongTruyen.NoiDung LIKE @Keyword 
                OR ChuongTruyen.IDTruyen LIKE @Keyword 
                OR Truyen.TenTruyen LIKE @Keyword ";

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


        public int CountChuongTruyen(string keyword)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT COUNT(*) FROM 
                ChuongTruyen          
            INNER JOIN 
                Truyen ON ChuongTruyen.IDTruyen = Truyen.IDTruyen
                WHERE ChuongTruyen.IDChuong LIKE @Keyword               
                OR ChuongTruyen.TenChuong LIKE @Keyword 
                OR ChuongTruyen.NoiDung LIKE @Keyword 
                OR ChuongTruyen.IDTruyen LIKE @Keyword 
                OR Truyen.TenTruyen LIKE @Keyword ";


                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                    return (int)command.ExecuteScalar();
                }
            }
        }

    }
}
