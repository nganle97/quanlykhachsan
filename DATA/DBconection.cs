using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DATA
{
    public class DBconection
    {
        private static DBconection instrance;

        public static DBconection Instrance
        {
            get
            {
                if (instrance == null)
                    instrance = new DBconection();
                return instrance;
            }

         private   set
            {
                DBconection.instrance = value;
            }
        }

        private DBconection() { }

        private  string ConnectionSTR = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyKhachSan;Integrated Security=True";
      
        public  DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConnectionSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(data);

                connection.Close();
            }

            return data;
        }

        public  int ExecutenonQuery(string query, object[] parameter = null)
        {
            int tem = 0;

            using (SqlConnection connection = new SqlConnection(ConnectionSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                tem = command.ExecuteNonQuery();
                connection.Close();
            }

            return tem;// trả về số dòng đc thực thi
            //sd:insert, update, delete
        }

    }


}
    

