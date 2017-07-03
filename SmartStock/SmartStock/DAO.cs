using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace SmartStock
{
    class DAO
    {
        public static SqlConnection getCon()
        {
            SqlConnection con = new SqlConnection("Server=DESKTOP-3RCK7JG\\MUSTAFAOZCAN; Initial Catalog=SmartStock; Integrated Security=SSPI");

            //Uzaktan kontrol için connection string aşağıdaki gibi olacaktır.
            //"Data Source=192.168.2.102,1433;Network Library=DBMSSOCN; Initial Catalog=SmartStock; User ID=sa; Password=13061041"

            return con;
        }
    }
}
