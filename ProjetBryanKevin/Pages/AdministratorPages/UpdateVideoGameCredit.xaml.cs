using ProjetBryanKevin.Classes;
using ProjetBryanKevin.DAO;
using ProjetBryanKevin.Factory;
using ProjetBryanKevin.Pages.AdministratorPages;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;


namespace ProjetBryanKevin.Pages.Administrator
{
    /// <summary>
    /// Logique d'interaction pour UpdateVideoGameCredit.xaml
    /// </summary>
    public partial class UpdateVideoGameCredit : Page
    {
        List<VideoGame> videoGames;
        public UpdateVideoGameCredit()
        {
            InitializeComponent();
            videoGames = VideoGame.GetAllVideoGames();
            dataGridVideoGame.ItemsSource = videoGames;
        }

        private void ButtonModification_Click(object sender, RoutedEventArgs e)
        {
            VideoGame vgToUpdate = (VideoGame) dataGridVideoGame.SelectedItem;
            MessageBoxResult res = MessageBox.Show("Voulez-vous modifier la valeur du jeu " + vgToUpdate.Name + " sur " + vgToUpdate.Console + " ?","Changement de coût en crédit",MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            switch (res)
            {
                case MessageBoxResult.Yes:
                    UpdateCreditCostWindow updateCreditCostWindow = new UpdateCreditCostWindow(vgToUpdate);
                    updateCreditCostWindow.Show();
                    break;
                default:
                    break;
            }
        }
    }
}
