using System;

namespace SortingAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Array to sort:");

            var a = GenerateRandomArray();
            Print(a);

            //BubbleSort(a);

            MergeSortExample(a);


            Console.WriteLine("Print any key to exit.");
            Console.ReadKey();

        }

        private static void MergeSortExample(int[] a) {
            MergeSort(a, 0, a.Length - 1);
            Print(a);
        }

        private static void MergeSort(int[] a, int left, int right)
        {
            if (right > left)
            {
                int middle = (right + left) / 2;
                MergeSort(a, left, middle);
                MergeSort(a, middle + 1, right);

                DoMerge(a, left, middle + 1, right);
            }

        }

        private static void DoMerge(int[] a, int left, int middle, int right)
        {
            int[] temp = new int[a.Length]; 

            int left_end, num_elements, pos;

            left_end = middle - 1;
            pos = left;
            num_elements = right - left + 1;

            while ((left <= left_end) && (middle <= right))
            {
                if (a[left] <= a[middle])
                    temp[pos++] = a[left++];
                else
                    temp[pos++] = a[middle++];
            }

            while (left <= left_end)
                temp[pos++] = a[left++];

            while (middle <= right)
                temp[pos++] = a[middle++];

            for (int i = 0; i < num_elements; i++)
            {
                a[right] = temp[right];
                right--;
            }
        }


        // not finished...
        private static void DoMerge_v2(int[] a, int left, int middle, int right)
        {
            int left_end = middle; // - 1;

            while ((left <= left_end) && (middle <= right))
            {
                if (a[left] <= a[middle])
                {
                    //left++;
                }
                else
                {
                    var temp = a[middle];
                    a[middle] = a[left];
                    a[left] = temp;

                    //middle++;
                }
                left++;

            }

            Print(a);

        }

        private static void Print(int[] a)
        {
            foreach (var item in a)
                Console.Write(item + " ");

            Console.WriteLine();
        }

        static int[] GenerateRandomArray()
        {
            int[] a = new int[27];

            var r = new Random();

            for (int i = 0; i < a.Length; i++)
            {
                a[i] = r.Next(0, 99);
            }

            return a;
        }

        static void BubbleSort(int[] a)
        {
            Console.WriteLine("Performing bubble sort");

            for (int i = 0; i < a.Length - 1; i++)
            {
                for (int j = 0; j < a.Length - 1; j++)
                {
                    // order from less to great
                    if (a[j] > a[j + 1])
                    {
                        // let's do bubble - change element with the next one
                        var temp = a[j + 1];
                        a[j + 1] = a[j];
                        a[j] = temp;
                    }
                }
            }

            Print(a);
        }


    }
}
