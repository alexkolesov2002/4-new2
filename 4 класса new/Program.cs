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
                Console.WriteLine(" 1 - метод Джонсона; 2 - Симплекс-метод; 3 - задача Коммивояжёра; \n 4 - метод потенциалов с первоночальным распределением по методу минимального элемента; \n 5 - нахождение критического пути; 6 - нахождение кратчайшего пути; \n 7 - метод потенциалов с первоночальным распределением по методу сереро-западного угла.");
                int nom = Convert.ToInt32(Console.ReadLine());
                if (nom == 1)
                {
                    Jonson d = new Jonson();
                    d.vvod();
                }
                else if (nom == 2)
                {
                    vvodZnach vz = new vvodZnach();
                    vz.simplexBol();
                }
                else if (nom == 3)
                {
                    Kommivoyajor k = new Kommivoyajor();
                    k.Jora();
                }
                else if (nom == 4)
                {

                }
                else if (nom == 5)
                {
                    CrtPth Cp = new CrtPth("vvodKritic.csv");
                }
                else if (nom == 6)
                {
                    MainKr kr = new MainKr();
                    kr.MainKrr();
                }
                else if (nom == 7)
                {

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
