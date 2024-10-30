using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certidão
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Projeto Certidao
            Console.WriteLine("Certidao");
            Console.WriteLine("\nPessoa com Certidao");
            Pessoa Pessoa1 = new Pessoa(DateTime.Now, "Jose gabriel");
            Console.WriteLine("Data de certtidao: " + (Pessoa1.getId().getDate().ToString("dd - MM - yyyy")));
            Console.WriteLine("Nome: " + Pessoa1.getnome());
            Console.WriteLine("\nRegistro pessoa sem certidao");
            Pessoa1 = new Pessoa("Roberto");
            Console.WriteLine("Date de certificado: " + Pessoa1.getId().getDate().ToString("dd - MM - yyyy"));
            Console.WriteLine("Nome: " + Pessoa1.getnome());
            Console.ReadLine();
        }

        class Certidao
        {
            DateTime date;
            public Certidao(DateTime aux)
            {
                this.date = aux;
            }

            public Certidao() { }
            public DateTime getDate() { return date; }

        }

        class Pessoa
        {
            string nome;
            Certidao id;
            bool flag;
            public Pessoa(DateTime date, string nome)
            {
                this.nome = nome;
                this.id = new Certidao(date);
                this.flag = true;
            }
            public Pessoa(string nome) { this.nome = nome; flag = false; }

            public Certidao getId()
            {
                if (this.flag)
                    return this.id;
                DateTime aux = new DateTime(0001, 01, 1, 0, 0, 0);
                Certidao temp = new Certidao();
                return temp;
            }
            public string getnome() { return nome; }

        }
    }
}
