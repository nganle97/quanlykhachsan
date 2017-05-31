using BUS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DATA
{
   public  class Datphong_DAO
    {
        private static Datphong_DAO instance;

        public static Datphong_DAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new Datphong_DAO();
                return instance;
            }

            set
            {
                Datphong_DAO.instance = value;
            }
        }
        private Datphong_DAO() { }
        public DataTable LoadDatphong()
        {
            return DBconection.Instrance.ExecuteQuery("SELECT p.tenphong,p.loaiphong,dp.ngay_bat_dau_thue FROM dbo.phieuthuephong dp, dbo.Phong p WHERE dp.idphong = p.id");
        }
        public void UpdatePhong()
        {
            
        }
    }
}
