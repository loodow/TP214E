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
        private DALCommandes dalCommandes;
        private List<Plat> PlatsDansPanier;


        public PageCommandes(DALCommandes dalCommandes)
        {
            InitializeComponent();

            PlatsDansPanier = new List<Plat>();

            this.dalCommandes = dalCommandes;
            plats = dalCommandes.Plats();
            commandes = dalCommandes.Commandes();

            liste_plats.ItemsSource = plats.Aggregate().ToList();
            liste_commande.ItemsSource = commandes.Aggregate().ToList();

        }

        private void boutonCreerCommande_Click(object sender, RoutedEventArgs e)
        {
            var commandeACreer = new Commande();
            commandeACreer.PlatsCommande = PlatsDansPanier;
            dalCommandes.AjouterCommande(commandeACreer);
            liste_commande.ItemsSource = commandes.Aggregate().ToList();
            liste_panier.Items.Clear();
            PlatsDansPanier.Clear();
        }

        private void boutonAjouterPlat_Click(object sender, RoutedEventArgs e)
        {
            if (liste_plats.SelectedItem != null) 
            { 
                Plat platSelectionne = (Plat)liste_plats.SelectedItem;
                liste_panier.Items.Add(platSelectionne);
                PlatsDansPanier.Add(platSelectionne);
            }
                

        }

        private void bouttonRetirer_Click(object sender, RoutedEventArgs e)
        {
            if(liste_panier.SelectedItem != null)
            {
                Plat platSelectionne = (Plat)liste_panier.SelectedItem;
                liste_panier.Items.Remove(platSelectionne);
            }
            
        }
    }
}
