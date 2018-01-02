namespace POP_SF_64_2017_GUI.Model
{

    public enum TipKorisnika { ADMINISTRATOR, PRODAVAC };

    public class Korisnik
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public TipKorisnika Tip { get; set; }

        public Korisnik()
        {

        }

        public Korisnik(Korisnik k)
        {
            ID = k.ID;
            Ime = k.Ime;
            Prezime = k.Prezime;
            Username = k.Username;
            Password = k.Password;
            Tip = k.Tip;
        }

        public Korisnik(int id, string ime, string prezime, string username, string password, TipKorisnika tip)
        {
            ID = id;
            Ime = ime;
            Prezime = prezime;
            Username = username;
            Password = password;
            Tip = tip;
        }

        public void Zameni(Korisnik k)
        {
            ID = k.ID;
            Ime = k.Ime;
            Prezime = k.Prezime;
            Username = k.Username;
            Password = k.Password;
            Tip = k.Tip;
        }
     }
}