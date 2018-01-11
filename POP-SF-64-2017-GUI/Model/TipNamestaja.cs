using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF_64_2017_GUI.Model
{
    public class TipNamestaja : INotifyPropertyChanged
    {
        private int id;
        private String naziv;
        private bool obrisano;

    public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }

        }

        public string Naziv
        {
            get { return naziv; }
            set
            {
                naziv = value;
                OnPropertyChanged("Naziv");
            }
        }

        public bool Obrisano
        {
            get { return obrisano; }
            set
            {
                obrisano = value;
                OnPropertyChanged("Obrisano");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public object Clone()
        {
            return new TipNamestaja
            {
                Id = id,
                Naziv = naziv,
                Obrisano = obrisano
            };
        }
    }
}
