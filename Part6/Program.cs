using System;
using System.IO;

namespace Part6
{
    class Program
    {
        static string _path = "UserData.txt";
        static void Main(string[] args)
        {
            bool exit = false; 

            if (!File.Exists(_path))
            {
                FileInfo fi1 = new FileInfo(_path);
                using (StreamWriter sw = fi1.CreateText())
                {
                    sw.WriteLine("");
                }
            }

            do
            {
                Console.Write("1 - показать данные сотрудников, 2 - Добавить нового сотрудника, 0 - выход из программы: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        ReadData();
                        break;
                    case "2":
                        WriteData();
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("\nЧто-то пошло не так. Пожалуйста, повторите ввод.\n");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }

            } while (!exit);
        }

        static private void ReadData()
        {
            using (StreamReader sr = new StreamReader(_path))
            {
                while (!sr.EndOfStream)
                    Console.WriteLine(sr.ReadLine());

            }
        }

        static private void WriteData()
        {
            int id= File.ReadAllLines(_path).Length;
            string newUser;
            Console.Write("Введите ФИО сотрудника: ");
            newUser = $"{id}#{DateTime.Now}#{Console.ReadLine()}#";
            Console.Write("Введите возраст сотрудника: ");
            newUser += Console.ReadLine() + "#";
            Console.Write("Введите рост сотрудника: ");
            newUser += Console.ReadLine() + "#";
            Console.Write("Введите дату рождения сотрудника: ");
            newUser += Console.ReadLine() + "#";
            Console.Write("Введите место рождения сотрудника: ");
            newUser += Console.ReadLine();

            using (StreamWriter sw = new StreamWriter(_path, true))
            {
                sw.WriteLine(newUser);
            }
            Console.WriteLine("Данные успешно сохранены, нажмите любую клавишу для выхода на главный экран.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
