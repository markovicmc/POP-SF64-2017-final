using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
using POP_SF_64_2017_GUI.Baza;
using POP_SF_64_2017_GUI.Model;

namespace POP_SF_64_2017_GUI.Prozori
{
    /// <summary>
    /// Interaction logic for DodajAkcijaProzor.xaml
    /// </summary>
    public partial class DodajAkcijaProzor : Window
    {
        public DodajAkcijaProzor(Akcija a)
        {
            InitializeComponent();
            NovaAkcija = a;
            DataContext = this;
            time1 = DateTime.Now;
            time2 = DateTime.Now;
            Popust = "0";
        }
        public Akcija NovaAkcija{ get; set; }

        public DateTime time1 { get; set; }
        public DateTime time2 { get; set; }
        public String Popust { get; set; }
        public Double PopustD;

        private void PovratakDugme_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SacuvajDugme_Click(object sender, RoutedEventArgs e)
        {
            time1 = this.dp1.SelectedDate.Value;
            time2 = this.dp2.SelectedDate.Value;
            if (string.IsNullOrEmpty(NovaAkcija.Naziv))
            {
                MessageBox.Show("Ime mora biti popunjeno.");
            }
            else if (string.IsNullOrEmpty(Popust))
            {
                MessageBox.Show("Popust mora biti popunjen.");
            }
            else if(!Double.TryParse(Popust, out PopustD))
            {
                MessageBox.Show("Popust mora biti broj.");
            }
            else if(time1 > time2)
            {
                MessageBox.Show("Vreme 1 nije vece od vremena 2.");
            }
            else
            {
                NovaAkcija.Popust = PopustD;
                NovaAkcija.PocetakAkcije = time1;
                NovaAkcija.KrajAkcije = time2;
                AkcijaProzor.Dodata = true;
                this.Close();
            }
            
        }
    }
}
