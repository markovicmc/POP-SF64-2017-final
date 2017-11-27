using POP_SF_64_2017_GUI.Model;
using POP_SF_64_2017_GUI.UI;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace POP_SF_64_2017_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnOK(object sender, RoutedEventArgs e)
        {
            string username = this.tbUsername.Text;
            string pass = this.tbPassword.Text;

            if (Database.Korisnici.ContainsKey(username)) //ako ovaj username postoji u Korisnicima
            {
                Korisnik k = Database.Korisnici[username]; //napravi objekat k za taj username
                if (k.Password == pass) //ako se Password tog objekta poklapa sa ovim passwordom
                {
                    NamestajWindow namestajProzor = new NamestajWindow(k);
                    namestajProzor.Show();
                    this.Close();
                    return;
                }
            }

            this.tbUsername.Text = "";
            this.tbPassword.Text = "";

            MessageBox.Show(this, "Neispravno ime ili lozinka.");





        }

        private void btnCancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
