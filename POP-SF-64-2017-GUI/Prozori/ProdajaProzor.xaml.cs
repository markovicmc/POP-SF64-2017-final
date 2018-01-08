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
    /// Interaction logic for ProdajaProzor.xaml
    /// </summary>
    public partial class ProdajaProzor : Window
    {
        public static bool dodaj;

        public ProdajaProzor()
        {
            InitializeComponent();
        }

        private void DodajDugme_Click(object sender, RoutedEventArgs e)
        {
            Prodaja p = new Prodaja();
            dodaj = false;
            DodajProdajaProzor dodajProdaju = new DodajProdajaProzor(p);
            dodajProdaju.ShowDialog();
            if (dodaj)
            {
                ListaProdaja.Add(p);
                Refresh(); 
            }

        }
    }
}
