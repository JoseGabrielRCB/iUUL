using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piramede
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Piramede Part
            Console.WriteLine("Piramede de entrada 9:");
            Piramide A1 = new Piramide(9);
            A1.Imprime_Piramede();
            Console.WriteLine("\nPiramede de entrada 0: ");
            A1.set_n(0);
            A1.Imprime_Piramede();
            Console.ReadLine();
        }


        //Projeto Piramede
        class Piramide
        {
            int n;
            public Piramide(int aux = 0)
            {
                if (aux <= 0)
                {
                    this.n = 1;
                    return;
                }
                this.n = aux;
            }

            public void set_n(int aux)
            {
                if (aux <= 0) { this.n = 1; return; }
                this.n = aux;
            }

            public void Imprime_Piramede()
            {
                if (this.n == 1)
                {
                    Console.WriteLine("   " + this.n);
                    return;
                }
                for (int i = 1; i <= this.n; i++)
                {
                    for (int j = 1; j <= this.n - i; j++)
                        Console.Write(" ");
                    for (int j = 1; j <= i; j++)
                        Console.Write(j);
                    // Console.WriteLine("j == "+j);
                    for (int j = i - 1; j > 0; j--)
                        Console.Write(j);
                    Console.WriteLine();
                }
            }
        }
    }
}
