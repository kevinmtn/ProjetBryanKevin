﻿using ProjetBryanKevin.Classes;
using ProjetBryanKevin.Pages.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjetBryanKevin
{
    /// <summary>
    /// Logique d'interaction pour PlayerWindow.xaml
    /// </summary>
    public partial class PlayerWindow : Window
    {

        Player play;
        VideoGame game;
        public PlayerWindow(Player player)
        {
            InitializeComponent();
            play= player;
        }

        private void menuDisconnect(Object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Vous  vous êtes déconnecté");

            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }


        private void menuHome(Object sender, RoutedEventArgs e)
        {
            Main.Content = new PlayerHome(play);
        }

        private void seeVideoGames(Object sender, RoutedEventArgs e)
        {
            Main.Content = new VideoGameAvailable(game);
        }
    }
}
