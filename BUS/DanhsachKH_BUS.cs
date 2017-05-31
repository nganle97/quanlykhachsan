using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class DanhsachKH_BUS
    {
        private int idkhachhang;
        private string hoten, loaikhachhang, sdt;
        private string socmt;
      
        public DanhsachKH_BUS(int id, string hoten, string loaiKh, string sdt,string socmt)
        {
            this.idkhachhang = id;
            this.hoten = hoten;
          
            this.loaikhachhang = loaiKh;
            this.sdt = sdt;
            this.socmt = socmt;
        }
        public DanhsachKH_BUS(DataRow r)
        {
           this.idkhachhang = (int)r["idNKhachHang"];
            this.hoten = r["hoten"].ToString();
            
            this.loaikhachhang = r["loaikhachhang"].ToString();
            this.sdt = r["sdt"].ToString();
            this.socmt = r["So_CMT"].ToString();
        }

        public int Idkhachhang
        {
            get
            {
                return idkhachhang;
            }

            set
            {
                idkhachhang = value;
            }
        }

        public string Hoten
        {
            get
            {
                return hoten;
            }

            set
            {
                hoten = value;
            }
        }

      

        public string Loaikhachhang
        {
            get
            {
                return loaikhachhang;
            }

            set
            {
                loaikhachhang = value;
            }
        }

        public string Sdt
        {
            get
            {
                return sdt;
            }

            set
            {
                sdt = value;
            }
        }

        public string Socmt
        {
            get
            {
                return socmt;
            }

            set
            {
                socmt = value;
            }
        }
    }
}
