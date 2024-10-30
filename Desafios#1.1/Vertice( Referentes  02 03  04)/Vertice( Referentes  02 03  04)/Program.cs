using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vertice__Referentes__02_03__04_
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("\n\nProjeto Vertice 01:");
            Vertice V1 = new Vertice(12.45, 14.7);
            Vertice V2 = new Vertice(34.45, 55.90);
            Console.WriteLine(" Valores V1 \n X1: " + V1.getX() + "\n Y1: " + V1.getY());
            Console.WriteLine(" Valores V2 \n X2: " + V2.getX() + "\n Y2: " + V2.getY());
            if (V1 == V2) { Console.WriteLine(" Vertice Iguais"); } else { Console.WriteLine("Valores diferentes"); }
            if (V1 != V2) { Console.WriteLine("Valores Difernetes"); } else { Console.WriteLine("Valores iguais"); }
            Vertice V3 = V1;
            if (V3 == V1) { Console.WriteLine("V3  ==  v1"); } else { Console.WriteLine("V3 != V1"); }
            double diff = V1 - V2;
            Console.WriteLine("Diferença dos pontos: " + diff.ToString("F2"));


            //Projeto Vertice 02
            Console.WriteLine("\nTriangulo: V1 = (0,0) V2(4,0) V3(2,3)");
            V1 = new Vertice(0, 0);
            V2 = new Vertice(4, 0);
            V3 = new Vertice(2, 3);
            Triangulo T1 = new Triangulo(V3, V1, V2);
            Console.WriteLine("Area: " + T1.get_Area().ToString("F3"));
            Console.WriteLine("Perimetro: " + T1.get_Perimetro().ToString("F3"));
            Console.WriteLine("Lado AB: " + T1.get_Lado_AB().ToString("F3"));
            Console.WriteLine("Lado BC: " + T1.get_Lado_BC().ToString("F3"));
            Console.WriteLine("Lado CA: " + T1.get_Lado_CA().ToString("F3"));
            Console.WriteLine("Tipo do triangulo: " + T1.get_Type_Name());


            //Projeto Vertice 03 Poligno
            Console.WriteLine("\nPoligno: ");
            Console.WriteLine("Triangulo: V1 = (0,0) V2(4,0) V3(2,3)");
            Poligno P1 = new Poligno(10, V1, V2, V3); // neste caso ,usario deve entrar com o valor do vetor, ele n é dinamico
            Console.WriteLine("Tentar Remover vertice(fica com menos 3)");
            P1.RemoveVertice(V3);
            Console.WriteLine("Adcionar Valor igual");
            if (P1.AddVertice(V1)) { Console.WriteLine("Valor Adcionado"); } else { Console.WriteLine("Erro de adicao"); }
            Console.WriteLine("Adciona Um valor qualquer: V4(3,4)");
            Vertice V4 = new Vertice(3, 4);
            if (P1.AddVertice(V4)) { Console.WriteLine("Valor Adcionado"); } else { Console.WriteLine("Erro de adicao"); }
            Console.WriteLine("Perimetro: " + P1.Perimetro().ToString("F4"));
            Console.WriteLine("Quantidade de Pontos: " + P1.Get_quant());
            Console.ReadLine();
        }


        //classe vertice 
        class Vertice
        {
            double x, y;
            public Vertice(double x, double y)
            {
                this.x = x;
                this.y = y;
            }

            public Vertice(Vertice a)
            {
                this.x = a.getX();
                this.y = a.getY();
            }

            public double getX() { return x; }
            public double getY() { return y; }

            public void Move(double x_, double _y)
            {
                this.x += x_;
                this.y += _y;
            }

            public bool Equal(Vertice x2)
            {
                if (x2.x == x)
                    if (x2.y == y)
                        return true;
                return false;
            }

            public static double operator -(Vertice a, Vertice b)
            {
                return Math.Sqrt(Math.Pow(a.x - b.x, 2) + Math.Pow(a.y - b.y, 2));

            }

            public override bool Equals(object obj)
            {
                return obj is Vertice vertice &&
                       x == vertice.x &&
                       y == vertice.y;
            }



            public override int GetHashCode()
            {
                int hashCode = 1502939027;
                hashCode = hashCode * -1521134295 + x.GetHashCode();
                hashCode = hashCode * -1521134295 + y.GetHashCode();
                return hashCode;
            }
        }

        class Triangulo
        {
            enum Forms
            {

                equlatero,
                isoiceles,
                escaleno

            }

            Vertice[] pontos = new Vertice[3];//A->B->C->Fecha triangulo
            double AB, BC, CA, Per, Ar;
            string name_type;
            public Triangulo(Vertice point, Vertice point2, Vertice point3)  //
            {
                double p1 = point.getX() * (point2.getY() - point3.getY()),
                       p2 = point2.getX() * (point3.getY() - point.getY()),
                       p3 = point3.getX() * (point.getY() - point2.getY());
                //Console.WriteLine("P1: "+p1+"P2: "+p2 + "P3: "+p3);

                double Colinear = (1.0 / 2.0) * Math.Abs(p1 + p2 + p3);  // nescessario deixar como 1.0 e 2.0 para forcar float  
                                                                         // Console.WriteLine("Valor colinear:"+Colinear.ToString("F4"));

                if (Colinear != 0)
                {
                    pontos[0] = point; // Ponto a
                    pontos[1] = point2; //  ponto b
                    pontos[2] = point3; // ponto c
                    Lados();
                    Perimetro();
                    Tipo();
                    Area();
                    return;
                }
                Console.WriteLine("Valores de entrada INvalidos");
                pontos[0] = new Vertice(0, 0); // Ponto a
                pontos[1] = new Vertice(0, 0); // ponto b
                pontos[2] = new Vertice(0, 0);  // ponto c
                Lados();
                Perimetro();
                this.name_type = "NULO";
                Area();
            }

            void Lados()
            {
                this.AB = pontos[0] - pontos[1];
                this.BC = pontos[1] - pontos[2];
                this.CA = pontos[2] - pontos[0];
            }

            void Tipo()
            {
                // 1 -> Equilatero
                //2 -> Isosciles
                //3 -> escaleno
                if (this.AB == this.BC && this.AB == this.CA)
                    this.name_type = Forms.equlatero.ToString(); //equilatero
                if (this.AB != this.BC && (this.AB != this.CA) && this.BC != this.CA)
                    this.name_type = Forms.escaleno.ToString(); // escaleno
                this.name_type = Forms.escaleno.ToString();// Isosciles
            }

            void Perimetro()
            {
                this.Per = this.AB + this.BC + this.CA;
            }

            void Area()
            {
                double S = this.Per / 2.0; //separa a formula para entender melhor
                double Sa = S - this.AB,
                       Sb = S - this.BC,
                       Sc = S - this.CA;
                this.Ar = Math.Sqrt(S * Sa * Sb * Sc); //salva valor final
            }

            public override bool Equals(object obj)
            {
                return obj is Triangulo triangulo &&
                       base.Equals(obj) &&
                       EqualityComparer<Vertice[]>.Default.Equals(pontos, triangulo.pontos);
            }

            public override int GetHashCode()
            {
                int hashCode = -458776118;
                hashCode = hashCode * -1521134295 + base.GetHashCode();
                hashCode = hashCode * -1521134295 + EqualityComparer<Vertice[]>.Default.GetHashCode(pontos);
                return hashCode;
            }

            //get e sets
            // A->B->C-> A....(triangulo ABC)
            public Vertice get_vert(int index) { return pontos[index]; }
            public double get_Perimetro() { return Per; }
            public double get_Area() { return this.Ar; }
            public double get_Lado_AB() { return this.AB; }
            public double get_Lado_BC() { return this.BC; }
            public double get_Lado_CA() { return this.CA; }
            public string get_Type_Name() { return this.name_type; }
        }
        //Projeto Poligno
        class Poligno
        {
            Vertice[] pontos;
            int index, quant;
            public Poligno(int index, Vertice p1, Vertice p2, Vertice p3)
            {
                if (index < 3 || p1 == p2 || p1 == p3 || p3 == p2)
                {
                    Console.WriteLine("Valor de entrada invalido");
                    return;
                }
                this.pontos = new Vertice[index];
                this.index = index;
                this.pontos[0] = p1; this.pontos[1] = p2; this.pontos[2] = p3;
                this.quant = 3;
            }

            public bool AddVertice(Vertice point)
            {
                bool flag = false;
                for (int i = 0; i < quant; i++)
                    if (point == this.pontos[i])
                        flag = true;
                if ((this.quant) + 1 > this.index || flag)
                {
                    return false;
                }
                this.quant++;
                this.pontos[quant - 1] = point;
                return true;
            }

            public bool RemoveVertice(Vertice point)
            {
                if ((this.quant) - 1 < 3)
                {
                    Console.WriteLine("Erro de remocao");
                    return false;
                }
                for (int i = 0; i < this.pontos.Length; i++)
                {
                    if (this.pontos[i] == point)
                    {
                        //this.pontos[i]=null;
                        for (int j = i; j < this.pontos.Length; j++)
                        {
                            if (j == this.pontos.LongLength)
                                this.pontos[i] = null;
                            else
                                this.pontos[i] = this.pontos[i + 1];
                        }
                        this.quant--;
                        return false;
                    }
                }
                return false;
            }

            public double Perimetro()
            {
                double aux = 0.0;
                for (int i = 0; i < quant - 1; i++)
                {
                    aux = this.pontos[i] - this.pontos[i + 1];
                }
                return aux;
            }

            public int Get_quant()
            {
                return this.quant;
            }


        }

    }
}
