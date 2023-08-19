using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing.Text;

namespace ZanimljivaGeografija
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ConnectorDb dbConnector;
        public MainWindow()
        {
            InitializeComponent();
            SetCenter(this);
            dbConnector = ConnectorDb.Instance;
        }

        private void SetCenter(Window window)
        {
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;

        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {
             Login login= new Login();
             login.Show();
             this.Close();


        }

        private void Signup_Click(object sender, RoutedEventArgs e)
        {
            Signup signup = new Signup();
            signup.Show();
            this.Close();
        }
    }
}
