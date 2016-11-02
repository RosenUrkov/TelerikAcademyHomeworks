using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Print_a_Deck
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] allCards = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            string card = Console.ReadLine();
            int i = 0;
            do
            {
                Console.WriteLine("{0} of spades, {0} of clubs, {0} of hearts, {0} of diamonds", allCards[i]);
                if(allCards[i]==card)
                {
                    break;
                }
                i++;
            } while (i<allCards.Length);
            

            
        }
    }
}
