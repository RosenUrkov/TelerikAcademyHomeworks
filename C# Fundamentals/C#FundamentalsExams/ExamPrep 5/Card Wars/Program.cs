using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card_Wars
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] cards = { "A", "10", "9", "8", "7", "6", "5", "4", "3", "2", "J", "Q", "K" };

            int numberOfGames = int.Parse(Console.ReadLine());

            bool firstPlayerWins = false;
            bool secondPlayerWins = false;

            int firstPlayersScore = 0;
            int secondPlayersScore = 0;


            int firstPlayerWonGames = 0;
            int secondPlayerWonGames = 0;


            for (int i = 0; i < numberOfGames; i++)
            {
                int firstHandStrenght = 0;
                int secondHandStrenght = 0;

                string firstPlayersCards = string.Empty;
                string secondPlayersCards = string.Empty;

                firstPlayerWins = false;
                secondPlayerWins = false;

                for (int j = 0; j < 3; j++)
                {
                    firstPlayersCards = Console.ReadLine();
                    if (firstPlayersCards == "Z")
                    {
                        firstPlayersScore *= 2;
                    }
                    else if (firstPlayersCards == "Y")
                    {
                        firstPlayersScore -= 200;
                    }
                    else if (firstPlayersCards == "X")
                    {
                        firstPlayerWins = true;
                    }
                    else
                    {
                        for (int k = 0; k < cards.Length; k++)
                        {
                            if (firstPlayersCards == cards[k])
                            {
                                firstHandStrenght += k + 1;
                            }
                        }
                    }
                }

                for (int j = 0; j < 3; j++)
                {
                    secondPlayersCards = Console.ReadLine();
                    if (secondPlayersCards == "Z")
                    {
                        secondPlayersScore *= 2;
                    }
                    else if (secondPlayersCards == "Y")
                    {
                        secondPlayersScore -= 200;
                    }
                    else if (secondPlayersCards == "X")
                    {
                        secondPlayerWins = true;
                    }
                    else
                    {
                        for (int k = 0; k < cards.Length; k++)
                        {
                            if (secondPlayersCards == cards[k])
                            {
                                secondHandStrenght += k + 1;
                            }
                        }
                    }
                }

                if (firstPlayerWins && secondPlayerWins)
                {
                    firstPlayersScore += 50;
                    secondPlayersScore += 50;
                }
                else if (firstPlayerWins || secondPlayerWins)
                {
                    break;
                }
                else if (firstHandStrenght > secondHandStrenght)
                {
                    firstPlayersScore += firstHandStrenght;
                    firstPlayerWonGames++;
                }
                else if (firstHandStrenght < secondHandStrenght)
                {
                    secondPlayersScore += secondHandStrenght;
                    secondPlayerWonGames++;
                }
            }
            if (firstPlayerWins)
            {
                Console.WriteLine("X card drawn! Player one wins the match!");
            }
            else if (secondPlayerWins)
            {
                Console.WriteLine("X card drawn! Player two wins the match!");
            }
            else if (firstPlayersScore > secondPlayersScore)
            {
                Console.WriteLine("First player wins!\r\nScore: {0}\r\nGames won: {1}", firstPlayersScore, firstPlayerWonGames);
            }
            else if (firstPlayersScore < secondPlayersScore)
            {
                Console.WriteLine("Second player wins!\r\nScore: {0}\r\nGames won: {1}", secondPlayersScore, secondPlayerWonGames);
            }
            else if (firstPlayersScore == secondPlayersScore)
            {
                Console.WriteLine("It's a tie!\r\nScore: {0}", firstPlayersScore);
            }
        }
    }
}
