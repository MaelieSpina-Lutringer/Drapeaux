
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Drapeaux
{
    public class Pays
    {
        public string Nom { get; set; }
        public string Drapeau { get; set; }

        public Pays(string nom, string drapeau = "")
        {
            Nom = nom;
            Drapeau = drapeau;
        }
    }

    public class Ville
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

    public class LesVilles : ObservableCollection<Ville>
    {
        public LesVilles()
        {
            Add(new Ville("Tokyo", 37435191,
                new Pays("Japon", "images/japon_flag.jpg")));

            Add(new Ville("New Delhi", 33807141,
                new Pays("Inde", "images/India_flag.png")));

            Add(new Ville("Shanghai", 29868104,
                new Pays("Chine", "images/China_Flag.jpg")));

            Add(new Ville("Dhaka", 23936000,
                new Pays("Bangladesh", "images/Bangladesh_flag.png")));

            Add(new Ville("Sao Paulo", 22806700,
                new Pays("Brésil", "images/bresil_flag.jpg")));

            Add(new Ville("Le Caire", 22623874,
                new Pays("Egypte", "images/Egypt_flag.png")));

            Add(new Ville("Mexico City", 21511908,
                new Pays("Mexique", "images/mexico_flag.jpg")));

            Add(new Ville("Pékin", 21335455,
                new Pays("Chine", "images/China_Flag.jpg")));

            Add(new Ville("Mumbai", 21673000,
                new Pays("Inde", "images/India_flag.png")));

            Add(new Ville("Osaka", 19222665,
                new Pays("Japon", "images/japon_flag.jpg")));
        }

        public void AjouterVille()
        {
            string nom = DemanderValeur("Nom de la ville :");

            if (nom == null)
                return;

            string populationTexte = DemanderValeur("Population :");

            if (populationTexte == null)
                return;

            int population;

            if (!int.TryParse(populationTexte, out population)
                || population < 0)
            {
                MessageBox.Show(
                    "La population doit contenir des nombres valides.");
                return;
            }

            string pays = DemanderValeur("Nom du pays :");

            if (pays == null)
                return;

            string drapeau = "";

            switch (pays.Trim().ToLower())
            {
                case "japon":
                    drapeau = "images/japon_flag.jpg";
                    pays = "Japon";
                    break;

                case "inde":
                    drapeau = "images/India_flag.png";
                    pays = "Inde";
                    break;

                case "chine":
                    drapeau = "images/China_Flag.jpg";
                    pays = "Chine";
                    break;

                case "bangladesh":
                    drapeau = "images/Bangladesh_flag.png";
                    pays = "Bangladesh";
                    break;

                case "brésil":
                case "bresil":
                    drapeau = "images/bresil_flag.jpg";
                    pays = "Brésil";
                    break;

                case "egypte":
                    drapeau = "images/Egypt_flag.png";
                    pays = "Egypte";
                    break;

                case "mexique":
                    drapeau = "images/mexico_flag.jpg";
                    pays = "Mexique";
                    break;

                case "france":
                    drapeau = "images/flag_france.jpg";
                    pays = "France";
                    break;
            }

            Add(new Ville(
                nom,
                population,
                new Pays(pays, drapeau)));
        }

        private string DemanderValeur(string message)
        {
            Window fenetre = new Window
            {
                Title = "Ajouter une ville",
                Width = 350,
                Height = 150,
                WindowStartupLocation =
                    WindowStartupLocation.CenterScreen,
                ResizeMode = ResizeMode.NoResize
            };

            StackPanel panneau = new StackPanel
            {
                Margin = new Thickness(10)
            };

            panneau.Children.Add(new TextBlock
            {
                Text = message,
                Margin = new Thickness(0, 0, 0, 5)
            });

            TextBox champ = new TextBox
            {
                Margin = new Thickness(0, 0, 0, 10)
            };

            panneau.Children.Add(champ);

            StackPanel boutons = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Right
            };

            Button boutonAjouter = new Button
            {
                Content = "Ajouter",
                Width = 75,
                IsDefault = true,
                Margin = new Thickness(5)
            };

            Button boutonAnnuler = new Button
            {
                Content = "Annuler",
                Width = 75,
                IsCancel = true,
                Margin = new Thickness(5)
            };

            boutons.Children.Add(boutonAjouter);
            boutons.Children.Add(boutonAnnuler);

            panneau.Children.Add(boutons);

            fenetre.Content = panneau;

            string resultat = null;

            boutonAjouter.Click += (s, e) =>
            {
                string texte = champ.Text.Trim();

                if (texte == "")
                {
                    MessageBox.Show(
                        "Ce champ est obligatoire.");
                    return;
                }

                resultat = texte;
                fenetre.DialogResult = true;
            };

            boutonAnnuler.Click += (s, e) =>
            {
                fenetre.DialogResult = false;
            };

            if (fenetre.ShowDialog() == true)
                return resultat;

            return null;
        }
    }
}
