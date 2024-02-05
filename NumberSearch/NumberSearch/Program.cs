namespace NumberSearch;

internal static class Program
{
    public static void Main()
    {
        int number;
        Console.Write("Введите целое число: ");
        while (!int.TryParse(Console.ReadLine(), out number))
        {
            Console.Write("Введенно не целое число! Введите еще раз: ");
        }

        int[,] array =
        {
            {1, 3, 7, 8, 12,14,16},
            {2, 5, 9, 11,16,19,21},
            {5, 8, 12,13,17,22,25},
            {6, 10,13,15,19,24,27},
            {11,14,16,18,21,27,30},
        };
        
        int[,] array2 =
        {
            {1, 2, 5, 6, 11},
            {3, 5, 8, 10,14},
            {7, 9, 12,13,16},
            {8, 11,13,15,18},
            {12,16,17,19,21},
            {14,19,22,24,27},
            {16,21,25,27,30},
        };
        
        NumberSearch(array,number);
    }

    public static void NumberSearch(int[,] array, int number)
    {
        int length1 = array.GetLength(0);
        int length2 = array.GetLength(1);
        
        int i = length1 > length2?length1-1:0;
        int j = length2 > length1?length2-1:0;
        
        while (i<=length1 && j<=length2)
        {
            if (i >= length1 || i < 0 || j >= length2|| j < 0)
            {
                Console.Write($"Число не найдено");
                return;
            }

            if (array[i, j] > number)
            {
                if (j == length2)
                    j--;
                else
                    i--;
            }
            else if (array[i, j] < number)
            {
                if (j == length2)
                    i++;
                else
                    j++;
            }
            else if (array[i, j] == number)
            {
                Console.Write($"Местоположение числа {number} - [{i},{j}]");
                return;
            }
        }
    }
}