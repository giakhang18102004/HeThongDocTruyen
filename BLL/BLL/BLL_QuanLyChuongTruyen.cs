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
    public class BLL_QuanLyChuongTruyen
    {
        private DAL_QuanLyChuongTruyen ChuongTruyenDAL;

        public BLL_QuanLyChuongTruyen(string Dbconnection)
        {
            ChuongTruyenDAL = new DAL_QuanLyChuongTruyen(Dbconnection);
        }

        public DataTable getListChuongTruyen()
        {
            return ChuongTruyenDAL.getAllChuong();
        }

        public bool AddNewChuong(ChuongTruyen chuong)
        {
            if (string.IsNullOrWhiteSpace(chuong.TenChuong) || string.IsNullOrWhiteSpace(chuong.NoiDung) || chuong.IDTruyen <= 0)
                throw new ArgumentException("Vui lòng nhập đủ thông tin trước khi thêm ! ");
          
            return ChuongTruyenDAL.AddChuongTruyen(chuong);
        }

        public bool UpdateNewChuong(ChuongTruyen chuong)
        {
            if (chuong.IDChuong <= 0 ||  string.IsNullOrWhiteSpace(chuong.TenChuong) || string.IsNullOrWhiteSpace(chuong.NoiDung) || chuong.IDTruyen <= 0)
                throw new ArgumentException("Vui lòng nhập đủ thông tin trước khi cập nhật thay đổi ! ");
          
            return ChuongTruyenDAL.UpdateChuongTruyen(chuong);
        }

        public bool DeleteNowChuong(ChuongTruyen chuong)
        {
            if (chuong.IDChuong <= 0)
                throw new ArgumentException("Vui lòng chọn mục trong bảng để thao tác xóa thông tin  ! ");

            return ChuongTruyenDAL.DeleteChuongTruyen(chuong);
        }
        public DataTable SearchListChuong(string keyword)
        {
            return ChuongTruyenDAL.SearchChuongTruyen(keyword);
        }
        public int CountListChuong(string keyword)
        {
            return ChuongTruyenDAL.CountChuongTruyen(keyword);
        }
    }
}
