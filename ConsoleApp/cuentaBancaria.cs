using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    class cuentaBancaria
    {
        object dep_lock = new object();
        private int saldo;

        public int Saldo { get { return saldo; }
            set {
                lock (dep_lock)
                {
                    saldo = value;
                }
            }
        }

        public void deposiar(int n)
        {
            lock (dep_lock)
            {
                Saldo = saldo + n;
            }
        }
        public void retirar(int n)
        {
            lock (dep_lock)
            {
                Saldo -= n;
            }
        }
    }
}
