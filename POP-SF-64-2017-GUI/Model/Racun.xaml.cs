﻿using System;
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

namespace POP_SF_64_2017_GUI.Model
{
    /// <summary>
    /// Interaction logic for Racun.xaml
    /// </summary>
    public partial class Racun : Window
    {
        public Racun()
        {
            InitializeComponent();
        }

        private void IzadjiDugme_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
