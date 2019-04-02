using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ReadFileAndCountWords
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string,int> resultDict =  GetFrequentWordCount("C:\\try\\wordcount.txt");

            foreach(var dict in resultDict)
            { 
            
            Console.WriteLine( dict.Key +" --- " +  dict.Value);
            }

            Console.ReadLine();
        }


        private static SortedDictionary<string,int> GetFrequentWordCount(string filePath)
        {
            var fileLines = File.ReadAllLines(filePath);
            int i = 1;
            SortedDictionary<string, int> result = new SortedDictionary<string, int>();

            foreach(var line in fileLines)
            {
                string[] words = line.Split(' ');
                foreach(string word in words)
                {
                    if(!result.ContainsKey(word))
                    {
                        result.Add(word, 1);
                    }
                    else
                    {
                        result[word]++;
                    }
                }
            }

            return result;

            //return result.OrderByDescending(v => v.Value).ToDictionary(x=>x.Key,y=>y.Value);



        }
    }
}
