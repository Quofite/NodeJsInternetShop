// YOU SHOULD ENTER YoUR OWN DATABASE DATA IN FIELDS
// YOU SHOULD RENAME THIS FILE TO "DbUtils" without quotation marks

using MySql.Data.MySqlClient;

namespace Orders
{
    class EXAMPLE_DBUtils
    {
        public static MySqlConnection GetDBConnection()
        {
            string host = "";
            int port = 0;
            string user = "";
            string pass = "";
            string database = "";

            return DBMySqlUtils.GetDBConnection(host, port, database, user, pass);
        }
    }
}
