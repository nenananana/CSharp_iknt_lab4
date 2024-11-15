using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace lab4
{
    internal class ListOperations
    {
        public static List<T> GetIntersection<T>(List<T> list1, List<T> list2)
        {
            HashSet<T> set1 = new HashSet<T>(list1);
            HashSet<T> set2 = new HashSet<T>(list2);
            set1.IntersectWith(set2);
            return set1.ToList();
        }

        public static List<T> AddReverseList<T>(List<T> list)
        {
            List<T> revlist = new List<T>(list);
            revlist.Reverse();
            list.AddRange(revlist);
            return list;
        }

        public static HashSet<string> AllStudents(List<HashSet<string>> studentTrcs)
        {
            HashSet<string> visitedByAll = new HashSet<string>(studentTrcs[0]);
            foreach (var trcs in studentTrcs.Skip(1))
            {
                visitedByAll.IntersectWith(trcs);
            }

            return visitedByAll;
        }
        public static HashSet<string> SomeStudents(List<HashSet<string>> studentTrcs)
        {
            var visitedBySome = new HashSet<string>();
            foreach (var trcs in studentTrcs)
            {
                visitedBySome.UnionWith(trcs);
            }

            return visitedBySome;
        }
        public static HashSet<string> NotVisited(List<string> allTrcs, List<HashSet<string>> studentTrcs)
        {
            var allVisited = new HashSet<string>(SomeStudents(studentTrcs));
            var notVisited = new HashSet<string>(allTrcs);
            notVisited.ExceptWith(allVisited);

            return notVisited;
        }

        public static HashSet<char> CountLetters(string filePath)
        {
            HashSet<char> uniqueLetters = new HashSet<char>();

            try
            {
                // Открываем файл для чтения
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                using (StreamReader reader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    int character;
                    // Читаем файл посимвольно
                    while ((character = reader.Read()) != -1)
                    {
                        char ch = Convert.ToChar(character);
                        // Добавляем символ в HashSet
                        if (IsCyrillic(ch))
                        {
                            uniqueLetters.Add(char.ToLower(ch));
                        }

                    }
                }              
            }
            catch
            {
                Console.WriteLine("Ошибка при чтении файла");
            }
            return uniqueLetters;
        }
        // Метод для проверки, является ли символ буквой кириллицы
        private static bool IsCyrillic(char ch)
        {
            return (ch >= 'А' && ch <= 'я') ;
        } 
    }
}
