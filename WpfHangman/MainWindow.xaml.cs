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
            while (gameOn)
            {
                StartNewGame();
                ChooseWord2Play();
                GameLogic();
                EndGameMessage();
            }
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
        static private bool gameOn = true;
        static private List<char> typedWords = new List<char> { };


        /// <summary>
        /// Method responsible for starting a new game of hangman.
        /// </summary>
        static private void StartNewGame()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the hangman game!");
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
        /// Method responsible for choosing a word to play from the hangmanKeys array.
        /// </summary>
        static private void ChooseWord2Play()
        {
            foreach (string key in hangmanKeys)
            {
                string modifiedKey = key;
                for (int i = 0; i < key.Length; i++)
                {
                    char char2Replace = key[i];
                    modifiedKey = modifiedKey.Replace(char2Replace, '_');
                }
            }
            remainingAttemptsCounter = maxAttemptsCounter;
        }
        /// <summary>
        /// Method responsible for checking if the guessed letter is correct.
        /// </summary>
        static private void CheckLetter()
        {
            {
                bool letterFound = false;
                Console.Write("Guess a letter: ");
                string? inputString = Console.ReadLine();

                while (string.IsNullOrEmpty(inputString) || (!Char.IsLetter(inputString[0]) || typedWords.Contains(Char.ToUpper(inputString[0])) || inputString.Length > 1))
                {
                    if (string.IsNullOrEmpty(inputString))
                    {
                        Console.Clear();
                        Console.Write("Empty field not allowed. Type a letter!: ");
                        inputString = Console.ReadLine();
                    }
                    else if ((!Char.IsLetter(inputString[0])))
                    {
                        Console.Clear();
                        Console.Write("This is not a letter. Type a letter!: ");
                        inputString = Console.ReadLine();
                    }
                    else if (typedWords.Contains(Char.ToUpper(inputString[0])))
                    {
                        Console.Clear();
                        Console.Write($"{Char.ToUpper(inputString[0])} already typed. Type a new letter!: ");
                        inputString = Console.ReadLine();
                    }
                    else if (inputString.Length > 1)
                    {
                        Console.Clear();
                        Console.Write("This is not a single letter. Type a single letter!: ");
                        inputString = Console.ReadLine();
                    }
                }

                char inputChar = inputString[0];
                inputChar = Char.ToUpper(inputChar);
                typedWords.Add(inputChar);
                for (int i = 0; i < word2GuessArray.Length; i++)
                {
                    if (word2GuessArray[i] == inputChar)
                    {
                        hiddenWord2GuessArray[i] = inputChar;
                        letterFound = true;
                    }
                    else
                    {
                        Console.WriteLine(remainingAttemptsCounter);
                    }
                }
                if (!letterFound)
                {
                    remainingAttemptsCounter--;
                }
                hiddenWord2Guess = string.Join("", hiddenWord2GuessArray);
                Console.WriteLine(hiddenWord2GuessArray);
                Console.WriteLine(word2GuessArray);
                Console.WriteLine(remainingAttemptsCounter);
                Console.Clear();
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
        static private void UpdateUI()
        {
            Console.WriteLine(hiddenWord2GuessArray);
            Console.WriteLine();
            Console.WriteLine($"You still have {remainingAttemptsCounter} attempts left.");
            switch (remainingAttemptsCounter)
            {
                case 11:
                    Console.WriteLine("###########");
                    break;
                case 10:
                    Console.WriteLine("  ##");
                    Console.WriteLine("  ##");
                    Console.WriteLine("  ##");
                    Console.WriteLine("  ##");
                    Console.WriteLine("  ##");
                    Console.WriteLine("  ##");
                    Console.WriteLine("  ##");
                    Console.WriteLine("###########");

                    break;
                case 9:
                    Console.WriteLine("  #######");
                    Console.WriteLine("  ##");
                    Console.WriteLine("  ##");
                    Console.WriteLine("  ##");
                    Console.WriteLine("  ##");
                    Console.WriteLine("  ##");
                    Console.WriteLine("  ##");
                    Console.WriteLine("  ##");
                    Console.WriteLine("###########");
                    break;
                case 8:
                    Console.WriteLine("  ########");
                    Console.WriteLine("  ##   |  ");
                    Console.WriteLine("  ##      ");
                    Console.WriteLine("  ##      ");
                    Console.WriteLine("  ##      ");
                    Console.WriteLine("  ##      ");
                    Console.WriteLine("  ##      ");
                    Console.WriteLine("  ##      ");
                    Console.WriteLine("############");
                    break;
                case 7:
                    Console.WriteLine("  ########");
                    Console.WriteLine("  ##   |  ");
                    Console.WriteLine("  ##   |  ");
                    Console.WriteLine("  ##      ");
                    Console.WriteLine("  ##      ");
                    Console.WriteLine("  ##      ");
                    Console.WriteLine("  ##      ");
                    Console.WriteLine("  ##      ");
                    Console.WriteLine("############");
                    break;
                case 6:
                    Console.WriteLine("  ########");
                    Console.WriteLine("  ##   | ");
                    Console.WriteLine("  ##   | ");
                    Console.WriteLine("  ##   @ ");
                    Console.WriteLine("  ##     ");
                    Console.WriteLine("  ##     ");
                    Console.WriteLine("  ##     ");
                    Console.WriteLine("  ##      ");
                    Console.WriteLine("############");
                    break;
                case 5:
                    Console.WriteLine("  ########");
                    Console.WriteLine("  ##   |  ");
                    Console.WriteLine("  ##   |  ");
                    Console.WriteLine("  ##   @  ");
                    Console.WriteLine("  ##   |  ");
                    Console.WriteLine("  ##      ");
                    Console.WriteLine("  ##      ");
                    Console.WriteLine("  ##      ");
                    Console.WriteLine("############");
                    break;
                case 4:
                    Console.WriteLine("  ########");
                    Console.WriteLine("  ##   | ");
                    Console.WriteLine("  ##   | ");
                    Console.WriteLine("  ##   @ ");
                    Console.WriteLine("  ##  -|- ");
                    Console.WriteLine("  ##      ");
                    Console.WriteLine("  ##      ");
                    Console.WriteLine("  ##      ");
                    Console.WriteLine("############");
                    break;
                case 3:
                    Console.WriteLine("  ########");
                    Console.WriteLine("  ##   |  ");
                    Console.WriteLine("  ##   |  ");
                    Console.WriteLine("  ##   @  ");
                    Console.WriteLine("  ## .-|-.");
                    Console.WriteLine("  ## '   '");
                    Console.WriteLine("  ##      ");
                    Console.WriteLine("  ##      ");
                    Console.WriteLine("############");
                    break;
                case 2:
                    Console.WriteLine("  ########");
                    Console.WriteLine("  ##   |  ");
                    Console.WriteLine("  ##   |  ");
                    Console.WriteLine("  ##   @  ");
                    Console.WriteLine("  ## .-|-.");
                    Console.WriteLine("  ## ' | '");
                    Console.WriteLine("  ##      ");
                    Console.WriteLine("  ##      ");
                    Console.WriteLine("############");
                    break;
                case 1:
                    Console.WriteLine("  ########");
                    Console.WriteLine("  ##   |  ");
                    Console.WriteLine("  ##   |  ");
                    Console.WriteLine("  ##   @  ");
                    Console.WriteLine("  ## .-|-.");
                    Console.WriteLine("  ## ' | '");
                    Console.WriteLine("  ## _|   ");
                    Console.WriteLine("  ##      ");
                    Console.WriteLine("############");
                    break;
                case 0:
                    Console.WriteLine("  ########");
                    Console.WriteLine("  ##   |  ");
                    Console.WriteLine("  ##   |  ");
                    Console.WriteLine("  ##   @  ");
                    Console.WriteLine("  ## .-|-.");
                    Console.WriteLine("  ## ' | '");
                    Console.WriteLine("  ## _| |_");
                    Console.WriteLine("  ##      ");
                    Console.WriteLine("############");
                    Console.WriteLine("Game over");
                    break;
            }
        }
        /// <summary>
        /// Method responsible for displaying the end game message.
        /// </summary>
        static private void EndGameMessage()
        {
            if (gameWon)
            {
                gameWon = false;
                Console.Clear();
                for (int i = 0; i < 50; i++)
                {
                    Console.Write("*");
                    Thread.Sleep(10);
                }
                Console.WriteLine();
                Console.WriteLine($"You are the winner. the search word was: {hiddenWord2Guess}.");
                for (int i = 0; i < 50; i++)
                {
                    Console.Write("*");
                    Thread.Sleep(10);
                }
                Console.WriteLine();
                Console.WriteLine("To quit type: N and press enter. ");
                Console.Write("To play again type: anything and press enter. ");
                string? decision = Console.ReadLine();
                while (string.IsNullOrEmpty(decision))
                {
                    Console.WriteLine("To quit type: N and press enter");
                    Console.Write("To play again type: anything and press enter. ");
                    decision = Console.ReadLine();
                }
                char decisionChar = Char.ToUpper(decision[0]);

                if (decisionChar == 'N')
                {
                    gameOn = false;
                    Console.WriteLine();
                    Console.WriteLine("Goodbye!");
                }
            }

            if (gameLost)
            {
                Console.Clear();
                gameLost = false;
                for (int i = 0; i < 50; i++)
                {
                    Console.Write("*");
                    Thread.Sleep(10);
                }
                Console.WriteLine();
                Console.WriteLine($"You lost. the search word was: developer: {word2Guess}.");
                for (int i = 0; i < 50; i++)
                {
                    Console.Write("*");
                    Thread.Sleep(10);
                }
                Console.WriteLine();
                Console.WriteLine("To quit type: N and press enter. ");
                Console.Write("To play again type: anything and press enter. ");
                string? decision = Console.ReadLine();
                while (string.IsNullOrEmpty(decision))
                {
                    Console.WriteLine("To quit type: N and press enter. ");
                    Console.Write("To play again type: anything and press enter. ");
                    decision = Console.ReadLine();
                }
                char decisionChar = Char.ToUpper(decision[0]);

                if (decisionChar == 'N')
                {
                    gameOn = false;
                    Console.WriteLine();
                    Console.WriteLine("Goodbye!");
                }
            }


        }
        /// <summary>
        /// Method responsible for the main game logic loop.
        /// </summary>
        static private void GameLogic()
        {
            while (!gameLost && !gameWon)
            {
                CheckLetter();
                UpdateUI();
                gameWon = hiddenWord2Guess != null && IsWordGuessed(hiddenWord2Guess);
                gameLost = IsGameLost(remainingAttemptsCounter);
            }
        }
    }
}