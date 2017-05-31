using BUS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA
{
    public class Hoadon_DAO
    {
        private static Hoadon_DAO instance;

         public static Hoadon_DAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new Hoadon_DAO();

                return Hoadon_DAO.instance;
            }

           private set
            {
               Hoadon_DAO.instance = value;
            }
        }
        private Hoadon_DAO() { }

        public int GetuncheckbillbyIdRom(int id)
        {
            DataTable data = DBconection.Instrance.ExecuteQuery("SELECT * FROM dbo.HoaDon WHERE id="+id+" AND TrangThai='chua thanh toan'");
            if(data.Rows.Count>0)
            {
                Hoadon_BUS hd = new Hoadon_BUS(data.Rows[0]);
                return hd.Idhoadon;
            }
            return -1;
        }
        public void checkout(int id,string acc, float thanhtien)
        {
            DBconection.Instrance.ExecuteNonQuery("EXEC dbo.usp_updatehoadon @idhoadon ="+id+" ,@tongtien = "+thanhtien+", @trangthai = N'chua thanh toan' ");
        }
        public void updatehoadon(int id)
        {
            DBconection.Instrance.ExecuteNonQuery("EXEC dbo.usp_themhoadon @idhoadon", new object[id]);
        }
        public int getmaxidbill()
        {
            try
            {
                return (int)DBconection.Instrance.ExecuteSalar("SELECT MAX(id) FROM dbo.HoaDon");
            }
            catch
            {
                return 1;
            }
        }
        public static int GetNumBillByDate(DateTime from, DateTime to)
        {
            return (int)DBconection.Instrance.ExecuteSalar("EXEC dbo.usp_tinhsohoadon @DateIn, @DateOut ", new object[] { from, to });
         }
        public static DataTable getlistbill()
        {
            return DBconection.Instrance.ExecuteQuery("SELECT hd.id, hd.TG_NhanPhong,hd.TG_TraPhong,hd.TongTien,p.tenphong,hd.TrangThai FROM dbo.HoaDon hd, dbo.phieuthuephong t, dbo.Phong p WHERE hd.idphieuthuephong=t.id AND p.id=t.idphong ");
        }
        public static DataTable getidClient()
        {
            return DBconection.Instrance.ExecuteQuery("SELECT id FROM  dbo.HoaDon  ");
        }
        public List<Hoadon_BUS> getlistClient()
        {
            List<Hoadon_BUS> list = new List<Hoadon_BUS>();

            DataTable data = DBconection.Instrance.ExecuteQuery("SELECT * FROM hoadon");
            foreach (DataRow item in data.Rows)
            {
                Hoadon_BUS p = new Hoadon_BUS(item);
                list.Add(p);
            }
            return list;
        }
    }
}
