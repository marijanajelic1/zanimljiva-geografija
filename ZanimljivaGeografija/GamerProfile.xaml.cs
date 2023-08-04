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
    /// Interaction logic for GamerProfile.xaml
    /// </summary>
    public partial class GamerProfile : Window
    {
        ConnectorDb databaseConnector = ConnectorDb.Instance;
        public GamerProfile()
        {
            InitializeComponent();
            Name();
        }

        private void Name()
        {
            int id = int.Parse(Application.Current.Properties["ID"].ToString());
            string sql = @"SELECT ime, prezime FROM profil 
                INNER JOIN korisnik ON profil.korisnik_id=korisnik.id
                WHERE korisnik_id='" + id + "';" ;
            string fullName = "Dobrodosli ";
            try
            {
                DataTable dataTable;
                dataTable = databaseConnector.ExecuteQueryD(sql);
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        string name= row["ime"].ToString();
                        fullName += name + " ";
                        string surname= row["prezime"].ToString();
                        fullName += surname;
                        tbD.Text = fullName;
                    }
                }
            }
            catch (Exception)
            {

            }

            tbD.Text = fullName;
        }

        private void GameStart_Click(object sender, RoutedEventArgs e)
        {
            Game game = new Game();
            game.Show();
            this.Close();
        }

        private void Score_Click(object sender, RoutedEventArgs e)
        {
            GamerInfo gamerInfo = new GamerInfo();
            gamerInfo.Show();
            this.Close();
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
