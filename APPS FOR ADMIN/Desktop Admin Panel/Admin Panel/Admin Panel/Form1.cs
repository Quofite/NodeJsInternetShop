using System;
using System.Data.Common;
using System.Threading;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Admin_Panel
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void ordersButton_Click(object sender, EventArgs e)
        {
            pageLabel.Text = "СТРАНИЦА: ЗАКАЗЫ";
            Show(1);
        }

        private void reviewButton_Click(object sender, EventArgs e)
        {
            pageLabel.Text = "СТРАНИЦА: ОТЗЫВЫ";
            Show(2);
        }

        private void asksButton_Click(object sender, EventArgs e)
        {
            pageLabel.Text = "СТРАНИЦА: ВОПРОСЫ";
            Show(3);
        }

        private void Show(int mode)
        {
            textBox.Text = string.Empty;
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();

            try
            {
                switch (mode)
                {
                    case 1:
                        GetOrders(conn);
                        break;
                    case 3:
                        GetAsks(conn);
                        break;
                    default:
                        MessageBox.Show("Пока недоступно");
                        break;
                }
            }
            catch (Exception err)
            {
                textBox.Text = err.Message + '\r' + '\n';
                textBox.Text += err.StackTrace;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        // -----------------------------------------

        private void GetOrders(MySqlConnection connection) {
            string sql = "SELECT * FROM `orders`";

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = sql;

            using (DbDataReader reader = cmd.ExecuteReader()) {
                if (reader.HasRows) {
                    while (reader.Read()) {
                        string orderId = reader.GetString(0);
                        string buyerName = reader.GetString(1);
                        string address = reader.GetString(2);
                        string phone = reader.GetString(3);
                        string carId = reader.GetString(4);

                        textBox.Text += "--------------------" + '\r' + '\n';
                        textBox.Text += "Order ID: " + orderId + '\r' + '\n';
                        textBox.Text += "Buyer Name: " + buyerName + '\r' + '\n';
                        textBox.Text += "Buyer's address: " + address + '\r' + '\n';
                        textBox.Text += "Buyer's phone: " + phone + '\r' + '\n';
                        textBox.Text += "Ordered car ID: " + carId + '\r' + '\n';
                    }
                }
            }
        }

        private void GetAsks(MySqlConnection connection) {
            string sql = "SELECT * FROM `asks`";

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = sql;

            using (DbDataReader reader = cmd.ExecuteReader()) {
                if (reader.HasRows) {
                    while (reader.Read()) {
                        string askerName = reader.GetString(0);
                        string askerEmail = reader.GetString(1);
                        string ask = reader.GetString(2);

                        textBox.Text += "--------------------" + '\r' + '\n';
                        textBox.Text += "Asker name: " + askerName + '\r' + '\n';
                        textBox.Text += "Asker email: " + askerEmail + '\r' + '\n';
                        textBox.Text += "Ask: " + ask + '\r' + '\n';
                    }
                }
            }
        }
    }
}
