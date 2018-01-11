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

        private List<Korisnik> korisnici = Database.Korisnici.Values.ToList();
        public List<Korisnik> Korisnici
        {
            get
            {
                korisnici = Database.Korisnici.Values.ToList();
                return korisnici;
            }
            set
            {
                korisnici = Database.Korisnici.Values.ToList();
                OnPropertyChanged("Korisnici");
            }
        }

        private void IzmeniKorisnikaDugme_Click(object sender, RoutedEventArgs e)
        {
            if(SelektovanKorisnik == null)
            {
                MessageBox.Show("Niste izabrali korisnika za izmenu.");
                return;
            }
            Korisnik k = new Korisnik(SelektovanKorisnik);
            dodaj = false;
            DodajKorisnikaProzor izmeniKorisnikaProzor = new DodajKorisnikaProzor(k);
            izmeniKorisnikaProzor.ShowDialog();

            if (dodaj)
            {
                SelektovanKorisnik.Zameni(k);
                Refresh();
                using(var unitOfWork = new Baza.Context())
                {
                    Korisnik izBaze = unitOfWork.Korisnici.Find(k.ID);
                    if (k != null)
                    {
                        izBaze.Zameni(k);
                        unitOfWork.SaveChanges();
                    }
                }
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
                using (var unitOfWork = new Baza.Context())
                {
                    Korisnik izBaze = unitOfWork.Korisnici.Add(k);
                    
                    unitOfWork.SaveChanges();
                    
                }
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
            Korisnici = new List<Korisnik>();
        }
        #endregion

        private void Button_Click(object sender, RoutedEventArgs e) //obrisi button
        {
            string sMessageBoxText = "Da li zelite da obrisete korisnika?";
            string sCaption = "Brisanje korisnika";

            MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
            MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

            MessageBoxResult rsltMessageBox = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);

            if (rsltMessageBox == MessageBoxResult.Yes)
            {
                if (Database.Korisnici.ContainsKey(SelektovanKorisnik.Username))
                {
                    using (var unitOfWork = new Baza.Context())
                    {
                        Korisnik izBaze = unitOfWork.Korisnici.Find(SelektovanKorisnik.ID);
                        if(izBaze != null)
                        {
                            unitOfWork.Korisnici.Remove(izBaze);
                            unitOfWork.SaveChanges();
                        }
                    }
                    Database.Korisnici.Remove(SelektovanKorisnik.Username);
                }
                Refresh();
            }
        }
    }
}
