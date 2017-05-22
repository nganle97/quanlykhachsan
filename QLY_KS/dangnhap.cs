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
    public partial class dangnhap : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public dangnhap()
        {
            InitializeComponent();
        }

        private void dangnhap_Load(object sender, EventArgs e)
        {
          
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string username = txtuserName.Text;
            string password = txtPassWord.Text;
            if(login(username,password))
            {
                Form1 f = new Form1();
                this.Hide();
                f.Show();
          
            }
            else
            {
                MessageBox.Show("tên đăng nhập hoặc tài khoản sai");
            }
        }
        bool login(string userName, string passWord)
        {
            return Account_DAO.Instance.login(userName, passWord);
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            
            Application.Exit();
        }

        private void dangnhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Do you really want to exit?", "Message", MessageBoxButtons.OKCancel)
                != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void txtuserName_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txtuserName_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyData==Keys.Down)
            {
                txtPassWord.Focus();
            }
        }

        private void txtPassWord_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtPassWord_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Up)
            {
                txtuserName.Focus();
            }
            if (e.KeyData == Keys.Enter)
            {
                simpleButton1_Click(this, new EventArgs());
            }
        }

        private void dangnhap_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyData==Keys.Enter)
            {
                simpleButton1.Select();
            }
        }
    }
}
