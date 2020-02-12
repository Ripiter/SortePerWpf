using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Threading;
using System.Diagnostics;
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
            currentPlayer = game.Players[currentPlayerIndex];
            
            


            steve.ItemsSource = game.Players;
            this.DataContext = this;
        }

        Player currentPlayer;
        Player nextPlayer;
        int currentPlayerIndex = 0;
        int nextPlayerIndex = 1;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Set next player in line
            if (nextPlayerIndex >= game.Players.Count)
                nextPlayerIndex = 0;

            if (currentPlayerIndex >= game.Players.Count)
                currentPlayerIndex = 0;

            currentPlayer = game.Players[currentPlayerIndex];
            nextPlayer = game.Players[nextPlayerIndex];


            Debug.WriteLine("Currect player index " + currentPlayerIndex);
            Debug.WriteLine("Next player index " + nextPlayerIndex);
            Debug.WriteLine("Current player name " + currentPlayer.Name);
            Debug.WriteLine("Next player name " + nextPlayer.Name);

            //MyTextBlock.DataContext = currentPlayer;
            MyTextBlock.Dispatcher.BeginInvoke(new Action(() => MyTextBlock.DataContext = currentPlayer));


            if (currentPlayer is Human)
            {
                Card card = game.TakeCard(nextPlayer, 0);
                int rndPos = new Random(DateTime.Now.Millisecond).Next(0, currentPlayer.PlayersCards.Count);
                currentPlayer.PlayersCards.Insert(rndPos, card);
                currentPlayer.RemovePairs(card);
            }
            else
            {
                Card card = game.TakeCard(nextPlayer, 0);
                int rndPos = new Random(DateTime.Now.Millisecond).Next(0, currentPlayer.PlayersCards.Count);
                currentPlayer.PlayersCards.Insert(rndPos, card);
                currentPlayer.RemovePairs(card);
            }



            ShowImageCards();

            nextPlayerIndex++;
            currentPlayerIndex++;

            game.CheckForLooser();
        }
        bool funmode = false;
        public void ShowImageCards()
        {
            IFactory factory;

            if (funmode == false)
                factory = new NormalPlayingCards();
            else
                factory = new CustomPlayingCards();

            List<ImageCard> displayCards = factory.GenerateImageCards(currentPlayer.PlayersCards);

            wonder.ItemsSource = displayCards;
        }

    }
}
