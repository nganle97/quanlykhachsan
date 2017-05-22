using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Phong_DTO
    {
        public int Maphong;
        public string Trangthai;// yes : phong kin, no: phongf co khach
        public string Loaiphong;
        public string Giaphong;
        public Phong_DTO() { }
        public Phong_DTO(int maphong,string trangthai,string loaiphong,string giaphong)
        {
            this.Maphong = maphong;
            this.Trangthai = trangthai;
            this.Loaiphong = loaiphong;
            this.Giaphong = giaphong;
        }
        public Phong_DTO(DataRow row)
        {
            this.Maphong = (int)row["id"];
            this.Loaiphong = row["loaiphong"].ToString();
            this.Giaphong = row["dongia"].ToString();
            this.Trangthai = row["trangthai"].ToString();
           
        }


    }
}
