using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TP214E.Data;

namespace TP214E
{
    /// <summary>
    /// Logique d'interaction pour Inventaire.xaml
    /// </summary>
    public partial class PageInventaire : Page
    {
        private IMongoCollection<Aliment> aliments;
        private DAL dal;

        public PageInventaire(DAL dal)
        {
            InitializeComponent();

            this.dal = dal;
            aliments = dal.Aliments();

            liste_aliments.ItemsSource = aliments.Aggregate().ToList();
        }

        private void boutonCreer_Click(object sender, RoutedEventArgs e)
        {
            CreerAliment();
        }

        private void SupprimerAlimentSelectionne()
        {
            Aliment alimentSelectionne = (Aliment)liste_aliments.SelectedItem;

            dal.RetirerAliment(alimentSelectionne);
        }

        private void CreerAliment()
        {
            Aliment aliment = new Aliment();
            aliment.Nom = txtb_creer_nom_aliment.Text;
            aliment.Quantite = Convert.ToInt32(txtb_creer_quantite_aliment.Text);
            aliment.ExpireLe = Convert.ToDateTime(txtb_creer_date_expiration_aliment.Text);
            aliment.Unite = txtb_creer_nom_aliment.Text;

            dal.AjouterAliment(aliment);
            liste_aliments.ItemsSource = aliments.Aggregate().ToList();
        }

        private void boutonSupprimer_Click(object sender, RoutedEventArgs e)
        {
            SupprimerAlimentSelectionne();
            liste_aliments.ItemsSource = aliments.Aggregate().ToList();
        }

        private void ModifierAliment()
        {
            Aliment alimentSelectionne = (Aliment)liste_aliments.SelectedItem;
            Aliment aliment = new Aliment();
            aliment.Nom = txtb_creer_nom_aliment.Text;
            aliment.Quantite = Convert.ToInt32(txtb_creer_quantite_aliment.Text);
            aliment.ExpireLe = Convert.ToDateTime(txtb_creer_date_expiration_aliment.Text);
            aliment.Unite = txtb_creer_unite_aliment.Text;

            dal.ModifierAliment(aliment, alimentSelectionne._id);
            liste_aliments.ItemsSource = aliments.Aggregate().ToList();
        }

        private void boutonModifier_Click(object sender, RoutedEventArgs e)
        {
            ModifierAliment();
            liste_aliments.ItemsSource = aliments.Aggregate().ToList();
        }
    }
}
