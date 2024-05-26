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

namespace WpfHangman
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            StartNewGame();
            hiddenWordDisplayed.Text = hiddenWord2Guess;
        }

        static private string[] hangmanKeys = new string[] { "DEVELOPER", "MICROSOFT", "SKILLS", "JOURNEY", "CHOROSZCZ" };
        private const int maxAttemptsCounter = 11;
        static private int remainingAttemptsCounter;
        static private char[] word2GuessArray = [];
        static private char[] hiddenWord2GuessArray = [];
        static private string? hiddenWord2Guess;
        static private string? word2Guess;
        static private bool gameWon;
        static private bool gameLost;
        static private List<char> typedWords = new List<char> { };


        /// <summary>
        /// Method responsible for starting a new game of hangman.
        /// </summary>
        static private void StartNewGame()
        {
            typedWords = [];
            Random random = new Random();
            int randomWordIndex = random.Next(0, hangmanKeys.Length);
            word2Guess = hangmanKeys[randomWordIndex];
            word2GuessArray = word2Guess.ToCharArray();

            hiddenWord2Guess = word2Guess;
            for (int i = 0; i < word2Guess.Length; i++)
            {
                char char2Replace = word2Guess[i];
                hiddenWord2Guess = hiddenWord2Guess.Replace(char2Replace, '_');
            }
            // Game state initiation
            hiddenWord2GuessArray = hiddenWord2Guess.ToCharArray();

            // Remaining attempts initation
            remainingAttemptsCounter = maxAttemptsCounter;
        }


        /// <summary>
        /// Method responsible for checking if the guessed letter is correct.
        /// </summary>
        /// 
        static private void CheckLetter(char inputChar, TextBlock hiddenWordDisplayed)
        {
            {
                bool letterFound = false;
                inputChar = Char.ToUpper(inputChar);
                typedWords.Add(inputChar);
                for (int i = 0; i < word2GuessArray.Length; i++)
                {
                    if (word2GuessArray[i] == inputChar)
                    {
                        hiddenWord2GuessArray[i] = inputChar;
                        letterFound = true;
                    }
                }
                if (!letterFound)
                {
                    remainingAttemptsCounter--;
                    MessageBox.Show("Wrong letter!");
                }
                hiddenWord2Guess = string.Join("", hiddenWord2GuessArray);
                hiddenWordDisplayed.Text = hiddenWord2Guess;
            }
        }
        
        
        /// <summary>
        /// Method responsible for checking if the word has been guessed.
        /// </summary>
        static private bool IsWordGuessed(string word2Guess)
        {
            return (!word2Guess.Contains("_"));
        }
        
        
        /// <summary>
        /// Method responsible for checking if the game has been lost.
        /// </summary>
        static private bool IsGameLost(int remainingAttemptsCounter)
        {
            return (!(remainingAttemptsCounter != 0));
        }
       
        
        /// <summary>
        /// Method responsible for updating the user interface.
        /// </summary>
        private void UpdateUI()
        {
            switch (remainingAttemptsCounter)
            {
                case 10:
                    Element1.Visibility = Visibility.Visible;
                    Element2.Visibility = Visibility.Visible;
                    break;
                case 9:
                    Element3.Visibility = Visibility.Visible;
                    break;
                case 8:
                    Element4.Visibility = Visibility.Visible;
                    break;
                case 7:
                    Element5.Visibility = Visibility.Visible;
                    break;
                case 6:
                    Element6.Visibility = Visibility.Visible;
                    Element7.Visibility = Visibility.Visible;
                    break;
                case 5:
                    Element8.Visibility = Visibility.Visible;
                    Element9.Visibility = Visibility.Visible;
                    break;
                case 4:
                    Element10.Visibility = Visibility.Visible;
                    Element11.Visibility = Visibility.Visible;
                    break;
                case 3:
                    Element12.Visibility = Visibility.Visible;
                    break;
                case 2:
                    Element13.Visibility = Visibility.Visible;
                    break;
                case 1:
                    Element14.Visibility = Visibility.Visible;
                    Element15.Visibility = Visibility.Visible;
                    break;
                case 0:
                    Element16.Visibility = Visibility.Visible;
                    break;
            }
        }
        

        private void Guess_Click(object sender, RoutedEventArgs e)
        {
            string inputString = inputLetter.Text.ToUpper();
            if (!string.IsNullOrEmpty(inputString) && Char.IsLetter(inputString[0]) && !typedWords.Contains(inputString[0]) && inputString.Length == 1)
            {
                CheckLetter(inputString[0], hiddenWordDisplayed);
                gameWon = hiddenWord2Guess != null && IsWordGuessed(hiddenWord2Guess);
                gameLost = IsGameLost(remainingAttemptsCounter);
                UpdateUI();
                if (gameWon)
                {
                    peppe1.Visibility = Visibility.Collapsed;
                    peppe2.Visibility = Visibility.Visible;
                    MessageBox.Show("You won");
                    this.Close();
                }
                else if (gameLost)
                {
                    peppe1.Visibility = Visibility.Collapsed;
                    peppe3.Visibility = Visibility.Visible;
                    MessageBox.Show("You lost");
                    this.Close();
                }
                inputLetter.Clear();
            }
            else
            {
                MessageBox.Show("Please enter a valid single letter that you haven't typed before.");
            }
        }

        private void inputLetter_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Guess_Click(sender, new RoutedEventArgs());
            }
        }
    }
}