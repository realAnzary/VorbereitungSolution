namespace Backend_5
{
    internal class Program
    {
        public static void Main(string[] args)
        {
#warning Change path of this file
            string path = @"d:\randomNumbers.txt";
            int arrayLength = 10;

            CreateFile(path, arrayLength, -50, 50);
            int[] unsortedList = ReadFile(path, arrayLength);

            int[] insertionSortList = InsertionSort(unsortedList);
            int[] bubbleSortList = BubbleSort(unsortedList);

            for (int i = 0; i < arrayLength; i++)
            {
                Console.WriteLine($"Item {i} | {unsortedList[i],4} | {bubbleSortList[i],4} | {insertionSortList[i],4}");
            }
        }

        /// <summary>
        /// Creates a new text file with random numbers.
        /// </summary>
        /// <param name="path">Desired path for the file</param>
        /// <param name="length">Amoun t of numbers</param>
        /// <param name="lowerLimit">Lower limit of the numbers</param>
        /// <param name="upperLimit">Upper limit of the numbers</param>
        public static void CreateFile(string path, int length, int lowerLimit, int upperLimit)
        {
            Random rand = new Random();

            using (StreamWriter sw = File.CreateText(path))
            {
                for (int i = 0; i < length; i++)
                {
                    sw.WriteLine(rand.Next(lowerLimit, upperLimit + 1));
                }
            }
        }

        /// <summary>
        /// Reads numbers from a text file.
        /// </summary>
        /// <param name="path">Path of the file</param>
        /// <param name="length">Amount of numbers</param>
        /// <returns>Array with the numbers from file</returns>
        public static int[] ReadFile(string path, int length)
        {
            int count = 0;
            int[] numberList = new int[length];
            using (StreamReader sr = File.OpenText(path))
            {
                string? s;
                while ((s = sr.ReadLine()) != null)
                {
                    numberList[count] = Convert.ToInt32(s);
                    count++;
                }
            }

            return numberList;
        }

        /// <summary>
        /// Sorts an array with the bubblesort algorithm.
        /// </summary>
        /// <param name="inputArray">Array with numbers</param>
        /// <returns>Sorted array</returns>
        public static int[] BubbleSort(int[] inputArray)
        {
            int[] arrayCopy = (int[])inputArray.Clone();
            bool madeSwitch = false;

            do
            {
                madeSwitch = false;

                for (int i = 0; i < arrayCopy.Length; i++)
                {
                    if (i != arrayCopy.Length - 1)
                    {
                        int item_a = arrayCopy[i];
                        int item_b = arrayCopy[i + 1];
                        if (item_a > item_b)
                        {
                            madeSwitch = true;
                            int temp_value = item_b;
                            arrayCopy[i + 1] = item_a;
                            arrayCopy[i] = temp_value;
                        }
                    }
                }
            }
            while (madeSwitch);
            return arrayCopy;
        }

        /// <summary>
        /// Sorts an array with the insertion-sort algorithm.
        /// </summary>
        /// <param name="inputArray">Array of numbers</param>
        /// <returns>Sorted array</returns>
        public static int[] InsertionSort(int[] inputArray)
        {
            int[] arrayCopy = (int[])inputArray.Clone();

            int n = arrayCopy.Count();
            int key, i, j;

            for (i = 1; i < n; i++)
            {
                key = arrayCopy[i];
                j = i - 1;

                while (j >= 0 && arrayCopy[j] > key)
                {
                    arrayCopy[j + 1] = arrayCopy[j];
                    j = j - 1;
                }

                arrayCopy[j + 1] = key;
            }

            return arrayCopy;
        }
    }
}