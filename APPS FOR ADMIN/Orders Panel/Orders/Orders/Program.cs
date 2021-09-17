using System;
using System.Threading;
using System.Data.Common;
using MySql.Data.MySqlClient;

namespace Orders
{
    class Program
    {
        static void Main(string[] args) {
            TimerCallback tc = new TimerCallback(GetConnection);    // creating delegate object for timer
            Timer timer = new Timer(tc, null, 0, 300000);            // creating timer. args: callback, value to send in callback, delay to start timer, delay to call function again

            Console.ReadKey();      // needs to make app don't close immediately
        }

        private static void GetOrders(MySqlConnection connection) {
            string sql = "SELECT * FROM `orders`";  // sql-string to get everything form table named 'orders'

            // getting ability to use sql commands and send request
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = sql;

            // using "using" as replace for try-catch-finally to have garanty that object gonna be destroyed as only it'll be unnedable
            using (DbDataReader reader = cmd.ExecuteReader()) {     // getting object that works with database
                if (reader.HasRows) {       // if there anything in db...

                    // ...than repeating commands-block below that getting data from db and displaying it in console
                    while (reader.Read()) {
                        string orderId = reader.GetString(0);
                        string buyerName = reader.GetString(1);
                        string address = reader.GetString(2);
                        string phone = reader.GetString(3);
                        string carId = reader.GetString(4);

                        Console.WriteLine("-------------------------------");   // amazing border
                        Console.WriteLine("Order ID: " + orderId);
                        Console.WriteLine("Buyer Name: " + buyerName);
                        Console.WriteLine("Buyer's address: " + address);
                        Console.WriteLine("Buyer's phone: " + phone);
                        Console.WriteLine("Ordered car ID: " + carId);
                    }
                }
            }
        }

        public static void GetConnection(object obj) {  // have to have this arg, for some reasons imposible to make callback without it, but in timer just setting "null" in it
            Console.Clear();
            MySqlConnection conn = DBUtils.GetDBConnection();   // getting connection, that creates in Class "DBUtils" and in Function "GetDBConnection"
            conn.Open();                                        // opening connection

            try {
                GetOrders(conn);    // getting data from db
            } catch (Exception e) {
                Console.WriteLine("Error: " + e);   // showing error if it excists
                Console.WriteLine(e.StackTrace);
            } finally {
                conn.Close();   // closing connection after all
                conn.Dispose(); // deleting connection object to free ram
            }
        }
    }
}
