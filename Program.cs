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



    }
}
