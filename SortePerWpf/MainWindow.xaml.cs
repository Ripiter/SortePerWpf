using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Threading;

namespace SortePerWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Game game = new Game();
        public MainWindow()
        {
            InitializeComponent();

            game.Start();
            currectPlayer = game.Players[0];
            MyTextBlock.DataContext = currectPlayer;
            ShowImageCards();


            steve.ItemsSource = game.Players;
            this.DataContext = this;
        }

        Player currectPlayer;
        int nextPlayer = 1;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Set next player in line
            if (nextPlayer >= game.Players.Count)
                nextPlayer = 0;

            MyTextBlock.Dispatcher.BeginInvoke(new Action(() => MyTextBlock.DataContext = currectPlayer));

            currectPlayer = game.Players[nextPlayer];
            ShowImageCards();
            nextPlayer++;
        }

        public void ShowImageCards()
        {
            List<ImageCard> displayCards = new List<ImageCard>();

            foreach (Card item in currectPlayer.PlayersCards)
            {
                ImageCard imgCard = new ImageCard(item);
                displayCards.Add(imgCard);
            }

            wonder.ItemsSource = displayCards;
        }

    }
}
