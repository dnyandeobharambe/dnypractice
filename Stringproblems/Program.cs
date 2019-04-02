using System;
using System.Collections.Generic;
using System.Text;

namespace Stringproblems
{
    public class Program
    {
        static void Main(string[] args)
        {
            //List<char> l = new List<char>();
            //l.Add('1');
            //l.Add('2');
            //l.Add('3');
            //StringBuilder result = new StringBuilder();

            //int[] arr = new int[] { 1,3,7,5,2,6,4 };
            ////Console.WriteLine("answer:" +  ":" + FindMissingNumber(arr));
            ////FindMaxProfit(arr);
            //TransformArray(arr);
            //for(int i = 0;i<arr.Length;i++)
            //{
            //    Console.WriteLine(arr[i]);
            //}

            //string s = "ABC";
            //char[] charArry = s.ToCharArray();
            ////permute(charArry, 0, 2);

            //PermuteString(charArry, 0, 2);


            //string s = "applepi";
            //List<string> solved = new List<string>();
            //List<string> dict = new List<string>();
            //dict.Add("pie");
            //dict.Add("pear");
            //dict.Add("apple");
            //dict.Add("peach");

            //Console.Write("Anser is " + Stringsegmentation(s, dict, solved));

            //int[] testArr = { 1,0,2,9,12,3,5,4,15,10,6,8 };
            //List<int[]> newList  = PythagoreanTriplate1(testArr);





            //for (int i= 0;i< newList.Count ;i++)
            //{
            //    Console.Write("start of  " + i);
            //    int[] resultArr = newList[i];
            //    for(int j = 0;j < resultArr.Length;j++)
            //    { 
            //    Console.Write(";" + resultArr[j]);
            //    }

            //    Console.Write("end of  " + i);
            //}

            //Console.Write(isPaliRec("NITIN") + ";");
            Console.Write(PowerRec(8, 8) + ";");

            Console.ReadLine();
        }

        //private static void PermuteString(string input)
        //{
        //    PermuteString(input.ToCharArray(), 0, input.Length - 1);
        //}


        private static string RemoveDuplicate(string str)
        {
            StringBuilder sb = new StringBuilder();
            if (str.Length == 0)
                return "empty";
            else
            {
                char[] charFromStr = str.ToCharArray();
                Dictionary<char, int> dc = new Dictionary<char, int>();
               
                int count = 1;
                foreach(char c in charFromStr)
                {
                    if(dc.ContainsKey(c))
                    {
                        count++;
                    }
                    else
                    {
                        dc.Add(c, 1);
                        sb.Append(c);
                    }
                }
            }

            return sb.ToString();
                
        }

        private static string RemoveDuplicateUsingHashSet(string str)
        {
            StringBuilder sb = new StringBuilder();
            if (str.Length == 0)
                return "empty";
            else
            {
                char[] charFromStr = str.ToCharArray();
                HashSet<char> hs = new HashSet<char>();

                foreach (char c in charFromStr)
                {
                    Boolean isAdd = hs.Add(c);
                    if (isAdd)
                        sb.Append(c);
                }

            }

            return sb.ToString();
        }

        private static string AddCharWithCount(string str)
        {
            StringBuilder sb = new StringBuilder();
            if (str.Length == 0)
                return "empty";
            else
            {
                char[] charFromStr = str.ToCharArray();

                int count = 1;
                char last = charFromStr[0];
                int i = 0;
                foreach (char c in charFromStr)
                {
                    
                  
                        if(charFromStr[i] == last)
                        {
                            
                            count++;
                        }
                        else
                        {
                            
                        sb.Append(last);
                        sb.Append(count);
                       
                        last = charFromStr[i];
                        count = 1;


                    }
                   

                    i++;
                }
            }

            return sb.ToString();
        }


        private static string RemoveSpace(string str)
        {
            char[] charArr = str.ToCharArray();
            int readIndex = 0;
            int writeIndex = 0;

            while(readIndex < charArr.Length && charArr[readIndex] != '\0')
            {
                if(!IsWhiteSpace(str[readIndex]))
                {
                    charArr[writeIndex] = charArr[readIndex];
                    ++writeIndex;
                }
                ++readIndex;
            }
            charArr[writeIndex] = '\0';

            return new string(charArr);


        }

        private static Boolean IsWhiteSpace(char c)
        {
            if(char.IsWhiteSpace(c) || c == '\t' )
            {
                return true;
            }
            else
            {
                return false;
            }



        }


        private static string FindKthCombination(List<char> lc,int k,StringBuilder sb)
        {
           

            if (lc.Count > 0)
            { 
               
            int count = CalculateFactorial(lc.Count - 1);
            int selected = (k - 1) / count;
            sb.Append(lc[selected]);
            lc.RemoveAt(selected);
            k = k - (selected * count);
            FindKthCombination(lc, k,sb);
            }
            return sb.ToString();


        }

        private static int CalculateFactorial(int n)
        {
            if (n== 0 || n== 1)
                return 1;
            return n * CalculateFactorial(n - 1);
        }


        private static int FindMissingNumber(int[] arr)
        {
            int sum = 0;
            for(int i =0;i<=arr.Length - 1;i++)
            {
                sum = sum + arr[i];
            }

            int len = arr.Length + 1;
            int actualSum = (len * (len + 1)) / 2;
            return actualSum - sum;
        }



