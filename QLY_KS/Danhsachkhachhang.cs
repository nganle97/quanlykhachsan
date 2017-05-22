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
    public partial class Danhsachkhachhang : Form
    {
        public Danhsachkhachhang()
        {
            InitializeComponent();
            loadlistkh();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        void loadlistkh()
        {
            dataGridView1.DataSource = DATA.DanhsachKH_DAO.Instance.getlistkh();
        }
        void loadkhbyid(string id)
        {
            dataGridView1.DataSource = DATA.DanhsachKH_DAO.Instance.getlistkhbyid(id);
        }
        void loadytype(string type)
        {
            dataGridView1.DataSource = DATA.DanhsachKH_DAO.Instance.getlistkhbytype(type);
        }
        void loadlistkhall(string type, string id)
        {
            dataGridView1.DataSource = DATA.DanhsachKH_DAO.Instance.getlistkhall(id,type);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            loadytype(comboBox1.Text);
            //if(textBox1.Text == "")
            //{
            //    loadytype(comboBox1.Text);
            //}
            //else if(comboBox1.Text == "")
            //{
            //    loadkhbyid(textBox1.Text);
            //}
            //else if(comboBox1.Text == "" & textBox1.Text == "")
            //{
            //    loadlistkh();
            //}
            //else
            //{
            //    loadlistkhall(comboBox1.Text,textBox1.Text);
            //}
        }
    }
}
