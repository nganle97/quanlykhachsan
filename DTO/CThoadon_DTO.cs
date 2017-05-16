using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class CThoadon_DTO
    {
        int Sohoadon;
        int Makh;
        int Maphong;
        long Thanhtien;
        public CThoadon_DTO() { }
        public CThoadon_DTO(int sohd,int makh,int maphong,long thanhtien)
        {
            this.Sohoadon = sohd;
            this.Makh = makh;
            this.Maphong = maphong;
            this.Thanhtien = thanhtien;
        }
    }
}
