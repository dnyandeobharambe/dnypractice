using System;
using System.Text;

namespace StringPractice
{
    public class Program
    {
        static void Main(string[] args)
        {
            //bool isPall = CheckPallendrom("NITIN");
            //Console.Write(isPall);
            //Console.Read();

            //string compress aabcccbbdcc will be a2b1c3b2dc2
           // string compressString = Compress("aabcccbbdcc");

            string newLet = CasarCypherEncruptor("xyz", 28);
            Console.Write(newLet);
            Console.Read();
        }

        static Boolean CheckPallendrom(string str)
        {
            int left = 0;
            int right = str.Length - 1;
           
            while(left < right)
            {
                char[] firstChar = str.ToCharArray(left, 1);
                char[] lastChar = str.ToCharArray(right, 1);
                if (firstChar.ToString() != lastChar.ToString())
                {
                    return false;
                }
                left++;
                right--;
            }
            return true;
        }

        static string Compress(string str)
        {
            if(str.Length < 1)
            {
                return str;
            }
            StringBuilder sb = new StringBuilder(str.Length + 1);
            char first = str.ToCharArray(0, 1)[0];
            int count = 1;
            for(int i= 1;i<str.Length; i++)
            {
                if(first == str.ToCharArray(i,1)[0])
                {
                    count++;
                }
                else
                {
                    sb.Append(first);
                    sb.Append(count);
                    if (sb.Length > str.Length)
                    {
                        return str;
                    }
                    first = str.ToCharArray(i, 1)[0];
                    count = 1;
                }
              
               
            }
            sb.Append(first);
            sb.Append(count);
            return sb.ToString();
        }

        static string CasarCypherEncruptor(string str,int key)
        {
            //total letter are 26
            key = key % 26;
            char[] newLetter = new char[str.Length];
            for(int i =0;i<str.Length;i++)
            {
                newLetter[i] = GetNewCode(str.ToCharArray(i, 1)[0], key);
            }
            return new string(newLetter);
        }
        


        static char GetNewCode(char letter,int key)
        {
            //unicode for alphabets are from 97 to 122
            // 97 is for a and 122 is for z
            int newCode = letter + key;
            if(newCode <= 122)
            {
                return (char)newCode;
            }
            else
            {
                return (char)(96 + newCode % 122);
            }
        }
    }
}
