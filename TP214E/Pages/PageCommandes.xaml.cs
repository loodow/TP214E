using MongoDB.Driver;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using TP214E.Data;

namespace TP214E
{
    public partial class PageCommandes : Page
    {
        private IMongoCollection<Plat> plats;
        private IMongoCollection<Commande> commandes;
        private DAL dal;
        private List<string> PlatsDansPanier;


        public PageCommandes(DAL dal)
        {
            InitializeComponent();

            PlatsDansPanier = new List<string>();

            this.dal = dal;
            plats = dal.Plats();
            commandes = dal.Commandes();

            liste_plats.ItemsSource = plats.Aggregate().ToList();
            liste_commande.ItemsSource = commandes.Aggregate().ToList();

        }

        private void boutonCreerCommande_Click(object sender, RoutedEventArgs e)
        {
            liste_panier.Items.Clear();
            List<string> platsDeLaCommande = new List<string>();

            foreach (string plat in PlatsDansPanier)
            {
                platsDeLaCommande.Add(plat);
            }

          

            var commandeCreer = new Commande();
            commandeCreer.PlatsCommandes = platsDeLaCommande;
            dal.AjouterCommande(commandeCreer);
            liste_commande.ItemsSource = commandes.Aggregate().ToList();
            liste_panier.Items.Clear();
            PlatsDansPanier.Clear();


        }

        private void boutonAjouterPlat_Click(object sender, RoutedEventArgs e)
        {
            Plat platSelectionne = (Plat)liste_plats.SelectedItem;
            liste_panier.Items.Add(platSelectionne);
            PlatsDansPanier.Add(platSelectionne.Nom);

        }

        private void bouttonRetirer_Click(object sender, RoutedEventArgs e)
        {
            Plat platSelectionne = (Plat)liste_panier.SelectedItem;
            liste_panier.Items.Remove(platSelectionne);
        }
    }
}
