using BUS;
using DATA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLY_KS
{
    public partial class Hoadon : Form
    {
    

        public Hoadon()
        {
            InitializeComponent();
            loadlistbill();
            loaddatafromgridcontrolintexbox();
            load();
        }

        void loadlistbill()
        {
           
            gridControl1.DataSource = Hoadon_DAO.getlistbill();
         
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            Image img = QLY_KS.Properties.Resources.imgLG;
            e.Graphics.DrawImage(img, 550, -30);
            e.Graphics.DrawString(@" KHÁCH SẠN MINH ANH
 KÍNH CHÀO QUÝ KHÁCH ", new Font("Brush", 25, FontStyle.Italic), Brushes.Black, 0, 20);
            e.Graphics.DrawString("HÓA ĐƠN", new Font("Arial", 40, FontStyle.Bold), Brushes.Black, 300, 200);
            e.Graphics.DrawString("KHÁCH HÀNG:", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, 50, 300);
            e.Graphics.DrawString("CMND:wwwwww ", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, 50, 330);
            e.Graphics.DrawString("PHÒNG SỐ: 121", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, 50, 360);
            e.Graphics.DrawString("THỜI GIAN ĐẶT PHÒNG: ", new Font("Arial", 15, FontStyle.Regular), Brushes.Black, 50, 400);
            e.Graphics.DrawString("THỜI GIAN TRẢ PHÒNG: ", new Font("Arial", 15, FontStyle.Regular), Brushes.Black, 50, 430);
            e.Graphics.DrawString("TỔNG THỜI GIAN Ở: ", new Font("Arial", 15, FontStyle.Regular), Brushes.Black, 50, 460);
            e.Graphics.DrawString("DỊCH VỤ ĐI KÈM ", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, 350, 500);
            e.Graphics.DrawString(@"------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, 0, 700);
            e.Graphics.DrawString("TỔNG TIỀN CẦN PHẢI THANH TOÁN :", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, 5, 750);
            e.Graphics.DrawString("Người In Hóa Đơn ", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, 550, 800);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
           
        }
        void load()
        {
            DataTable list = DanhsachKH_DAO.Instance.danhsachkhachhang();


            foreach (DataRow r in list.Rows)
            {
                txtTenkhachhang.Text = r["HoTen"].ToString();
            }

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }
          void loadlistnamerom()
        {
            List<DanhsachPhong_BUS> list = Danhsachphong_DAO.Instance.getlistRomName();
            comboBox1.DataSource = list;
            comboBox1.DisplayMember = "tenphong";
        }
        public List<DanhsachPhong_BUS> list = Danhsachphong_DAO.Instance.getlistRomName();
        
        private void gridView_hoadon_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
           
        }
        void loaddatafromgridcontrolintexbox()
        {
           
            txtTenkhachhang.DataBindings.Clear();
            txtTenkhachhang.DataBindings.Add("text",gridControl1.DataSource, "TongTien");
        }
    }
}
