﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskViewer
{
    class TaskViewer
    {
        static void Main(string[] args)
        {
            /*Console.Write("Enter a number (Type 0 to exit): ");
            string number = Console.ReadLine();
            while (number != "0")
            {
                if (FindPrime(Convert.ToInt32(number)))
                {
                    Console.WriteLine("Prime");
                }
                else
                {
                    Console.WriteLine("Not Prime");
                }
                Console.Write("Enter a number (Type 0 to exit): ");
                number = Console.ReadLine();
            }*/

        }

        internal static void chkPalindrome(string str)
        {

        }

        internal static void FindSecondLargeInArray(int[] arr)
        {

        }

        /// <summary>
        /// Determines if a number is prime.
        /// </summary>
        /// <param name="number">Supplied number to check.</param>
        /// <returns>A truth statement.</returns>
        internal static bool FindPrime(int number)
        {
            //If the number is 1, then there is no need to check.
            // Otherwise if the number is 2, return true.
            // Otherwise search through a list of numbers for a number
            // that makes the given number 0.
            if (number == 1)
            {
                return false;
            }
            else if (number == 2)
            {
                return true;
            }
            else
            {
                //Start list from 2 to account for all even numbers.
                List<int> numbers = Enumerable.Range(2, number).ToList();

                //While determining if the number is prime
                // reduce the each future process by removing
                // composite numbers.
                for (int i = 0; i < numbers.Count; i++)
                {
                    numbers.RemoveAll(x => x % numbers[i] == 0 && x != numbers[i]);
                    
                    if (!numbers.Contains(number))
                    {
                        return false;
                    }
                }
                
                return true;
            }
        }
    }
}
