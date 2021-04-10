using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace _102190395_Soukthavilay_Bouphaphan_GK
{
    class CSDL
    {
        public  DataTable DTSanPham { get; set; }
        public  DataTable DTMatHang { get; set; }
        public static CSDL _Instance;
        public static CSDL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    return _Instance = new CSDL();
                }
                else
                {
                    return _Instance;
                }
            }
            set
            {

            }
        }
        private CSDL ()
        {
            DataTable MatHang = new DataTable();
            MatHang.Columns.AddRange(new DataColumn[]{
                new DataColumn("ID_MatHang",typeof(string)),
                new DataColumn("NameMH",typeof(string))
            });
            DataRow k1 = MatHang.NewRow();
            k1["ID_MatHang"] = "101";
            k1["NameMH"] = "A";
            MatHang.Rows.Add(k1);

            DataTable SanPham = new DataTable();
            SanPham.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("ID_SanPham",typeof (string)),
                new DataColumn("ID_MatHang", typeof(string)),
                new DataColumn("NameSP",typeof(string)),
                new DataColumn("SoLuong", typeof(int)),
                new DataColumn("NSX",typeof(DateTime)),
                new DataColumn("NHH",typeof(DateTime)),
            }) ;
            DataRow dt1 = SanPham.NewRow();
            dt1["ID_SanPham"] = "1";
            dt1["ID_MatHang"] = "101";
            dt1["NameSP"] = "B";
            dt1["SoLuong"] = 30;
            dt1["NSX"] = new DateTime(2000, 2, 2);
            dt1["NHH"] = new DateTime(2021, 2, 2);
            SanPham.Rows.Add(dt1);
            DTMatHang = MatHang;
            DTSanPham = SanPham;

        }
       
    }
    
            
}
       

