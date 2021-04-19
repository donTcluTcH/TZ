using System;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZ
{
    class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            Console.WriteLine("Введите путь к текстовому файлу:");

            string adress1 = Console.ReadLine();
            string text = System.IO.File.ReadAllText(adress1, Encoding.GetEncoding(1251));
            char[] a = text.ToCharArray();
            List<string> triplet = new List<string>();
            int cnt = 0;
            bool flag;
            string str = "";
            for (int i = 0; i < a.Length - 3; i++)
            {
                if (char.IsLetter(a[i]) & char.IsLetter(a[i + 1]) & char.IsLetter(a[i + 2]))
                {
                    cnt = 0;
                    flag = true;
                    for (int j = 0; j < a.Length - 3; j++)
                    {
                        if (a[i] == a[j] & a[i + 1] == a[j + 1] & a[i + 2] == a[j + 2])
                        {

                            if (flag)
                            {
                                str = Char.ToString(a[i]) + Char.ToString(a[i + 1]) + Char.ToString(a[i + 2]);
                                flag = false;
                            }
                            cnt++;

                        }

                    }
                    str = str + " " + cnt.ToString();
                    triplet.Add(str);

                }

            }

            string temp;

            for (int i = 0; i < triplet.Count; i++)
            {
                for (int j = 0; j < triplet.Count - 1; j++)
                {

                    if (Convert.ToInt32(triplet[j].Substring(4)) < Convert.ToInt32(triplet[j + 1].Substring(4)))
                    {
                        temp = triplet[j];
                        triplet[j] = triplet[j + 1];
                        triplet[j + 1] = temp;
                    }
                }
            }
            Console.WriteLine();
            for (int i = 0; i < 10; i++)
            {
                Console.Write(triplet[i].Substring(0, 3) + ", ");
            }
            Console.WriteLine();

            stopWatch.Stop();

            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{3:000}",
                        ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);

            Console.WriteLine("Время выполнения программы в миллисекундах: " + elapsedTime);

            Console.ReadKey();
        }
    }
}
