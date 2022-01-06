using System;
using System.Collections;
using System.Collections.Generic;

namespace SweetNSalty
{
    class Program
    {
        static void Main(string[] args)
        {
            Counter(); // Method to count sweet, salty, sweetNsalty

        }
        public static void Counter()
        {
            ArrayList Alist = new ArrayList();
            int sCount = 0;
            int slCount = 0;
            int sNsCount = 0;

            for (int i = 1; i < 1000; i++)
            {

                if (i % 20 == 0)     //groups of twenty
                {
                    Console.WriteLine();
                }

                if (i % 5 == 0 && i % 3 == 0 && i > 1)
                {
                    Console.Write("Sweet n Salty, ");
                    sNsCount++;
                }
                else if (i % 3 == 0 && i > 1)
                {
                    Console.Write("Sweet, ");
                    sCount++;
                }
                else if (i % 5 == 0 && i > 1)
                {
                    Console.Write("Salty, ");
                    slCount++;
                }
                else
                {
                    Console.Write($"{ i}, ");
                }

                if (i == 999)
                {
                    Console.WriteLine($"\n\n\n\nSweet appears {sCount} times.");
                    Console.WriteLine($"Salty appears {slCount} times");
                    Console.WriteLine($"Sweet N Salty appears {sNsCount} times");
                }

            }

        }
    }
}
        




