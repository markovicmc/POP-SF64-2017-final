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
    /// Interaction logic for KorpaProzor.xaml
    /// </summary>
    public partial class KorpaProzor : Window, INotifyPropertyChanged
    {
        private List<Namestaj> listaNamestaja;
        public Namestaj IzabraniNamestaj { get; set; }
        public int IzabraniIndex { get; set; }
        public List<Namestaj> ListaKupovine
        {
            get
            {
                return listaNamestaja;
            }
            set
            {
                listaNamestaja = value;
                OnPropertyChanged("ListaKupovine");
            }
        }

        private double sumaCena;

        public KorpaProzor(List<Namestaj> l)
        {
            ListaKupovine = l;
            InitializeComponent();
            DataContext = this;
            Refresh();
        }

        private void Nastavi_Click(object sender, RoutedEventArgs e)
        {

            ListaKupovine.Clear();
            this.Close();
        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            ListaKupovine.Clear();
            this.Close();
        }

        private void Kupi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
            List<Namestaj> tempList = new List<Namestaj>(ListaKupovine);
            ListaKupovine = tempList;
            sumaCena = 0;
            foreach (var item in ListaKupovine)
            {
                sumaCena += item.Cena;
            }
            this.suma.Content = sumaCena.ToString();
        }
        #endregion

        private void DodajUKorpu_Click(object sender, RoutedEventArgs e)
        {
            if (IzabraniIndex >= 0 && IzabraniIndex < ListaKupovine.Count)
            {
                ListaKupovine.RemoveAt(IzabraniIndex);
                IzabraniIndex = -1;
                Refresh();
            }
        }

       
    }
}
