using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF_64_2017_GUI.Model
{
    class Prodaja : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;

            private int iD;
            private String nazivProizvoda;
            private int kolicina;
            private DateTime datumProdaje;
            private String kupac;
            private int brojRacuna;
            private int ukupnaCena;
            public const double PDV = 0.02;
            private Boolean obrisan;
            private int uslugaID;
           // private Usluga usluga;

               //da li treba da ovde pisemo one konstruktore kao sto smo u ostalim? Nece da mi prosledi neke stvari
               //jer kaze da Prodaja ne prihvata argumente 

            public int ID
            {
                get { return iD; }
                set
                {
                    iD = value;
                    OnPropertyChanged("ID");
                }
            }

        public String NazivProizvoda
        {
            get { return nazivProizvoda; }
            set
            {
                nazivProizvoda = value;
                OnPropertyChanged("NazivProizvoda");
            }
        }

        public int Kolicina
        {
            get { return kolicina; }
            set
            {
                kolicina = value;
                OnPropertyChanged("Kolicina");
            }
        }

        public DateTime DatumProdaje
            {
                get { return datumProdaje; }
                set
                {
                    datumProdaje = value;
                    OnPropertyChanged("DatumProdaje");
                }
            }

            public String Kupac
            {
                get { return kupac; }
                set
                {
                    kupac = value;
                    OnPropertyChanged("Kupac");
                }
            }

            public int BrojRacuna
            {
                get { return brojRacuna; }
                set
                {
                    brojRacuna = value;
                    OnPropertyChanged("BrojRacuna");
                }
            }

            public int UkupnaCena
            {
                get { return ukupnaCena; }
                set
                {
                    ukupnaCena = value;
                    OnPropertyChanged("UkupnaCena");
                }
            }

            public Boolean Obrisan
            {
                get { return obrisan; }
                set { obrisan = value; }
            }

            public int UslugaID
            {
                get { return uslugaID; }
                set
                {
                    uslugaID = value;
                    OnPropertyChanged("UslugaID");
                }
            }

            //public Usluga Usluga
            //{
            //    get
            //    {
            //        if (usluga == null)
            //        {
            //            usluga = UslugaBLL.GetById(UslugaID);
            //        }
            //        return usluga;
            //    }
            //    set
            //    {
            //        usluga = value;
            //        UslugaID = usluga.ID;
            //        OnPropertyChanged("Usluga");
            //    }
            //}

            protected void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    }

