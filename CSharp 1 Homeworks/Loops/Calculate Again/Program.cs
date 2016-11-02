using System;


namespace Calculate_Again
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong N = ulong.Parse(Console.ReadLine());
            ulong K = ulong.Parse(Console.ReadLine());
            System.Numerics.BigInteger sum=1;

            do
            {
                sum *= N;
                N--;

            } while (!(N == K));
            Console.WriteLine(sum);

        }
    }
}
