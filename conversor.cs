using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class HelloWorld {
  static void Main() {
    int tipo;
    bool continuar = true,valido = true;
    string tp = "";
    while(continuar){
        do{
            Console.Clear();
            
            if(!valido)
                Alert("Adicione um valor válido");

            Console.WriteLine("Escolha a base de entrada!\n");
            Console.WriteLine("1 - Decimal");
            Console.WriteLine("2 - Binário");
            Console.WriteLine("3 - Octal");
            valido = int.TryParse(Console.ReadLine(), out tipo);
            
            Console.WriteLine(tipo);
            
            switch(tipo){
                case 1:
                tp = "decimal";
                break;
                
                case 2:
                tp = "Binário";
                break;
                
                case 3:
                tp = "octal";
                break;
                
                default:
                valido = false;
                break;
                
            }
        }while(!valido);
        
        Console.Clear();
        
        Console.WriteLine($"Digite um número na base {tp}: ");
        string numero = Console.ReadLine();
        
        if(tipo == 1){
            Console.WriteLine("Decimal: " + numero);
            Console.WriteLine("Binario: " + FromDecimal(numero,2));
            Console.WriteLine("Octal: " + FromDecimal(numero,8));
        }else if(tipo == 2){
            
            if(!ValidaBase(numero,2)){
                numero = "0";
                Alert("O número digitado não está na base " + tp);
            }
            
            Console.WriteLine("Decimal: " + ToDecimal(numero,2));
            Console.WriteLine("Binario: " + numero);
            Console.WriteLine("Octal: " + FromDecimal(ToDecimal(numero,2).ToString(),8));
        }else if(tipo == 3){
            if(!ValidaBase(numero,8)){
                numero = "0";
                Alert("O número digitado não está na base " + tp);
            }
            Console.WriteLine("Decimal: " + ToDecimal(numero,8));
            Console.WriteLine("Binario: " + FromDecimal(ToDecimal(numero,8).ToString(),2));
            Console.WriteLine("Octal: " + numero);
        }
     
        Console.WriteLine("\n\nDigite qulquer tecla para uma nova consulta ou\n 'N' para encerrar!");
        string sContinua = Console.ReadLine();
        
        if(sContinua == "n" || sContinua == "N")
            continuar = false;
    }
}
    
    public static bool ValidaBase(string num, int bas){
        int j = 0;
        for(int i = 0; i < num.Length; i++){
            if(int.Parse(Char.ToString(num[i])) >= bas)
                j++;
        }
        
        if(j > 0)
            return false;
        else
            return true;
    }
  
    public static double FromDecimal(string entrada, int bas){
        int resto, num = int.Parse(entrada);
        string resultado = "";
        if(num != 0){
            while(num >= 1){
                resto = num % bas;
                num = num / bas;
                resultado += Convert.ToString(resto);
            }
            
            resultado = new string(resultado.Reverse().ToArray());
        }else{
            resultado = "0";
        }
        return double.Parse(resultado);
    }
  
    public static double ToDecimal(string entrada, int bas){
        int[] arrBase;
        double resultado = 0;
        
        arrBase = new int[entrada.Length];
        
        for(int i = 0; i < entrada.Length; i++){
            arrBase[i] = Convert.ToInt32(Char.ToString(entrada[i]));
        }
        
        Array.Reverse(arrBase);
        
        for(int i = 0; i < arrBase.Length; i++){
            resultado += arrBase[i] * Math.Pow(bas,i);
        }
        
        return resultado;
    }
  
    static void Alert(string msg){
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.BackgroundColor = ConsoleColor.White;
        Console.WriteLine(msg);
        Console.ResetColor();
    }
}
