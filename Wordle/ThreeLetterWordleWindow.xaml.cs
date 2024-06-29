using System.Windows;
using System.Windows.Controls;

namespace Wordle
{
    public partial class ThreeLetterWordleWindow : Window
    {
        private WordleGame _wordleGame;

        public ThreeLetterWordleWindow()
        {
            InitializeComponent();
            _wordleGame = new WordleGame(3, "Resources/three_letter_words.txt", WordGrid, KeyboardWrapPanel);
        }

        private void KeyButton_Click(object sender, RoutedEventArgs e)
        {
            _wordleGame.KeyButton_Click(sender, e);
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            _wordleGame.EnterButton_Click(sender, e);
        }

        private void BackspaceButton_Click(object sender, RoutedEventArgs e)
        {
            _wordleGame.BackspaceButton_Click(sender, e);
        }
    }
}
