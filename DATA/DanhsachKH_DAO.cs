using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DATA
{
    public class DanhsachKH_DAO
    {
        private static DanhsachKH_DAO instance;
        public static DanhsachKH_DAO Instance
        {
            get { if (instance == null) instance = new DanhsachKH_DAO(); return DanhsachKH_DAO.instance; }
            set => instance = value;
        }
        private DanhsachKH_DAO() { }
        public DataTable getlistkh()
        {
            return DBconection.Instrance.ExecuteQuery("select * from dbo.khachhang");
        }
        public DataTable getlistkhbyid(string id)
        {
            string query = "select * from dbo.khachhang where So_CMT = " + id;
            return DBconection.Instrance.ExecuteQuery(query);
        }
        public DataTable getlistkhbytype(string type)
        {
            string query = "select * from dbo.khachhang where loaikhachhang = N'"+type+"'";
            return DBconection.Instrance.ExecuteQuery(query);
        }
        public DataTable getlistkhall(string id,string type)
        {
            string query = "select * from dbo.khachhang where loaikhachhang = N'" + type + "' and So_CMT = " + id;
            return DBconection.Instrance.ExecuteQuery(query);
        }
    }
}
