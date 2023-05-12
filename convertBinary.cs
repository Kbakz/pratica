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
    bool continuar = true,tipo;
    
    while(continuar){
        do{
            Console.WriteLine("1 - Decimal para binário\n2 - Binário para decimal");
            conversor = int.Parse(Console.ReadLine());
            if(conversor < 1 && conversor > 2)
                tipo = true;
            else
                tipo = false;
        }while(tipo);
       
        Console.Clear();
        
        if(conversor == 1){
            Console.WriteLine("Conversor de decimal para binário!\n");
            
            int num,resto;
            string resultado = "";
            
            Console.Write("Digite um número: ");
            num = int.Parse(Console.ReadLine());
            
            while(num >= 1){
                resto = num % 2;
                num = num / 2;
                resultado += Convert.ToString(resto);
            }
            
            resultado = new string(resultado.Reverse().ToArray());
            Console.Write(resultado);
           
        }else{
            Console.WriteLine("Conversor de binário para decimal!\n");
            
            int[] binario;
            double resultado = 0;
            string entrada;
            
            Console.Write("Digite um número em binário: ");
            entrada = Console.ReadLine();
            
            binario = new int[entrada.Length];
            
            for(int i = 0; i < entrada.Length; i++){
                binario[i] = Convert.ToInt32(Char.ToString(entrada[i]));
            }
            
            Array.Reverse(binario);
            
            for(int i = 0; i < binario.Length; i++){
                resultado += binario[i] * Math.Pow(2,i);
            }
            
            Console.WriteLine(resultado);
        }
        
        Console.WriteLine("\n\nDigite qulquer tecla para uma nova consulta ou\n 'N' para encerrar!");
        string sContinua = Console.ReadLine();
        if(sContinua == "n" || sContinua == "N")
            continuar = false;
    }
        }
    }
}
