using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiAOD_LR2
{
    class Program
    {
        /* На основе динамических списков необходимо реализовать словарь. 
         * Основные операции, выполняемые над данными словаря:
         * - поиск;
         * - вставка;
         * - удаление.
         */

        /* Размер таблицы ркомендуется выберать по формуле 2^n.
         * 
         */

        public static void command()
        {
            Console.WriteLine("Команды:");
            Console.WriteLine("\tпоиск");
            Console.WriteLine("\tвставка");
            Console.WriteLine("\tудаление");
            Console.WriteLine("\tвыход");
        }

        //функция для генерации хеш кода
        public static int hashGeneration(string text, int count)
        {
            int hash = 0;
            for (int i = 0; i < text.Length; i++)
            {
                hash += text[i] + (int)Math.Pow(count, i);
                hash %= count;
            }
            return Math.Abs(hash);
        }

        static void Main(string[] args)
        {
            int n = 0;
            bool flag = false;
            while (!flag)
            {
                try
                {
                    Console.Write("Введите размер хеш таблицы:");
                    n = Math.Abs(Convert.ToInt32(Console.ReadLine()));
                    flag = true;
                }
                catch
                {
                    Console.WriteLine("Не верный ввод. Повторите попытку.");
                    flag = false;
                }
            }
            MyList[] table = new MyList[n];
            for (int i = 0; i < table.Length; i++)
                table[i] = new MyList();
            command();
            while (true)
            {
                Console.Write("Введите команду:");
                string consoleCommand = Convert.ToString(Console.ReadLine());

                if (consoleCommand == "поиск")
                {
                    Console.Write("Введите ключевое слово для поиска:");
                    string key = Convert.ToString(Console.ReadLine());
                    HashList item = table[hashGeneration(key, n)].searchKey(key);
                    if (item.key == key)
                    {
                        Console.WriteLine("key:" + item.key);
                        Console.WriteLine("text:" + item.text);
                    }
                    else
                        Console.WriteLine("По запросу ничего не найдено.");
                }
                else
                if (consoleCommand == "вставка")
                {
                    Console.Write("Введите ключевое слово для записи:");
                    string key = Convert.ToString(Console.ReadLine());
                    Console.Write("Введите сопроводительный текст:");
                    string text = Convert.ToString(Console.ReadLine());
                    table[hashGeneration(key, n)].add(key, text);
                    Console.WriteLine("Запись выполнена успешно.");
                }
                else
                if (consoleCommand == "удаление")
                {
                    Console.Write("Введите ключевое слово для удаления:");
                    string key = Convert.ToString(Console.ReadLine());
                    MyList ho = new MyList();

                    try
                    {
                        table[hashGeneration(key, n)].delete(key);
                        Console.WriteLine("Удаление выполнено успешно.");
                    }
                    catch
                    {
                        Console.WriteLine("Данный ключ не существует.");
                    }

                }
                else
                if (consoleCommand == "выход")
                {
                    break;
                }
                else
                    Console.WriteLine("не верная команда. Повторите ввод.");
            }
            Console.Write("нажмите любую кнопку для закрытия...");
            Console.ReadKey();
        }
    }
}