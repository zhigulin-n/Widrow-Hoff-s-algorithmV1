using System;
using System.Diagnostics;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch time = new Stopwatch();
            time.Start();
            int[,] mass = { { -1, -1 }, { -1, 1 }, { 1, -1 }, { 1, 1 } };
            int[] mass_y = { -1, 1, 1, 1 };
            double[] mass_cnt = new double[4];

            double w1 = 1;
            double w2 = 1;
            double S = 1;
            double sum = 1;
            int cnt = 0;
            double schetch = 0;
            int number = 0;

            while (cnt < 30)
            {
                Console.WriteLine($"Итерация {cnt + 1}");
                Console.WriteLine($"w11({cnt}) = {w1},  w21({cnt}) = {w2}, S = {S}");
                cnt++;
                double y1 = Math.Round(w1 * mass[0, 0] + w2 * mass[0, 1] - S, 5);
                Console.WriteLine($"y1 = {w1} * {mass[0, 0]} + {w2} * {mass[0, 1]} - {S} = {y1}");
                double E1 = Math.Round(0.5 * Math.Pow(y1 - mass_y[0], 2), 5);
                Console.WriteLine($"E1 = 0.5 * ({y1} - {mass_y[0]})^2 = {E1}");


                double y2 = Math.Round(w1 * mass[1, 0] + w2 * mass[1, 1] - S, 5);
                Console.WriteLine($"y2 = {w1} * {mass[1, 0]} + {w2} * {mass[1, 1]} - {S} = {y2}");
                double E2 = Math.Round(0.5 * Math.Pow(y2 - mass_y[1], 2), 5);
                Console.WriteLine($"E2 = 0.5 * ({y2} - {mass_y[1]})^2 = {E2}");

                double y3 = Math.Round(w1 * mass[2, 0] + w2 * mass[2, 1] - S, 5);
                Console.WriteLine($"y3 = {w1} * {mass[2, 0]} + {w2} * {mass[2, 1]} - {S} = {y3}");
                double E3 = Math.Round(0.5 * Math.Pow(y3 - mass_y[2], 2), 5);
                Console.WriteLine($"E3 = 0.5 * ({y3} - {mass_y[2]})^2 = {E3}");

                double y4 = Math.Round(w1 * mass[3, 0] + w2 * mass[3, 1] - S, 5);
                Console.WriteLine($"y4 = {w1} * {mass[3, 0]} + {w2} * {mass[3, 1]} - {S} = {y4}");
                double E4 = Math.Round(0.5 * Math.Pow(y4 - mass_y[3], 2), 5);
                Console.WriteLine($"E4 = 0.5 * ({y4} - {mass_y[3]})^2 = {E4}");

                mass_cnt[0] = E1;
                mass_cnt[1] = E2;
                mass_cnt[2] = E3;
                mass_cnt[3] = E4;

                for (int i = 0; i < mass_cnt.Length; i++)
                {
                    if (mass_cnt[i] >= schetch)
                    {
                        schetch = mass_cnt[i];
                        number = i;
                    }
                }
                schetch = 0;

                if (number == 0)
                {
                    w1 = Math.Round(w1 - 0.3 * (y1 - mass_y[0]) * mass[0, 0], 5);
                    w2 = Math.Round(w2 - 0.3 * (y1 - mass_y[0]) * mass[0, 1], 5);
                    S = Math.Round(S + 0.3 * (y1 - mass_y[0]), 5);
                }
                else if (number == 1)
                {
                    w1 = Math.Round(w1 - 0.3 * (y2 - mass_y[1]) * mass[1, 0], 5);
                    w2 = Math.Round(w2 - 0.3 * (y2 - mass_y[1]) * mass[1, 1], 5);
                    S = Math.Round(S + 0.3 * (y2 - mass_y[1]), 5);
                }
                else if (number == 2)
                {
                    w1 = Math.Round(w1 - 0.3 * (y3 - mass_y[2]) * mass[2, 0], 5);
                    w2 = Math.Round(w2 - 0.3 * (y3 - mass_y[2]) * mass[2, 1], 5);
                    S = Math.Round(S + 0.3 * (y3 - mass_y[2]), 5);
                }
                else if (number == 3)
                {
                    w1 = Math.Round(w1 - 0.3 * (y4 - mass_y[3]) * mass[3, 0], 5);
                    w2 = Math.Round(w2 - 0.3 * (y4 - mass_y[3]) * mass[3, 1], 5);
                    S = Math.Round(S + 0.3 * (y4 - mass_y[3]), 5);
                }
                sum = Math.Round(E1 + E2 + E3 + E4, 5);
                number = 0;
                Console.WriteLine($"E = {E1} + {E2} + {E3} + {E4} = {sum}");
                Console.WriteLine();
            }
            Console.WriteLine($"Затраченное время: {time.Elapsed}");
        }
    }
}
