using System;

namespace TwoNumSum;

public static class Program
{
    public static void Main()
    {
        int length;
        Console.Write("Введите длинну массива: ");
        while (!int.TryParse(Console.ReadLine(), out length))
        {
            Console.Write("Введенно не целое число! Введите еще раз: ");
        }
        
        int[] array = GenerateArray(length);
        Console.WriteLine("Неотсортированный массив: ");
        WriteArray(array);
        
        SortArray(array, 0,array.Length-1);
        Console.WriteLine("Отсортированный массив: ");
        
        WriteArray(array);
        
        Console.WriteLine("Введите сумму чисел которые нужно найти: ");
        int number;
        while (!int.TryParse(Console.ReadLine(), out number))
        {
            Console.Write("Введенно не целое число! Введите еще раз: ");
        }
        Console.WriteLine("Ответ: ");
        WriteArray(FindTwoNumbOfSum(array, number));
    }
    
    private static int[] GenerateArray(int length)
    {
        Random rnd = new Random();
        
        int[] array = new int[length];
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = rnd.Next(-20,20);
        }
        
        return array;
    }
    
    private static void WriteArray(int[] array)
    {
        foreach (var VARIABLE in array)
        {
            Console.Write(VARIABLE+" ");
        }
        Console.Write("\n");
    }
    
    private static void SortArray(int[] array,int leftIndex, int rightIndex)
    {
        var i = leftIndex;
        var j = rightIndex;
        var pivot = array[leftIndex];
        while (i <= j)
        {
            while (array[i] < pivot)
            {
                i++;
            }
        
            while (array[j] > pivot)
            {
                j--;
            }
            
            if (i <= j)
            {
                (array[i], array[j]) = (array[j], array[i]);
                i++;
                j--;
            }
        }
    
        if (leftIndex < j)
            SortArray(array, leftIndex, j);
        if (i < rightIndex)
            SortArray(array, i, rightIndex);
    }
    
    private static int[] FindTwoNumbOfSum(int[] array, int integer)
    {
        int nearestL = 0;
        int nearestR = array.Length-1;
        int nearestDifference =integer-array[nearestL]-array[nearestR];
        nearestDifference = (nearestDifference>=0?nearestDifference:-nearestDifference);
        
        for (int l = 0, r = array.Length-1; l < r;)
        {
            int sum = array[l] + array[r];
            int difference = integer - sum;
            difference = difference >= 0 ? difference : -difference;
            
            if(difference<nearestDifference)
            {
                nearestL = l;
                nearestR = r;
                nearestDifference = difference;
            }
            if (sum == integer)
                return new[] { array[l], array[r] };
            if (sum > integer)
                r--;
            if (sum < integer)
                l++;
        }

        return new[] {array[nearestL], array[nearestR]};
    }
}