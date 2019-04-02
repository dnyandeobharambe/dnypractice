using System;
using System.Collections.Generic;

namespace CharFrequency
{
    class Program
    {
        static void Main(string[] args)
        {

            //Break dtring to character
            //Add characters in dictionary
            //dictionary does not allow duplicate, so when key exist increase count
            // Value of dictionary indicates frequency
            // initialize max value as count when count is bigger than max, replace max with new value
            //final max value will be highest frequency 
            Char maxFreqAns = GetMaxFrequency("abacdabaefacabbbbccccccccccccccccccccccccccc");
            Console.WriteLine("Max Freq Char is " + maxFreqAns);
            Console.ReadLine();

            //try remove duplicate and pallindrom permutation 
        }

        public static char GetMaxFrequency(string s)
        {
            Dictionary<char, int> stringDictionary = new Dictionary<char, int>();
            int max = 1;
            char ans  = '|';

            foreach (char c in s.ToCharArray())
            {
              
                if (stringDictionary.ContainsKey(c))
                {
             
                    stringDictionary[c]++;
                    if(stringDictionary[c]++ > max)
                    {
                        max = stringDictionary[c]++;
                        ans = c;
                    }
                }
                else
                {
                    stringDictionary.Add(c, 1);
                }
                //i++;
            }

            return ans;

        }
    }
}
