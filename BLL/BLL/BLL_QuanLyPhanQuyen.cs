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
    public class BLL_QuanLyPhanQuyen
    {
        private DAL_QuanLyPhanQuyen PhanQuyenDAL;

        public BLL_QuanLyPhanQuyen(string Dbconnection)
        {
            PhanQuyenDAL = new DAL_QuanLyPhanQuyen(Dbconnection);
        }

        public DataTable getListPhanQuyen()
        {
            return PhanQuyenDAL.getAllPhanQuyen();
        }

        public bool AddNewPhanQuyen(PhanQuyen quyen)
        {
            if (string.IsNullOrWhiteSpace(quyen.TenPhanQuyen) || string.IsNullOrWhiteSpace(quyen.MoTa))
                throw new ArgumentException("Vui lòng nhập đủ thông tin trước khi thêm ! ");
            return PhanQuyenDAL.AddPhanQuyen(quyen);
        }

        public bool UpdateNewPhanQuyen(PhanQuyen quyen)
        {
            if (quyen.IDPhanQuyen <= 0 || string.IsNullOrWhiteSpace(quyen.TenPhanQuyen) || string.IsNullOrWhiteSpace(quyen.MoTa))
                throw new ArgumentException("Nhập đủ thông tin trước khi cập nhật ! ");
            return PhanQuyenDAL.UpdatePhanQuyen(quyen);
        }



        public bool DeletePhanQuyen(PhanQuyen quyen)
        {
            if (quyen.IDPhanQuyen <= 0) throw new ArgumentException("Vui lòng chọn mục trong bảng trước khi thao tác xóa ! ");
            return PhanQuyenDAL.deletePhanQuyen(quyen);
        }
        public DataTable searchListPhanQuyen(string keyword)
        {
            return PhanQuyenDAL.SearchQuyen(keyword);
        }
        public int CountListPhanQuyen(string keyword)
        {
            return PhanQuyenDAL.CountQuyen(keyword);
        }


    }
}
