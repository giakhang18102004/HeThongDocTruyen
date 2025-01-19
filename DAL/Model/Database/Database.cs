using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongDocTruyen.Model.Database
{
    public class Database
    {
        string connectionString = "Data Source=GIAKHANGGGGG\\SQLEXPRESS;Initial Catalog=HeThongDocTruyen;Persist Security Info=True;User ID=sa;Password=123;Encrypt=True;TrustServerCertificate=True";

        public string GetConnectionString() // tạo phương thức lấy chuỗi kết nối
        {
            return connectionString; // trả về chuỗi kết nối
        }

        public SqlConnection GetConnection() 
        {
            return new SqlConnection(connectionString); 
        }
    }
}
