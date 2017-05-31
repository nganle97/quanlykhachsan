using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLY_KS
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private Account loginAccount;

        public Account LoginAccount
        {
            get
            {
                return loginAccount;
            }

            set
            {
                loginAccount = value;

            }
        }
        public Form1(Account acc)
        {
            InitializeComponent();
            this.LoginAccount = acc;
        }
        private bool checkform(string nameform)
        {
            bool check = false;
            foreach(Form form in this.MdiChildren)
            {
                if(form.Name==nameform)
                {
                    check = true;
                    break;
                }
            }

            return check;
        }
        private void activeform(string nameform)
        {
            foreach(Form form in this.MdiChildren)
            {
                if(form.Name==nameform)
                {
                    form.Activate();
                    break;
                }
            }
        }
        private void barbtnsodophong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(!checkform("Sodophong"))
            {
                Sodophong form = new Sodophong();
                form.MdiParent = this;
                form.Show();
            }
            else
            {
                activeform("Sodophong");
            }
        }

        private void barbtnDatp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!checkform("Datphong"))
            {
                Datphong form = new Datphong();
                form.MdiParent = this;
                form.Show();
            }
            else
            {
                activeform("Datphong");
            }
           
        }

        private void barbtnds_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            if(!checkform("Danhsachphong"))
            {
                Danhsachphong form = new Danhsachphong();
                form.MdiParent = this;
                form.Show();
            }
            else
            {
                activeform("Danhsachphong");
            }
        }

        private void barbtnDanhSachkh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(!checkform("Danhsachkhachhang"))
            {
                Danhsachkhachhang form = new Danhsachkhachhang();
                form.MdiParent = this;
                form.Show();
            }
            else
            {
                activeform("Danhsachkhachhang");
            }
        }

        private void barbtnHoadon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (!checkform("Hoadon"))
            {
                Hoadon form = new Hoadon();
                form.MdiParent = this;
                form.Show();
            }
            else
            {
                activeform("Hoadon");
            }
        }

        private void barbtnBaocao_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(!checkform("Baocao"))
            {
                Baocao form = new Baocao();
                form.MdiParent = this;
                form.Show();
            }
            else
            {
                activeform("Hoadon");
            }
                    
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
     

        private void barBtnInfAccount_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           fUpdateAccount inf = new fUpdateAccount(LoginAccount);
         
            inf.Show();
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
