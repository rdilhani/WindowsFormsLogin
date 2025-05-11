using System.Data.SqlClient;

namespace WindowsFormsLogin
{
    class DBConnection
    {    
        public SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-5KH52MH;Initial Catalog=DIT77;Integrated Security=True");
            return connection;
        }   
    }
}
