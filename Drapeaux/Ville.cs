using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drapeaux
{
    internal class Pays
    {
        private string v;

        String Nom { get; set; }
        String Drapeau { get; set; }
        public Pays(String nom, String drapeau)
        {
            Nom = nom;
            Drapeau = drapeau;
        }

        public Pays(string v)
        {
            this.v = v;
        }
    }
    internal class Ville
    {
        private string v1;
        private int v2;

        public Ville(string v1, int v2, Pays pays)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.pays = pays;
        }

        String Nom {  get; set; }
        int Population { get; set; }
        Pays pays { get; set; }
    }
    class LesVilles : ObservableCollection<Ville>
    {
        public LesVilles()
        {
            Add(new Ville("Tokyo", 37435191, new Pays("Japon")));
            Add(new Ville("New Delhi", 33807141, new Pays("Inde")));
            Add(new Ville("Shanghai", 29868104, new Pays("Chine")));
            Add(new Ville("Dhaka", 23936000, new Pays("Bangladesh")));
            Add(new Ville("Sao Paulo", 22806700, new Pays("Brésil")));
            Add(new Ville("Le Caire", 22623874, new Pays("Egypte")));
            Add(new Ville("Mexico City", 21335455, new Pays("Mexique")));
            Add(new Ville("Pekin", 21335455, new Pays("Chine")));
            Add(new Ville("Mumbai", 21673000, new Pays("Inde")));
            Add(new Ville("Osaka", 19222665, new Pays("Japon")));

        }
    }
}
