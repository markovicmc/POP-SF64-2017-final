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

namespace POP_SF_64_2017_GUI.UI
{
    /// <summary>
    /// Interaction logic for SalonWindow.xaml
    /// </summary>
    public partial class NamestajWindow : Window
    {
        public Korisnik PrijavljenKorisnik { get; set; }
        public NamestajWindow(Korisnik k)
        {
            InitializeComponent();
            PrijavljenKorisnik = k;
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }
    }
}
