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
    /// Interaction logic for DodajTipProzor.xaml
    /// </summary>
    public partial class DodajTipProzor : Window
    {
        public DodajTipProzor()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //ok dugme
            if(string.IsNullOrEmpty(tbTip.Text))
            {
                MessageBox.Show("Morate popunite polje da biste sacuvali tip.");
            }
            else
            {
                TipNamestaja noviNamestaj = new TipNamestaja()
                {
                    Naziv = tbTip.Text
                };

                using(var unitOfWork = new Baza.Context())
                {
                    unitOfWork.TipoviNamestaja.Add(noviNamestaj);
                    unitOfWork.SaveChanges();
                }

                this.Close();

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
