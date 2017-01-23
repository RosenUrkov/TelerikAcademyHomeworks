using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BunnyFactory
{
    class Program
    {


        static void Main(string[] args)
        {
            List<int> cages = new List<int>();

            try
            {
                while (true)
                {
                    cages.Add(int.Parse(Console.ReadLine()));
                }
            }
            catch (FormatException)
            {

            }

            var list = InitialCagesCycle(cages);
            Console.WriteLine(string.Join(" ", list));


        }

        //static bool CagesValidate(int cageNumber, List<int> listOfCages,int counter)
        //{
        //    if (cageNumber < (listOfCages.Count - counter))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }

        //}

        static List<int> InitialCagesCycle(List<int> cages)
        {
            var nextCages = new List<int>();
            nextCages = FillNextCages(cages);
            int counter = 1;


            for (int i = 0; i < nextCages.Count; i++)
            {
                if (nextCages.Count < counter)
                {
                    return nextCages;
                }

                int bunnies = CalculateCages(counter, nextCages);
                if (nextCages.Count - counter > bunnies)
                {
                    string nextOnes = GetNextCages(bunnies, counter, nextCages);
                    nextOnes = DigitClear(nextOnes);
                    nextCages.Clear();
                    nextCages = FillNextCages(nextOnes);
                }

                else
                {
                    return nextCages;
                }

                counter++;

            }

            return nextCages;
        }


        static string GetNextCages(int cageNumber, int counter, List<int> listOFCages)
        {
            var result = new StringBuilder();
            BigInteger sumOfCages = 0;
            BigInteger productOfCages = 1;

            for (int j = counter; j < cageNumber + counter; j++)
            {
                sumOfCages += listOFCages[j];
                productOfCages *= listOFCages[j];
            }

            result.Append(sumOfCages);
            result.Append(productOfCages);
            var list = new List<int>();
            list = FillNextCages(listOFCages, cageNumber + counter);
            result.Append(string.Join("", list));
            return result.ToString();
        }

        static int CalculateCages(int cagesCoeff, List<int> listOfCages)
        {
            int bunniesInCages = 0;
            for (int i = 0; i < cagesCoeff; i++)
            {
                bunniesInCages += listOfCages[i];
            }

            return bunniesInCages;
        }

        static string DigitClear(string newCages)
        {
            string result = newCages.Replace(0.ToString(), string.Empty).Replace(1.ToString(), string.Empty);
            return result;

        }

        static List<int> FillNextCages(List<int> listCages, int index = 0)
        {
            var result = new List<int>();
            for (int i = index; i < listCages.Count; i++)
            {
                result.Add(listCages[i]);
            }
            return result;
        }

        static List<int> FillNextCages(string cages)
        {
            var listOfCages = new List<int>();
            for (int i = 0; i < cages.Length; i++)
            {
                listOfCages.Add(cages[i] - '0');
            }

            return listOfCages;

        }

    }
}
