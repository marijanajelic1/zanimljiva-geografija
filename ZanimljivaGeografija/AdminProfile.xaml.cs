using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for AdminProfile.xaml
    /// </summary>
    public partial class AdminProfile : Window
    {
        ConnectorDb databaseConnector = ConnectorDb.Instance;
        public AdminProfile()
        {
            InitializeComponent();
            SetCenter(this);
            Name();
        }
        private void Name()
        {
            int id = int.Parse(Application.Current.Properties["ID"].ToString());
            string sql = @"SELECT ime, prezime FROM profil 
                INNER JOIN korisnik ON profil.korisnik_id=korisnik.id
                WHERE korisnik_id='" + id + "';";
            string fullName = "Dobrodošli ";
            try
            {
                DataTable dataTable;
                dataTable = databaseConnector.ExecuteQueryD(sql);
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        string name = row["ime"].ToString();
                        fullName += name + " ";
                        string surname = row["prezime"].ToString();
                        fullName += surname;
                        tbD.Text = fullName;
                    }
                }
            }
            catch (MySqlException x)
            {
                MessageBox.Show("Došlo je do greške: " + x);
            }

            tbD.Text = fullName;
        }

        private void SetCenter(Window window)
        {
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;

        }

        private void CreateQuestion_Click(object sender, RoutedEventArgs e)
        {
            CreateQuestion createQuestion = new CreateQuestion();
            createQuestion.Show();
            this.Close();
        }
        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Properties.Remove("ID");
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
