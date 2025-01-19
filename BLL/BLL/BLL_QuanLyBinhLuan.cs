using HeThongDocTruyen.DAL;
using HeThongDocTruyen.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongDocTruyen.BLL
{
    public class BLL_QuanLyBinhLuan
    {
        private DAL_QuanLyBinhLuan BinhLuanDAL;

        public BLL_QuanLyBinhLuan(string Dbconnection)
        {
            BinhLuanDAL = new DAL_QuanLyBinhLuan(Dbconnection);
        }
        public DataTable getListBinhLuan()
        {
            return BinhLuanDAL.getAllBinhLuan();
        }

        public bool DeleteNowBinhLuan(BinhLuanDanhGia binhluan)
        {
            if (binhluan.IDBinhLuan <= 0) throw new ArgumentException("Vui lòng chọn mục trong bảng để thao tác xóa ! ");
            return BinhLuanDAL.DeleteDanhGia(binhluan);
        }
        public DataTable SearchListBinhLuan(string keyword)
        {
            return BinhLuanDAL.SearchDanhGia(keyword);
        }

        public int CountListBinhLuan(string keyword)
        {
            return BinhLuanDAL.CountDanhGia(keyword);
        }
    }
}
