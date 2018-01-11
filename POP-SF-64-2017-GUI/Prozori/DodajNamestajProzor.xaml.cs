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
    /// Interaction logic for DodajNamestajProzor.xaml
    /// </summary>
    public partial class DodajNamestajProzor : Window
    {
        public static int AkcijaId;
        public DodajNamestajProzor(Namestaj n)
        {
            InitializeComponent();
            DataContext = this;
            Namestaj = n; //ako otvaramo kada kliknemo na edit, moramo da prosledimo selektovani namestaj

            List<string> listaZaCb = new List<string>();
            foreach (var item in Database.Akcije)
            {
                listaZaCb.Add(item.ID + ": " + item.Naziv);
            }
            cbAkcija.ItemsSource = listaZaCb;

            cbTip.ItemsSource = Database.TipoviNamestaja;
        }
        public Namestaj Namestaj{ get; set; }
        public string Cena {
            get
            {
                return Namestaj.Cena.ToString();
            }
            set
            {
                double cena;
                if(double.TryParse(value, out cena))
                {
                    Namestaj.Cena = cena;
                }  
            }
        }

        private void DodajNamestaj_Click(object sender, RoutedEventArgs e)
        {
            //validacije da je sve popunjeno, onda baza nece pucati jer polje nije null.. ako ga nema, npr neki string nije obavezan, staviti = ""
            if (string.IsNullOrEmpty(Namestaj.Naziv))
            {
                MessageBox.Show("Ime nije popunjeno.");
            }
            else if (string.IsNullOrEmpty(Namestaj.Sifra))
            {
                MessageBox.Show("Sifra nije popunjeno.");
            }
            else if(this.cbTip.SelectedIndex == -1)
            {
                MessageBox.Show("Izaberite tip namestaja");
            }
            else 
            {
                if(this.cbAkcija.SelectedIndex == -1)
                {
                    Namestaj.AkcijaId = -1;
                }
                else
                {
                    Namestaj.AkcijaId = int.Parse(this.cbAkcija.SelectedValue.ToString().Split(':')[0]);
                }

                Namestaj.Tip = this.cbTip.SelectedValue.ToString();
                SalonProzor.dodaj = true;
                this.Close();
            }

            
        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
