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
    public class BLL_QuanLyTheLoai
    {
        private DAL_QuanLyTheLoai TheLoaiDAL;

        public BLL_QuanLyTheLoai(string Dbconnection)
        {
            TheLoaiDAL = new DAL_QuanLyTheLoai(Dbconnection);
        }

        public DataTable getListTHeLoai()
        {
            return TheLoaiDAL.getAllTheLoai();
        }

        public bool AddNewTheLoai(TheLoaiTruyen theLoai)
        {
            if (string.IsNullOrWhiteSpace(theLoai.TenTheLoai))
                throw new ArgumentException("vui lòng nhập đủ thông tin trước khi thêm ! ");

            if (TheLoaiDAL.CheckTheLoai(theLoai.TenTheLoai)) throw new ArgumentException($"Tên thể loại {theLoai.TenTheLoai} này đã tồn tại ! ");

            return TheLoaiDAL.AddTheLoai(theLoai);
        }

        public bool UpdateNewTheLoai(TheLoaiTruyen theLoai)
        {
            if (theLoai.IDTheLoai <= 0 || string.IsNullOrWhiteSpace(theLoai.TenTheLoai))
                throw new ArgumentException("Nhập đủ thông tin trước khi cập nhật ! ");
            return TheLoaiDAL.UpdateTheLoai(theLoai);
        }

        public bool DeleteTheLoai(TheLoaiTruyen theLoai)
        {
            if (theLoai.IDTheLoai <= 0) throw new ArgumentException("Vui lòng chọn mục trong bảng trước khi thao tác xóa ! ");
            return TheLoaiDAL.DeleteTheLoai(theLoai);
        }
        public DataTable SearchListTheLoai(string keyword)
        {
            return TheLoaiDAL.SearchTheLoai(keyword);
        }
        public int CountListTheLoai(string keyword)
        {
            return TheLoaiDAL.CountTheLoai(keyword);
        }


    }
}
