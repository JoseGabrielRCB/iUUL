using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Armstrong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Projeto Armstrong
            Console.WriteLine("\nNumero de Armstrong");
            Console.WriteLine("Numero: 153");
            if (isArmstrong(153)) { Console.WriteLine("Numero Armstrong"); } else { Console.WriteLine("Numero nao Arsmtrong"); }
            Console.WriteLine("Numero: 154");
            if (isArmstrong(154)) { Console.WriteLine(" Numero Armstrong"); } else { Console.WriteLine("Numero nao Arsmtrong"); }
            Console.WriteLine("Imprime os 1000 primeiros Arsmtrongs: ");
            Imprime_1000_Armstrong();
            Console.ReadLine();
        }

        // Projeto Numeros de Armstrong
        static bool isArmstrong(int numero)
        {
            int soma = 0;
            int temp = numero;
            int digitos = numero.ToString().Length;
            while (temp > 0)
            {
                int digito = temp % 10;
                soma += (int)Math.Pow(digito, digitos);
                temp /= 10;
            }
            if (numero == soma) { return true; } else { return false; }
        }

        static void Imprime_1000_Armstrong()
        {
            for (int i = 0; i < 1000; i++)
                if (isArmstrong(i))
                    Console.Write(i + " ");
        }




    }
}
