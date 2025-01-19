using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongDocTruyen.Model
{
    public class TaiKhoan
    {
      
        public int IDTaiKhoan { get; set; }

       
        public string TaiKhoanNguoiDung { get; set; }

      
        public string MatKhau { get; set; }

        
        public string HoTen { get; set; }

      
        public string Email { get; set; }

      
        public string GioiTinh { get; set; }

        public string SDT { get; set; }

    
        public DateTime NgayTao { get; set; }

      
        public int IDPhanQuyen { get; set; }
    }
}
