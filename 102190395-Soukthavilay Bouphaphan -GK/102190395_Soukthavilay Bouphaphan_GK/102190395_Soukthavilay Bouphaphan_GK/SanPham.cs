using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _102190395_Soukthavilay_Bouphaphan_GK
{
   public class SanPham
    {
        public string ID_SanPham { get; set; }
        public string ID_MatHang { get; set; }
        public string NameSP { get; set; }
        public int SoLuong { get; set; }
        // datetime thouk thuea trng kum not kha vun t hai mun pen kha default
        public DateTime NSX { get; set; } = new DateTime(2000, 1, 1);
        public DateTime NHH { get; set; } = new DateTime(2000, 1, 1);
        public override string ToString()
        {
                {
                return NameSP + ":" + ID_SanPham + NSX + NHH + ":" + ID_MatHang;
                } 
                
        }
    }
}
