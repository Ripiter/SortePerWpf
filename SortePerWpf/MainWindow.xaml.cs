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
        public MainWindow()
        {
            InitializeComponent();
            steve.ItemsSource = people;
            this.DataContext = this;
        }

        ObservableCollection<Person> people = new ObservableCollection<Person>
        {
            new Person("Jon", "15"),
            new Person("Jack", "9"),
            new Person("Stefan", "20")
        };

        Person currectPlayer;
        public void RemovePerson()
        {
            people.RemoveAt(0);
        }

        
        int nextPlayer = 1;
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            // Set next player in line
            if (nextPlayer >= people.Count)
                nextPlayer = 0;

            
            MyTextBlock.Dispatcher.BeginInvoke(new Action(() => MyTextBlock.DataContext = currectPlayer));
            nextPlayer++;
        }

    }
}
