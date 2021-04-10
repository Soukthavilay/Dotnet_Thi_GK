using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace _102190395_Soukthavilay_Bouphaphan_GK
{
    class CSDL_OOP
    {
        private static CSDL_OOP _Instance;
        public static CSDL_OOP Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CSDL_OOP();
                    return _Instance;
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
        private CSDL_OOP()
        {

        }
        public List<SanPham> GetListSanPham(string ID_MatHang, string NameMH)
        {
            List<SanPham> sanphamList = new List<SanPham>();
            if (ID_MatHang == "" && "".Equals(NameMH))
            {
                foreach (SanPham sanpham in GetAllSanPham())
                {

                    sanphamList.Add(sanpham);
                }
            }
            else if ("".Equals(NameMH))
            {
                foreach (SanPham sanpham in GetAllSanPham())
                {
                    if (sanpham.ID_MatHang == ID_MatHang)
                    {
                        sanphamList.Add(sanpham);
                    }
                }
            }
            else
            {
                foreach (SanPham sanpham in GetAllSanPham())
                {
                    if (ID_MatHang == "")
                    {

                        if (sanpham.NameSP.Contains(NameMH))// contains mun ja shub kha ngaiy kua Equal 
                        {
                            sanphamList.Add(sanpham);
                        }
                    }
                    else
                    {
                        if (sanpham.ID_MatHang == ID_MatHang && sanpham.NameSP.Contains(NameMH))
                        {
                            sanphamList.Add(sanpham);
                        }
                    }
                }
            }
            return sanphamList;

        }
        public List<SanPham> GetAllSanPham()
        {
            List<SanPham> sanphamList = new List<SanPham>();
            DataTable dt1 = CSDL.Instance.DTSanPham;
            foreach (DataRow dr in dt1.Rows)
            {

                sanphamList.Add(GetSanPham(dr));


            }
            return sanphamList;
        }
        public SanPham GetSanPham(DataRow i)
        {
            return new SanPham
            {
                ID_MatHang = i["ID_MatHang"].ToString(),
                ID_SanPham = i["ID_SanPham"].ToString(),
                NameSP = i["NameSP"].ToString(),
                SoLuong = Convert.ToInt32(i["SoLuong"]),
                NSX = Convert.ToDateTime(i["NSX"]),
                NHH = Convert.ToDateTime(i["NHH"]),
            };
        }
        public List<MatHang> GetAllMatHang()
        {
            List<MatHang> lshList = new List<MatHang>();
            DataTable MatHang = CSDL.Instance.DTMatHang;
            foreach (DataRow k1 in MatHang.Rows)
            {

                lshList.Add(GetMatHang(k1));
            }
            return lshList;
        }
        public MatHang GetMatHang(DataRow i)
        {

            return new MatHang
            {
                ID_MatHang = i["ID_MatHang"].ToString(),
                NameMH = i["NameMH"].ToString(),
            };
        }
        public MatHang GetMatHangById(string ID_MatHang)
        {
            MatHang mathang = new MatHang();
            foreach (MatHang l in GetAllMatHang())
            {
                if (ID_MatHang == l.ID_MatHang)
                {
                    mathang = l;
                    break;
                }
            }
            return mathang;
        }
        public SanPham getSanPhamById(string ID_SanPham)
        {
            SanPham sanpham = new SanPham();
            foreach (SanPham t in GetAllSanPham())
            {
                if (ID_SanPham.Equals(t.ID_SanPham))
                {
                    sanpham = t;
                    break;
                }
            }
            return sanpham;
        }
        public void deleteSanPham(String ID_SanPham)
        {
            DataTable dt1 = new DataTable();
            dt1 = CSDL.Instance.DTSanPham;
            foreach (DataRow r in dt1.Rows)
            {
                if (r["ID_SanPham"].Equals(ID_SanPham))
                {
                    r.Delete();
                    break;
                }
            }
            dt1.AcceptChanges();
            CSDL.Instance.DTSanPham = dt1;
        }
        public void updateSanPham(SanPham sanpham)
        {
            DataTable dt2 = new DataTable();
            dt2 = CSDL.Instance.DTSanPham;
            foreach (DataRow dr in dt2.Rows)
            {
                if (dr["ID_SanPham"].Equals(sanpham.ID_SanPham))
                {
                    dr["ID_MatHang"] = sanpham.ID_MatHang;
                    dr["NameSP"] = sanpham.NameSP;
                    dr["SoLuong"] = sanpham.SoLuong;
                    dr["NSX"] = sanpham.NSX;
                    dr["NHH"] = sanpham.NHH;

                    break;
                }
            }
            dt2.AcceptChanges();
            CSDL.Instance.DTSanPham = dt2;
        }
        public void insertSanPham(SanPham sanpham )
        {
            DataRow dr2 = CSDL.Instance.DTSanPham.NewRow();
            dr2["ID_SanPham"] = sanpham.ID_SanPham;
            dr2["ID_MatHang"] = sanpham.ID_MatHang;
            dr2["NameSP"] = sanpham.NameSP;
            dr2["SoLuong"] = sanpham.SoLuong;
            dr2["NSX"] = sanpham.NSX;
            dr2["NHH"] = sanpham.NHH;
            CSDL.Instance.DTSanPham.Rows.Add(dr2);
        }
        public bool SanPhamIsExist(string id_sanpham)
        {
            bool check = false;
            foreach (DataRow r in CSDL.Instance.DTSanPham.Rows)
            {
                if (r["ID_SanPham"].Equals(id_sanpham))
                {
                    check = true;
                    break ; 
                }
            }
            return check; 
        }
    }
}
