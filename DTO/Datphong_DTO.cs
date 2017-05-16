using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class Datphong_DTO
    {
        int Makh;
        int Maphong;
        int Soluong;
        string LoaiKH;
        string Tenkh;
        string Sodt;
        string SoCM;
        public Datphong_DTO() { }
        public Datphong_DTO(int makh,int maphong,int soluong,string loaiKH,string tenkh,string sodt,string soCM)
        {
            this.Makh = makh;
            this.Maphong = maphong;
            this.Soluong = soluong;
            this.LoaiKH = loaiKH;
            this.Tenkh = tenkh;
            this.Sodt = sodt;
            this.SoCM = soCM;
        }
    }
}
