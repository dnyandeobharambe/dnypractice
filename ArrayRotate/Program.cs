using System;
using System.Collections;
using System.Collections.Generic;

namespace ArrayRotate
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] firstArr = new int[] { 10, 23, 32, 40, 51, 58, 67, 75, 90, 105, 120 };
            int[] secondArr = new int[] { 25,30,32,67,89 };
            int[] thirdArr = new int[] { 7,16,46,78,67,32,39,90 };

            int[] indexArr = new int[] { 0, 3, 3, 5, 5, 5, 7, 7, 7, 7, 7, 7, 9, 13, 13, 13, 13 };
            //Console.WriteLine("low" + FindLowIndex(indexArr, 13));
            //Console.WriteLine("high" + FindHighIndex(indexArr, 13));
            //Console.ReadLine();

            //int[] zeroArr = new int[] { 1, 2, 0, 10, 20, 0, 88, 89, 0 };
            //Console.WriteLine("Before" + zeroArr);
            //MoveZeroToLeft(zeroArr);
            //for(int i = 0;i<= zeroArr.Length -1;i++)
            //{ 
            //Console.WriteLine(zeroArr[i] + ",");
            //}
            //Console.ReadLine();

            //int[] slideWindowArr = { 1, 2, 3, 6, 9, 0, -2, 10, 25, 8, -1 };

            //SlideWindow(slideWindowArr, 3);
            //Console.ReadLine();


            int[] a = {2, 5 ,- 4, 11, 0, 18 ,22, 67, 51, 6};
            int n = a.Length - 1;
            //Console.Write("Maximum contiguous sum is "+ LargestSumOfContinousNumbersInArray(a,n));
            //Console.ReadLine();

            //QuickSort(a,0, n);

            //foreach (var item in a)
            //{
            //    Console.Write(" " + item);
            //}

            List<Tuple<int, int>> v1 = new List<Tuple<int, int>>();
            Tuple<int, int> t1 = new Tuple<int, int>(2, 10);
            Tuple<int, int> t2 = new Tuple<int, int>(4, 12);
            Tuple<int, int> t3 = new Tuple<int, int>(13, 16);
            Tuple<int, int> t4 = new Tuple<int, int>(19, 20);
            Tuple<int, int> t5 = new Tuple<int, int>(20, 24);

            v1.Add(t1);
            v1.Add(t2);
            v1.Add(t3);
            v1.Add(t4);
            v1.Add(t5);

            List<Tuple<int, int>> v2 = MergeIntervals(v1);

            for (int i = 0; i < v2.Count; i++)
            {
                Console.WriteLine(string.Format("Range is {0} {1} " ,v2[i].Item1, v2[i].Item2));
            }

            Console.ReadLine();



            // for (int i = 0,int j = 0, int k = 0; i < firstArr.Length - 1, j < secondArr.Length - 1, k < thirdArr.Length - 1;
            //Console.WriteLine("Answer" + FindMinCommonNumber(firstArr, secondArr, thirdArr));
            //Console.ReadLine();

            //int[] numArr = new int[] { 10,23,32,40,51,58,67,75,90,105,120 };

            //Console.WriteLine("Answer" + SearchInRotatedArray(numArr,32,6));
            //Console.ReadLine();

            //Console.WriteLine("Answer" + SumOfTwoValuesInArray(numArr, 8));
            //Console.ReadLine();

            //Console.WriteLine("Answer" + BinarySearchInArray(numArr, 9));
            //Console.ReadLine();

            //for (int i = 0;i<= numArr.Length - 1;i++)
            //{ 
            ////Console.WriteLine("Result is :"  + RotateArray(numArr)[i]);
            ////Console.WriteLine("Result is :" + RotateArrayMultipleTimes(numArr,5)[i]);
            //}
            //Console.ReadLine();
        }

        private static int[] RotateArray(int[] arr)
        {


            //int[] newArr = new int[] {1,1,1,1,1};
            int[] newArr = (int[])arr.Clone();


            for (int i =0;i<= arr.Length -1; i++)
            {
                if (i == arr.Length - 1)
                {
                    newArr[0] = arr[i];
                }
                else
                {
                    
                    newArr[i + 1] = arr[i];
                }
            }

            return newArr;
        }

        private static int[] RotateArrayMultipleTimes(int[] arr,int t)
        {


            //int[] newArr = new int[] {1,1,1,1,1};
            Array.Sort(arr);
            int[] newArr = new int[arr.Length];

            int moveBy = t % arr.Length;

            for (int i = 0; i <= arr.Length -1; i++)
            {
                if(i + moveBy <= arr.Length - 1)
                {

                    newArr[i + moveBy] = arr[i];
                }
                else
                {
                    newArr[i + moveBy - arr.Length] = arr[i];
                }

            }

            return newArr;
        }


        private static Boolean SumOfTwoValuesInArray(int[] arr, int val)
        {
            Array.Sort(arr);
            for (int i = 0,j= arr.Length -1;i<j;)
            {
                int sum = arr[i] + arr[arr.Length - 1];
                if(sum == val)
                {
                    return true;
                }
                if(sum < val)
                {
                    ++i;
                }
                else
                {
                    --j;
                }
            }
            return false;

        }

        private static int BinarySearchInArray(int[] arr,int key)
        {
            Array.Sort(arr);
            int low = 0;
            int high = arr.Length -1 ;
            while(low <= high)
            {
                int mid = low + ((high - low) / 2);
                if(arr[mid] == key)
                {
                    return mid;
                }
                //search in first half 
               if(key < arr[mid])
                {
                    high = mid - 1;
                }
               else
                {
                    low = mid + 1;
                }
            }

            return -1;


        }

        private static int BinarySearchInArrayRec(int [] arr,int key,int startIndex,int endIndex)
        {
            //Array.Sort(arr);
            if(startIndex > endIndex)
            {
                return -1;
            }

            int mid = startIndex + ((endIndex - startIndex) / 2);

            if (arr[mid] == key)
            { return mid; }
            else if (key < arr[mid])
            {
                return BinarySearchInArrayRec(arr, key, startIndex, mid - 1);
            }
            else
            {
               return  BinarySearchInArrayRec(arr, key, mid + 1,arr.Length);
            }

           
        }

        private static int SearchInRotatedArray(int[] arr,int key,int time)
        {
            int[] newArr = new int[arr.Length];
            for(int i = 0; i<= arr.Length -1;i++)
            {
                 newArr[i] = RotateArrayMultipleTimes(arr, time)[i];
            }

            int startIndex = 0;
            int endIndex = arr.Length - 1;
            int mid = startIndex + ((endIndex - startIndex) / 2);
            if(key < newArr[mid] && key >= newArr[startIndex] && newArr[startIndex] < newArr[mid])
            {
                return BinarySearchInArrayRec(newArr, key, startIndex, mid -1);
            }
            else if(key > newArr[mid] && key <= newArr[endIndex] && newArr[mid] < newArr[endIndex])
            {
                return BinarySearchInArrayRec(newArr, key, mid + 1, endIndex);
            }
            else if(newArr[startIndex] > newArr[mid])
            {
                return BinarySearchInArrayRec(newArr, key, startIndex, mid - 1);
            }
            else if(newArr[mid] > newArr[endIndex])
            {
                return BinarySearchInArrayRec(newArr, key, mid + 1, endIndex);
            }
            return -1;


        }

        private static int FindMinCommonNumber(int[] arr1, int[] arr2, int[] arr3)
        {
            int i = 0;
            int j = 0;
            int k = 0;
            Array.Sort(arr1);
            Array.Sort(arr2);
            Array.Sort(arr3);
            while (i <= arr1.Length -1 && j <= arr2.Length -1  && k <= arr3.Length -1)
            {
                if (arr1[i] == arr2[j] && arr1[i] == arr3[k])
                {
                    return arr1[1];
                }

                if (arr1[i] <= arr2[j] && arr1[i] <= arr3[k])
                {
                    i++;
                }
                else if (arr2[j] <= arr1[i] && arr2[j] <= arr3[k])
                {
                    j++;
                }
                else if (arr3[k] <= arr1[i] && arr3[k] <= arr2[j])
                {
                    k++;
                }
            }

            return -1;
        }

        

        private static int FindLowIndex(int[] arr,int key)
        {
            int low = 0;
            int high = arr.Length - 1;
            int mid = high / 2;

            while(low <= high)
            {
                if(arr[mid] < key)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
                mid = low + ((high - low) / 2);

            }

            if(arr[low] == key)
            {
                return low;
            }

            return -1;

        }

        private static int FindHighIndex(int[] arr, int key)
        {
            int low = 0;
            int high = arr.Length - 1;
            int mid = high / 2;

            while (low <= high)
            {
                if (arr[mid] <= key)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
                mid = low + ((high - low) / 2);

            }

            if (arr[high] == key)
            {
                return high;
            }

            return -1;

        }

        private static void MoveZeroToLeft(int[] arr)
        {
            int read = arr.Length - 1;
            int write = arr.Length - 1;

            while (read >= 0)
            {
                if(arr[read] != 0)
                {
                    arr[write] = arr[read];
                    write--;
                }
                read--;

            }

            while(write >= 0)
            {
                arr[write] = 0;
                write--;
            }

        }

        private static void SlideWindow(int[] arr,int window)
        {
            int len = arr.Length;
            int max;

            for(int i = 0; i< len - window;i++)
            {
                max = arr[i];

                for(int j = 1;j <window;j++)
                {
                    if(arr[i+j] > max)
                    {
                        max = arr[i + j];
                    }
                 
                }

                Console.WriteLine(max + ",");
            }
        }

        private static int LargestSumOfContinousNumbersInArray(int[] arr,int window)
        {
            int max_Sofar = arr[0];
            int max_current = arr[0];

            for(int i = 1;i< window; i++)
            {
                max_current = Math.Max(arr[i], max_current + arr[i]);
                max_Sofar = Math.Max(max_Sofar, max_current);
            }
            return max_Sofar;
        }


        //private static int MaxSumInArray(int[] arr)
        //{
        //    //find positive number first 
        //    int max_sofar = 0;
        //    int max_end = 0;

        //    for(int i = 0; i<arr.Length; i++)
        //    {
        //        max_end = max_end + arr[i];

        //        if(max_sofar < max_end)
        //        {
        //            max_sofar = max_end;
        //        }

        //        if(max_end <0)
        //        {
        //            max_end = 0;
        //        }
        //    }
        //    return max_sofar;
        //}


        //public static void quickSort(int[] A, int left, int right)
        //{
        //    if (left > right || left < 0 || right < 0) return;

        //    int index = partition(A, left, right);

        //    if (index != -1)
        //    {
        //        quickSort(A, left, index - 1);
        //        quickSort(A, index + 1, right);

              
        //    }

           
               
           


        //}

        //private static int partition(int[] A, int left, int right)
        //{
        //    if (left > right) return -1;

        //    int end = left;

        //    int pivot = A[right];    // choose last one to pivot, easy to code
        //    for (int i = left; i < right; i++)
        //    {
        //        if (A[i] < pivot)
        //        {
        //            swap(A, i, end);
        //            end++;
        //        }
        //    }

        //    swap(A, end, right);

        //    return end;
        //}

        //private static void swap(int[] A, int left, int right)
        //{
        //    int tmp = A[left];
        //    A[left] = A[right];
        //    A[right] = tmp;
        //}


      private static void QuickSort(int[] arr,int left,int right)
        {
            if (left < right)
            {
                int index = Partition(arr, left, right);
                if(index != -1)
                {
                    QuickSort(arr, left, index - 1);
                    QuickSort(arr, index + 1,right);

                }
            }
        }
       
     


        private static int Partition(int[] arr,int left,int right)
        {


            int pivot = arr[left];

            while(true)
            {
                if(arr[left] < pivot)
                {
                    left++;
                }
                if(arr[right] > pivot)
                {
                    right--;
                }
                if(left < right)
                {
                    if (arr[left] == arr[right]) return right;

                    int temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;


                }
                else
                {
                    return right;
                }


            }

        }

        private static void Swap(ref int first,ref int second)
        {
            
            int temp = first;
            first = second;
            second = first;
        }

        public static List<Tuple<int,int>> MergeIntervals(List<Tuple<int, int>> firstList)
        {
            List<Tuple<int, int>> secondList = new List<Tuple<int, int>>();

            secondList.Add(new Tuple<int,int>(firstList[0].Item1, firstList[0].Item2));

            for(int i = 0; i<= firstList.Count - 1;i++)
            {
                int x1 = firstList[i].Item1;
                int y1 = firstList[i].Item2;
                int x2 = secondList[secondList.Count - 1].Item1;
                int y2 = secondList[secondList.Count - 1].Item2;

                if(y2 >= x1)
                {
                    //secondList[secondList.Count - 1].Item2 = Math.Max(y1, y2);
                    Tuple.Create(x1, Math.Max(y1, y2));
                }
                else
                {
                    secondList.Add(new Tuple<int, int>(x1, y1));
                }
            }



            return secondList;
        }

    }

   
}
