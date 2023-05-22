using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prooffer
{
    internal class Decoding
    {
        //Исходные текстовые файлы
        public string path1 = "Ribs.txt";
        public string path2 = "Code.txt";
        public void Action(int AmCode)
        {
            List<int> Code = new List<int>(); //Код Прюфера
            List<int> Peaks = new List<int>(); //Вершины, которые есть в графе
            List<string> Ribs = new List<string>(); //Конечные ребра (для вывода в консоль)
            string[] arr = new string[1];
            string[] spl = new string[AmCode];
            arr = File.ReadAllLines(path2); //Считывание кода
            spl = arr[0].Split(' '); //Разделение по пробелам
            for (int i = 0; i < spl.Length; i++) //Запись в лист
            {
                Code.Add(Convert.ToInt32(spl[i]));
            }
            for (int i = 0; i < AmCode + 2; i++) //Все вершины графа
            {
                Peaks.Add(i + 1);
            }
            int index = 0;
            int min;
            int LastCode = Code[Code.Count - 1]; //Последний элемент из кода
            int LastPeak = Peaks[Peaks.Count - 1]; //Последняя вершина
            for (int i = 0; i < Code.Count; i++) 
            {
                min = 10000;
                for (int j = 0; j < Peaks.Count; j++) //Поиск минимальный вершины, которой нет в коде
                {
                    if ((Peaks[j] != Code[i]) && (Peaks[j] < min) && (Peaks[j] != 0)) //Поиск минимума
                    {
                        if (Code.Contains(Peaks[j]) == false) //Проверка на наличие в коде
                        {
                            min = Peaks[j];
                            index = j;
                        }
                    }
                }
                Ribs.Add($"{Code[i]} {min}"); //Запись нового ребра
                //Зануление элементов
                Peaks[index] = 0;
                Code[i] = 0;
            }
            Ribs.Add($"{LastCode} {LastPeak}"); //Запись последних элементов
            Console.WriteLine();
            Console.WriteLine("Список рёбер:"); 
            foreach (string s in Ribs) //Вывод ребер в консоль
            {
                Console.WriteLine(s);
            }
        }
    }
}