using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Drapeaux
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AjouterVille_Click(object sender, RoutedEventArgs e)
        {
            LesVilles villes = (LesVilles)FindResource("lesvilles");
            villes.AjouterVille();
        }

        private void listeVilles_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var ville = listeVilles.SelectedItem as Ville;
            if (ville == null)
                return;

            var fenetre = new Window
            {
                Title = "Modifier la ville",
                Width = 400,
                Height = 260,
                Owner = this,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };

            var stack = new StackPanel
            {
                Margin = new Thickness(10)
            };

            stack.Children.Add(new TextBlock { Text = "Nom de la ville" });
            var txtNom = new TextBox { Text = ville.Nom, Margin = new Thickness(0, 0, 0, 10) };
            stack.Children.Add(txtNom);

            stack.Children.Add(new TextBlock { Text = "Population" });
            var txtPopulation = new TextBox { Text = ville.Population.ToString(), Margin = new Thickness(0, 0, 0, 10) };
            stack.Children.Add(txtPopulation);

            stack.Children.Add(new TextBlock { Text = "Nom du pays" });
            var txtPays = new TextBox { Text = ville.Pays.Nom, Margin = new Thickness(0, 0, 0, 10) };
            stack.Children.Add(txtPays);

            stack.Children.Add(new TextBlock { Text = "Image du drapeau" });
            var txtDrapeau = new TextBox { Text = ville.Pays.Drapeau, Margin = new Thickness(0, 0, 0, 10) };
            stack.Children.Add(txtDrapeau);

            var bouton = new Button
            {
                Content = "OK",
                Width = 80,
                HorizontalAlignment = HorizontalAlignment.Right,
                Margin = new Thickness(0, 10, 0, 0)
            };

            bouton.Click += (s, args) =>
            {
                if (!int.TryParse(txtPopulation.Text.Trim(), out int population) || population < 0)
                {
                    MessageBox.Show("La population doit être un nombre entier positif.",
                                    "Erreur",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Warning);
                    return;
                }

                ville.Nom = txtNom.Text.Trim();
                ville.Population = population;
                ville.Pays.Nom = txtPays.Text.Trim();
                ville.Pays.Drapeau = txtDrapeau.Text.Trim();

                fenetre.DialogResult = true;
                fenetre.Close();
            };

            stack.Children.Add(bouton);
            fenetre.Content = stack;

            fenetre.ShowDialog();
        }
    }
}