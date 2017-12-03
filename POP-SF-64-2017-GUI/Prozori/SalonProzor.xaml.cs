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
    /// Interaction logic for SalonProzor.xaml
    /// </summary>
    public partial class SalonProzor : Window
    {
        public static bool dodaj;
        public List<Namestaj> ListaNamestaja { get; set; }
        public Namestaj IzabraniNamestaj { get; set; }
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
            }
        }

        private void IzmeniNamestaj_Click(object sender, RoutedEventArgs e)
        {
            if(IzabraniNamestaj != null)
            {
                dodaj = false;
                DodajNamestajProzor dodajNamestaj = new DodajNamestajProzor(IzabraniNamestaj);
                dodajNamestaj.ShowDialog();
                if (dodaj)
                {
                    //preuzmi novi
                }
            }
        }

        private void ObrisiNamestaj_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
