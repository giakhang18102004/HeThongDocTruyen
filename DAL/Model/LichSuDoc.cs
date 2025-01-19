using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongDocTruyen.Model
{
    internal class LichSuDoc
    {
      
        public int IDLichSu { get; set; }

        public int IDTaiKhoan { get; set; }

       
        public int IDTruyen { get; set; }

      
        public DateTime NgayDoc { get; set; }
    }
}
