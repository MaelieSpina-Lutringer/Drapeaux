
using System.Windows;

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
    }
}
