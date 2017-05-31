using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public  class Hoadon_BUS
    {

        private int idhoadon, idkhachhang, idphieuthuephong;
        private float Tongtien;
        private string trangthai;
        private DateTime? tgnhanphong, tgtraphong;
        public Hoadon_BUS(int idhoadon, int idkhachhang, int idphieuthuephong, float tongtien, string trangthai, DateTime? tgnhanphong,DateTime? tgTraphong)
        {
            this.idhoadon = idhoadon;
            this.idkhachhang = idkhachhang;
            this.idphieuthuephong = idphieuthuephong;
            this.Tongtien = tongtien;
            this.trangthai = trangthai;
            this.tgnhanphong = tgnhanphong;
            this.tgtraphong = tgTraphong;
        }
        public Hoadon_BUS (DataRow r)
        {
            this.idhoadon =(int)r["idhoadon"];
            this.idkhachhang = (int)r[" idkhachhang"];
            this.idphieuthuephong = (int)r["idphieuthuephong"];
            this.Tongtien = (float)r["tongtien"];
            this.trangthai =r["trangthai"].ToString();
            this.tgnhanphong =(DateTime?)r["tgnhanphong"];
            this.tgtraphong = (DateTime?)r["tgTraphong"];
        }
        public int Idhoadon
        {
            get
            {
                return idhoadon;
            }

            set
            {
                idhoadon = value;
            }
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

        public int Idphieuthuephong
        {
            get
            {
                return idphieuthuephong;
            }

            set
            {
                idphieuthuephong = value;
            }
        }

        public float Tongtien1
        {
            get
            {
                return Tongtien;
            }

            set
            {
                Tongtien = value;
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

        public DateTime? Tgnhanphong
        {
            get
            {
                return tgnhanphong;
            }

            set
            {
                tgnhanphong = value;
            }
        }

        public DateTime? Tgtraphong
        {
            get
            {
                return tgtraphong;
            }

            set
            {
                tgtraphong = value;
            }
        }
    }
}
