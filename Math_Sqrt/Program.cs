namespace Math_Sqrt;

internal static class Program
{
    public static void Main()
    {
        int integer;
        int decimalPoint;
        Console.Write("Введите натурадьное число под корнем: ");
        while (!int.TryParse(Console.ReadLine(), out integer))
        {
            Console.Write("Введенно не натуральное число! Введите еще раз: ");
        }
        Console.Write("Введите натурадьное число цифр после запятой: ");
        while (!int.TryParse(Console.ReadLine(), out decimalPoint))
        {
            Console.Write("Введенно не натуральное число! Введите еще раз: ");
        }
        
        Console.WriteLine($"Квадратный корень из {integer} = {Sqrt(integer,decimalPoint).ToString($"F{decimalPoint}")}");
    }

    public static double Sqrt(double integer, int decimalPoint)
    {
        double result = 0;
        int digitCount = (int)Math.Log10(integer) + 1;
        int pairsCount = digitCount / 2;
        if (digitCount % 2 != 0)
        {
            pairsCount += 1;
        }
        
        double residual = 0;
        
        double firstPair = integer % IntPow(10, (pairsCount-1) * 2 + 2) / IntPow(10, (pairsCount-1) * 2);
        for (int j = 1; j*j <= firstPair; j++)
        {
            int nextSquare = (j+1) * (j+1);
            
            if (nextSquare > firstPair)
            {
                residual = firstPair-j*j;
                result += j;
                break;
            }
        }
        
        for (int i = 1; i < pairsCount; i++)
        {
            double pair = integer % IntPow(10, (pairsCount-i-1) * 2 + 2) / IntPow(10, (pairsCount-i-1) * 2);
            
            double n1 = residual*100 + pair;
            double n2 = 0;
            double l = result * 2;
            
            for (int k = 0; k <= 9; k++)
            {
                if ((l * 10 + k + 1) * (k + 1) > n1)
                {
                    n2 = (l * 10 + k) * k;
                    result = result*10 + k;
                    break;
                }
            }
            
            residual = n1-n2;
        }
        
        int doubleDigit = 0;
        while (residual != 0 && doubleDigit < decimalPoint)
        {
            double n1 = residual*100;
            double n2 = 0;
            double l = result * 2;
            
            for (double k = 0; k <= 9; k++)
            {
                if ((l * 10 + k + 1) * (k + 1) > n1)
                {
                    n2 = (l * 10 + k) * k;
                    result = result*10 +k;
                    doubleDigit++;
                    break;
                }
            }
            
            residual = n1-n2;
        }
        
        result *= DoublePow(0.1,doubleDigit);
        return result;
    }
    
    private static int IntPow(int x, int pow)
    {
        int ret = 1;
        while ( pow != 0 )
        {
            if ( (pow & 1) == 1 )
                ret *= x;
            x *= x;
            pow >>= 1;
        }
        return ret;
    }
    
    private static double DoublePow(double x, int pow)
    {
        double ret = 1;
        while ( pow != 0 )
        {
            if ( (pow & 1) == 1 )
                ret *= x;
            x *= x;
            pow >>= 1;
        }
        return ret;
    }
}

