/*
 * TaskViewer.cs
 * Author: Timothy Tucker
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskViewer
{
    /// <summary>
    /// A class with multiple methods
    /// designed to fulfill three tasks.
    /// </summary>
    class TaskViewer
    {
        /// <summary>
        /// The main method
        /// </summary>
        /// <param name="args">Arguments from command prompt.</param>
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

            /*int[] arr = { 5, 4, 3, 2, 1 };

            FindSecondLargeInArray(arr);*/

        }

        /// <summary>
        /// Checks if a given string is a palindrome.
        /// </summary>
        /// <param name="str">The string to check.</param>
        internal static void chkPalindrome(string str)
        {
            //A list of common special characters that act as delimiters.
            char[] separators = { ' ', ',', '\'', '?', ':', '.', '!', '"', '-', '—' };

            //Create two StringBuilders for each way a word order is said,
            //and a boolean for the word is identified as a palindrome.
            StringBuilder wordOrder = new StringBuilder();
            StringBuilder reverseWordOrder;
            bool palindrome = false;

            //Collect all words in the string, and add it to the forward read word order.
            List<string> words = str.ToLower().Split(separators).ToList();
            words.RemoveAll(empty => empty == "");
            words.ForEach(word => wordOrder.Append(word));

            //If there is more than one word,
            // check if it is a word palindrome.
            if (words.Count > 1)
            {
                reverseWordOrder = new StringBuilder();
                for (int index = words.Count - 1; index > -1; index--)
                {
                    reverseWordOrder.Append(words[index]);
                }

                if (reverseWordOrder.Equals(wordOrder))
                {
                    palindrome = true;
                    Console.WriteLine("Palindrome");
                }
            }
            if (!palindrome)
            {
                //Initialize or reinitialize StringBuilder for new reverse word order.
                reverseWordOrder = new StringBuilder();

                //Append to the reverse word order, character-by-character.
                for (int index = wordOrder.Length - 1; index > -1; index--)
                {
                    reverseWordOrder.Append(wordOrder[index]);
                }

                //If the word order backwards is the same forward, then it is a palindrome.
                if (wordOrder.Equals(reverseWordOrder))
                {
                    Console.WriteLine("Palindrome");
                }
                else
                {
                    Console.WriteLine("Not Palindrome");
                }
            }
        }

        /// <summary>
        /// Finds the second largest number in an array.
        /// </summary>
        /// <param name="arr">The array being checked.</param>
        internal static void FindSecondLargeInArray(int[] arr)
        {
            //Create two integers to hold the largest number,
            // and second largest number in the array.
            int largestNum = 0;
            int secondLargestNum = 0;

            //For each number in the array,
            // the second number should always be
            // greater than every preceding number,
            // and smaller than the largest number.
            for (int index = 0; index < arr.Length; index++)
            {
                if (arr[index] > largestNum)
                {
                    secondLargestNum = largestNum;
                    largestNum = arr[index];
                }
                else if (arr[index] <= largestNum && arr[index] > secondLargestNum)
                {
                    secondLargestNum = arr[index];
                }
            }

            // Print the second largest number.
            Console.WriteLine(secondLargestNum);
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
