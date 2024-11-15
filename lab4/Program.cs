using lab4;
using System;
using System.Collections.Generic;
using System.Data;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;
class Program
{
    static void Main()
    {
        string ex;

        Console.WriteLine("Выберете номер задания: \n\n" +
            "1.  Задание 1.\n" +
            "2.  Задание 2.\n" +
            "3.  Задание 3.\n" +
            "4.  Задание 4.\n" +
            "5.  Задание 5.\n");
        ex = Console.ReadLine();
        switch (ex)
        {
            case "1":
                Console.WriteLine("Формирует список L, включив в него по одному разу элементы, которые входят одновременно в оба списка L1 и L2.");
                List<string> L1 = new List<string>();
                Console.WriteLine("Введите через пробел элементы списка L1");
                string inputL1 = Console.ReadLine();
                string[] splitWordsL1 = inputL1.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string word in splitWordsL1)
                {
                    L1.Add(word);
                }

                List<string> L2 = new List<string>();
                Console.WriteLine("Введите через пробел элементы списка L2");
                string inputL2 = Console.ReadLine();
                string[] splitWordsL2 = inputL2.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string word in splitWordsL2)
                {
                    L2.Add(word);
                }
                List<string> intersection = ListOperations.GetIntersection(L1, L2);
                if (intersection.Count() == 0)
                {
                    Console.WriteLine("В списках нет одинаковых элементов");
                }
                else
                {
                    Console.WriteLine("Пересечения: " + string.Join(", ", intersection));
                }
                
                break;
            case "2":
                Console.WriteLine("В конец непустого списка L добавить все его элементы, располагая их в обратном порядке");
                List<string> L3 = new List<string>();
                string inputL3;
                do
                {
                    Console.WriteLine("Введите через пробел элементы списка. Список не должен быть пустым");
                    inputL3 = Console.ReadLine();
                    string[] splitWordsL3 = inputL3.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string word in splitWordsL3)
                    {
                        L3.Add(word);
                    }
                } while (string.IsNullOrWhiteSpace(inputL3)) ;
                List<string> reversed = ListOperations.AddReverseList(L3);
                Console.WriteLine(string.Join(", ", reversed));
                break;
            case "3":
                try
                {
                    List<string> allTrcs = new List<string> { "ТЦ1", "ТЦ2", "ТЦ3", "ТЦ4", "ТЦ5" };
                    Console.WriteLine("Сколько студентов в группе: ");
                    int studentCount = Convert.ToInt32(Console.ReadLine());
                    List<HashSet<string>> studentTrcs = new List<HashSet<string>>();
                    Console.WriteLine("Список ТЦ: " + string.Join(", ", allTrcs));
                    for (int i = 0; i < studentCount; i++)
                    {
                        HashSet<string> collection = new HashSet<string>();
                        Console.WriteLine($"Введите ТЦ из списка для студента {i + 1} (введите '0' для завершения ввода):");

                        while (true)
                        {
                            string input = Console.ReadLine();
                            if (input.ToLower() == "0")
                            {
                                break;
                            }

                            if (allTrcs.Contains(input))
                            {
                                collection.Add(input);
                            }
                            else
                            {
                                Console.WriteLine("Введенные данные не соответствуют списку. Попробуйте снова.");
                            }
                        }

                        studentTrcs.Add(collection);
                    }

                    Console.WriteLine("\nСписок студентов:");
                    for (int i = 0; i < studentTrcs.Count; i++)
                    {
                        Console.WriteLine($"Студент {i + 1}: {string.Join(", ", studentTrcs[i])}");
                    }
                   
                    var visitedAll = ListOperations.AllStudents(studentTrcs);
                    var visitedSome = ListOperations.SomeStudents(studentTrcs);
                    var notVisited = ListOperations.NotVisited(allTrcs, studentTrcs);

                    Console.WriteLine("ТЦ, которые посещали все студенты: " + string.Join(", ", visitedAll));
                    Console.WriteLine("ТЦ, которые посещали некоторые студенты: " + string.Join(", ", visitedSome));
                    Console.WriteLine("ТЦ, которые не посещал ни один студент: " + string.Join(", ", notVisited));            
                }
                catch
                {
                    Console.WriteLine("Некорректный ввод");
                }
                break;
            case "4":
                string filePath = "C:\\Users\\Nanana\\source\\repos\\lab4\\lab4\\file.txt";
                HashSet<char> uniqueLetters = ListOperations.CountLetters(filePath);

                Console.WriteLine($"Количество букв в тексте: {uniqueLetters.Count}");
                Console.WriteLine("Уникальные буквы: " + string.Join(", ", uniqueLetters));
                
                break;
            case "5":
                
                break;
            default:
                Console.WriteLine("Такого номера нет или вы нажали лишний раз на пробел.");
                break;
        }     
    }
}