using System;
using System.Threading;

namespace ConsoleApp
{
    class Program
    {
        
        static void Main(string[] args)
        {
            cuentaBancaria cb = new cuentaBancaria();
            cb.Saldo = 100;
            for(int i = 0;  i < 100; i++)
            {
                new Thread(() => {
                    for (int x = 0; x < 100; x++)
                    {
                        cb.deposiar(1);
                    }                   
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId + "Termino: " + cb.Saldo);
                }).Start();                 
            }
            for (int i = 0; i < 100; i++)
            {
                new Thread(() => {
                    for (int x = 0; x < 100; x++)
                    {                        
                         cb.retirar(1);                       
                    }
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId + "Termino: "+cb.Saldo);
                }).Start();
            }
            Console.ReadKey();
            Console.WriteLine(cb.Saldo);
            Console.ReadKey();
        }
  
    }
}
