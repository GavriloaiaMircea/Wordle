using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Wordle
{
    public partial class SixLetterWordleWindow : Window
    {
        private WordleGame _wordleGame;

        public SixLetterWordleWindow()
        {
            InitializeComponent();
            _wordleGame = new WordleGame(6, "Resources/six_letter_words.txt", WordGrid, KeyboardWrapPanel);
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
