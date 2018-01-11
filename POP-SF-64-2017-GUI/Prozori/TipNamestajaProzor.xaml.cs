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
    /// Interaction logic for TipNamestajaProzor.xaml
    /// </summary>
    public partial class TipNamestajaProzor : Window
    {
        private ObservableCollection<TipNamestaja> ListaTipova;
        public TipNamestaja SelektovanTip { get; set; }

        public TipNamestajaProzor()
        {
            using (var unitOfWork = new Baza.Context())
            {
                ListaTipova = new ObservableCollection<TipNamestaja>(unitOfWork.TipoviNamestaja.ToList());
            }

            InitializeComponent();
            DataContext = this;
            dataGrid1.ItemsSource = ListaTipova;

        }


        private void DodajDugme_Click(object sender, RoutedEventArgs e)
        {
            new DodajTipProzor().ShowDialog();
            using (var unitOfWork = new Baza.Context())
            {
                ListaTipova = new ObservableCollection<TipNamestaja>(unitOfWork.TipoviNamestaja.ToList());
                dataGrid1.ItemsSource = ListaTipova;
            }
        }

        private void ObrisiDugme_Click(object sender, RoutedEventArgs e)
        {
            if (SelektovanTip == null)
            {
                MessageBox.Show("Niste izabrali tip za brisanje.");
            }
            else
            {
                using (var unitOfWork = new Baza.Context())
                {
                    var izBaze = unitOfWork.TipoviNamestaja.Find(SelektovanTip.Id);
                    if (izBaze != null)
                    {
                        unitOfWork.TipoviNamestaja.Remove(izBaze);
                        unitOfWork.SaveChanges();
                    }
                }

                ListaTipova.Remove(SelektovanTip);
            }
        }

        private void PovratakDugme_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
