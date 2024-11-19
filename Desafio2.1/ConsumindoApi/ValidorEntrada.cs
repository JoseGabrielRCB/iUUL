using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumindoApi
{
    public  class ValidorEntrada
    {
        public ValidorEntrada() { }  
      

        static public bool Valida_Nome(string nome_origem,string nome_destino)
        {
            if(nome_destino == nome_origem) {  return true; }
            return false;    
        }

        static public bool Nome_Empty(string nome_origem)
        {
     
            if (string.IsNullOrEmpty(nome_origem)|| string.IsNullOrWhiteSpace(nome_origem)) {  return true; }
            return false;
        }

        static public bool Valida_valor(double valor) 
        {
            if(valor <= 0) { return true; }
            return false;   
        }
    }
}
