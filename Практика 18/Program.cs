using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Практика_18
{
    internal class Program
    {
        static void Main(string[] args)
        {
            short m;
            Console.Write("Введите число: ");
            while (!Int16.TryParse(Console.ReadLine(), out m))
            {
                Console.Write("Неверный формат ввода. Повторите ввод: ");
            }

            string path = "sum.txt";
            short[] data;
            if (File.Exists(path))
            {
                data = File.ReadAllText(path)
                           .Split(new char[] { ' ', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                           .Select(x => Int16.Parse(x))
                           .ToArray();

                var list = Count(data);

                foreach (var item in list) Console.WriteLine(item); 

            }

            Console.ReadKey();
        }

        static List<int> Count(short[] data)
        {
            var list = new List<int>();

            for (int i = 0; i < data.Length*data.Length-1; i++) 
            {
                list.Add(SetSum(data, GenerateCode(i, data.Length)));
            }

            return list;
        }
        static int SetSum(short[] set, string code)
        {
            int sum = 0;
            for (int i = 0; i < set.Length; i++)
            {
                if (code[i] == '1')
                    sum += set[i];
            }
            return sum;
        }
        static string GenerateCode(int number, int length)
        {
            string code = Convert.ToString(number, 2);
                while (code.Length != length)
                {
                    code = '0' + code;
                }
            return code;
        }

    }
}
