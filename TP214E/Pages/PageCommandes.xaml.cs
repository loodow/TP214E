using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TP214E.Data;

namespace TP214E
{
    /// <summary>
    /// Logique d'interaction pour PageCommandes.xaml
    /// </summary>
    public partial class PageCommandes : Page
    {
        private IMongoCollection<Plat> plats;
        private IMongoCollection<Commande> commandes;
        private DAL dal;
        private List<Plat> PlatsDansPanier;


        public PageCommandes(DAL dal)
        {
            InitializeComponent();

            PlatsDansPanier = new List<Plat>();

            this.dal = dal;
            plats = dal.Plats();
            commandes = dal.Commandes();

            liste_plats.ItemsSource = plats.Aggregate().ToList();
            liste_commande.ItemsSource = commandes.Aggregate().ToList();

        }

        private void boutonCreerCommande_Click(object sender, RoutedEventArgs e)
        {
            var commandeACreer = new Commande();
            commandeACreer.PlatsCommande = PlatsDansPanier;
            dal.AjouterCommande(commandeACreer);
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
