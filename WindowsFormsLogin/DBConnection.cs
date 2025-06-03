using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsLogin
{
    class DBConnection
    {
        public SqlConnection getConnection() {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5KH52MH;Initial Catalog=SMS;Integrated Security=True");
            return con;

        }
    }
}
