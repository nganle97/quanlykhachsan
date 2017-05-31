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
    public partial class fUpdateAccount : DevExpress.XtraBars.Ribbon.RibbonForm
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
                ChangeAcount(loginAccount);
            }
        }
        public fUpdateAccount(Account acc)
        {
            InitializeComponent();
            loginAccount = acc;
        }
        void ChangeAcount(Account acc)
        {
            txtUserName.Text = acc.Username;
        }
      
       
        private void lbcPassWord_Click(object sender, EventArgs e)
        {

        }

        private void sbtnUpdate_Click(object sender, EventArgs e)
        {
           
        }
        void UpdateAccount()
        {
            string password = txtPassW.Text;
            string username = txtUserN.Text;
            string newpassword = txtNewPass.Text;
            string re_enterpassword = txtReEnterPass.Text;
            if (!re_enterpassword.Equals(newpassword))
            {
                MessageBox.Show("nhập lại mật khẩu mới!!");
            }
            else
            {
                if (Account_DAO.Instance.doimatkhau(username, password, newpassword))
                {
                    MessageBox.Show("Cập Nhập Thành Công");
                }
                else
                {
                    MessageBox.Show("Điền lại mật khẩu");
                }
            }
        }

        private void fUpdateAccount_Load(object sender, EventArgs e)
        {
           
        }

        private void sbtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUserName_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtReEnterPassWord_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            UpdateAccount();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
