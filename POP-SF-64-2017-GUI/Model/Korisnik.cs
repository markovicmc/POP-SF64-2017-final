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

        public Korisnik(int id, string ime, string prezime, string username, string password, TipKorisnika tip)
        {
            ID = id;
            Ime = ime;
            Prezime = prezime;
            Username = username;
            Password = password;
            Tip = tip; 
        }
     }
}