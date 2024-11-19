using ConsumindoApi.Entidades;
using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumindoApi
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            bool flag = false;
            while (!flag)
            {
                string Origem = " ";
                string Destino = " ";
                double valor= 0;
                while (ValidorEntrada.Valida_Nome(Origem,Destino) ||ValidorEntrada.Valida_valor(valor))
                {
                    //sistemas de entrada
                    Console.WriteLine("Informe a moeda de origem");
                    Origem = Console.ReadLine();
                    if (ValidorEntrada.Nome_Empty(Origem))
                    {
                        //Console.WriteLine("Empity");
                        flag = true; 
                        break;
                    }
                    Console.WriteLine("Informe a moeda de destino");
                    Destino = Console.ReadLine();
                    if (ValidorEntrada.Valida_Nome(Origem, Destino))
                    {
                        Console.WriteLine("Necessarios valores diferentes");
                    }
                    Console.WriteLine("Informe o valor a ser convertido");
                    valor = Convert.ToDouble(Console.ReadLine());
                    if (ValidorEntrada.Valida_valor(valor)) { Console.WriteLine("Valor de Entrada Invalido"); }

                }
                if (!flag)
                {
                    //Console.WriteLine("ENTROU");
                    Services ConversaoServices = new Services();
                    Conversion Conversao = await ConversaoServices.Integracao(Origem, Destino);

                    if (!Conversao.Verifica)
                    {
                        double final = Math.Round(valor * Conversao.conversion_rate,2,MidpointRounding.ToEven);
                        
                        Console.WriteLine("Valor de Origem: " + Origem);
                        Console.WriteLine("Valor de Destino: " + Destino);
                        Console.WriteLine("Valor de conversão: " + Conversao.conversion_rate.ToString("F6"));
                        Console.WriteLine("Valor COnvertido: "+Destino+ " " + final.ToString("F2"));
                    }
                }


            }
        }
    }
}
