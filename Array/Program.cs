using System;
using System.Collections;
using System.Collections.Generic;

namespace Codepractice
{
    public class Program
    {
        static void Main(string[] args)
        {
            //int[] inputArr = { 5, 3, -1, 6, 2, -4, 12, 9 };
            //int[] result = SumOfTwoNumbers(inputArr, 11);

            //int[] inputArr = { 12, 3, 1, 2, -6, 5, -8, 6 };
            //ArrayList result = SumOfThreeNumbers(inputArr, 0);

            //int[] arr1 = { -1, 5, 10, 28, 3 };
            //int[] arr2 = { 26, 134, 135, 15, 17 };
            //int[] result = SmallestDifference(arr1, arr2);
            int[] arr = { 10, 20, 30, 40, 50 };
            int[] result = RotateArray(arr);
            int fibNum = GetnthFib(20);
            Console.WriteLine(fibNum);
            int[] arr1 = { 10, 30, 35, 40, 50, 55, 60, 75, 80, 85, 90 };
            int pos = GetPositionByBinarySearch(arr1, 60);
            Console.WriteLine(pos);
            List<int> arr2 = new List<int> { 1, 2, 3 };
            List<List<int>> permutation = GetPermutation(arr2);
            foreach (List<int> lst in permutation)
            {
                foreach(int n in lst)
                { 
                //Console.WriteLine(n);
                //Console.WriteLine();
                }
            }

            int[] arr3 = { 10, 6, 9, -3, 23, -1, 34, 56, 67, -1, -4, -8, -2, 9, 10, 34, 67 };
            int x = GetMaxNumberinArrayBySlidingWindow(arr3, 3);
            Console.WriteLine("Max Number is :" + x);
            int[] arr4 = { 1, 4, 2, 10, 2, 3, 1, 0, 20 };
            int y = GetMaxInSlideWindowSum(arr4, 4);
            Console.WriteLine("Max Number  alternate way is :" + y);

            int[] dem = { 1, 2, 5, 10 };
            int numofWays = NumberOfWays(10, dem);
            Console.WriteLine("Number of ways : " + numofWays);
            CheckAnagram("ABC", "BCA");
            Console.Read();
        }

        static int[] SumOfTwoNumbers(int[] arr,int sum)
        {
            Array.Sort(arr);
            int left = 0;
            int right = arr.Length - 1;

            while(left < right)
            {
                int checkSum = arr[left] + arr[right];
                if(checkSum == sum)
                {
                    return new int[] { arr[left], arr[right] };
                }
                else if(checkSum > sum)
                {
                    right--;
                }
                else
                {
                    left++;
                }

            }
            return new int[0];
        }

        static ArrayList SumOfThreeNumbers(int[] arr,int sum)
        {
            
            Array.Sort(arr);
            ArrayList arrLst = new ArrayList();
            for(int i=0;i<= arr.Length - 1;i++)
            {
                int left = i + 1;
                int right = arr.Length - 1;
                while(left < right)
                {
                    int checkSum = arr[i] + arr[left] + arr[right];
                    if(checkSum == sum)
                    {
                         int[] ans =  { arr[i], arr[left], arr[right] };
                        arrLst.Add(ans);
                        left++;
                        right--;
                       
                    }
                    else if(checkSum > sum)
                    {
                        right--;
                    }
                    else
                    {
                        left++;
                    }
                }
                
            }
            return arrLst;
        }

        static int[] SmallestDifference(int[] arr1,int[] arr2)
        {
           
            Array.Sort(arr1);
            Array.Sort(arr2);
            int first = 0;
            int second = 0;
            int current = int.MaxValue;
            int small = int.MaxValue;
            int[] result = new int[2];
            while(first < arr1.Length && second < arr1.Length)
            {
                int num1 = arr1[first];
                int num2 = arr2[second];
                if(num1 < num2)
                {
                    current = num2 - num1;
                    first++;
                }
                else if(num1 > num2)
                {
                    current = num1 - num2;
                    second++;
                }
                else
                {
                    return new int[] { num1, num2 };
                }
                if(small >current)
                {
                    small = current;
                    result = new int[] { num1, num2 };
                }
            }

            return result;
        }

        static int[] RotateArray(int[] arr)
        {
            int[] temp = new int[arr.Length];
            for(int i =0 ;i <arr.Length;i++)
            {
                if(i == arr.Length -1)
                {
                    temp[0] = arr[i];
                }
                else
                {

                    temp[i + 1] = arr[i];

                }
            }
            return temp;
        }

        static int GetnthFib(int n)
        {
            int[] lastNums = { 0, 1 };
            int count = 3;
            while(count <= n)
            {
                int nextNum = lastNums[0] + lastNums[1];
                lastNums[0] = lastNums[1];
                lastNums[1] = nextNum;
                count++;
            }

            if (n > 1)
                return lastNums[1];
            else
                return lastNums[0];
        }

