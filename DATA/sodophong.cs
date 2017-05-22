using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
namespace DATA
{
    public class sodophong
    {
        private static sodophong instance;

        public static sodophong Instance
        {
            get { if (instance == null) instance = new sodophong();return sodophong.instance; } 
            private set { sodophong.instance = value; }
        }
        private sodophong() { }
        public List<Phong_DTO> listphong()
        {
            List<Phong_DTO> roms = new List<Phong_DTO>();
            DataTable rom = DBconection.Instrance.ExecuteQuery("USP_getroms");
            foreach(DataRow item in rom.Rows)
            {
                Phong_DTO r = new Phong_DTO(item);
                roms.Add(r);
            }
            return roms;
        }
    }
}
