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
    public partial class ProdavacProzor : Window, INotifyPropertyChanged
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

        public Namestaj IzabraniNamestaj { get; set; }
        public int IzabraniIndex { get; set; }

        private List<Namestaj> listaZaProdaju = new List<Namestaj>();

        public ProdavacProzor()
        {
            InitializeComponent();
            DataContext = this;
            UcitajNamestaj();
            cbTipPretrage.ItemsSource = Database.TipoviNamestaja;
        }

        private void UcitajNamestaj()
        {
            ListaNamestaja = new List<Namestaj>();
            ListaNamestaja.Add(new Namestaj("Radni sto Lora", "4324", 7500, 3, "Radna soba", true, false));
            ListaNamestaja.Add(new Namestaj("Kuhinjski sto Tama", "324", 15000, 5, "Kuhinja", false, false));

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

        private void ButtonAddToShop_Click(object sender, RoutedEventArgs e)
        {
            listaZaProdaju.Add(IzabraniNamestaj);
        }

        private void Zatvori(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

        private void PretragaDugme_Click(object sender, RoutedEventArgs e)
        {
            List<Namestaj> tempList = new List<Namestaj>();

            foreach (var item in ListaNamestaja)
            {
                if(cbTipPretrage.SelectedValue.ToString() == "SVE" || item.Tip == cbTipPretrage.SelectedValue.ToString())
                {
                    if (item.Naziv.Contains(tbPretraga.Text))
                    {
                        tempList.Add(item);
                    }
                }
            }

            ListaNamestaja = tempList;
        }
    }
}
