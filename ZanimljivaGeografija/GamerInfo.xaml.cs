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
    /// Interaction logic for GamerInfo.xaml
    /// </summary>
    public partial class GamerInfo : Window
    {
        ConnectorDb databaseConnector = ConnectorDb.Instance;
        public GamerInfo()
        {
            InitializeComponent();
            GetInfo();
        }

        private void GetInfo()
        {
            string count="";
            string answer="";
            int countInt=0;
            int answerInt=0;
            string info = "";
            int id = int.Parse(Application.Current.Properties["ID"].ToString());
            string sql = "SELECT COUNT(id) AS broj, SUM(brojtacnih) AS brtacnih FROM odgovori WHERE igrac_id = '" + id + "';";
            DataTable dataTable = new DataTable();
            dataTable = databaseConnector.ExecuteQueryD(sql);
            //proveriti da li radi
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    count = row["broj"].ToString();
                    info += "Na " + count + " testa imali ste ";
                    if (!int.TryParse(count, out countInt))
                    {
                        Debug.WriteLine("Greska");
                    }
                    answer = row["brtacnih"].ToString();
                    info += answer + " tačnih odgovora. ";
                    if (!int.TryParse(answer, out answerInt))
                    {
                        Debug.WriteLine("Greska");
                    }
                }
            }
            int testNumber = countInt * 5;
            int score = 0; 
            score+= (answerInt / testNumber) * 100;
            info += "To ukupno čini " + score + " %.";
          //  info += "Na " + count + " testa imali ste " + answer + " tačnih odgovora. To ukupno čini " + score + "%.";
            Debug.WriteLine(info);
            tbInfo.Text = info;
        }
    }
}