        private static void FindMaxProfit(int[] arr)
        {
            int size = arr.Length;

            int buy = 0;
            int sell = 0;
            int currMin = 0;
            int currProf = 0;
            int maxProf = 0;
            int i = 0;
            for (i = 0; i < size; i++)
            {
                if (arr[i] < arr[currMin])
                {
                    currMin = i;
                }
                currProf = arr[i] - arr[currMin];

                if (currProf > maxProf)
                {
                    buy = currMin;
                    sell = i;
                    maxProf = currProf;
                }
            }

            Console.WriteLine("Buy day : " + buy);
            Console.WriteLine("Sell Date :" + sell);
            Console.WriteLine("Profit :" + maxProf);




        }

        private static void TransformArray(int[] arr)
        {
            int mid = arr.Length / 2;

            for(int i = 0;i < mid;i++)
            {
                for(int j = 0;j<i;j++)
                {
                    SwapArr(arr, mid - i + 2 * j, mid - i + 2 * j + 1);
                }
            }

        }

        private static void SwapArr(int[] arr,int first,int second)
        {
            int temp = arr[first];
            arr[first] = arr[second];
            arr[second] = arr[first];
        }


        private static void SwapChar(ref char first,ref char second)
        {
            char temp ;
            temp = first;
            first = second;
            second = temp;
        }

        private static void PermuteString(char[] inputArr,int startIndex,int endIndex)
        {
            int i;
            if(startIndex == endIndex)
            {
                Console.WriteLine(inputArr);
                //Console.ReadLine();
                //return;
            }
            else
            { 
                for (i = startIndex; i <= endIndex ; i++)
                {
                    SwapChar(ref inputArr[startIndex], ref inputArr[i]);
              

                    PermuteString(inputArr, startIndex + 1, endIndex);
                    SwapChar(ref inputArr[startIndex], ref inputArr[i]);
              


                }
            }
        }


        static void permute(char[] arry, int i, int n)
        {
            int j;
            if (i == n)
                Console.WriteLine(arry);
            else
            {
                for (j = i; j <= n; j++)
                {
                    swap(ref arry[i], ref arry[j]);
                    permute(arry, i + 1, n);
                    swap(ref arry[i], ref arry[j]); //backtrack
                }
            }
        }

        static void swap(ref char a, ref char b)
        {
            char tmp;
            tmp = a;
            a = b;
            b = tmp;
        }


        private static Boolean Stringsegmentation(string str,List<string> dict,List<string> solved)
        {
            for(int i = 0;i<=str.Length;i++)
            {
                string firstStr = str.Substring(0, i);
                if(dict.Contains(firstStr))
                {
                    string secondStr = str.Substring(i);
                    if (secondStr == null || secondStr.Length ==0 || dict.Contains(secondStr))
                    {
                        return true;
                    }
                    if(!solved.Contains(secondStr))
                    {
                        if (Stringsegmentation(secondStr, dict, solved))
                        {
                            return true;
                        }
                        solved.Add(secondStr);
                    }

                    
                }

               
            }
            return false;
        }


        private static Boolean PythagoreanTriplate(int[] arr)
        {
            int n = arr.Length;
            for(int i = 0;i< n;i++)
            
                arr[i] = arr[i] * arr[i];
            

            Array.Sort(arr);

            //do one by one
            for(int i = n-1;i>=2;i--)
            {
                int j = 0;
                int k = i - 1;
                while(j < k)
                {
                    if(arr[j] + arr[k] == arr[i])
                    { return true; }
                    else if(arr[j] + arr[k] < arr[i])
                    {
                        j++;
                    }
                    else
                    {
                        k--;
                    }
                }
            }

            return false;



        }

        private static List<int[]> PythagoreanTriplate1(int[] arr)
        {
            int n = arr.Length;
            int[] newArr = (int[])arr.Clone();
            List<int[]> result = new List<int[]>();

            for (int i = 0; i < n; i++)
            {

               int c2 = arr[i] * arr[i];


            Array.Sort(arr);

            
                int j = 0;
                int k = i - 1;
                while (j < k)
                {
                    //if(j==i)
                    //{
                    //    j++;
                    //}
                    //if(k==i)
                    //{
                    //    k--;
                    //}
                    int a2 = arr[j] * arr[j];
                    int b2 = arr[k] * arr[k];

                    if (a2 + b2 == c2)
                    { result.Add(new int[] { arr[i], arr[j], arr[k] });
                        break;

                    }
                    else if (a2 + b2 < c2)
                    {
                        j++;
                    }
                    else
                    {
                        k--;
                    }
                }
           

            
            }

            return result;

        }

        private static  Boolean isPaliRec(string str)
        {
            Boolean result = false;
           
            if(str.Length <= 1)
            {
                result = true;
            }
            else
            { 
            if(str[0] != str[str.Length -1])
            {
                result = false;
            }
            else
            { 
                string newStr = str.Substring(1,str.Length - 2);
                result = isPaliRec(newStr);
            }
            }



            return result;
            
        }

        private static int PowerRec(int n,int p)
        {
            if(p == 0)
            {
                return 1;
            }
            else
            {
                return n * PowerRec(n,p - 1);
            }
        }







    }
}
