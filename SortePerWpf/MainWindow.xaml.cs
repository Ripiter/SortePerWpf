using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
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
            steve.ItemsSource = game.Players;
            nextPlayerEvent += NextPlayer;
            this.DataContext = this;
        }

        Player currentPlayer;
        Player nextPlayer;
        int currentPlayerIndex = 0;
        int nextPlayerIndex = 1;
        bool gameover = false;

        public event EventHandler nextPlayerEvent;
        private void NextPlayer(object sender, EventArgs e)
        {
            if (gameover == true)
                return;

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
           

            nextplayerText.DataContext = nextPlayer;
            MyTextBlock.DataContext = currentPlayer;
            ShowImageCards();
            //MyTextBlock.Dispatcher.BeginInvoke(new Action(() => MyTextBlock.DataContext = currentPlayer));
            //nextplayerText.Dispatcher.BeginInvoke(new Action(() => nextplayerText.DataContext = nextPlayer));

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (nextPlayerEvent != null)
                nextPlayerEvent(this, new EventArgs());
        }
        
        private void TakeCard(object sender, RoutedEventArgs e)
        {
            if (currentPlayer is Human)
            {
                Card card = game.TakeCard(nextPlayer, 0);
                int rndPos = new Random(DateTime.Now.Millisecond).Next(0, currentPlayer.PlayersCards.Count + 1);
                currentPlayer.PlayersCards.Insert(rndPos, card);
                currentPlayer.RemovePairs(card);
            }
            else
            {
                Card card = game.TakeCard(nextPlayer, 0);
                int rndPos = new Random(DateTime.Now.Millisecond).Next(0, currentPlayer.PlayersCards.Count + 1);
                currentPlayer.PlayersCards.Insert(rndPos, card);
                currentPlayer.RemovePairs(card);
                //nextPlayerIndex++;
                //currentPlayerIndex++;
                //if (nextPlayerEvent != null)
                //    nextPlayerEvent(this, new EventArgs());
            }

            Log.AddToLog(new LogMessage("after " + currentPlayer.Name + " has " + currentPlayer.PlayersCards.Count), MessageType.playersTurn);
            Log.AddToLog(new LogMessage("after " + nextPlayer.Name + " has " + nextPlayer.PlayersCards.Count), MessageType.playersTurn);

            if (game.CheckForLooser())
            {
                gameover = true;
                MessageBox.Show("And tonights bigest loser is: " + game.Players[0].Name);
            }
            

            MyTextBlock.Dispatcher.BeginInvoke(new Action(() => MyTextBlock.DataContext = RefreshPlayer(currentPlayer)));
            nextplayerText.Dispatcher.BeginInvoke(new Action(() => nextplayerText.DataContext = RefreshPlayer(nextPlayer)));
            ShowImageCards();

            nextPlayerIndex++;
            currentPlayerIndex++;
        }
        Player RefreshPlayer(Player player)
        {
            Player pl = null;
            if(player is Human)
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            LogWindow win2 = new LogWindow();
            win2.Show();
        }
    }
}