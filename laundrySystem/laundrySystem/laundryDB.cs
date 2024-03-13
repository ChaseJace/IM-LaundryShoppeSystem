using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace laundrySystem
{
    internal class laundryDB
    {
        private string connectionString;

        public laundryDB(string ConnectionString)
        {
            this.connectionString = ConnectionString;
            MySqlConnection dbconn = new MySqlConnection(connectionString);
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable dt = new DataTable();

            //laundryDB laundryDb = new laundryDB("datasource=127.0.0.1; port = 3306; username = root; password=; database = db_laundry"); put this in other forms
        }

        public void ExecuteNonQuery(string query)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString)) 
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Connection Success");
                } catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
