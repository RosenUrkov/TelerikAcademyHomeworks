namespace SecretMessage
{
    using System;

    public class SecretMessage
    {
        public static void Main(string[] args)
        {
            int frasesCounter = 1;
            string decodedMessage = string.Empty;

            while (true)
            {
                int startOfDecoding = 0;

                try
                {
                    startOfDecoding = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    break;
                }

                int endOfDecoding = int.Parse(Console.ReadLine());
                string decodingFrase = Console.ReadLine();

                if (startOfDecoding < 0)
                {
                    startOfDecoding = decodingFrase.Length + startOfDecoding;
                }

                if (endOfDecoding < 0)
                {
                    endOfDecoding = decodingFrase.Length + endOfDecoding;
                }

                int step;
                if ((frasesCounter % 2) == 1)
                {
                    step = 3;   
                }
                else
                {
                    step = 4;
                }

                for (int i = startOfDecoding; i <= endOfDecoding; i += step)
                {
                    decodedMessage += decodingFrase[i];
                }

                frasesCounter++;
            }

            Console.WriteLine(decodedMessage);
        }
    }
}