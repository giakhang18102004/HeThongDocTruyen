using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongDocTruyen.Model
{
    public class Truyen
    {
     
        public int IDTruyen { get; set; }

        public string TenTruyen { get; set; }

        public string AnhTruyen { get; set; }

        public string TacGia { get; set; }

        public string MoTa { get; set; }

     
        public DateTime NgayDang { get; set; }

      
        public int IDDanhMuc { get; set; }

      
        public int IDTheLoai { get; set; }

        public int SoLuotDoc { get; set; }
    }
}
