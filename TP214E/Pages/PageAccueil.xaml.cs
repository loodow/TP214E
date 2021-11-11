using System.Windows;
using System.Windows.Controls;
using TP214E.Data;

namespace TP214E
{
    public partial class PageAccueil : Page
    {
        private DAL dal;
        private DALAliments dalAliments;
        public PageAccueil()
        {
            InitializeComponent();
            dal = new DAL();
        }

        private void BoutonInventaire_Click(object sender, RoutedEventArgs e)
        {
            dalAliments = new DALAliments();
            PageInventaire frmInventaire = new PageInventaire(dalAliments);

            NavigationService.Navigate(frmInventaire);
        }
        private void BoutonCommandes_Click(object sender, RoutedEventArgs e)
        {
            PageCommandes frmCommandes = new PageCommandes(dal);

            NavigationService.Navigate(frmCommandes);
        }
    }
}
