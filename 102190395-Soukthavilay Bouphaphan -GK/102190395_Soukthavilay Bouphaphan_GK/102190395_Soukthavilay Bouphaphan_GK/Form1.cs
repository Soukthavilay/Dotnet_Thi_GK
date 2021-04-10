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
    public partial class Form1 : Form
    {
        public delegate void passdata (string id_sanpham);
        public Form1()
        {
            InitializeComponent();
        }
        private void HandleCloseReq(object sender,EventArgs e)
        {
            button_show.PerformClick();
        }
        // hai button_show kub button_search sa daeng khr moun kue kun 
        private void showListSanPham(string namesp)
        {
            CBBItem cb = (CBBItem)cbb_MH.SelectedItem; //selecteditem lueak kha jark item t lueak 
            dataGridView1.DataSource = CSDL_OOP.Instance.GetListSanPham(cb.Value,namesp);//kum not khrng datagridview
        }
        private void setCBB() // h hai sa daeng khr moun khuen nai combo box
        {
            cbb_MH.Items.Add(new CBBItem
            {
                Value = "",
                Text = "All"
                // pherm kham va all khao nai combo box 
            });
            foreach (MatHang m in CSDL_OOP.Instance.GetAllMatHang())
            {
                cbb_MH.Items.Add(new CBBItem
                {
                    Value = m.ID_MatHang,
                    Text = m.NameMH
                });
            }
            cbb_MH.SelectedIndex = 0;
        }
        private void button_search_Click(object sender, EventArgs e)
        {
            showListSanPham(txt_search.Text);
        }

        private void button_show_Click(object sender, EventArgs e)
        {
            showListSanPham("");
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            // luk kan perd form mai 
            Form2 y = new Form2();
            passdata p = new passdata(y.passData);
            p("");// br hu kha y
            y.ClosePanel += HandleCloseReq;
            // vi t perd form
            y.Show();
        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            string id_sanpham = "";
            DataGridViewRow row = (DataGridViewRow)dataGridView1.CurrentRow;
            id_sanpham = row.Cells["id_sanpham"].Value.ToString();
            Form2 y = new Form2();
            passdata p = new passdata(y.passData);
            // h tarm lung 
            y.ClosePanel += HandleCloseReq;
            //
            p(id_sanpham);// br hu kha y
            // vi t perd form
            y.Show();
        }

        private void button_del_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count > 0)
            {
                string id_sanpham = "";
                foreach (DataGridViewRow d in dataGridView1.SelectedRows)
                {
                    id_sanpham = d.Cells["ID_SanPham"].Value.ToString();
                    CSDL_OOP.Instance.deleteSanPham(id_sanpham);

                };
                button_show.PerformClick(); // refesh
            }
        }
        private void sort() // phuea sai nai poum sort
        {
            List<SanPham> spList = (List<SanPham>)dataGridView1.DataSource;
            spList.Sort(delegate (SanPham s1, SanPham s2)
            {
                return (s1.SoLuong.CompareTo(s2.SoLuong));
            });
            dataGridView1.DataSource = spList;
        }
        private void button_sort_Click(object sender, EventArgs e)
        {
            sort();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            setCBB();
        }
    }
}
