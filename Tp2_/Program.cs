    using System;
    using System.Linq;
    using System.Threading;

    namespace Tp2_
    {
        class Program
        {
            static object guile = new object();
            static void Main(string[] args)
            {
                String[] p = null;
                p = (from value in Enumerable.Range(0, 100)
                     select
                value.ToString()).ToArray();
                //----------------------------------------------------------------
                Thread t = new Thread(() =>
                {
                    int i = 0;
                    while (true)
                    {
                        lock (guile)
                        {
                            while ((++i) < 100)
                            {
                                if (p[i] != null)
                                {
                                    Console.WriteLine($"p[{i}]={p[i].ToUpper()}");
                                }
                            }
                            i = 0;
                        }
                        Thread.Sleep(100);
                    }
                });
                Thread r = new Thread(() =>
                {
                    int i = 0;
                    bool invertir = false;
                    while (true)
                    {
                        lock (guile)
                        {
                            while (++i < 100)
                            {
                                if (!invertir)
                                {
                                    if (i % 2 == 0)
                                        p[i] = null;
                                    else
                                        p[i] = i.ToString();
                                }
                                else
                                {
                                    if (i % 2 != 0)
                                        p[i] = null;
                                    else
                                        p[i] = i.ToString();
                                }
                            }
                            i = 0;
                            invertir = !invertir;
                        }
                        Thread.Sleep(1000);
                    }
                });
                t.Start();
                r.Start();
                Console.ReadLine();
            }
        }
    }
