using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class Hoadon_DTO
    {
        int Mahoadon;
        DateTime Ngayhoadon;
        int Makh;
        int Tongtien;
        int Maphong;
        public Hoadon_DTO() { }
        public Hoadon_DTO(int mahd,DateTime ngayhd, int makh,int tongtien,int maphong)
        {
            this.Mahoadon = mahd;
            this.Ngayhoadon = ngayhd;
            this.Makh = makh;
            this.Tongtien = tongtien;
            this.Maphong = maphong;
        }

    }
}
