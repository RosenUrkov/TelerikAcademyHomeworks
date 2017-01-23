﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximal_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int[] numbers = new int[number];
            int currentSequence = 0;
            int maxSequence = 0;
            int sequenceChar = 0;
            bool isFirst = true;
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
                if (isFirst)
                {
                    isFirst = false;
                    sequenceChar = numbers[i];
                    currentSequence++;
                    maxSequence = currentSequence;
                }
                else if (sequenceChar == numbers[i])
                {
                    currentSequence++;
                }
                else if (sequenceChar != numbers[i])
                {
                    if (currentSequence > maxSequence)
                    {
                        maxSequence = currentSequence;
                    }
                   
                    sequenceChar = numbers[i];
                    currentSequence = 1;

                }
                if(i+1 == numbers.Length)
                {
                    if (currentSequence > maxSequence)
                    {
                        maxSequence = currentSequence;
                    }
                }


            }
            Console.WriteLine(maxSequence);
        }
    }
}
