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
    /// Interaction logic for CreateQuestion.xaml
    /// </summary>
    public partial class CreateQuestion : Window
    {
        ConnectorDb databaseConnector = ConnectorDb.Instance;
        List<string> letters = new List<string>();
        List<string> oblast = new List<string>();
        public CreateQuestion()
        {
            InitializeComponent();
            SetInfo();
        }

        private void SetInfo()
        {
            string sql = "SELECT naziv FROM slovo;";
            DataTable dataTable = new DataTable();
            dataTable = databaseConnector.ExecuteQueryD(sql);
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    string letter = row["naziv"].ToString();
                    Debug.WriteLine(letter);
                    letters.Add(letter);
                }
            }
            letterBox.ItemsSource = letters;

            string sql1 = "SELECT naziv FROM oblast;";
            dataTable = databaseConnector.ExecuteQueryD(sql1);
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    string o = row["naziv"].ToString();
                    oblast.Add(o);
                }
            }
            oblastBox.ItemsSource = oblast;
        }

        private void AddQuestion_Click(object sender, RoutedEventArgs e)
        {
            string letter = "";
            string oblast = "";
            string question = "";
            string answer = "";
            int letterId = 0;
            int oblastId = 0;
            if (letterBox.SelectedItem != null)
            {
                letter = letterBox.SelectedItem.ToString();
            }
            else
            {
                MessageBox.Show("Izaberite slovo!");
            }

            if (oblastBox.SelectedItem != null)
            {
                oblast = oblastBox.SelectedItem.ToString();
            }
            else
            {
                MessageBox.Show("Izaberite oblast!");
            }


            DataTable dataTable = new DataTable();
            string sql = "SELECT id FROM slovo WHERE naziv='" + letter + "';";
            dataTable = databaseConnector.ExecuteQueryD(sql);
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    letterId= Convert.ToInt32(row["id"]); 
                }
            }
            string sql1 = "SELECT id FROM oblast WHERE naziv='" + oblast + "';";
            dataTable = databaseConnector.ExecuteQueryD(sql);
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    oblastId = Convert.ToInt32(row["id"]);
                }
            }

            question = tbQuestion.Text;
            if (string.IsNullOrEmpty(question))
            {
                MessageBox.Show("Unesite pitanje!");
            }

            answer = tbAnswer.Text;
            if (!string.IsNullOrEmpty(question))
            {
                answer=answer.Replace("š", "s")
                       .Replace("č", "c")
                       .Replace("ć", "c")
                       .Replace("ž", "z")
                       .Replace("đ", "dj")
                       .Replace("Š", "S")
                       .Replace("Č", "C")
                       .Replace("Ć", "C")
                       .Replace("Ž", "Z")
                       .Replace("Đ", "Dj");
            }
            else
            {
                MessageBox.Show("Unesite odgovor!");
            }

            string sql2 = "INSERT INTO `pitanje`(`tekst`, `odgovor`, `oblast_id`, `slovo_id`) VALUES ('" + question + "','" + answer + "','" + oblastId + "','" + letterId + "');";
            Debug.WriteLine(sql2);
            databaseConnector.ExecuteQuery(sql2);
            MessageBox.Show("Uspesno ste kreirali pitanje");
        }
    }
}
