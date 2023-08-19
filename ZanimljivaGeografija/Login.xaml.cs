using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ZanimljivaGeografija
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        string username;
        string password;
        int type;
        public Login()
        {
            InitializeComponent();
            SetCenter(this);
        }

        private void SetCenter(Window window)
        {
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;

        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            ConnectorDb databaseConnector = ConnectorDb.Instance;
            string sql;
            username = tbUsername.Text;
            password = tbPassword.Password;
            int id;
            string user;
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Niste lepo popunili zahtev.");
            }
            else
            {
               sql = "SELECT * FROM korisnik WHERE username ='" + username + "' AND password = '" + password + "';";
                try
                {
                    DataTable dataTable = databaseConnector.ExecuteQueryD(sql);
                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        Debug.WriteLine("Korisnik id: ");
                        foreach (DataRow row in dataTable.Rows)
                        {
                            id = Convert.ToInt32(row["id"]);
                            Application.Current.Properties["ID"] = id;
                            user = row["username"].ToString();
                            type = Convert.ToInt32(row["tip_id"]);
                            Debug.WriteLine($"ID: {id}, user: {username}");
                        }
                        int id1 = int.Parse(Application.Current.Properties["ID"].ToString());
                        Debug.WriteLine("Id je " + id1);
                        if (type == 1)
                        {
                            GamerProfile gamerProfile = new GamerProfile();
                            gamerProfile.Show();
                            this.Close();
                        }
                        else
                        {
                            AdminProfile adminProfile = new AdminProfile();
                            adminProfile.Show();
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Pogresan username ili password");
                    }
                }catch(MySqlException x)
                {
                    MessageBox.Show("Došlo je do greške: " + x);
                }
            }
            tbUsername.Text = "";
            tbPassword.Password = "";
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Signup signup = new Signup();
            signup.Show();
            this.Close();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
