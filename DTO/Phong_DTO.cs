using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class Phong_DTO
    {
        string Maphong;
        bool Trangthai;// yes : phong kin, no: phongf co khach
        string Loaiphong;
        int Giaphong;
        public Phong_DTO() { }
        public Phong_DTO(string maphong,bool trangthai,string loaiphong,int giaphong)
        {
            this.Maphong = maphong;
            this.Trangthai = trangthai;
            this.Loaiphong = loaiphong;
            this.Giaphong = giaphong;
        }


    }
}
