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

        public DodajNamestajProzor(Namestaj n)
        {
            InitializeComponent();
            DataContext = this;
            Namestaj = n; //ako otvaramo kada kliknemo na edit, moramo da prosledimo selektovani namestaj
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
            SalonProzor.dodaj = true;
            this.Close();
        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DodajAkciju_Click(object sender, RoutedEventArgs e)
        {
            DodajAkcijaProzor akcijaProzor = new DodajAkcijaProzor();
            akcijaProzor.Show();
        }
    }
}
