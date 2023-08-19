using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ZanimljivaGeografija
{
    public class ConnectorDb
    {
        private static ConnectorDb instance;
        private MySqlConnection msq;
        private string conString = "Server=127.0.0.1;Port=3306;Database=zanimljivageografija;Uid=root;";

        private ConnectorDb()
        {
            msq = new MySqlConnection(conString);
        }

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

        public void OpenConnection()
        {
            if (msq.State == System.Data.ConnectionState.Closed)
                msq.Open();

        }

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
                return false;
            }
        }

        public void ExecuteQuery(string query)
        {
            try
            {
                OpenConnection();

                MySqlCommand cmd = new MySqlCommand(query, msq);
                int rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine($"Insert command: {rowsAffected} rows affected");
                CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške: " + ex);
            }
        }
      
        public DataTable ExecuteQueryD(string query)
        {
            DataTable dataTable = new DataTable();

            try
            {
                OpenConnection();

                MySqlCommand cmd = new MySqlCommand(query, msq);
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                dataAdapter.Fill(dataTable);

                CloseConnection();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Došlo je do greške: " + ex);
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
