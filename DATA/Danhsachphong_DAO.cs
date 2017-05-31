﻿using BUS;
using DATA;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA
{
   public class Danhsachphong_DAO
    {
        private static Danhsachphong_DAO instance;

        public static Danhsachphong_DAO Instance
        {
            get { if (instance == null) instance = new Danhsachphong_DAO(); return Danhsachphong_DAO.instance; }
            private set { Danhsachphong_DAO.instance = value; }

        }
        private Danhsachphong_DAO() { }
        public DataTable getlistroms()
        {
            return DBconection.Instrance.ExecuteQuery("USP_getroms");
        }
        public DataTable getlistromid(string loai, string trangthai)
        {
            string query = "select * from dbo.Phong where loaiphong = N'" + loai + "' and trangthai = N'" + trangthai + "'";
            return DBconection.Instrance.ExecuteQuery(query);
        }
        private DataTable getlistromtrangthai(string trangthai)
        {
            string query = "select * from dbo.Phong where trangthai = N'" + trangthai + "'";
            return DBconection.Instrance.ExecuteQuery(query);
        }
        private DataTable getlistromloai(string loai)
        {
            string query = "select * from dbo.Phong where loaiphong = N'" + loai + "'";
            return DBconection.Instrance.ExecuteQuery(query);
        }
        public List<DanhsachPhong_BUS> getlistRomName()
        {
            List < DanhsachPhong_BUS > list= new List<DanhsachPhong_BUS>();

            DataTable data= DBconection.Instrance.ExecuteQuery("SELECT * FROM dbo.Phong");
            foreach(DataRow item in data.Rows)
            {
                DanhsachPhong_BUS phong = new DanhsachPhong_BUS(item);
                list.Add(phong);
            }
            return list;
        }
       

    }

}
