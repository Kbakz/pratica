using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int conversor;
            bool continuar = true;
            
            while(continuar){
              do{
                Console.WriteLine("1 - Decimal para binário\n2 - binário para decimal");
                conversor = int.Parse(Console.ReadLine());
              }while(conversor < 1 && conversor > 2); //Corrigir essa linha
            }
        }
    }
}
