using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intervalo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Projeto Intervalo
            Console.WriteLine("Insira data,hora de inicio, respectivamente separados por espaço:\n");
            int[] date = new int[2];
            for (int i = 0; i < date.Length; i++)
                date[i] = Convert.ToInt32(Console.ReadLine());
            DateTime Inicio = new DateTime(0001, 01, date[0], date[1], 0, 0);
            Console.WriteLine("Insira dia,hora de termino , respectivamente separados por espaço:\n");
            for (int i = 0; i < date.Length; i++)
                date[i] = Convert.ToInt32(Console.ReadLine());
            DateTime Fim = new DateTime(0001, 01, date[0], date[1], 0, 0);
            Intervalo comp = new Intervalo(Inicio, Fim);
            DateTime aux_Ini = new DateTime(0001, 01, 3, 12, 0, 0), aux_fim = new DateTime(0001, 01, 3, 13, 0, 0);
            Intervalo aux = new Intervalo(aux_Ini, aux_fim);
            Console.WriteLine("Valor de comparação: \n Inicio :" + aux_Ini.ToString() + "\nFim: " + aux_fim.ToString());
            Console.WriteLine("Os valores Tem INtersexão:\n");
            if (Intervalo.TemIntersecao(aux, comp)) { Console.WriteLine("Valores Tem Intersexão"); } else { Console.WriteLine("Sem Intersexao"); }
            ListaIntervalo L1 = new ListaIntervalo();
            Console.WriteLine("\nLista de INtervalos");

            // parte de listas de intervalo nao funcionando
            Console.WriteLine("ARRUMAR ESSA PARTE");
            /*L1.Push(comp);
            L1.Push(aux);
            Fim = new DateTime(0001, 01, 25, 7, 0, 0);
            Ini = new DateTime(0001, 01, 25, 8, 0, 0);
            aux = new Intervalo(Inicio, Fim);
            L1.Push(comp);
            L1.Imprime();*/
            Console.ReadLine();
        }


        //Projeto INtervalo
        class Intervalo
        {
            DateTime Inicio, Fim;
            double diferenca;

            public Intervalo(DateTime Inicio, DateTime Fim)
            {
                if (Inicio > Fim)
                {
                    Console.WriteLine("ERRO DE ENTRADA\n");
                    return;
                }
                this.Inicio = Inicio;
                this.Fim = Fim;
            }

            public Intervalo(Intervalo a)
            {
                if (a.Inicio > a.Fim)
                {
                    Console.WriteLine("ERRO de ENTRADa\n");
                    return;
                }
                this.Fim = a.Fim;
                this.Inicio = a.Inicio;
            }

            public DateTime get_Inicio() { return Inicio; }
            public DateTime get_Fim() { return Fim; }
            static public bool Equal(DateTime a, DateTime b)
            {
                if (a == b) return true;
                return false;
            }

            static public bool TemIntersecao(Intervalo a, Intervalo b)
            {
                return (a.get_Inicio() < b.get_Fim() && a.get_Fim() > b.get_Inicio());
            }


        }

        class ListaIntervalo
        {
            private List<Intervalo> intervaloList = new List<Intervalo>();
            public ListaIntervalo(Intervalo a)
            {
                this.intervaloList.Add(a);
            }

            public ListaIntervalo() { }

            public void Push(Intervalo novo)
            {
                this.intervaloList.Add(novo);
            }

            public void Pop(Intervalo old)
            {
                this.intervaloList.Remove(old);
            }

            void ordena()
            {
                this.intervaloList.Sort();
            }


        }
    }
}
