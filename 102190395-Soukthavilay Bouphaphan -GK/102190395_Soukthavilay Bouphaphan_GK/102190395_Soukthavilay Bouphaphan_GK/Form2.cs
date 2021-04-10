using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _102190395_Soukthavilay_Bouphaphan_GK
{
    public partial class Form2 : Form
    {
        public event ClosePanelHandler ClosePanel;
        public delegate void ClosePanelHandler(object sender, EventArgs e);
        public Form2()
        {
            InitializeComponent();
        }
        public void passData(string  id_sanpham)
        {
            sanpham = CSDL_OOP.Instance.getSanPhamById(id_sanpham);
        }
        
        private SanPham sanpham;
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void setCBB() // h hai sa daeng khr moun khuen nai combo box
        {
            foreach (MatHang m in CSDL_OOP.Instance.GetAllMatHang())
            {
                cbb_MH.Items.Add(new CBBItem
                {
                    Value = m.ID_MatHang,Text = m.NameMH
                }) ;
                
            }
            cbb_MH.SelectedIndex = 0; // hai combo box lueak hai lery un thum it 
        }
        private void setData() // hub khr jark toolbox ma sai nai SanPham
        {
            sanpham.ID_SanPham = txt_IDSP.Text;
            sanpham.NameSP = txt_NameSP.Text;
            sanpham.SoLuong = Convert.ToInt32(txt_SL.Text);
            //
            CBBItem cb = (CBBItem)cbb_MH.SelectedItem;
            sanpham.ID_MatHang = cb.Value;
            // ao kha ma jark combo box ma sai opject 
            sanpham.NSX = dtp_NSX.Value;
            sanpham.NHH = dtp_NHH.Value;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //  txt_IDSP.Clear();
            setData();
            if (CSDL_OOP.Instance.SanPhamIsExist(sanpham.ID_SanPham))
            {
                CSDL_OOP.Instance.updateSanPham(sanpham);
            }
            else
            {
                CSDL_OOP.Instance.insertSanPham(sanpham);
            }
            // check vela pit hub ma jark ClosePanelHandler
            if (ClosePanel != null)
            {
                ClosePanel(this, new EventArgs());
            }
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            txt_IDSP.Text = sanpham.ID_SanPham;
            txt_NameSP.Text = sanpham.NameSP;
            txt_SL.Text = sanpham.SoLuong.ToString();
            dtp_NSX.Value = sanpham.NSX;
            dtp_NHH.Value = sanpham.NHH;
            setCBB();

        }

        
    }
}