        public static int GetPositionByBinarySearch(int[] arr,int target)
        {
            Array.Sort(arr);
            int left = 0;
            int right = arr.Length - 1;
            while(left <= right)
            { 
            int mid = (left + right) / 2;
            int possibleMatch = arr[mid];
                if(possibleMatch == target )
                {
                    return mid;
                }
                else if(target < possibleMatch )
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }


            }

            return -1;

        }

        public static List<List<int>> GetPermutation(List<int> arr)
        {
            List<List<int>> resultList = new List<List<int>>();
            CalculatePermutation(0, arr, resultList);
            return resultList;
            
        }

        private static void CalculatePermutation(int i,List<int> orgArr,List<List<int>> result)
        {
            if(i == orgArr.Count - 1)
            {
                result.Add(new List<int>(orgArr));

            }
            else
            {
                for(int j = i;j < orgArr.Count;j++)
                {
                    Swap(orgArr, i, j);
                    CalculatePermutation(i + 1, orgArr, result);
                    Swap(orgArr, i, j);
                }
            }
        }

        private static void Swap(List<int> arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        public static List<List<int>> PowerSet(List<int> orgList)
        {
            List<List<int>> subsets = new List<List<int>>();
            subsets.Add(new List<int>());
            foreach(int elem in orgList)
            {
                int len = subsets.Count;
                for(int i=0;i < len;i++)
                {
                    List<int> currentSubset = new List<int>(subsets[i]);
                    currentSubset.Add(elem);
                    subsets.Add(currentSubset);

                }
            }
            return subsets;
        }


        private static int GetInnerElemt(List<List<int>> newList,int indx)
        {
            foreach(List<int> elm in newList)
            {
                for(int i = 0;i < elm.Count;i++)
                {
                    if (elm[i] == indx)
                        return elm[i];
                }
            }
            return -1;

        }

        private static List<List<int>> GetInnerList(List<List<int>> newList,int indx)
        {
            List<List<int>> result = new List<List<int>>();

            for(int i = 0; i < newList.Count;i++)
            {
                if(i == indx)
                {
                    result.Add(newList[i]);
                    return result;
                }
            }
             result.Add(new List<int>(-1));
            return result;
                
        }

        public static int NumberOfWays(int n, int[] arr)
        {
            int[] ways = new int[n + 1];
            ways[0] = 1;
            foreach(int elem in arr)
            {
                for(int amt = 1;amt < n+1;amt++)
                {
                    if(elem <= amt)
                    {
                        ways[amt] +=  ways[amt - elem];
                    }
                }
            }
            return ways[n];

        }
            


        //Sliding window
        //Add index of each big number in deque at last
        //remove last from deque if current bigger
        //remove first from queue when it old that is first elemet in deque <= n- k
        //deque is sorted from bigger to smaller




        internal static int GetMaxNumberinArrayBySlidingWindow(int[] arr,int window)
        {
            List<int> result = new List<int>();

            if(arr.Length < window)
            {
                Console.WriteLine("Array is very short");
            }

            List<int> deque = new List<int>();
            int startIndex = 0;
            for(int i = startIndex; i< window;++i)
            {
                while(deque.Count >0 && arr[i] >= arr[deque[deque.Count -1]])
                {
                    deque.Remove(deque[deque.Count - 1]);
                }
                deque.Add(i);
                startIndex++;
            }

            for(int j = startIndex; j< arr.Length;++j)
            {
                result.Add(arr[deque[0]]);
                while(deque.Count > 0 && deque[0] <= j - window)
                {
                    deque.RemoveAt(0);


                }
                while (deque.Count > 0 && arr[j] >= arr[deque[deque.Count - 1]])
                {
                    deque.RemoveAt(deque.Count - 1);
                }
                deque.Add(j);
            }

            var a = result;
            return arr[deque[deque.Count - 1]];
             
        }


        internal static int GetMaxInSlideWindowSum(int[] arr,int window)
        {
            if (arr.Length < window)
                Console.WriteLine("Invalid");

            int sum = 0;
           
            for(int i = 0; i<window;i++)
            {
                sum = sum + arr[i];
            }
            int windowSum = sum;
            for (int j=window;j<arr.Length;j++)
            {
                windowSum = windowSum + arr[j] - arr[j - window];
                sum = Math.Max(sum, windowSum);
            }

            return sum;
        }


        public static Boolean CheckAnagram(string s1,string s2)
        {
            if(s1.Length != s2.Length )
            {
                return false;
            }
            int[] letters = new int[256];

            foreach(char c1 in s1)
            {
                letters[c1]++;
            }
            foreach(char c2 in s2)
            {
                letters[c2]--;
            }

            foreach(int i in letters)
            {
                if (i != 0)
                    return false;
            }

            return true;
        }
        
            





    }
}
