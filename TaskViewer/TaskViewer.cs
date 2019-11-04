/*
 * TaskViewer.cs
 * Author: Timothy Tucker
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

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
            string taskNumber;
            do
            {
                //Prompt the user for a task to perform.
                Console.WriteLine("\nTask 1: Palindrome Checker");
                Console.WriteLine("Task 2: Find Second Largest Number");
                Console.WriteLine("Task 3: Prime Number Checker\n");
                Console.Write("Select a Task (Enter 0 to exit): ");
                taskNumber = Console.ReadLine();
                Console.WriteLine();

                //Check that the task number is valid.
                while (taskNumber != "0" &&
                       taskNumber != "1" && 
                       taskNumber != "2" && 
                       taskNumber != "3")
                {
                    Console.WriteLine("\n\nInvalid Option\n\n");
                    Console.WriteLine("Task 1: Palindrome Checker");
                    Console.WriteLine("Task 2: Find Second Largest Number");
                    Console.WriteLine("Task 3: Prime Number Checker\n");
                    Console.Write("Select a Task (Enter 0 to exit): ");
                    taskNumber = Console.ReadLine();
                    Console.WriteLine();
                }

                switch (taskNumber)
                {
                    //Use the Palindrome Checking method.
                    case "1":

                        string str;

                        //Check user-entered words until the string is blank.
                        do
                        {
                            Console.Write("Enter a word or phrase (Leave blank to return to selection): ");
                            str = Console.ReadLine();
                            if (!str.Equals(""))
                            {
                                chkPalindrome(str);
                            }
                        } while (str != "");
                        break;

                    //Use the Find Second Largest Number method.
                    case "2":
                        string option = "";

                        //Loop possible options until the user selects 0.
                        do
                        {
                            //Prompt for option choice, similar to above.
                            Console.WriteLine("\nOption 1: Randomly Generated List of 10. Numbers are from 1 to 1000.");
                            Console.WriteLine("Option 2: Make a list of numbers manually.");
                            Console.Write("\nSelect an Option (Enter 0 to exit): ");
                            option = Console.ReadLine();
                            Console.WriteLine();

                            while (option != "0" &&
                                   option != "1" &&
                                   option != "2")
                            {
                                Console.WriteLine("\nInvalid Option\n\n");
                                Console.WriteLine("\nOption 1: Randomly Generated List of 10. Numbers are from 1 to 1000.");
                                Console.WriteLine("Option 2: Make a list of numbers manually.");
                                Console.Write("\nSelect an Option (Enter 0 to exit): ");
                                option = Console.ReadLine();
                                Console.WriteLine();
                            }

                            switch (option)
                            {
                                //Find the second largest number in an array of numbers.
                                case "1":
                                    Random random = new Random();
                                    int[] randNumbers = new int[10];

                                    Console.Write("Numbers in list: ");

                                    //Populate list with random numbers.
                                    for (int index = 0; index < 10; index++)
                                    {
                                        randNumbers[index] = random.Next(1, 1000);
                                        Console.Write(randNumbers[index] + ", ");
                                    }

                                    Console.Write("\nSecond largest in array is: ");
                                    FindSecondLargeInArray(randNumbers);
                                    break;

                                case "2":
                                    string number = "";
                                    List<int> numbers = new List<int>();
                                    Regex reg = new Regex("[^0-9]");

                                    //Prompt the user for numbers until they enter 'd'
                                    // to signal they are finished.
                                    while (number != "d")
                                    {
                                        Console.Write("Enter value (enter 'd' to finish): ");
                                        number = Console.ReadLine();

                                        //If the user enters a non-integer
                                        // then it should not be added to the list.
                                        if (reg.IsMatch(number))
                                        {

                                        }
                                        else
                                        {
                                            numbers.Add(Convert.ToInt32(number));
                                        }
                                    }

                                    //The second largest in an array
                                    // should be shown only when the
                                    // array has more than 1 number.
                                    if (numbers.Count >= 2)
                                    {
                                        Console.Write("\nSecond largest in array is: ");
                                        FindSecondLargeInArray(numbers.ToArray());
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nThere are not enough numbers to determine the second largest number.");
                                    }

                                    break;

                            }
                        } while (option != "0");
                        
                        break;
                }
            } while (taskNumber != "0");
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
                    Console.WriteLine("Palindrome\n");
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
                    Console.WriteLine("Palindrome\n");
                }
                else
                {
                    Console.WriteLine("Not Palindrome\n");
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
