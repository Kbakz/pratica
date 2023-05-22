using System;
using System.Linq;
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
            Console.WriteLine("4 - Hexadecimal");
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
                
                case 4:
                tp = "hexadecimal";
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
            if(!ValidaBase(numero,10)){
                numero = "0";
                Alert("O número digitado não está na base " + tp);
            }
            Console.WriteLine("Decimal: " + numero);
            Console.WriteLine("Binario: " + FromDecimal(numero,2));
            Console.WriteLine("Octal: " + FromDecimal(numero,8));
            Console.WriteLine("Hexadecimal: " + FromDecimal(numero,16));
        }else if(tipo == 2){
            
            if(!ValidaBase(numero,2)){
                numero = "0";
                Alert("O número digitado não está na base " + tp);
            }
            
            Console.WriteLine("Decimal: " + ToDecimal(numero,2));
            Console.WriteLine("Binario: " + numero);
            Console.WriteLine("Octal: " + FromDecimal(ToDecimal(numero,2),8));
            Console.WriteLine("Hexadecimal: " + FromDecimal(ToDecimal(numero,2),16));
        }else if(tipo == 3){
            if(!ValidaBase(numero,8)){
                numero = "0";
                Alert("O número digitado não está na base " + tp);
            }
            Console.WriteLine("Decimal: " + ToDecimal(numero,8));
            Console.WriteLine("Binario: " + FromDecimal(ToDecimal(numero,8),2));
            Console.WriteLine("Octal: " + numero);
            Console.WriteLine("Hexadecimal: " + FromDecimal(ToDecimal(numero,8),16));
        }else if(tipo == 4){
            if(!ValidaBase(numero,16)){
                numero = "0";
                Alert("O número digitado não está na base " + tp);
            }
            Console.WriteLine("Decimal: " + ToDecimal(numero,16));
            Console.WriteLine("Binario: " + FromDecimal(ToDecimal(numero,16),2));
            Console.WriteLine("Octal: " + FromDecimal(ToDecimal(numero,16),8));
            Console.WriteLine("Hexadecimal: " + numero);
        }
     
        Console.WriteLine("\n\nDigite qulquer tecla para uma nova consulta ou\n 'N' para encerrar!");
        string sContinua = Console.ReadLine();
        
        if(sContinua == "n" || sContinua == "N")
            continuar = false;
    }
}
    
    public static bool ValidaBase(string num, int bas){
        int j = 0;
        string[] check = new string[num.Length];
        int[] intCheck = new int[num.Length];
        bool retorno;
        for(int i = 0; i < num.Length; i++){
            check[i] = Char.ToString(num[i]);
            switch(check[i]){
                case "A":
                check[i] = "10";
                break;
                case "B":
                check[i] = "11";
                break;
                case "C":
                check[i] = "12";
                break;
                case "D":
                check[i] = "13";
                break;
                case "E":
                check[i] = "14";
                break;
                case "F":
                check[i] = "15";
                break;
                case "a":
                check[i] = "10";
                break;
                case "b":
                check[i] = "11";
                break;
                case "c":
                check[i] = "12";
                break;
                case "d":
                check[i] = "13";
                break;
                case "e":
                check[i] = "14";
                break;
                case "f":
                check[i] = "15";
                break;
                
            }
            
            retorno = int.TryParse(check[i], out intCheck[i]);
            if(!retorno)
                j++;
            else if(intCheck[i] >= bas)
                j++;
        }
        
        if(j > 0)
            return false;
        else
            return true;
    }
  
    public static string FromDecimal(string entrada, int bas){
        int resto, num = int.Parse(entrada);
        string resultado = "", check;
        if(num != 0){
            while(num >= 1){
                resto = num % bas;
                num = num / bas;
                check = resto.ToString();
                switch(check){
                    case "10":
                    check = "A";
                    break;
                    case "11":
                    check = "B";
                    break;
                    case "12":
                    check = "C";
                    break;
                    case "13":
                    check = "D";
                    break;
                    case "14":
                    check = "E";
                    break;
                    case "15":
                    check = "F";
                    break;
                }
                resultado += check;
            }
            
            resultado = new string(resultado.Reverse().ToArray());
        }else{
            resultado = "0";
        }
        return resultado;
    }
  
    public static string ToDecimal(string entrada, int bas){
        int[] arrBase;
        string[] arrCheck;
        double resultado = 0;
        
        arrBase = new int[entrada.Length];
        arrCheck = new string[entrada.Length];
        
        for(int i = 0; i < entrada.Length; i++){
            arrCheck[i] = Char.ToString(entrada[i]);
            switch(arrCheck[i]){
                case "A":
                arrCheck[i] = "10";
                break;
                case "B":
                arrCheck[i] = "11";
                break;
                case "C":
                arrCheck[i] = "12";
                break;
                case "D":
                arrCheck[i] = "13";
                break;
                case "E":
                arrCheck[i] = "14";
                break;
                case "F":
                arrCheck[i] = "15";
                break;
                case "a":
                arrCheck[i] = "10";
                break;
                case "b":
                arrCheck[i] = "11";
                break;
                case "c":
                arrCheck[i] = "12";
                break;
                case "d":
                arrCheck[i] = "13";
                break;
                case "e":
                arrCheck[i] = "14";
                break;
                case "f":
                arrCheck[i] = "15";
                break;
            }
            
            arrBase[i] = int.Parse(arrCheck[i]);
            
        }
        
        Array.Reverse(arrBase);
        
        for(int i = 0; i < arrBase.Length; i++){
            resultado += arrBase[i] * Math.Pow(bas,i);
        }
        
        return resultado.ToString();
    }
  
    static void Alert(string msg){
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.BackgroundColor = ConsoleColor.White;
        Console.WriteLine(msg);
        Console.ResetColor();
    }
}
