using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prooffer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Coding code = new Coding();
            code.Action(9); //Размерность массива (число ребер)
            Decoding dec = new Decoding();
            dec.Action(8); //Кол-во элементов в коде Прюфера
            Console.ReadKey();
        }
    }
}