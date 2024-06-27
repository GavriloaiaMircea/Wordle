using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Wordle
{
    public partial class FiveLetterWordleWindow : Window
    {
        private List<string> _words;
        private string _targetWord;
        private int _currentRow;
        private string _currentGuess;

        public FiveLetterWordleWindow()
        {
            InitializeComponent();
            _words = LoadWordsFromResource("Resources/five_letter_words.txt");
            var random = new Random();
            _targetWord = _words[random.Next(_words.Count)].ToUpper();
            _currentRow = 0;
            _currentGuess = string.Empty;
        }

        private List<string> LoadWordsFromResource(string resourcePath)
        {
            var words = new List<string>();
            var uri = new Uri(resourcePath, UriKind.Relative);
            var resourceStream = Application.GetResourceStream(uri);

            if (resourceStream != null)
            {
                using (var reader = new StreamReader(resourceStream.Stream))
                {
                    while (!reader.EndOfStream)
                    {
                        words.Add(reader.ReadLine());
                    }
                }
            }
            else
            {
                throw new FileNotFoundException("Resource not found.", resourcePath);
            }

            return words;
        }

        private void KeyButton_Click(object sender, RoutedEventArgs e)
        {
            if (_currentGuess.Length < 5)
            {
                var button = sender as Button;
                _currentGuess += button.Content.ToString();
                UpdateCurrentGuessDisplay();
            }
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            if (_currentGuess.Length == 5)
            {
                CheckGuess();
                _currentGuess = string.Empty;
                _currentRow++;

                if (_currentRow == 6 || _currentGuess.Equals(_targetWord, StringComparison.OrdinalIgnoreCase))
                {
                    EndGame();
                }
            }
        }

        private void BackspaceButton_Click(object sender, RoutedEventArgs e)
        {
            if (_currentGuess.Length > 0)
            {
                _currentGuess = _currentGuess.Substring(0, _currentGuess.Length - 1);
                UpdateCurrentGuessDisplay();
            }
        }

        private void UpdateCurrentGuessDisplay()
        {
            for (int i = 0; i < 5; i++)
            {
                var textBox = FindName($"TextBox{_currentRow}{i}") as TextBox;
                if (i < _currentGuess.Length)
                {
                    textBox.Text = _currentGuess[i].ToString();
                }
                else
                {
                    textBox.Text = string.Empty;
                }
            }
        }

        private void CheckGuess()
        {
            Dictionary<char, int> letterFrequency = new Dictionary<char, int>();
            foreach (char c in _targetWord)
            {
                if (letterFrequency.ContainsKey(c))
                    letterFrequency[c]++;
                else
                    letterFrequency[c] = 1;
            }

            // First pass to apply green for correct matches
            for (int i = 0; i < 5; i++)
            {
                var textBox = FindName($"TextBox{_currentRow}{i}") as TextBox;
                if (_currentGuess[i] == _targetWord[i])
                {
                    textBox.Background = Brushes.Green;
                    letterFrequency[_currentGuess[i]]--;
                    UpdateKeyboardKeyColor(_currentGuess[i].ToString(), Brushes.Green);
                }
            }

            // Second pass to apply yellow or gray
            for (int i = 0; i < 5; i++)
            {
                var textBox = FindName($"TextBox{_currentRow}{i}") as TextBox;
                if (textBox.Background != Brushes.Green)
                {
                    if (_targetWord.Contains(_currentGuess[i]) && letterFrequency[_currentGuess[i]] > 0)
                    {
                        textBox.Background = Brushes.Yellow;
                        letterFrequency[_currentGuess[i]]--;
                        UpdateKeyboardKeyColor(_currentGuess[i].ToString(), Brushes.Yellow, ignoreGreen: true);
                    }
                    else
                    {
                        textBox.Background = Brushes.Gray;
                        UpdateKeyboardKeyColor(_currentGuess[i].ToString(), Brushes.Gray, ignoreGreen: true);
                    }
                }
            }
        }

        private void UpdateKeyboardKeyColor(string key, Brush color, bool ignoreGreen = false)
        {
            foreach (Button button in KeyboardWrapPanel.Children)
            {
                if (button.Content.ToString().Equals(key, StringComparison.OrdinalIgnoreCase))
                {
                    if (!ignoreGreen || button.Background != Brushes.Green) // Do not overwrite green with yellow or gray
                        button.Background = color;
                }
            }
        }


        private void UpdateKeyboardKeyColor(string key, Brush color)
        {
            foreach (Button button in KeyboardWrapPanel.Children)
            {
                if (button.Content.ToString().Equals(key, StringComparison.OrdinalIgnoreCase))
                {
                    button.Background = color;
                }
            }
        }

        private void EndGame()
        {
            if (_currentGuess.Equals(_targetWord, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show($"Congratulations! You guessed the word {_targetWord}!", "Game Over", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show($"You did not guess the word. The word was {_targetWord}.", "Game Over", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            Close();
        }
    }
}
