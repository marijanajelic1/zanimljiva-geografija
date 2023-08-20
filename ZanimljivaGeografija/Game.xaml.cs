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
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Window

    {
        ConnectorDb databaseConnector = ConnectorDb.Instance;
        public string drzava = "";
        public string grad = "";
        public string reka = "";
        public string zivotinja = "";
        public string biljka = "";
        List<char> letters = new List<char>
        {
            'A','B','C','D','E','F','G','H','I','J','K','L','M','N'
        };
        public Game()
        {
            InitializeComponent();
            SetCenter(this);
            GetQuestions();
        }

        private void SetCenter(Window window)
        {
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;

        }
        private DataTable MakeQuery(char letter, string type)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string sql = @"SELECT tekst, odgovor FROM pitanje 
                            INNER JOIN oblast o ON pitanje.oblast_id=o.id
                            INNER JOIN slovo s ON pitanje.slovo_id=s.id
                            WHERE s.naziv='" + letter + "' AND o.naziv='" + type + "' ORDER BY RAND() LIMIT 1;";
                dataTable = databaseConnector.ExecuteQueryD(sql);
                return dataTable;
            }
            catch (MySqlException x)
            {
                MessageBox.Show("Došlo je do greške prilikom izvršavanja SELECT upita. Proverite bazu podataka i konekciju: " + x.ToString(), "Greška!");
            }
            return dataTable;
        }

        private void SetQuestions(DataTable dataTable, out string odgovor, int id)
        {
            odgovor = "";
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    switch (id)
                    {
                        case 1: 
                            tb1.Text = row["tekst"].ToString();
                            break;
                        case 2:
                            tb2.Text = row["tekst"].ToString();
                            break;
                        case 3:
                            tb3.Text = row["tekst"].ToString();
                            break;
                        case 4:
                            tb4.Text = row["tekst"].ToString();
                            break;
                        case 5:
                            tb5.Text = row["tekst"].ToString();
                            break;
                        default:
                            break;
                    }
                    odgovor = row["odgovor"].ToString();
                }
            }
        }

        private void GetQuestions()
        {

            char letter = GetLetter(letters);
            tbZ.Text = "Zanimljiva geografija na slovo " + letter.ToString();
            DataTable dataTableDrzava = MakeQuery(letter, "drzava");
            SetQuestions(dataTableDrzava, out drzava, 1);
          
            DataTable dataTableGrad = MakeQuery(letter, "grad");
            SetQuestions(dataTableGrad, out grad, 2);
            
            DataTable dataTableReka = MakeQuery(letter, "reka");
            SetQuestions(dataTableReka, out reka, 3);
           
            DataTable dataTableZivotinja= MakeQuery(letter, "zivotinja");
            SetQuestions(dataTableZivotinja, out zivotinja, 4);
           
            DataTable dataTableBiljka = MakeQuery(letter, "biljka");
            SetQuestions(dataTableBiljka, out biljka, 5);
        }
        static char GetLetter(List<char> letters)
        {
            Random rand = new Random();
            int letterIndex = rand.Next(0, letters.Count);
            return letters[letterIndex];
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int count = 0;
            string netacno = "";
            string answerDrzava = tbAnswer1.Text;
            if (!string.IsNullOrEmpty(answerDrzava)) { 
                answerDrzava = answerDrzava.Replace("š", "s")
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
            if (!string.IsNullOrEmpty(answerDrzava) && char.IsLower(answerDrzava[0]))
            {
                answerDrzava = char.ToUpper(answerDrzava[0]) + answerDrzava.Substring(1);
            }
            if(!string.IsNullOrEmpty(answerDrzava) && answerDrzava == drzava)
            {
                count++;
            }
            else
            {
                string netacanOdgovor = "Pogrešili ste pitanje broj 1. Tačan odgovor na pitanje je: " + drzava + "\n";
                netacno += netacanOdgovor;
            }
            

            string answerGrad = tbAnswer2.Text;
            if (!string.IsNullOrEmpty(answerGrad))
            {
                answerGrad = answerGrad.Replace("š", "s")
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
            if (!string.IsNullOrEmpty(answerGrad) && char.IsLower(answerGrad[0]))
            {
                answerGrad = char.ToUpper(answerGrad[0]) + answerGrad.Substring(1);
            }
            if (!string.IsNullOrEmpty(answerGrad) && answerGrad == grad)
            {
                count++;
            }
            else
            {
                string netacanOdgovor = "Pogrešili ste pitanje broj 2. Tačan odgovor na pitanje je: " + grad + "\n";
                netacno += netacanOdgovor;
            }

            string answerReka = tbAnswer3.Text;
            if (!string.IsNullOrEmpty(answerReka))
            {
                answerReka = answerReka.Replace("š", "s")
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
            if (!string.IsNullOrEmpty(answerReka) && char.IsLower(answerReka[0]))
            {
                answerReka = char.ToUpper(answerReka[0]) + answerReka.Substring(1);
            }
            if (!string.IsNullOrEmpty(answerReka) && answerReka == reka)
            {
                count++;
            }
            else
            {
                string netacanOdgovor = "Pogrešili ste pitanje broj 3. Tačan odgovor na pitanje je: " + reka + "\n";
                netacno += netacanOdgovor;
            }

            string answerZivotinja = tbAnswer4.Text;
            if (!string.IsNullOrEmpty(answerZivotinja))
            {
                answerZivotinja = answerZivotinja.Replace("š", "s")
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
            if (!string.IsNullOrEmpty(answerZivotinja) && char.IsLower(answerZivotinja[0]))
            {
                answerZivotinja = char.ToUpper(answerZivotinja[0]) + answerZivotinja.Substring(1);
            }
            if (!string.IsNullOrEmpty(answerZivotinja) && answerZivotinja == zivotinja)
            {
                count++;
            }
            else
            {
                string netacanOdgovor = "Pogrešili ste pitanje broj 4. Tačan odgovor na pitanje je: " + zivotinja + "\n";
                netacno += netacanOdgovor;
            }

            string answerBiljka = tbAnswer5.Text;
            if (!string.IsNullOrEmpty(answerBiljka))
            {
                answerBiljka = answerBiljka.Replace("š", "s")
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
            if (!string.IsNullOrEmpty(answerBiljka) && char.IsLower(answerBiljka[0]))
            {
                answerBiljka = char.ToUpper(answerBiljka[0]) + answerBiljka.Substring(1);
            }
            if (!string.IsNullOrEmpty(answerBiljka) && answerBiljka == biljka)
            {
                count++;
            }
            else
            {
                string netacanOdgovor = "Pogrešili ste pitanje broj 5. Tačan odgovor na pitanje je: " + biljka +"\n";
                netacno += netacanOdgovor;
            }

            int id = int.Parse(Application.Current.Properties["ID"].ToString());
         
            if (count != 0)
            {
                try
                {
                    string sql = "INSERT INTO `odgovori`(`igrac_id`, `brojtacnih`) VALUES ('" + id + "','" + count + "');";
                    databaseConnector.ExecuteQuery(sql);
                }
                catch (MySqlException x)
                {
                    MessageBox.Show("Došlo je do greške prilikom izvršavanja INSERT upita. Proverite bazu podataka i konekciju: " + x.ToString(), "Greška!");
                }
            }

            MessageBox.Show("Imate sledeći broj tačnih odgovora: " + count + "\n" + netacno, "Rezultati");
            GamerProfile gamerProfile = new GamerProfile();
            gamerProfile.Show();
            this.Close();

        }
    }
}
