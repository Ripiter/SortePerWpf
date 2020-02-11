using System;
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
            Console.WriteLine(game.RemoveDuplicates());
            steve.ItemsSource = game.Players;
            this.DataContext = this;
        }

        
        int nextPlayer = 1;
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            // Set next player in line
            //if (nextPlayer >= people.Count)
            //    nextPlayer = 0;

            
            //MyTextBlock.Dispatcher.BeginInvoke(new Action(() => MyTextBlock.DataContext = currectPlayer));
            nextPlayer++;
        }

    }
}
