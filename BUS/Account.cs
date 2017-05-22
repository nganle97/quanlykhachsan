using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
  public  class Account
    {

        private string username, password;
        private int idnhanvien, loaitk;
        public Account(string userName, string passWord,int idNhanVien, int loaiTK)
        {
            this.username = userName;
            this.password = passWord;
            this.idnhanvien = idNhanVien;
            this.loaitk = loaiTK;
        }
        public Account(DataRow data)
        {
            this.Username = data["username"].ToString();
            this.Password = data["pass"].ToString();
            this.Idnhanvien = (int)data["idnhanvien"];
            this.Loaitk = (int)data["loaitk"];
        }

       

        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public int Idnhanvien
        {
            get
            {
                return idnhanvien;
            }

            set
            {
                idnhanvien = value;
            }
        }

        public int Loaitk
        {
            get
            {
                return loaitk;
            }

            set
            {
                loaitk = value;
            }
        }

       
    }
}
