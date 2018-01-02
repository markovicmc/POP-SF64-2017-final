using POP_SF_64_2017_GUI.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for KorisniciProzor.xaml
    /// </summary>
    public partial class KorisniciProzor : Window, INotifyPropertyChanged
    {
        public KorisniciProzor()
        {
            InitializeComponent();
            DataContext = this;
        }
        public static bool dodaj;

        public Korisnik SelektovanKorisnik { get; set; }

        private List<Korisnik> korisnici =  Database.Korisnici.Values.ToList();
        public List<Korisnik> Korisnici {
            get
            {
                korisnici = Database.Korisnici.Values.ToList();
                return korisnici;
            }
            set
            {
                korisnici =  Database.Korisnici.Values.ToList();
                OnPropertyChanged("Korisnici");
            }
        }

        private void IzmeniKorisnikaDugme_Click(object sender, RoutedEventArgs e)
        {
            Korisnik k = new Korisnik(SelektovanKorisnik);
            dodaj = false;
            DodajKorisnikaProzor izmeniKorisnikaProzor = new DodajKorisnikaProzor(k);
            izmeniKorisnikaProzor.ShowDialog();

            if (dodaj)
            {
                SelektovanKorisnik.Zameni(k);
                Refresh();
                //sacuvati u bazu?
            }
        }

        private void PovratakDugme_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DodajKorisnikaDugme_Click(object sender, RoutedEventArgs e)
        {
            Korisnik k = new Korisnik();
            dodaj = false;
            DodajKorisnikaProzor izmeniKorisnikaProzor = new DodajKorisnikaProzor(k);
            izmeniKorisnikaProzor.ShowDialog();

            if (dodaj)
            {
                Database.Korisnici[k.Username] = k;
                Refresh();
                //sacuvati u bazu?
            }
        }

        #region INotifyPropertyChanged 

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        void Refresh()
        {
            // List<Namestaj> tempList = new List<Namestaj>(korisnici);
            Korisnici = new List<Korisnik>() ;
        }
        #endregion

    }
}
