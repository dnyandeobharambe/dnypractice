using System;
using System.Collections;
using System.Collections.Generic;

namespace PossibleStrCombinations
{
    class Program
    {
        // starting index and length as parameters 
        //starting index and length is same means print values
        // each charcter is swap with all others 
        static void Main(string[] args)
        {
            string s = "ABC";
            char[] charArr = s.ToCharArray();
            Permute(charArr, 0, s.Length - 1);
            Console.ReadKey();
            
        }

        private static void Permute(char[] arr,int i,int n)
        {
            int j;
            if(i == n)
            {
                Console.WriteLine(arr);
            }
            else
            {
                for(j= i;j<=n;j++)
                {
                    Swap(ref arr[i], ref arr[j]);
                    Permute(arr, i + 1, n);
                    Swap(ref arr[i], ref arr[j]);
                }

            }
        }

        private static void Swap(ref char a,ref char b)
        {
            char tmp;
            tmp = a;
            a = b;
            b = tmp;
        }
           



    }
}
