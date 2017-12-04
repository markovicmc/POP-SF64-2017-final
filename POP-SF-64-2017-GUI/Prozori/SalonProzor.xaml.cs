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
    /// Interaction logic for SalonProzor.xaml
    /// </summary>
    public partial class SalonProzor : Window,  INotifyPropertyChanged
    {
        public static bool dodaj;

        private List<Namestaj> listaNamestaja;

        public List<Namestaj> ListaNamestaja
        {
            get
            {
                return listaNamestaja;
            }
            set
            {
                listaNamestaja = value;
                OnPropertyChanged("ListaNamestaja");
            }
        }

        public Namestaj IzabraniNamestaj { get; set; } //DataGrid je bindovan na ova dva
        public int IzabraniIndex { get; set; }

        private List<Namestaj> listaZaProdaju = new List<Namestaj>(); //ovu listu prosledjujemo korpi

        public SalonProzor()
        {
            InitializeComponent();
            DataContext = this;
            UcitajNamestaj();
        }

        private void UcitajNamestaj()
        {
            ListaNamestaja = new List<Namestaj>();
            ListaNamestaja.Add(new Namestaj("Radni sto Lora", "4324", 7500, 3, "Radna soba", true, false));
            ListaNamestaja.Add(new Namestaj("Kuhinjski sto Tama", "324", 15000, 5, "Kuhinja", false, false));

        }

        private void DodajNamestaj_Click(object sender, RoutedEventArgs e)
        {
            Namestaj n = new Namestaj();
            dodaj = false;
            DodajNamestajProzor dodajNamestaj = new DodajNamestajProzor(n);
            dodajNamestaj.ShowDialog();
            if (dodaj)
            {
                ListaNamestaja.Add(n);
                Refresh();
            }
        }

        private void IzmeniNamestaj_Click(object sender, RoutedEventArgs e)
        {
            if(IzabraniNamestaj != null)
            {
                Namestaj n = new Namestaj(IzabraniNamestaj);
                dodaj = false;
                DodajNamestajProzor dodajNamestaj = new DodajNamestajProzor(n);
                dodajNamestaj.ShowDialog();
                if (dodaj)
                {
                    IzabraniNamestaj.Zameni(n);
                    Refresh();
                }
            }
        }

        private void ObrisiNamestaj_Click(object sender, RoutedEventArgs e)
        {
            if(IzabraniIndex >= 0 && IzabraniIndex < ListaNamestaja.Count)
            {
                ListaNamestaja.RemoveAt(IzabraniIndex);
                IzabraniIndex = -1;
                Refresh();
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
            List<Namestaj> tempList = new List<Namestaj>(ListaNamestaja);
            ListaNamestaja = tempList;
        }
        #endregion

        private void OtvoriKorpu_Click(object sender, RoutedEventArgs e)
        {
            KorpaProzor korpa = new KorpaProzor(listaZaProdaju);
            korpa.ShowDialog();
        }

        private void DodajUKorpu_Click(object sender, RoutedEventArgs e)
        {
            listaZaProdaju.Add(IzabraniNamestaj);
        }
    }
}
