using POP_SF_64_2017_GUI.Baza;
using POP_SF_64_2017_GUI.Model;
using POP_SF_64_2017_GUI.Prozori;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace POP_SF_64_2017_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            string path = Directory.GetCurrentDirectory();
            path = path.Substring(0, path.LastIndexOf("bin")) + "Baza";
            AppDomain.CurrentDomain.SetData("DataDirectory", path);
            InitializeComponent();
     
            using (var unitOfWork = new Context())
            {
                if (unitOfWork.Korisnici.Find(1) == null)
                {
                    unitOfWork.Korisnici.Add(new Korisnik(0, "admin1", "admin1", "admin1", "admin1", TipKorisnika.ADMINISTRATOR));
                    unitOfWork.SaveChanges();
                    MessageBox.Show("Dodat admin1");
                }
                else
                {
                    MessageBox.Show("Vec postoji admin1");
                }

            }
        }

        private void btnOK(object sender, RoutedEventArgs e)
        {
            string username = this.tbUsername.Text;
            string pass = this.tbPassword.Password.ToString();

            if (Database.Korisnici.ContainsKey(username)) //ako ovaj username postoji u Korisnicima
            {
                Korisnik k = Database.Korisnici[username]; //napravi objekat k za taj username
                if (k.Password == pass) //ako se Password tog objekta poklapa sa ovim passwordom
                {
                    Window salonWindow;
                    if (k.Tip == TipKorisnika.ADMINISTRATOR)
                    {
                        salonWindow = new SalonProzor();
                    }
                    else
                    {
                        salonWindow = new ProdavacProzor();
                    }
                    salonWindow.Show();
                    this.Close();
                    return;
                }
            }

            this.tbUsername.Text = "";
            this.tbPassword.Password = "";

            MessageBox.Show(this, "Neispravno ime ili lozinka.");





        }

        private void btnCancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
