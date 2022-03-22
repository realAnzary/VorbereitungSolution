namespace Backend_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"d:\randomNumbers.txt";
            int arrayLength = 10;

            createFile(path, arrayLength, -50, 50);
            int[] unsortedList = readFile(path, arrayLength);
            int[] bubbleSortList = bubbleSort(unsortedList);
            int[] insertionSortList = insertionSort(unsortedList);
            /*
            int[] unsortedList = createList(10, 1, 100);
            int[] sortedList = bubbleSort(unsortedList);

            for (int i = 0; i < sortedList.Length; i++)
            {
            }
                Console.WriteLine($"Item {i} | {unsortedList[i],3} | {sortedList[i],3}");
            */

            for (int i = 0; i < arrayLength; i++)
            {
                Console.WriteLine($"Item {i} | {unsortedList[i], 4} | {bubbleSortList[i], 4} | {insertionSortList[i], 4}");
            }
        }

        static int[] createList(int length, int lowerLimit, int upperLimit)
        {
            Random rand = new Random();
            int[] array = new int[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = rand.Next(lowerLimit, upperLimit + 1);
            }
            return array;
        }
        static void createFile(string path, int length, int lowerLimit, int upperLimit)
        {
            Random rand = new();

            using (StreamWriter sw = File.CreateText(path))
            {
                for (int i = 0; i < length; i++)
                {
                    sw.WriteLine(rand.Next(lowerLimit, upperLimit + 1));
                }
            }
        }

        static int[] readFile(string path, int length)
        {
            int count = 0;
            int[] numberList = new int[length];
            using (StreamReader sr = File.OpenText(path))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    numberList[count] = Convert.ToInt32(s);
                    count++;
                }
            }

            return numberList;
        }
        static int[] bubbleSort(int[] inputArray)
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
            } while (madeSwitch);
            return arrayCopy;
        }

        static int[] insertionSort(int[] inputArray)
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