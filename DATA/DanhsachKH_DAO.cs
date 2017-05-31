using BUS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA
{
    public class DanhsachKH_DAO
    {
        private static DanhsachKH_DAO instance;

        public static DanhsachKH_DAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new DanhsachKH_DAO();

                return DanhsachKH_DAO.instance;
            }

            private set
            {
                DanhsachKH_DAO.instance = value;
            }
        }
        private DanhsachKH_DAO() { }


        public List<DanhsachKH_BUS> getlistClient()
        {
            List<DanhsachKH_BUS> list = new List<DanhsachKH_BUS>();

            DataTable data = DBconection.Instrance.ExecuteQuery("SELECT * FROM dbo.khachhang");
            foreach (DataRow item in data.Rows)
            {
                DanhsachKH_BUS p = new DanhsachKH_BUS(item);
                list.Add(p);
            }
            return list;
        }
        public List<DanhsachKH_BUS> getlistCMT()
        {
            List<DanhsachKH_BUS> list = new List<DanhsachKH_BUS>();

            DataTable data = DBconection.Instrance.ExecuteQuery("SELECT So_CMT FROM dbo.khachhang");
            foreach (DataRow item in data.Rows)
            {
                DanhsachKH_BUS p = new DanhsachKH_BUS(item);
                list.Add(p);
            }
            return list;
        }
        public DataTable danhsachkhachhang()
        {
            return DBconection.Instrance.ExecuteQuery("SELECT * FROM dbo.khachhang");
        }
        public DataTable layidkhachhang()
        {
            return DBconection.Instrance.ExecuteQuery("SELECT id FROM dbo.khachhang");
        }
        public bool Insertkhachhang(string hoten, string sdt, string soCMT, string LoaiKH)
        {
            int resutl = DBconection.Instrance.ExecuteNonQuery("EXEC dbo.usp_insertkhachhang @hoten , @sdt , @soCMT , @loaikh ", new object[] { hoten, sdt, soCMT, LoaiKH });
            return resutl > 0;
        }
        public bool Updatekhachhang(string hoten, string sdt, string soCMT, string LoaiKH)
        {
            int resutl = DBconection.Instrance.ExecuteNonQuery("EXEC dbo.usp_updatekhachhang @hoten , @sdt , @soCMT , @loaikh  ", new object[] { hoten, sdt, soCMT, LoaiKH });
            return resutl > 0;
        }
        public int MAXidClient()
        {
            try
            {
                return (int)DBconection.Instrance.ExecuteSalar("SELECT MAX(idNKhachHang) FROM dbo.khachhang");
            }
            catch
            {
                return 1;
            }
        }
             public bool xoakhachhang()
        {
            int resutl = DBconection.Instrance.ExecuteNonQuery("EXEC dbo.usp_xoakhachhang ", new object[] {  });
            return resutl > 0;
        }
    }
    }

