using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DATA;

namespace QLY_KS
{
    public partial class Danhsachphong : Form
    {
        public Danhsachphong()
        {
            InitializeComponent();
            loadlistrom();
        }
        void loadlistrom()
        {

            dataGridView1.DataSource = DATA.Danhsachphong_DAO.Instance.getlistroms();
        }
        void loadlistrombyid(string loai,string trangthai)
        {
            dataGridView1.DataSource = DATA.Danhsachphong_DAO.Instance.getlistromid(loai, trangthai);
        }
        void loadlistrombystatus(string trangthai)
        {
            dataGridView1.DataSource = DATA.Danhsachphong_DAO.Instance.getlistromtrangthai(trangthai);
        }
        void loadlistrombytype(string loai)
        {
            dataGridView1.DataSource = DATA.Danhsachphong_DAO.Instance.getlistromloai(loai);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if(comboBoxEdit2.Text==""&comboBoxEdit3.Text!="")
            {
                loadlistrombytype(comboBoxEdit3.Text);
            }
            else if(comboBoxEdit2.Text != "" & comboBoxEdit3.Text == "")
            {
                loadlistrombystatus(comboBoxEdit2.Text);
            }
            else if(comboBoxEdit2.Text != "" & comboBoxEdit3.Text != "")
            {
                loadlistrombyid(comboBoxEdit3.Text, comboBoxEdit2.Text);
            }
            else
            {
                loadlistrom();
            }
            
        }
    }
}
