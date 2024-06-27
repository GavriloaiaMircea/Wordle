using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Wordle
{
    public partial class ThreeLetterWordleWindow : Window
    {
        private readonly List<string> _words;
        private readonly string _targetWord;
        private int _currentRow;
        private string _currentGuess;

        public ThreeLetterWordleWindow()
        {
            InitializeComponent();
            _words = LoadWordsFromResource("Resources/three_letter_words.txt");
            var random = new Random();
            _targetWord = _words[random.Next(_words.Count)].ToUpper();
            _currentRow = 0;
            _currentGuess = string.Empty;
            InitializeWordGrid();
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

        private void InitializeWordGrid()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    var textBox = new TextBox
                    {
                        Name = $"TextBox{i}{j}",
                        FontSize = 24,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        TextAlignment = TextAlignment.Center,
                        IsReadOnly = true,
                        BorderThickness = new Thickness(0),
                        Background = Brushes.Transparent,
                        CaretBrush = Brushes.Transparent,
                        Focusable = false,
                        Cursor = Cursors.None
                    };
                    Grid.SetRow(textBox, i);
                    Grid.SetColumn(textBox, j);
                    WordGrid.Children.Add(textBox);
                }
            }
        }

        private void KeyButton_Click(object sender, RoutedEventArgs e)
        {
            if (_currentGuess.Length < 3)
            {
                _currentGuess += (sender as Button).Content.ToString();
                UpdateCurrentRow();
            }
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            if (_currentGuess.Length == 3)
            {
                CheckGuess();
                if (_currentGuess == _targetWord)
                {
                    MessageBox.Show($"You guessed the word in {_currentRow + 1} tries!", "Congratulations!");
                    this.Close();
                }
                else if (_currentRow == 5)
                {
                    MessageBox.Show($"You did not guess the word. The word was {_targetWord}.", "Game Over");
                    this.Close();
                }
                else
                {
                    _currentRow++;
                    _currentGuess = string.Empty;
                }
            }
        }

        private void BackspaceButton_Click(object sender, RoutedEventArgs e)
        {
            if (_currentGuess.Length > 0)
            {
                _currentGuess = _currentGuess.Substring(0, _currentGuess.Length - 1);
                UpdateCurrentRow();
            }
        }

        private void UpdateCurrentRow()
        {
            for (int i = 0; i < 3; i++)
            {
                var textBox = (TextBox)FindName($"TextBox{_currentRow}{i}");
                if (textBox != null)
                {
                    textBox.Text = i < _currentGuess.Length ? _currentGuess[i].ToString() : string.Empty;
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
            for (int i = 0; i < 3; i++)
            {
                var textBox = (TextBox)FindName($"TextBox{_currentRow}{i}");
                if (_currentGuess[i] == _targetWord[i])
                {
                    textBox.Background = Brushes.Green;
                    letterFrequency[_currentGuess[i]]--;
                    UpdateKeyboardKeyColor(_currentGuess[i].ToString(), Brushes.Green);
                }
            }

            // Second pass to apply yellow or gray
            for (int i = 0; i < 3; i++)
            {
                var textBox = (TextBox)FindName($"TextBox{_currentRow}{i}");
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
    }
}
