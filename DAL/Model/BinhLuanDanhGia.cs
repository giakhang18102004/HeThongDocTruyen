using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongDocTruyen.Model
{
    public class BinhLuanDanhGia
    {
       
        public int IDBinhLuan { get; set; }

     
        public string NoiDung { get; set; }

      
        public DateTime NgayBinhLuan { get; set; }

       
        public int IDTaiKhoan { get; set; }

       
        public int IDTruyen { get; set; }

      
        public int SoSao { get; set; }
    }
}
