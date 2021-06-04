﻿    using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_класса_new
{
    class Jonson
    {
        public int[,] mas;
        public int d;
        public void vvod()
        {
            int[] ms1 = { }, ms2 = { };
            //Читаем
            using (StreamReader sr = new StreamReader("DjonsonVvod.csv"))
            {
                while (sr.EndOfStream != true)
                {
                    string str1 = sr.ReadLine();
                    string str2 = sr.ReadLine();
                    ms1 = Array.ConvertAll(str1.Split(';'), int.Parse);
                    ms2 = Array.ConvertAll(str2.Split(';'), int.Parse);
                }
            }
            //Количество деталей
            int detal = ms1.Length;
            //Массив деталей
            int[,] mas = new int[2, detal];
            //Из 1 в двумерный 
            for (int i = 0; i < detal; i++)
            {
                mas[0, i] = ms1[i];
                mas[1, i] = ms2[i];
            }
            this.mas = mas;
            d = detal;
            obrab();
        }
        public void obrab()
        {
            //d- счетчик dd-тоже
            int d = this.d, dd = this.d;
            int[,] mas = new int[2, d];
            //счетчик и мин
            int min, sch = 1;
            int max = this.mas[0, 0];
            //Счетчики для перестановки минимумов
            int ii = 0;
            int jj = 0;
            //Поиск максимума
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < d; j++)
                {
                    if (max < this.mas[i, j])
                    {
                        max = this.mas[i, j];
                    }
                }
            }
            //Поиск минимума на шагах
            for (int g = 0; g < dd; g++)
            {
                min = max;
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < d; j++)
                    {
                        if (min > this.mas[i, j] && this.mas[i, j] != 0)
                        {
                            min = this.mas[i, j];
                            ii = i;//Поиск номера станка
                            jj = j;
                        }
                    }
                }
                //Перестановка
                //Если станок первый, то 
                if (ii == 0)
                {
                    mas[0, g] = this.mas[0, jj];
                    mas[1, g] = this.mas[1, jj];
                }
                //Если второй то перестановка в конец
                else
                {
                    mas[0, dd - 1] = this.mas[0, jj];
                    mas[1, dd - 1] = this.mas[1, jj];
                    dd--;
                    g--;
                }
                Console.WriteLine("\n\n{0} шаг\n", sch);
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < this.d; j++)
                    {
                        Console.Write(mas[i, j] + " ");
                    }
                    Console.WriteLine();
                }
                this.mas[0, jj] = 0;
                this.mas[1, jj] = 0;
                sch++;
            }
            //Временной массив для подсчета простоя 2 станка
            int[] vremia = new int[d];
            int forVRE = 0;//Счетчик для времени 
            vremia[forVRE] = mas[0, 0];//Первый простой(всегда)
            int sum = 0;
            for (int o = 1; o < d; o++)//Первый просто учтен, поэтому 1.
            {
                //Сумма первой строки
                for (int j = 0; j < o; j++)
                {
                    sum += mas[0, j];
                }
                //Разность первой и второй строки
                for (int j = 0; j < o - 1; j++)
                {
                    sum -= mas[1, j];
                }
                forVRE++;
                vremia[forVRE] = sum;
                sum = 0;
            }
            int maxProst = vremia.Max();//Максимальный простой
            Console.WriteLine("\n\n\nОкончательное распределение: \n");
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < d; j++)
                {
                    Console.Write($"{mas[i, j],3} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Время простоя: " + maxProst);
            using (StreamWriter sw = new StreamWriter("DjonsonOTV.csv", false, Encoding.Default, 10))
            {
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < d; j++)
                    {
                        sw.Write(mas[i, j] + ";");
                    }
                    sw.Write("\n");
                }
                sw.Write("Время; простоя:;" + maxProst);
            }
        }
    }
}
