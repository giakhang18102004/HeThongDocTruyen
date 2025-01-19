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
    public class BLL_QuanLyDanhMuc
    {
        private DAL_QuanLyDanhMuc DanhMucDAL;

        public BLL_QuanLyDanhMuc(string DbConnection)
        {
            DanhMucDAL = new DAL_QuanLyDanhMuc(DbConnection);
        }

        public DataTable getListDanhMuc()
        {
            return DanhMucDAL.getAllDanhMuc();
        }

        public bool AddNewDanhMuc(DanhMucTruyen danhmuc)
        {
            if (string.IsNullOrWhiteSpace(danhmuc.TenDanhMuc) || string.IsNullOrWhiteSpace(danhmuc.MoTa))
                throw new ArgumentException("vui lòng nhập đủ thông tin trước khi thêm ! ");

            if (DanhMucDAL.CheckDanhMuc(danhmuc.TenDanhMuc)) throw new ArgumentException( $"Tên danh mục {danhmuc.TenDanhMuc} này đã tồn tại ! ");

            return DanhMucDAL.AddDanhMuc(danhmuc);            
        }

        public bool UpdateNewDanhMuc(DanhMucTruyen danhmuc)
        {
            if (danhmuc.IDDanhMuc <= 0 || string.IsNullOrWhiteSpace(danhmuc.TenDanhMuc) || string.IsNullOrWhiteSpace(danhmuc.MoTa))
                throw new ArgumentException("Nhập đủ thông tin trước khi cập nhật ! ");
            return DanhMucDAL.UpdateDanhMuc(danhmuc);
        }

        public bool DeleteDanhMuc(DanhMucTruyen danhmuc)
        {
            if (danhmuc.IDDanhMuc <= 0) throw new ArgumentException("Vui lòng chọn mục trong bảng trước khi thao tác xóa ! ");
            return DanhMucDAL.deleteDanhMuc(danhmuc);
        }
        public DataTable searchListDanhMuc(string keyword)
        {
            return DanhMucDAL.SearchDanhMuc(keyword);
        }
        public int CountListDanhMuc(string keyword)
        {
            return DanhMucDAL.CountDanhMuc(keyword);
        }
    }
}
