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
        private List<Aliment> aliments;
        public PageInventaire(DAL dal)
        {
            InitializeComponent();
            // Bd ne marche pas pour le moment
            //aliments = dal.ALiments();

            aliments = new List<Aliment>
            {
                new Aliment(),
                new Aliment(),
                new Aliment()
            } ();

            liste_aliments.ItemsSource = aliments;
        }

        private void boutonCreer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void boutonModifier_Click(object sender, RoutedEventArgs e)
        {

        }

        private void boutonSupprimer_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
