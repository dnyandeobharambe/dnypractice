using System;
using System.Collections.Generic;

namespace Anagram
{

    //Create directory (characters as key and number of times character come as value) by characters of first string
    //Create directory of characters of second string
    //Compare two directories if key or value not mtaching means not anagram
    class Program
    {
        static void Main(string[] args)
        {
            //Boolean ans = isAnagram("dnyandeo", "nyandeob");
            //Console.Write("Answer is" + ans.ToString());

            MathOp mathop = new MathOp();
            //int ans = mathop.Add(-12,-13);
            //int ans = mathop.Substract(50, 25);
            //int ans = mathop.Multiply(50, 25);
            int ans = mathop.Division(13, 2);
            Console.WriteLine("Answer is :" + ans);
            Console.ReadLine();


        }

        private static Boolean  isAnagram(string first,string second)
        {
            if(first == second)
            {
                return true;
            }
            else
            {
                if(first.Length != second.Length )
                {
                    return false;
                }
                else
                { 

                    Dictionary<char,int> firstDictionary = new Dictionary<char, int>();
                    Dictionary<char, int> secondDictionary = new Dictionary<char, int>();

                    foreach (char c in first.ToCharArray())
                    {
                        int i = 1;
                         if(firstDictionary.ContainsKey(c))
                        {
                            firstDictionary[c]++;
                        }
                         else
                        { 
                        firstDictionary.Add(c, i);
                        }
                        //i++;
                    }

                    foreach (char c in second.ToCharArray())
                    {
                        int i = 1;
                        if (secondDictionary.ContainsKey(c))
                        {
                            secondDictionary[c]++;
                        }
                        else
                        {
                            secondDictionary.Add(c, i);
                        }
                        //i++;
                    }

                    foreach(var k in firstDictionary)
                    {
                        if(!secondDictionary.ContainsKey(k.Key))
                        {
                            return false;
                        }
                        if(firstDictionary[k.Key] != secondDictionary[k.Key])
                        {
                            return false;
                        }
                    }

                    return true;



                }


            }


        }
    }
}
