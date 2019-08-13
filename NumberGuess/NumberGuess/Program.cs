using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuess
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayGame();

        }

        /// <summary>
        /// Prompts the player defined by playerNumber for their name
        /// </summary>
        /// <param name="playerNumber"> The number for the player</param>
        /// <returns>The player's name </returns>
        private static string GetPlayerName(int playerNumber)
        {
            Console.WriteLine("Player {0}, what is your name?", playerNumber);
            return Console.ReadLine();
        }

        /// <summary>
        /// Prompts the user for a number
        /// </summary>
        /// <param name="playerName"> The player's name </param>
        /// <param name="message"> The message to be displayed </param>
        /// <returns> The number the player picks </returns>
        private static int GetNumber(string playerName, string message)
        {
            Console.Write("{0}: {1}", playerName, message);
            int num;
            const int minimumValue = 1;
            const int maximumValue = 100;
            while (!int.TryParse(Console.ReadLine(),out num) || num < minimumValue || num > maximumValue)
            {
                Console.WriteLine("Please enter a number between 1 and 100");
            }
            return num;
        }

        /// <summary>
        /// Starts the game
        /// </summary>
        private static void PlayGame()
        {
            Console.WriteLine("Welcome to NumberGuess");
            const int maxGuesses = 2;
            string player1Name = GetPlayerName(1);
            string player2Name = GetPlayerName(2);
            while(player2Name == player1Name)
            {
                Console.WriteLine("Both names can not be the same.");
                player2Name = GetPlayerName(2);
            }

           
            while (true)
            {
                int numberToGuess = GetNumber(player1Name,"What's your number? ");
                Console.Clear();
                int incorrectGuesses = 0;
                while(incorrectGuesses < maxGuesses)
                {
                    int guess = GetNumber(player2Name, "Guess a number: ");
                    if(guess == numberToGuess)
                    {
         
                        break;
                    }else
                    {
                        if(guess < numberToGuess)
                        {
                            Console.Write("Sorry, your guess was too low. ");
                        }else
                        {
                            Console.Write("Sorry, your guess was too high. ");
                        }
                        incorrectGuesses++;
                        Console.WriteLine("You have {0} guesses left.", maxGuesses - incorrectGuesses);
                    }
                }
                if (incorrectGuesses < maxGuesses)
                {
                    Console.WriteLine("Congratulations, you win!");
                }
                else
                {
                    Console.WriteLine("You lost");
                }
                Console.WriteLine("Do you want to play again?");
                if(Console.ReadLine().ToLower() == "yes")
                {
                    string tempName = player1Name;
                    player1Name = player2Name;
                    player2Name = tempName;
                    Console.Clear();
                }else
                {
                    break;
                }
            }
            

        }
    }
}
