using MongoDB.Driver;
using System;
using System.Windows;
using System.Windows.Controls;
using TP214E.Data;

namespace TP214E
{
    /// <summary>
    /// Logique d'interaction pour Inventaire.xaml
    /// </summary>
    public partial class PageInventaire : Page
    {
        private IMongoCollection<Aliment> aliments;
        private DALAliments dal;

        public PageInventaire(DALAliments dal)
        {
            InitializeComponent();

            this.dal = dal;
            aliments = dal.Aliments();

            RafraichirListeAliments();
        }

        private void boutonCreer_Click(object sender, RoutedEventArgs e)
        {
            CreerAliment();
            RafraichirListeAliments();
        }

        private void CreerAliment()
        {
            Aliment aliment = AssignerEntreesFormVersAliment();

            dal.AjouterAliment(aliment);
        }
        private void SupprimerAlimentSelectionne()
        {
            Aliment alimentSelectionne = (Aliment)liste_aliments.SelectedItem;

            dal.RetirerAliment(alimentSelectionne);
        }

        private void boutonSupprimer_Click(object sender, RoutedEventArgs e)
        {
            SupprimerAlimentSelectionne();
            RafraichirListeAliments();
        }

        private void ModifierAlimentSelectionne()
        {
            Aliment alimentSelectionne = (Aliment)liste_aliments.SelectedItem;
            Aliment aliment = AssignerEntreesFormVersAliment();

            dal.ModifierAliment(aliment, alimentSelectionne._id);
        }



        private void boutonModifier_Click(object sender, RoutedEventArgs e)
        {
            ModifierAlimentSelectionne();
            RafraichirListeAliments();
        }
        private Aliment AssignerEntreesFormVersAliment()
        {
            Aliment aliment = new Aliment();
            aliment.Nom = txtb_creer_nom_aliment.Text;
            aliment.Quantite = Convert.ToInt32(txtb_creer_quantite_aliment.Text);
            aliment.ExpireLe = Convert.ToDateTime(txtb_creer_date_expiration_aliment.Text);
            aliment.Unite = txtb_creer_nom_aliment.Text;
            return aliment;
        }
        private void RafraichirListeAliments()
        {
            liste_aliments.ItemsSource = aliments.Aggregate().ToList();
        }
    }
}
