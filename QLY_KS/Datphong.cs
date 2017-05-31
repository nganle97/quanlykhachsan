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
    public partial class Datphong : Form
    {
        public Datphong()
        {
            InitializeComponent();
            loaddp();
        }

        void insertInfCl()
        {
            string hoten = txthot.Text;
            string sdt = txtSDT.Text;
            string socmnn = txtCMNN.Text;
            string loaikh = comboBox1_loaikhach.Text;
            string soluong = comboBox2_soluong.Text;
            if (hoten ==""||sdt==""||socmnn==""||loaikh==""||soluong=="")
            {
                MessageBox.Show("vui lòng điền đủ thông tin khách hàng !!");
            }
            else
            {
                if(DanhsachKH_DAO.Instance.Insertkhachhang(hoten,sdt,socmnn,loaikh))
                {
                    MessageBox.Show("Đặt phòng thành công!!");
                }
                else
                {
                    MessageBox.Show("Điền lại thông tin khách hàng");
                }
            }
           // List<DanhsachKH_BUS> list = DanhsachKH_DAO.Instance.getlistCMT();
          //  int n = DanhsachKH_DAO.Instance.MAXidClient();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            insertInfCl();
        }
        void reset()
        {
            txthot.Text="";
             txtSDT.Text = "";
             txtCMNN.Text = "";
             comboBox1_loaikhach.Text = "";
            txtghichu.Text = "";
            comboBox2_soluong.Text = "";
        }
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            reset();
        }
        void delete()
        {
            if(DanhsachKH_DAO.Instance.xoakhachhang())
            {
                MessageBox.Show("Xóa Thành Công!!");
            }
        }
        void ModifyInformationClient()
        {
            string hoten = txthot.Text;
            string sdt = txtSDT.Text;
            string socmnn = txtCMNN.Text;
            string loaikh = comboBox1_loaikhach.Text;
            string soluong = comboBox2_soluong.Text;
            if (hoten == "" || sdt == "" || socmnn == "" || loaikh == "" || soluong == "")
            {
                MessageBox.Show("vui lòng điền đủ thông tin khách hàng !!");
            }
            else
            {
                if (DanhsachKH_DAO.Instance.Updatekhachhang(hoten, sdt, socmnn, loaikh))
                {
                    MessageBox.Show("Sửa thành công!!");
                }
            }
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            delete();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            ModifyInformationClient();
        }
        private void loaddp()
        {
            gcDatphong.DataSource = DATA.Datphong_DAO.Instance.LoadDatphong();
        }
        private void gcDatphong_Click(object sender, EventArgs e)
        {

        }
    }
}
