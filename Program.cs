using System;
using System.Text;
class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        string binaryNumber1 = "", binaryNumber2 = "";

        while (binaryNumber1.Length != 8 || binaryNumber2.Length != 8)
        {
            Console.Write("Введіть перше 8-бітове двійкове число: ");
            binaryNumber1 = Console.ReadLine();
            Console.Write("Введіть друге 8-бітове двійкове число: ");
            binaryNumber2 = Console.ReadLine();
            if (binaryNumber1.Length != 8 || binaryNumber2.Length != 8)
            {
                Console.WriteLine("Будь ласка, введіть число правильної довжини");
            }
        }
        Console.WriteLine($"\n{binaryNumber1} x {binaryNumber2} = {MultiplyTwoBinaries(binaryNumber1, binaryNumber2)}");
        Console.WriteLine($"{ConvertBinaryToDecimal(binaryNumber1)} x {ConvertBinaryToDecimal(binaryNumber2)} = {ConvertBinaryToDecimal(MultiplyTwoBinaries(binaryNumber1, binaryNumber2))}");
    }
    static string MultiplyTwoBinaries(string binaryNumber1, string binaryNumber2)
    {
        string result = "0";
        for (int i = binaryNumber2.Length - 1; i >= 0; i--)
        {
            if (binaryNumber2[i] == '1') //Якщо у нас є 1, то вона записується в result
            {
                result = GetSumOfTwoBinaries(result, binaryNumber1);
            }
            binaryNumber1 += "0"; //Кожен раз, коли виконується ітерація циклу, до binaryBumber1 додається нуль, що еквівалентно зсуву бітів вліво.
        }
        return result;
    }
    static string GetSumOfTwoBinaries(string binaryNumber1, string binaryNumber2) //Обчислюємо суму двох чисел 
    {
        string result = "";
        int sum = 0;
        int i = binaryNumber1.Length - 1, j = binaryNumber2.Length - 1;
        while (i >= 0 || j >= 0 || sum == 1)
        {
            if (i >= 0)
            {
                sum += binaryNumber1[i] - '0';
            }
            if (j >= 0)
            {
                sum += binaryNumber2[j] - '0';
            }
            result = (sum % 2) + result;
            sum /= 2;
            i--;
            j--;
        }
        return result;
    }
    static int ConvertBinaryToDecimal(string binaryNumber) //Переводимо з бінарного в десяткове число
    {
        int decimalValue = 0;
        int power = binaryNumber.Length - 1;
        foreach (char digit in binaryNumber)
        {
            if (digit == '1')
            {
                decimalValue += (int)Math.Pow(2, power);
            }
            power--;
        }
        return decimalValue;
    }
}
