using System.Collections;

namespace HIndex;

internal static class Program
{
    public static void Main()
    {
        int[] array = GenerateArray();
        Console.WriteLine("Неотсортированный массив: ");
        WriteArray(array);
        
        SortArray(array, 0,array.Length-1);
        Console.WriteLine("Отсортированный массив: ");
        
        WriteArray(array);
        
        Console.WriteLine("Ответ - " + HIndexAlgorithm(array));
    }

    private static int[] GenerateArray()
    {
        Random rnd = new Random();
        
        int[] array = new int[20];
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = rnd.Next(20);
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
            while (array[i] > pivot)
            {
                i++;
            }
        
            while (array[j] < pivot)
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
    
    private static int HIndexAlgorithm(int[] array)
    {
        Dictionary<int, int> dictionary = new Dictionary<int, int>();

        for (int i = 0; i < array.Length; i++)
        {
            if(!dictionary.ContainsKey(array[i]))
                dictionary.Add(array[i],1+i);
            else
                dictionary[array[i]] += 1;
            
            if (array[i] <= dictionary[array[i]])
                return array[i];
        }

        return -1;
    }
}