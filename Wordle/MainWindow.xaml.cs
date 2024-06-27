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

namespace Wordle
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ThreeLettersButton_Click(object sender, RoutedEventArgs e)
        {
            var threeLetterWordleWindow = new ThreeLetterWordleWindow();
            threeLetterWordleWindow.Show();
        }

        private void FourLettersButton_Click(object sender, RoutedEventArgs e)
        {
            var fourLetterWordleWindow = new FourLetterWordleWindow();
            fourLetterWordleWindow.Show();
        }

        private void FiveLettersButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Starting game with 5-letter words.");
            // Logic to start the game with 5-letter words
        }

        private void SixLettersButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Starting game with 6-letter words.");
            // Logic to start the game with 6-letter words
        }

        private void HowToPlayButton_Click(object sender, RoutedEventArgs e)
        {
            var howToPlayWindow = new HowToPlayWindow();
            howToPlayWindow.Show();
        }
    }
}
