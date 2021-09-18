using MySql.Data.MySqlClient;

namespace Admin_Panel
{
    class DBMySqlUtils
    {
        // this code is understandable enought
        public static MySqlConnection GetDBConnection(string host, int port, string database, string username, string password)
        {
            string connString = "Server=" + host + ";Database=" + database + ";port=" + port + ";User Id=" + username + ";password=" + password + "; SSL Mode=None";
            MySqlConnection connect = new MySqlConnection(connString);
            return connect;
        }
    }
}
