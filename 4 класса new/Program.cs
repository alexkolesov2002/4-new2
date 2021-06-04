using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_класса_new
{
    class Program
    {
        static void Main(string[] args)
        {
            int otv = 1;
            while (otv != 0)
            {
                Console.WriteLine("Выберите номер задачи");
                Console.WriteLine(" 1 - Симплекс-метод; 2 - метод Джонсона;  \n 3 - метод потенциалов;4 - задача Коммивояжёра; \n  5 - нахождение кратчайшего пути;6 - нахождение критического пути.");
                int nom = Convert.ToInt32(Console.ReadLine());
                if (nom == 1)
                {
                    vvodZnach vz = new vvodZnach();
                    vz.simplexBol();
                }
                else if (nom == 2)
                {
                    Jonson d = new Jonson();
                    d.vvod();
                }
                else if (nom == 3)
                {
                   
                }
                else if (nom == 4)
                {
                    Kommivoyajor k = new Kommivoyajor();
                    k.Jora();
                }
                else if (nom == 5)
                {
                    MinPth m = new MinPth("КратчайшийПуть.csv");
                }
                else if (nom == 6)
                {
                    CrtPth Cp = new CrtPth("КратчайшийПуть.csv");
                }
                else 
                {
                    Console.WriteLine("Подумай еще раз!");
                }
                Console.WriteLine("Продолжить работу? Для завершения нажмите <0>");
                otv = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
            }
            Console.ReadKey();
        }
    }
}
