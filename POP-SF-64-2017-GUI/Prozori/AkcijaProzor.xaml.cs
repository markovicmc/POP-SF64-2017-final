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
    /// Interaction logic for AkcijaProzor.xaml
    /// </summary>
    public partial class AkcijaProzor : Window
    {
        public AkcijaProzor()
        {
            InitializeComponent();
        }

        private void btnSacuvaj(object sender, RoutedEventArgs e)
        {
           
        }

        private void btnPovratak(object sender, RoutedEventArgs e)
        {
            this.Close();
            
        }
    }
}
