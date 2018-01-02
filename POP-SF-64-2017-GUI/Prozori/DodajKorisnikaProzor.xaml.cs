using POP_SF_64_2017_GUI.Model;
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
using System.Windows.Shapes;

namespace POP_SF_64_2017_GUI.Prozori
{
    /// <summary>
    /// Interaction logic for DodajKorisnikaProzor.xaml
    /// </summary>
    public partial class DodajKorisnikaProzor : Window
    {
        public DodajKorisnikaProzor(Korisnik korisnik) //Isti prozor korisim i za dodavanje i za editovanje
                                                       //kod dodavanja prosledim prazan objekat, kod izmene selektovan
        {
            InitializeComponent();
            DataContext = this;
            Korisnik = korisnik;

            Izbor = new List<string>();
            Izbor.Add("Administrator");
            Izbor.Add("Prodavac");
            cbTipKorisnika.ItemsSource = Izbor;

            if (korisnik.Tip == TipKorisnika.ADMINISTRATOR)
                cbTipKorisnika.SelectedItem = Izbor[0];
            else if (korisnik.Tip == TipKorisnika.PRODAVAC)
                cbTipKorisnika.SelectedItem = Izbor[1];
        }

        public List<string> Izbor { get; set; }

        public Korisnik Korisnik { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            switch (cbTipKorisnika.SelectedValue)
            {
                case "Administrator":
                    Korisnik.Tip = TipKorisnika.ADMINISTRATOR;
                    break;
                case "Prodavac":
                    Korisnik.Tip = TipKorisnika.PRODAVAC;
                    break;
                default:
                    MessageBox.Show("Niste izabrali tip korisnika.");
                    return;
            }

            if(string.IsNullOrEmpty(Korisnik.Username) || string.IsNullOrWhiteSpace(Korisnik.Username))
            {
                MessageBox.Show("Nije uneto korisnicko ime.");
                return;
            }

            if (string.IsNullOrEmpty(Korisnik.Ime) || string.IsNullOrWhiteSpace(Korisnik.Ime))
            {
                MessageBox.Show("Nije uneto  ime.");
                return;
            }

            if (string.IsNullOrEmpty(Korisnik.Password) || string.IsNullOrWhiteSpace(Korisnik.Password))
            {
                MessageBox.Show("Nije uneto Password.");
                return;
            }

            if (string.IsNullOrEmpty(Korisnik.Prezime) || string.IsNullOrWhiteSpace(Korisnik.Prezime))
            {
                MessageBox.Show("Nije uneto Prezime.");
                return;
            }

            KorisniciProzor.dodaj = true;
            this.Close();
        }
    }
}
