using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class Khachhang_DTO
    {
        int Makh;
        string Tenkh;
        string SoCM;
        string Sodt;
        string LoaiKH;
        public Khachhang_DTO() { }
        public Khachhang_DTO(int makh,string tenkh,string socm,string sodt)
        {
            this.Tenkh = tenkh;
            this.Makh = makh;
            this.SoCM = socm;
            this.Sodt = sodt;

        }
    }
}
