﻿using ProjetBryanKevin.Classes;
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
namespace ProjetBryanKevin.Pages.Player
{
    /// <summary>
    /// Logique d'interaction pour PlayerHome.xaml
    /// </summary>
    public partial class PlayerHome : Page
    {
        PlayerHome play;

        public PlayerHome(Classes.Player player)
        {
            InitializeComponent();
            player = play;
            
            Connection.Text = "Connecté en tant que Responsable";
            Name.Text = player.UserName;
        }
    }
}
