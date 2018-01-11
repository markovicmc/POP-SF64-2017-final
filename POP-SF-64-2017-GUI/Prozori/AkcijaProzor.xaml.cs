using POP_SF_64_2017_GUI.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for AkcijaProzor.xaml
    /// </summary>
    public partial class AkcijaProzor : Window
    {
        public AkcijaProzor()
        {
            InitializeComponent();
            ListaAkcija = new ObservableCollection<Akcija>(Database.Akcije);
            this.dataGrid.ItemsSource = ListaAkcija;
            DataContext = this;
         
        }

        public Akcija SelektovanaAkcija { get; set; }

        private List<Akcija> akcije = Database.Akcije.ToList();
        public List<Akcija> Akcije
        {
            get
            {
                akcije = Database.Akcije.ToList();
                return akcije;
            }
            set
            {
                akcije = Database.Akcije.ToList();
                OnPropertyChanged("Akcije");
            }
        }

        private void OnPropertyChanged(string v)
        {
            throw new NotImplementedException();
        }

        ObservableCollection<Akcija> ListaAkcija
        {
            get; set;
        }
        public Akcija IzabranaAkcija { get; set; }
        public static bool Dodata;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DodajDugme_Click(object sender, RoutedEventArgs e)
        {
            Dodata = false;
            Akcija temp = new Akcija();
            DodajAkcijaProzor prozor = new DodajAkcijaProzor(temp);
            prozor.ShowDialog();
            if (Dodata)
            {
                ListaAkcija.Add(temp);

                using (var unitOfWork = new Baza.Context())
                {

                    unitOfWork.Akcije.Add(temp);
                    unitOfWork.SaveChanges();
                }
            }
        }

        private void ObrisiDugme_Click(object sender, RoutedEventArgs e)
        {
            string sMessageBoxText = "Da li zelite da obrisete ovu akciju?";
            string sCaption = "Brisanje akcije";

            MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
            MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

            MessageBoxResult rsltMessageBox = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);

            if (rsltMessageBox == MessageBoxResult.Yes)
            {
                

                using (var unitOfWork = new Baza.Context())
                {
                    var izBaze = unitOfWork.Akcije.Find(IzabranaAkcija.ID);
                    if (izBaze != null)
                    {
                        unitOfWork.Akcije.Remove(izBaze);
                        unitOfWork.SaveChanges();
                    }

                }
                ListaAkcija.Remove(IzabranaAkcija);
            }
        }

        void Refresh()
        {
            // List<Namestaj> tempList = new List<Namestaj>(korisnici);
           Akcije = new List<Akcija>();
        }

        private void IzmeniDugme_Click(object sender, RoutedEventArgs e)
        {
                //if (SelektovanaAkcija == null)
                //{
                //    MessageBox.Show("Niste izabrali akciju za izmenu.");
                //    return;
                //}
                Akcija a = new Akcija(SelektovanaAkcija);
                Dodata = false;
                DodajAkcijaProzor izmeniAkcijaProzor = new DodajAkcijaProzor(a);
                izmeniAkcijaProzor.ShowDialog();

                if (Dodata)
                {
                    SelektovanaAkcija.Zameni(a);
                    Refresh();
                    using (var unitOfWork = new Baza.Context())
                    {
                        Akcija izBaze = unitOfWork.Akcije.Find(a.ID);
                        if (a != null)
                        {
                            izBaze.Zameni(a);
                            unitOfWork.SaveChanges();
                        }
                    }
                }
            }
        }
    }

