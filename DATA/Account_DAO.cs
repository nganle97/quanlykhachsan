using BUS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA
{
    public class Account_DAO
    {
        private static Account_DAO instance;

        public static Account_DAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new Account_DAO();
                return instance;
            }

            set
            {
                Account_DAO.instance = value;
            }
        }
        private Account_DAO() { }
        public bool login(string username, string password)
        {
            string query = "SELECT * FROM dbo.thongtintaikhoan WHERE userName=N'"+ username + " ' AND pass=N'"+ password +" '";
            DataTable result = DBconection.Instrance.ExecuteQuery(query);
            return result.Rows.Count>0;
        }
        public int kiemtradangnhap()
        {

            return  0 ;
        }
        public  Account getaccountbyUsername(string username)
        {
          
           DataTable data = DBconection.Instrance.ExecuteQuery("SELECT * FROM dbo.thongtintaikhoan where username='"+username +"'");

            foreach(DataRow item in data.Rows)
            {
                return new Account(item);
            }
            return null;
        }
       
        public bool doimatkhau(string username, string password, string newpassword)
        {
            int result = DBconection.Instrance.ExecuteNonQuery("EXEC dbo.usp_updateAccount @userName , @pass , @newpass ", new object[] { username, password, newpassword });

            return result > 0;
        }
      
    }
}
