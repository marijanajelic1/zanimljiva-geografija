using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZanimljivaGeografija
{
    public class ConnectorDb
    {
        private static ConnectorDb instance;
        private MySqlConnection msq;
        private string conString = "Server=127.0.0.1;Port=3306;Database=zanimljivageografija;Uid=root;";

        // Private constructor to prevent external instantiation
        private ConnectorDb()
        {
            msq = new MySqlConnection(conString);
        }

        // Public static property to access the single instance
        public static ConnectorDb Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ConnectorDb();
                }
                return instance;
            }
        }

        // Method to open the database connection
        public void OpenConnection()
        {
            if (msq.State == System.Data.ConnectionState.Closed)
                msq.Open();

        }

        // Method to close the database connection
        public void CloseConnection()
        {
            if (msq.State == System.Data.ConnectionState.Open)
                msq.Close();
        }
        public bool IsDatabaseConnected()
        {
            try
            {
                msq.Open();
                msq.Close();
                return true;
            }
            catch (Exception ex)
            {
                // Handle exceptions or display an error message.
                return false;
            }
        }

        // Example method to execute a query
        public void ExecuteQuery(string query)
        {
            try
            {
                OpenConnection();

                MySqlCommand cmd = new MySqlCommand(query, msq);
                // Execute your query here using cmd
                int rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine($"Insert command: {rowsAffected} rows affected");
                CloseConnection();
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately
            }
        }
      
        public DataTable ExecuteQueryD(string query)
        {
            DataTable dataTable = new DataTable();

            try
            {
                // Open the database connection
                OpenConnection();

                // Execute the query and read the results into the DataTable
                MySqlCommand cmd = new MySqlCommand(query, msq);
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                dataAdapter.Fill(dataTable);

                // Close the database connection
                CloseConnection();
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine("Error: " + ex.Message);
            }

            return dataTable;
        }
        public void InitializeDatabase()
        {
            try
            {

               //   string filePath = @"C:\Users\mjeli\source\repos\WpfApp1\WpfApp1\zanimljivageografija.sql";

                string filePath = @"..\..\..\zanimljivageografija.sql";

                Debug.WriteLine(filePath);

                string sqlScript = File.ReadAllText(filePath);

                ExecuteQuery(sqlScript);
                Debug.WriteLine("SQL Script Contents:");
                Debug.WriteLine(sqlScript);
                Debug.WriteLine("Database initialization completed.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error during database initialization:");
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
