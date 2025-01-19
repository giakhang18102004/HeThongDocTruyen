using HeThongDocTruyen.DAL;
using HeThongDocTruyen.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HeThongDocTruyen.BLL
{
    public class BLL_QuanLyTruyen
    {
        private DAL_QuanLyTruyen TruyenDAL;
        public BLL_QuanLyTruyen(string Dbconnection)
        {
            TruyenDAL = new DAL_QuanLyTruyen(Dbconnection);
        }
        public DataTable getListTruyen()
        {
            return TruyenDAL.getallTruyen();
        }

        public void AddNewTruyen(Truyen truyen)
        {
            if (string.IsNullOrWhiteSpace(truyen.TenTruyen) || string.IsNullOrWhiteSpace(truyen.AnhTruyen) ||
                string.IsNullOrWhiteSpace(truyen.TacGia) || string.IsNullOrWhiteSpace(truyen.MoTa) ||
                truyen.NgayDang == default || truyen.IDDanhMuc <= 0 || truyen.IDTheLoai <= 0)
            {
                throw new ArgumentException("Vui lòng nhập đủ thông tin trước khi thêm truyện!");
            }

            if (TruyenDAL.CheckTruyen(truyen.TenTruyen))
            {
                throw new ArgumentException($"Tên truyện: '{truyen.TenTruyen}' đã tồn tại!");
            }

            if (!TruyenDAL.CheckDanhMuc(truyen.IDDanhMuc))
            {
                throw new ArgumentException($"Danh mục với ID {truyen.IDDanhMuc} không tồn tại!");
            }

            if (!TruyenDAL.CheckTheLoai(truyen.IDTheLoai))
            {
                throw new ArgumentException($"Thể loại với ID {truyen.IDTheLoai} không tồn tại!");
            }

            string directoryImage = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "HeThongDocTruyen", "AnhTruyen");

            if (!Directory.Exists(directoryImage))
            {
                Directory.CreateDirectory(directoryImage);
            }

            try
            {
                string imageFileName = $"{Guid.NewGuid()}.png";
                string destinationPath = Path.Combine(directoryImage, imageFileName);
                File.Copy(truyen.AnhTruyen, destinationPath, true);

                truyen.AnhTruyen = destinationPath;

                TruyenDAL.AddTruyen(truyen);
            }
            catch (IOException ex)
            {
                throw new Exception("Lỗi khi xử lý file hình ảnh: " + ex.Message);
            }
        }

        public bool UpdateNewTruyen(Truyen truyen)
        {
            if (truyen.IDTruyen <= 0 || string.IsNullOrWhiteSpace(truyen.TenTruyen) ||
                string.IsNullOrWhiteSpace(truyen.TacGia) || string.IsNullOrWhiteSpace(truyen.MoTa) ||
                truyen.NgayDang == default || truyen.IDDanhMuc <= 0 || truyen.IDTheLoai <= 0)
            {
                throw new ArgumentException("Vui lòng nhập đủ thông tin trước khi cập nhật truyện!");
            }

            if (!File.Exists(truyen.AnhTruyen))
            {
                throw new ArgumentException("Đường dẫn ảnh không tồn tại!");
            }

            return TruyenDAL.UpdateTruyen(truyen);
        }



        public bool DeleteTruyenNow(int MaTruyen)
        {
            if (MaTruyen <= 0) throw new ArgumentException("Vui lòng chọn mục truyện trong bảng để xóa ! ");

            return TruyenDAL.DeleteTruyen(MaTruyen);
        }

        public DataTable SearchListTruyen(string keyword)
        {
            return TruyenDAL.SearchTruyen(keyword);
        }

        public int CountListTruyen(string keyword)
        {
            return TruyenDAL.CountTruyen(keyword);  
        }




    }
}
