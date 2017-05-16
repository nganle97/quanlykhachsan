using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class Baocao_DTO
    {
        int Mabaocao;
        DateTime Thoigian;
        long Doanhthu;
        public Baocao_DTO() { }
        public Baocao_DTO(int mabaocao,DateTime thoigian,long doanhthu)
        {
            this.Mabaocao = mabaocao;
            this.Thoigian = thoigian;
            this.Doanhthu = doanhthu;

        }
    }
}
