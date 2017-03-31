namespace Cards
{
    using System;
    using System.Text;

    public class Cards
    {
        public static void Main(string[] args)
        {
            int numberOfHands = int.Parse(Console.ReadLine());

            int[] cardValues = new int[52];
            string[] cards =
                {
                "2c", "3c", "4c", "5c", "6c", "7c", "8c", "9c", "Tc", "Jc", "Qc", "Kc", "Ac",
                "2d", "3d", "4d", "5d", "6d", "7d", "8d", "9d", "Td", "Jd", "Qd", "Kd", "Ad",
                "2h", "3h", "4h", "5h", "6h", "7h", "8h", "9h", "Th", "Jh", "Qh", "Kh", "Ah",
                "2s", "3s", "4s", "5s", "6s", "7s", "8s", "9s", "Ts", "Js", "Qs", "Ks", "As"
            };

            long result = 0;
            for (int hand = 0; hand < numberOfHands; hand++)
            {
                long currentHand = long.Parse(Console.ReadLine());

                result = currentHand | result;

                for (int i = 0; i < 52; i++)
                {
                    if (((currentHand >> i) & 1) == 1)
                    {
                        cardValues[i]++;
                    }
                }
            }

            if (result + 1 == Math.Pow(2, 52))
            {
                Console.WriteLine("Full deck");
            }
            else
            {
                Console.WriteLine("Wa wa!");
            }

            var builder = new StringBuilder();
            for (int i = 0; i < 52; i++)
            {
                if ((cardValues[i] & 1) == 1)
                {
                    builder.Append(cards[i]);
                    builder.Append(' ');
                }
            }

            if (builder.Length > 0)
            {
                builder.Remove(builder.Length - 1, 1);
            }

            Console.WriteLine(builder.ToString());
        }
    }
}
