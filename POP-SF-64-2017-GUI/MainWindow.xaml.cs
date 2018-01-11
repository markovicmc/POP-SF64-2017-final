using POP_SF_64_2017_GUI.Baza;
using POP_SF_64_2017_GUI.Model;
using POP_SF_64_2017_GUI.Prozori;
using System;
using System.IO;
using System.Windows;


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
