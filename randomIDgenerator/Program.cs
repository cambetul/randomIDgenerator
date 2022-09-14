using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace randomIDgenerator
{
    internal class Program
    {
        static void bubbleSort(List<char> arr)
        {
            int n = arr.Count;
            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                    if (arr[j] > arr[j + 1])
                    {
                        // swap temp and arr[i]
                        char temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
        }
        static string generateRandomID(int digit, List<char> characters)
        {
            int numOfChar = characters.Count;
            int combinations = Convert.ToInt32(Math.Pow(numOfChar, digit)); // num of possible combinations

            bubbleSort(characters);

            Random random = new Random();
            int randomNumber = random.Next(0, combinations);

            Dictionary<int, char> dictionary = new Dictionary<int, char>();
            for (int i = 0; i < numOfChar; i++)
            {
                dictionary.Add(i, characters[i]);
            }

            string result = "";
            int temp = randomNumber;
            List<int> digits = new List<int>();
            int remainder;
            while (temp != 0)
            {
                remainder = temp % numOfChar;
                digits.Add(remainder);
                temp /= numOfChar;
            }
            for (int i = digits.Count - 1; i >= 0; i--)
            {
                result += dictionary[digits[i]];
            }
            return result;
        }
        static void Main(string[] args)
        {
            // sample input
            int digit = 4;
            var list = new List<char>
            {
               '0', '1', '2', '3', '4', '5', '6', 'A', 'B', 'C', 'D', 'E', 'F', 'a', 'b', 'c', 'd', 'e', 'f'
            };

            Console.WriteLine(generateRandomID(4, list));
            Console.ReadLine();
        }
    }
}