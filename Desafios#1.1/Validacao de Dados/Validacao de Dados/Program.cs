using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Validacao_de_Dados
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Validacao de dados");
            DateTime date;
            string nome,cpf;
            float renda;
            char civil_estado;
            int dependentes;
            while (true)
            {
                while (true)
                {
                    Console.WriteLine("\nInisira o nome do Cliente:");
                    nome = Console.ReadLine();
                    if(nome.Length < 5)
                    {
                        Erro();
                    }
                    else { break;}
                }
                while (true)
                {
                    Console.WriteLine("\nINsira o CPF:");
                    cpf = Console.ReadLine();
                    if (!Valida_CPF(cpf))
                    {
                        Erro();
                    }
                    else { break; }
                }

                while (true)
                {
                    Console.WriteLine("\nInsira a data de nascimento no formato DD/MM/AAAA");
                    date = Convert.ToDateTime(Console.ReadLine());
                    DateTime now = DateTime.Now;
                    if((now.Year - date.Year) < 18)
                    {
                        Erro();
                    }
                    else { break;}
                }

                while (true)
                {
                    Console.WriteLine("\nInsira a renda mensal:");
                    //tring aux = Console.ReadLine();
                    renda = float.Parse(Console.ReadLine());
                    if (renda < 0.0)
                    {
                        Erro();
                    }
                    else { break; }
                }

                while (true)
                {
                    Console.WriteLine("\nInsira o estado civil C,S,V,D");
                    string aux = Console.ReadLine();
                    civil_estado = Convert.ToChar(aux[0]);
                    if (!Estados(civil_estado))
                    { Erro(); }
                    else { break; }
                }

                while (true)
                {
                    Console.WriteLine("\nInsira o numero de dependentes\n");
                    dependentes = Convert.ToInt32(Console.ReadLine());
                    if (dependentes < 0 || dependentes > 10) { Erro(); }
                    else { break; }
                  
                }
                Console.Clear();
                Console.WriteLine("NOme: "+ nome);
                Console.WriteLine("Cpf :" + cpf);
                Console.WriteLine("Data de nascimento: " + date.ToString("dd/MM/yyyy"));
                Console.WriteLine("Renda mensal: " + renda);
                Console.WriteLine("Estado civil:" + civil_estado);
                Console.WriteLine("Numero de dependentes: " + dependentes);
                int loop;
                while (true)
                {
                    Console.WriteLine("\n\n Deseja fazer validacao : 1-sim 0-nao)");
                    loop = Convert.ToInt32(Console.ReadLine());
                    if (loop != 0 && loop != 1) { Erro(); }
                    else { break; }
                }
                if(loop == 0) { break; }

            }

            
        }
        static public bool Valida_CPF(string cpf)
        {
            
            if (cpf.Length != 11)
                return false;
            
            bool flag = false;
            for (int i = 0; i < cpf.Length - 1; i++)
                if (cpf[i] != cpf[i + 1])
                    flag = true;
            if (!flag) return false; 

            int Soma = 0;
            for (int i = 0; i < 9; i++)
                Soma += (cpf[i] - '0') * (10 - i);
            int resto = Soma % 11;
            int Dv1; 
            if( resto < 2) { Dv1 = 0; }
            else { Dv1 = 11 - resto; }
            if (Dv1 != (cpf[9] - '0'))
                return false;
            
            Soma = 0;
            for (int i = 0; i < 10; i++)
                Soma += (cpf[i] - '0') * (11 - i);
            resto = Soma % 11;
            int Dv2;
            if(resto < 2) { Dv2 = 0; }
            else {Dv2 =  11 - resto; }
            
            if (Dv2 != (cpf[10] - '0'))
                return false;
            return true; // Retorna verdadeiro se o CPF e valido
        }

        static public bool Estados(char estado)
        {
            string estados = "CSVD" ;
            for (int i = 0; i < estados.Length -1; i++)
                if(estado == Convert.ToChar(estados[i]))
                    return true;
            return false;
        }

        static void Erro()
        {
            Console.Clear();
            Console.WriteLine("Valor de entrada invalido");
        }


    }
}
