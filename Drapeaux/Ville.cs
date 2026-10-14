using System.Collections.ObjectModel;
namespace Drapeaux
{
    internal class Pays
    {
        public string Nom { get; set; }
        public string Drapeau { get; set; }
        public Pays(string nom)
        {
            Nom = nom;
            Drapeau = "";
        }
        public Pays(string nom, string drapeau)
        {
            Nom = nom;
            Drapeau = drapeau;
        }
    }
    internal class Ville
    {
        public string Nom { get; set; }
        public int Population { get; set; }
        public Pays Pays { get; set; }
        public Ville(string nom, int population, Pays pays)
        {
            Nom = nom;
            Population = population;
            Pays = pays;
        }
    }
    internal class LesVilles : ObservableCollection<Ville>
    {
public LesVilles()
        {
            Add(new Ville("Tokyo", 37435191, new Pays("Japon", "images/japon_flag.jpg")));
            Add(new Ville("New Delhi", 33807141, new Pays("Inde", "images/India_flag.png")));
            Add(new Ville("Shanghai", 29868104, new Pays("Chine", "images/China_Flag.jpg")));
            Add(new Ville("Dhaka", 23936000, new Pays("Bangladesh", "images/Bangladesh_flag.png")));
            Add(new Ville("Sao Paulo", 22806700, new Pays("Brésil", "images/bresil_flag.jpg")));
            Add(new Ville("Le Caire", 22623874, new Pays("Egypte", "images/Egypt_flag.png")));
            Add(new Ville("Mexico City", 21511908, new Pays("Mexique", "images/mexico_flag.jpg")));
            Add(new Ville("Pékin", 21335455, new Pays("Chine", "images/China_Flag.jpg")));
            Add(new Ville("Mumbai", 21673000, new Pays("Inde", "images/India_flag.png")));
            Add(new Ville("Osaka", 19222665, new Pays("Japon", "images/japon_flag.jpg")));
        }

    }
}