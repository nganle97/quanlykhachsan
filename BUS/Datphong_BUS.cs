using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
   public class Datphong_BUS
    {
        private int iddatphong, idphong;
        private DateTime? ngaybatdau;

        public Datphong_BUS(int iddp, int idphong, DateTime? ngaybatdau)
        {
            this.iddatphong = iddp;
            this.idphong = idphong;
            this.ngaybatdau = ngaybatdau;
        }
        public Datphong_BUS(DataRow r)
        {
            this.iddatphong = (int)r["iddp"];
            this.idphong =(int) r["idphong"];
            this.ngaybatdau = (DateTime?)r["ngaybatdau"];
        }
        public int Iddatphong
        {
            get
            {
                return iddatphong;
            }

            set
            {
                iddatphong = value;
            }
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

        public DateTime? Ngaybatdau
        {
            get
            {
                return ngaybatdau;
            }

            set
            {
                ngaybatdau = value;
            }
        }
    }
}
