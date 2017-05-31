using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
   public class DanhsachPhong_BUS
    {

        private int idphong;
        private string tenphong, loaiphong, trangthai;
        private float dongia;
        public DanhsachPhong_BUS(int idp, string tenphong, string loaiphong, string trangthai,float dongia)
        {
            this.idphong = idp;
            this.tenphong = tenphong;
            this.loaiphong = loaiphong;
            this.trangthai = trangthai;
            this.dongia = dongia;
        }
        public DanhsachPhong_BUS(DataRow r)
        {
            this.idphong =(int)r["id"];
            this.tenphong = r["tenphong"].ToString();
            this.loaiphong = r["loaiphong"].ToString() ;
            this.trangthai = r["trangthai"].ToString();
            this.dongia = (float)Convert.ToDouble(r["dongia"]);
        }

        public int Idphong
        {
            get
            {
                return idphong;
            }

            set
            {
                idphong = value;
            }
        }

        public string Loaiphong
        {
            get
            {
                return loaiphong;
            }

            set
            {
                loaiphong = value;
            }
        }

        public string Tenphong
        {
            get
            {
                return tenphong;
            }

            set
            {
                tenphong = value;
            }
        }

        public string Trangthai
        {
            get
            {
                return trangthai;
            }

            set
            {
                trangthai = value;
            }
        }

        public float Dongia
        {
            get
            {
                return dongia;
            }

            set
            {
                dongia = value;
            }
        }
    }
}
