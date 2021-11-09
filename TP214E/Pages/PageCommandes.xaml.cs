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
        private DAL dal;


        public PageCommandes(DAL dal)
        {
            InitializeComponent();

            this.dal = dal;
            plats = dal.Plats();

            liste_plats.ItemsSource = plats.Aggregate().ToList();
        }

        private void boutonCreerCommande_Click(object sender, RoutedEventArgs e)
        {

        }

        private void boutonAjouterPlat_Click(object sender, RoutedEventArgs e)
        {
            Plat platSelectionne = (Plat)liste_plats.SelectedItem;
            liste_panier.Items.Add(platSelectionne);

        }

    }
}
