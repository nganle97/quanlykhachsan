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
                Account acc = Account_DAO.Instance.getaccountbyUsername(username);
                Form1 f = new Form1(acc);
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

        private void txtPassWord_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void dangnhap_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyData==Keys.Enter)
            {
                simpleButton1.Select();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked==true)
            {
                checkBox1.ForeColor = Color.Red;
                txtPassWord.UseSystemPasswordChar = false;
            }
            else
            {
                

                 checkBox1.ForeColor = Color.Blue;
                txtPassWord.UseSystemPasswordChar = true;
            }

        }

        private void txtPassWord_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtPassWord_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void admin(object sender, EventArgs e)
        {

        }
    }
}
