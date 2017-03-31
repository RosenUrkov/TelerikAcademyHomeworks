namespace GoingToAParty
{
    using System;

    public class GoingToAParty
    {
        public static void Main(string[] args)
        {
            string directions = Console.ReadLine();
            int currentDirection = 0;
            bool atTheParty = false;

            while (true)
            {
                if (currentDirection < 0 || currentDirection > directions.Length - 1)
                {
                    break;
                }
                else if (directions[currentDirection] >= 'a' && directions[currentDirection] <= 'z')
                {
                    currentDirection = directions[currentDirection] - 'a' + 1 + currentDirection;
                }
                else if (directions[currentDirection] >= 'A' && directions[currentDirection] <= 'Z')
                {
                    currentDirection = 'A' - directions[currentDirection] - 1 + currentDirection;
                }
                else if (directions[currentDirection] == '^')
                {
                    atTheParty = true;
                    break;
                }
            }

            if (atTheParty)
            {
                Console.WriteLine("Djor and Djano are at the party at {0}!", currentDirection);
            }
            else
            {
                Console.WriteLine("Djor and Djano are lost at {0}!", currentDirection);
            }
        }
    }
}
