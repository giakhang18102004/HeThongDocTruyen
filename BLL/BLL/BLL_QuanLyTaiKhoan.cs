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
    public class BLL_QuanLyTaiKhoan
    {
        private DAL_QuanLyTaiKhoan TaiKhoanDAL;

        public BLL_QuanLyTaiKhoan(string Dbconnection)
        {
            TaiKhoanDAL = new DAL_QuanLyTaiKhoan(Dbconnection); 
        }

        public DataTable getListTaiKhoan()
        {
            return TaiKhoanDAL.getAllTaiKhoan();
        }

        public bool AddNewTaiKhoan(TaiKhoan taikhoan)
        {
            if (string.IsNullOrWhiteSpace(taikhoan.TaiKhoanNguoiDung) ||
                string.IsNullOrWhiteSpace(taikhoan.MatKhau) ||
                string.IsNullOrWhiteSpace(taikhoan.HoTen) ||
                string.IsNullOrWhiteSpace(taikhoan.Email) ||
                string.IsNullOrWhiteSpace(taikhoan.GioiTinh) ||
                string.IsNullOrWhiteSpace(taikhoan.SDT) ||
                taikhoan.IDPhanQuyen <= 0 ||
                taikhoan.NgayTao == default)
                throw new ArgumentException("Vui lòng nhập đủ thông tin trước khi thêm ! ");

            if (TaiKhoanDAL.checkEmail(taikhoan.Email)) throw new ArgumentException($"Địa chỉ {taikhoan.Email} này đã tồn tại ! ");

            return TaiKhoanDAL.AddTaiKhoan(taikhoan);
        }

        public bool UpdateNewTaiKhoan(TaiKhoan taikhoan)
        {
            if (taikhoan.IDTaiKhoan <= 0 ||
                string.IsNullOrWhiteSpace(taikhoan.TaiKhoanNguoiDung) ||
               string.IsNullOrWhiteSpace(taikhoan.MatKhau) ||
               string.IsNullOrWhiteSpace(taikhoan.HoTen) ||
               string.IsNullOrWhiteSpace(taikhoan.Email) ||
               string.IsNullOrWhiteSpace(taikhoan.GioiTinh) ||
               string.IsNullOrWhiteSpace(taikhoan.SDT) ||
               taikhoan.IDPhanQuyen <= 0 ||
               taikhoan.NgayTao == default)
                throw new ArgumentException("Vui lòng nhập đủ thông tin trước khi thêm ! ");

          

            return TaiKhoanDAL.UpdateTaiKhoan(taikhoan);
        }

        public bool DeleteTaiKhoanNow(TaiKhoan taikhoan)
        {
            if (taikhoan.IDTaiKhoan <= 0) throw new ArgumentException("Vui lòng chọn mục trong bảng để thao tác xóa ! ");
            return TaiKhoanDAL.DeleteTaiKhoan(taikhoan);
        }

        public DataTable SearchListTaiKhoan(string keyword)
        {
            return TaiKhoanDAL.SearchTaiKhoan(keyword);
        }

        public int CountListTaiKhoan(string keyword)
        {
            return TaiKhoanDAL.CountTaiKhoan(keyword);
        }

    }
}
