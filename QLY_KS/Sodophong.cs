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
using DTO;
namespace QLY_KS
{
    public partial class Sodophong : Form
    {
        public Sodophong()
        {
            InitializeComponent();
        }
    
        
        private void simpleButton10_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
        }
#region menthod
        void loadrom()
        {
            int i = 1;
            List<Phong_DTO> roms = DATA.sodophong.Instance.listphong();
            foreach(Phong_DTO item in roms)
            {
                
                switch(i)
                {
                    case 1:
                        if(item.Trangthai=="phòng Trống")
                        {
                            radioButton2.Checked = true;
                            radioButton1.Checked = false;
                        }
                        else
                        {
                            radioButton1.Checked=true;
                            radioButton2.Checked = false;
                        }
                        break;
                    case 2:
                        if (item.Trangthai == "phòng Trống")
                        {
                            radioButton3.Checked = true;
                            radioButton4.Checked = false;
                        }
                        else
                        {
                            radioButton4.Checked = true;
                            radioButton3.Checked = false;
                        }
                        break;
                    case 3:
                        if (item.Trangthai == "phòng Trống")
                        {
                            radioButton5.Checked = true;
                            radioButton6.Checked = false;
                        }
                        else
                        {
                            radioButton6.Checked = true;
                            radioButton5.Checked = false;
                        }
                        break;
                    case 4:
                        if (item.Trangthai == "phòng Trống")
                        {
                            radioButton7.Checked = true;
                            radioButton8.Checked = false;
                        }
                        else
                        {
                            radioButton8.Checked = true;
                            radioButton7.Checked = false;
                        }
                        break;
                    case 5:
                        if (item.Trangthai == "phòng Trống")
                        {
                            radioButton9.Checked = true;
                            radioButton10.Checked = false;
                        }
                        else
                        {
                            radioButton10.Checked = true;
                            radioButton9.Checked = false;
                        }
                        break;
                    case 6:
                        if (item.Trangthai == "phòng Trống")
                        {
                            radioButton11.Checked = true;
                            radioButton12.Checked = false;
                        }
                        else
                        {
                            radioButton12.Checked = true;
                            radioButton11.Checked = false;
                        }
                        break;
                    case 7:
                        if (item.Trangthai == "phòng Trống")
                        {
                            radioButton13.Checked = true;
                            radioButton14.Checked = false;
                        }
                        else
                        {
                            radioButton14.Checked = true;
                            radioButton13.Checked = false;
                        }
                        break;
                    case 8:
                        if (item.Trangthai == "phòng Trống")
                        {
                            radioButton15.Checked = true;
                            radioButton16.Checked = false;
                        }
                        else
                        {
                            radioButton16.Checked = true;
                            radioButton15.Checked = false;
                        }
                        break;

                }

                i++;
            }

        }
#endregion
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Sodophong_Load(object sender, EventArgs e)
        {
            loadrom();
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            loadrom();
        }
    }
}
