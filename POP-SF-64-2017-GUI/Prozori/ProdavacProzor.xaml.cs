using POP_SF_64_2017_GUI.Baza;
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
    /// 

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

        public Namestaj IzabraniNamestaj { get; set; } //DataGrid je bindovan na ova dva
        public int IzabraniIndex { get; set; }

        private List<Namestaj> listaZaProdaju = new List<Namestaj>(); //ovu listu prosledjujemo korpi
        void PreuzmiTipove()
        {
            List<string> tipovi = new List<string>();
            tipovi.Add("SVE");

            foreach (var item in ListaNamestaja)
            {
                tipovi.Add(item.Tip);
            }

            cbTipPretrage.ItemsSource = tipovi;
            cbTipPretrage.SelectedValue = "SVE";
        }
        public ProdavacProzor()
        {
            InitializeComponent();
            DataContext = this;
            UcitajNamestaj();
            PreuzmiTipove();

        }

        private void UcitajNamestaj()
        {
            using (var unitOfWork = new Context())  //povezemo sa bazom
            {
                ListaNamestaja = unitOfWork.Namestaji.ToList(); //uzmemo iz baze i stavimo u listu
            }
        }
       

        private void ObrisiNamestaj_Click(object sender, RoutedEventArgs e)
        {
            if (IzabraniNamestaj == null)
            {
                MessageBox.Show("Niste izabrali namestaj.");
                return;
            }
            string sMessageBoxText = "Da li zelite da obrisete ovaj komad namestaja?";
            string sCaption = "Brisanje namestaja";

            MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
            MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

            MessageBoxResult rsltMessageBox = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);

            if (rsltMessageBox == MessageBoxResult.Yes)
            {
                if (IzabraniNamestaj != null)
                {
                    Namestaj n = new Namestaj(IzabraniNamestaj);

                    using (var unitOfWork = new Context())
                    {
                        Namestaj izBaze = unitOfWork.Namestaji.Find(n.ID);
                        if (izBaze != null)
                        {
                            unitOfWork.Namestaji.Remove(izBaze);
                            unitOfWork.SaveChanges();
                        }

                    }

                    if (IzabraniIndex >= 0 && IzabraniIndex < ListaNamestaja.Count)
                    {
                        ListaNamestaja.RemoveAt(IzabraniIndex);
                        IzabraniIndex = -1;

                        Refresh();
                    }
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

       
            private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<Namestaj> tempList = new List<Namestaj>();
            using (var unitOfWork = new Context())
            {
                ListaNamestaja = unitOfWork.Namestaji.ToList();
            }

            foreach (var item in ListaNamestaja)
            {
                if (cbTipPretrage.SelectedValue.ToString() == "SVE" || item.Tip == cbTipPretrage.SelectedValue.ToString())
                {
                    if (item.Naziv.Contains(tbPretraga.Text))
                    {
                        tempList.Add(item);
                    }
                }
            }
            tbPretraga.Text = "";
            ListaNamestaja = tempList;
        }

        private void ZatvoriDugme_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
                 this.Close();
        }

        private void OtvoriProdajaDugme_Click(object sender, RoutedEventArgs e)
        {
            var prozor = new ProdajaProzor();
            prozor.ShowDialog();
        }
    }
}



