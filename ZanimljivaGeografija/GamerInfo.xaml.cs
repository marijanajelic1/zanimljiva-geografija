using iTextSharp.text.pdf;
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
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using iTextSharp.text;
using Paragraph = iTextSharp.text.Paragraph;
using Microsoft.Win32;

namespace ZanimljivaGeografija
{
    /// <summary>
    /// Interaction logic for GamerInfo.xaml
    /// </summary>
    public partial class GamerInfo : Window
    {
        ConnectorDb databaseConnector = ConnectorDb.Instance;
        public int finalCount = 0;
        public int finalAnswer = 0;
        public int finalScore = 0;
        public GamerInfo()
        {
            InitializeComponent();
            SetCenter(this);
            GetInfo();
        }

        private void SetCenter(Window window)
        {
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;

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
            try
            {
                DataTable dataTable = new DataTable();
                dataTable = databaseConnector.ExecuteQueryD(sql);

                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        count = row["broj"].ToString();
                        if (!int.TryParse(count, out countInt))
                        {
                            Debug.WriteLine("Greska");
                        }
                        answer = row["brtacnih"].ToString();
                        if (!int.TryParse(answer, out answerInt))
                        {
                            Debug.WriteLine("Greska");
                        }
                    }
                }
                if (countInt == 0)
                {
                    info += "Niste odradili nijedan test.";
                    tbInfo.Text = info;
                }
                else
                {
                    int testNumber = countInt * 5;
                    Debug.WriteLine(testNumber);
                    int answers = answerInt;
                    float score;
                    score = ((float)answers / testNumber) * 100;
                    int roundScore = (int)Math.Round(score);
                    Debug.WriteLine(score);
                    info += "Na " + count + " testa imali ste " + answer + " tačnih odgovora. To ukupno čini " + roundScore + "%.";
                    finalCount = countInt;
                    finalAnswer = answerInt;
                    finalScore = roundScore;
                    Debug.WriteLine(info);
                    tbInfo.Text = info;
                }
            }
            catch (MySqlException x)
            {
                MessageBox.Show("Došlo je do greške: " + x);
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            GamerProfile gamerProfile = new GamerProfile();
            gamerProfile.Show();
            this.Close();
        }

        private void PDF_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(Application.Current.Properties["ID"].ToString());
            string sql = @"SELECT ime, prezime FROM profil 
                INNER JOIN korisnik ON profil.korisnik_id=korisnik.id
                WHERE korisnik_id='" + id + "';";
            string name = "";
            string surname = "";
            try
            {
                DataTable dataTable;
                dataTable = databaseConnector.ExecuteQueryD(sql);
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        name = row["ime"].ToString();
                        surname = row["prezime"].ToString();
                    }
                }

                string dataPDF = "";
                dataPDF += "Korisnik " + name + " " + surname + " ";
                if (finalCount == 0)
                {
                    dataPDF += "do sada nije odradio nijedan test.";
                }
                else
                {
                    dataPDF+="je do sada odradio " + finalCount + " testa. Korisnik je na testiranjima imao ukupno " + finalAnswer + " odgovora i to cini " + finalScore + "%.";
                }
                Document document = new Document();
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream("info.pdf", FileMode.Create));
                document.Open();
                Paragraph paragraph = new Paragraph(dataPDF);
                paragraph.Alignment = Element.ALIGN_CENTER;
                paragraph.SpacingBefore = 20f;
                paragraph.SpacingAfter = 20f;
                document.Add(paragraph);

                string date= DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string datePDF = "Generisano datuma " + date;
                Paragraph dateParagraph = new Paragraph(datePDF);
                dateParagraph.Alignment = Element.ALIGN_CENTER;
                dateParagraph.SpacingAfter = 20f;
                document.Add(dateParagraph);
                document.Close();

                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.FileName = "info.pdf";
                if (saveDialog.ShowDialog() == true)
                {
                    File.Copy("info.pdf", saveDialog.FileName, true);
                }

            }
            catch (MySqlException x)
            {
                MessageBox.Show("Došlo je do greške: " + x);
            }

        }
    }
}
