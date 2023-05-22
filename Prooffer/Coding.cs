using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prooffer
{
    internal class Coding
    {
        //Исходные текстовые файлы
        public string path1 = "Ribs.txt";
        public string path2 = "Code.txt";
        public void Action(int AmRibs)
        {
            string[] arr = new string[AmRibs];
            string[] spl = new string[2];
            arr = File.ReadAllLines(path1);
            List<int> Ribsu = new List<int>(); //Вершины, с которых начинаются ребра
            List<int> Ribsd = new List<int>(); //Вершины, которыми заканчиваются ребра
            List<int> Prooff = new List<int>(); //Код Прюфера
            for (int i = 0; i < arr.Length; i++) //Считывание текста из файла в массив
            {
                spl = arr[i].Split(' '); //Разделение по пробелу
                Ribsu.Add(Convert.ToInt32(spl[0])); //Родитель
                Ribsd.Add(Convert.ToInt32(spl[1])); //Ветка
            }
            int min;
            int index = 0;
            for (int i = 0; i < Ribsd.Count - 1; i++) //Перебор листов с концами ребер
            {
                min = 10000;
                for (int j = 0; j < Ribsd.Count; j++) //Нахождение минимума
                {
                    if ((Ribsd[j] < min) && (Ribsu.Contains(Ribsd[j]) == false) && (Ribsd[j] != 0)) 
                    {
                        min = Ribsd[j];
                    }
                }
                if (Ribsu.Contains(min) == false) //Запись родителя в код Прюфера и зануление использованных значений
                {
                    index = Ribsd.IndexOf(min);
                    Prooff.Add(Ribsu[index]);
                    Ribsd[index] = 0;
                    Ribsu[index] = 0;
                }
            }
            Console.WriteLine("Код Прюфера:");
            foreach (int i in Prooff) //Вывод кода Прюфера в консоль
            {
                Console.Write(i + " ");
            }
        }
    }
}
