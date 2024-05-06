using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;
using System.Reflection;

namespace AlgoLibrary
{
    public static class AlgoExtentions
    {
        public static void LinearSearch(this IEnumerable<int> source, int value)
        {
            var copy = source.ToArray();
            int tries = 1;
            for(int i = 0; i < copy.Length; ++i)
            {
                ++tries;
                if (copy[i] == value)
                {
                    Console.WriteLine(@$"it has been founded..! after : {{{tries}}} Tries.");
                    return;
                }
            }

            Console.WriteLine("it has not been founded..!");
        }

        public static void BinarySearch(this IEnumerable<int> source ,int value)
        {
            var copy = source.ToArray();

            int tries = 1;
            BinarySearchHandler(copy,value,0,copy.Length-1);

            void BinarySearchHandler(int[] arr , int val, int lft , int rht)
            {

                int mid = lft + (rht - lft) / 2;
                if (lft<=rht)
                {
                    if (val == arr[mid])
                    {
                        Console.WriteLine(@$"it has been founded..! ,  after : {{{tries}}} Tries.");
                        return;
                    }
                    else if (val > arr[mid])
                    {

                        ++tries;
                        BinarySearchHandler(arr, val,mid + 1, rht);
                    }
                    else if (val < arr[mid])
                    {
                        ++tries;
                        BinarySearchHandler(arr, val, lft, mid-1);
                    }

                }
                else
                {
                    Console.WriteLine("it has not been founded..!");
                }

            }

        }

        public static void InterPolation(this IEnumerable<int> source, int value)
        {
            var copy = source.ToArray();

            int tries = 1;
            BinarySearchHandler(copy, value, 0, copy.Length - 1);

            void BinarySearchHandler(int[] arr, int val, int lft, int rht)
            {

                int mid = lft + ((rht - lft) / (arr[rht] - arr[lft])) * val - arr[lft];
                if (lft <= rht)
                {
                    if (val == arr[mid])
                    {
                        Console.WriteLine(@$"it has been founded..! ,  after : {{{tries}}} Tries.");
                        return;
                    }
                    else if (val > arr[mid])
                    {

                        ++tries;
                        BinarySearchHandler(arr, val, mid + 1, rht);
                    }
                    else if (val < arr[mid])
                    {
                        ++tries;
                        BinarySearchHandler(arr, val, lft, mid - 1);
                    }

                }
                else
                {
                    Console.WriteLine("it has not been founded..!");
                }

            }

        }

        public static IEnumerable<int> BubbleSort(this IEnumerable<int> source)
        {

            var copy = source.ToArray();

            for (int i = 1; i < copy.Length; i++)
            {
               
                for (int j = 0; j < copy.Length-i; j++)
                {
                    if (copy[j] > copy[j+1])
                    {
                        Swap(ref copy[j],ref copy[j + 1]);
                    }
                }
            }
            return copy;
        }
        private  static void Swap(ref int number1 , ref int number2)
        {
            int temp= number1;
            number1 = number2;
            number2 = temp;
        }
      
        public static IEnumerable<int> MergeSort(this IEnumerable<int> source)
        {

            var copy = source.ToArray();

            divide(copy, 0, copy.Length-1);
            // divde 

            void divide(int[] arr , int low , int high)
            {
                if (low<high)
                {
                int mid = low + (high - low) / 2;
                divide(arr, low, mid);
                divide(arr, mid + 1, high);
                merge(arr, low, mid , high);

                }
            }
            //merge

            void merge(int[] arr , int low , int m,int high)
            {
                int n1 = m - low +1 ;
                int n2 = high - m;

                int[] arr1 = new int[n1];
                int[] arr2 = new int[n2];

                int i = 0;
                int j = 0;
                int k;
                while (i<arr1.Length)
                {
                    arr1[i] = arr[i + low];
                    i++;
                
                }
                while (j < arr2.Length)
                {
                    arr2[j] = arr[j +m+1];
                    j++;

                }
                i = 0;
                j = 0;
                k = low;
                while(i<arr1.Length && j < arr2.Length)
                {
                    if (arr1[i] < arr2[j])
                    {
                        arr[k] = arr1[i];
                        ++i;
                    }
                    else
                    {
                        arr[k] = arr2[j];
                        ++j;
                    }
                    ++k;
                }
                while (i < arr1.Length)
                {
                    arr[k] = arr1[i];
                    ++i;
                    ++k;
                }
                while (j < arr2.Length)
                {
                    arr[k] = arr2[j];
                    ++j;
                    ++k;
                }
            }
            return copy;

        }

        public static IEnumerable<int>QuickSort(this IEnumerable<int> source)
        {

            var copy = source.ToArray();

            divide(copy, 0, copy.Length - 1);
     
            // divide
            
            void divide(int[] arr , int low , int high)
            {
                if (low<high)
                {
                    int pivotIndex = partition(arr, low, high);

                    divide(arr, pivotIndex + 1, high);
                    divide(arr , low, pivotIndex-1);
                }
            }


            // partitioning

            int partition(int[]arr , int low , int high)    // { 12, 4, 5, 6, 7, 3, 1, 15 };
            {
                var pivot = arr[high];
                var i = low - 1; 
                
                for (int j= low; j < high; j++)
                {
                    if (arr[j] <= pivot)
                    {
                        i++;
                        Swap(ref arr[i], ref arr[j]);
                    }

                }

                Swap(ref arr[i + 1], ref arr[high]);
                return i + 1;
            }

            return copy;

        }


    }
}