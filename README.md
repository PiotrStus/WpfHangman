# Hangman Game (WPF)

Hangman is a simple word-guessing game where players try to guess a hidden word by inputting single letters. The player has a limited number of attempts to guess the word, and each time a letter is not guessed correctly, a new part of the hangman is drawn. The player's objective is to guess the word before running out of attempts.

## Game Logic

1. The player starts the game try to guess a hidden word (word lists contained in an array).
2. The player has a fixed number of attempts (usually 11) to guess the word.
3. The player inputs single letters.
4. If the letter is present in the word, it is displayed in the correct positions.
5. If the letter is not present in the word, a new part of the hangman is drawn.
6. The game ends when the player guesses the word or runs out of attempts.
7. The player has the option to start a new game after finishing the current one.

* Protections in case of typing: the same letter twice, not a letter, more than one letter at the same time, empty char added.

## Video

[![Alt text for your video](http://img.youtube.com/vi/A_k6epJdFwQ/0.jpg)](http://www.youtube.com/watch?v=A_k6epJdFwQ)


## Requirements

To run the game, you need to:

1. Clone the repository to your local machine.
2. Open the project in a development environment that supports C#, such as Visual Studio.
3. Run the application in the development environment to play the game.

## Notes

1. The project is created using C# and WPF (Windows Presentation Foundation).
2. The Hangman game is easy to play and provides enjoyable entertainment for players who like to test their word skills.

## Project Origin

This project is an extension of the Hangman project originally created by me You can find the original project [here](https://github.com/PiotrStus/Hangman).
