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
    /// Interaction logic for Signup.xaml
    /// </summary>
    public partial class Signup : Window
    {
        string name;
        string surname;
        string phone;
        int p;
        string email;
        string username;
        string password;
        public Signup()
        {
            InitializeComponent();
            SetCenter(this);
        }

        private void SetCenter(Window window)
        {
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;

        }

        private void Signup_Click(object sender, RoutedEventArgs e)
        {
            ConnectorDb databaseConnector = ConnectorDb.Instance;
            name = tbName.Text;
            surname = tbSurname.Text;
            phone = tbPhone.Text;
            if(!int.TryParse(phone, out p))
            {
                Debug.WriteLine("Greska");
            }
            email = tbEmail.Text;
            username = tbUsername.Text;
            password = tbPassword.Password;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Niste pravilno popunili zahtev.");
            }
            else
            {
                string check= "SELECT `id` FROM `korisnik` WHERE `username` LIKE '" + username + "';";
                try
                {
                    DataTable dataTableCheck = databaseConnector.ExecuteQueryD(check);
                    if (dataTableCheck != null && dataTableCheck.Rows.Count > 0)
                    {
                        MessageBox.Show("Korisničko ime koje ste izabrali već postoji!");
                    }
                    else
                    {
                        string sql = "INSERT INTO `korisnik`(`username`, `password`, `tip_id`) VALUES('" + username + "', '" + password + "', '1'); ";
                        databaseConnector.ExecuteQuery(sql);
                        string sql1 = "SELECT `id` FROM `korisnik` WHERE `username` LIKE '" + username + "';";
                        DataTable dataTable = databaseConnector.ExecuteQueryD(sql1);
                        if (dataTable != null && dataTable.Rows.Count > 0)
                        {
                            DataRow row = dataTable.Rows[0];
                            int id = Convert.ToInt32(row["id"]);

                            sql = "INSERT INTO `profil`(`ime`, `prezime`, `email`, `telefon`, `korisnik_id`) VALUES('" + name + "', '" + surname + "', '" + email + "', '" + p + "', '" + id + "');";
                            databaseConnector.ExecuteQuery(sql);
                            MessageBox.Show("Uspešno ste kreirali profil.");
                            Login login = new Login();
                            SetCenter(login);
                            login.Show();
                            this.Close();
                        }
                    }
                }catch(MySqlException x)
                {
                    MessageBox.Show("Došlo je do greške: " + x);
                }
            }
            tbName.Text = "";
            tbSurname.Text = "";
            tbEmail.Text = "";
            tbPhone.Text = "";
            tbUsername.Text = "";
            tbPassword.Password = "";
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
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
