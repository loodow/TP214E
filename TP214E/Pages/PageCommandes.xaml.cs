﻿using MongoDB.Driver;
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


        public PageCommandes(DALCommandes dalCommandes, DALPlats dalPlats)
        {
            InitializeComponent();

            PlatsDansPanier = new List<Plat>();

            this.dalCommandes = dalCommandes;
            plats = dalPlats.ObtenirPlats();
            commandes = dalCommandes.ObtenirCommandes();

            MiseAjourDesListBoxAvecLaBD();

        }

        private void boutonCreerCommande_Click(object sender, RoutedEventArgs e)
        {
            if (liste_panier.Items.Count != 0)
            {
                CréerUneCommandeAvecPlatsDuPanier();
                ViderLePanier();
            }
            else
            {
                label_erreurCreerCommande.Visibility = Visibility.Visible;
            }
        }

        private void boutonAjouterPlat_Click(object sender, RoutedEventArgs e)
        {
            if (liste_plats.SelectedItem != null)
            {
                AjouterLePlatSelectionneALaListe();
            }
        }

        private void bouttonRetirer_Click(object sender, RoutedEventArgs e)
        {
            if (liste_panier.SelectedItem != null)
            {
                RetiRerLePlatSelectionneDuPanier();
            }
           
        }
        private void bouttonRetour_Click(object sender, RoutedEventArgs e)
        {
            RetournerALaPageDaccueil();
        }

        public void AjouterLePlatSelectionneALaListe()
        {
            Plat platSelectionne = (Plat)liste_plats.SelectedItem;
            liste_panier.Items.Add(platSelectionne);
            PlatsDansPanier.Add(platSelectionne);

        }

        public void RetiRerLePlatSelectionneDuPanier()
        {
            Plat platSelectionne = (Plat)liste_panier.SelectedItem;
            liste_panier.Items.Remove(platSelectionne);
        }

        public void CréerUneCommandeAvecPlatsDuPanier()
        {

            var commandeACreer = new Commande();
            commandeACreer.Plats = PlatsDansPanier;
            dalCommandes.AjouterCommande(commandeACreer);
            liste_commande.ItemsSource = commandes.Aggregate().ToList();

            if (label_erreurCreerCommande.Visibility == Visibility.Visible)
            {
                label_erreurCreerCommande.Visibility = Visibility.Hidden;
            }
        }
        public void MiseAjourDesListBoxAvecLaBD()
        {
            liste_plats.ItemsSource = plats.Aggregate().ToList();
            liste_commande.ItemsSource = commandes.Aggregate().ToList();
        }

        public void ViderLePanier()
        {
            liste_panier.Items.Clear();
            PlatsDansPanier.Clear();
        }
        public void RetournerALaPageDaccueil()
        {
            PageAccueil pageAccueil = new PageAccueil();
            NavigationService.Navigate(pageAccueil);
        }
    }
}
