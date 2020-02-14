using System;
using System.Collections.Generic;
using System.Windows;
namespace SortePerWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Game game = new Game();
        bool funmode = true;
        Player currentPlayer;
        Player nextPlayer;
        int currentPlayerIndex = 0;
        int nextPlayerIndex = 1;
        bool gameover = false;


        public MainWindow()
        {
            InitializeComponent();
            steve.ItemsSource = game.Players;
            game.Start();

            this.DataContext = this;

            NextPlayer();
        }


        private void NextPlayer()
        {
            NextPlayerButtonDisable();

            // Set next player in line
            if (nextPlayerIndex >= game.Players.Count)
                nextPlayerIndex = 0;

            if (currentPlayerIndex >= game.Players.Count)
                currentPlayerIndex = 0;

            if (currentPlayerIndex == nextPlayerIndex)
            {
                if (nextPlayerIndex >= game.Players.Count)
                    nextPlayerIndex = 0;
                else
                    nextPlayerIndex++;
            }

            currentPlayer = game.Players[currentPlayerIndex];
            nextPlayer = game.Players[nextPlayerIndex];

            Log.AddToLog(new LogMessage("before " + currentPlayer.Name + " has " + currentPlayer.PlayersCards.Count), MessageType.playersTurn);
            Log.AddToLog(new LogMessage("before " + nextPlayer.Name + " has " + nextPlayer.PlayersCards.Count), MessageType.playersTurn);


            if (currentPlayer is Computer)
                ComputerTakeCard();


            nextplayerText.DataContext = nextPlayer;
            MyTextBlock.DataContext = currentPlayer;
            ShowImageCards();

            //MyTextBlock.Dispatcher.BeginInvoke(new Action(() => MyTextBlock.DataContext = currentPlayer));
            //nextplayerText.Dispatcher.BeginInvoke(new Action(() => nextplayerText.DataContext = nextPlayer));
        }

        private void NextPlayerButton(object sender, RoutedEventArgs e)
        {
            if (gameover)
                return;
            NextPlayer();
        }

        private void TakeCard(object sender, RoutedEventArgs e)
        {
            if (gameover)
                return;

            NextPlayerButtonDisable();

            Card card = game.TakeCard(nextPlayer, 0);
            int rndPos = new Random(DateTime.Now.Millisecond).Next(0, currentPlayer.PlayersCards.Count + 1);
            currentPlayer.PlayersCards.Insert(rndPos, card);
            currentPlayer.RemovePairs(card);


            Log.AddToLog(new LogMessage("after " + currentPlayer.Name + " has " + currentPlayer.PlayersCards.Count), MessageType.playersTurn);
            Log.AddToLog(new LogMessage("after " + nextPlayer.Name + " has " + nextPlayer.PlayersCards.Count), MessageType.playersTurn);

            MyTextBlock.DataContext = RefreshPlayer(currentPlayer);
            nextplayerText.DataContext = RefreshPlayer(nextPlayer);

            ShowImageCards();

            CheckForLoser();

            nextPlayerIndex++;
            currentPlayerIndex++;
        }

        void ComputerTakeCard()
        {
            NextPlayerButtonDisable();
            Card card = game.TakeCard(nextPlayer, 0);
            int rndPos = new Random(DateTime.Now.Millisecond).Next(0, currentPlayer.PlayersCards.Count + 1);
            currentPlayer.PlayersCards.Insert(rndPos, card);
            currentPlayer.RemovePairs(card);

            Log.AddToLog(new LogMessage("after " + currentPlayer.Name + " has " + currentPlayer.PlayersCards.Count), MessageType.playersTurn);
            Log.AddToLog(new LogMessage("after " + nextPlayer.Name + " has " + nextPlayer.PlayersCards.Count), MessageType.playersTurn);

            nextPlayerIndex += 1;
            currentPlayerIndex += 1;

            CheckForLoser();

            NextPlayer();
        }

        Player RefreshPlayer(Player player)
        {
            Player pl = null;
            if (player is Human)
            {
                pl = new Human(player.Name);
                pl.PlayersCards = player.PlayersCards;
            }
            else
            {
                pl = new Computer(player.Name);
                pl.PlayersCards = player.PlayersCards;
            }

            return pl;
        }

        void CheckForLoser()
        {
            if (game.CheckForLooser())
            {
                currentPlayer = game.Players[0];
                ShowImageCards();
                gameover = true;
                MessageBox.Show("And tonights bigest loser is: " + game.Players[0].Name);
            }
        }

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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            LogWindow win2 = new LogWindow();
            win2.Show();
        }

        private void FunModeButtonEvent(object sender, RoutedEventArgs e)
        {
            if (funmode == true)
                funmode = false;
            else
                funmode = true;
        }

        private void NextPlayerButtonDisable()
        {
            if (nextPlayerB.IsEnabled)
            {
                nextPlayerB.IsEnabled = false;
                takeCardB.IsEnabled = true;
            }
            else
            {
                nextPlayerB.IsEnabled = true;
                takeCardB.IsEnabled = false;
            }
        }
    }
}