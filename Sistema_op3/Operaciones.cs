using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_op3
{
   public class Operaciones
    {
        //Calculo del factorial
        public long Factorial(int numero)
        {
            long numero_Inicio = 1;

            for (int i = 1; i <= numero; i++)
            {
                numero_Inicio *= i;
                
            }

            return numero_Inicio;
        }


        //Calculo de Fibonacci
        public int Fibonacci(int n)
        {

            if ((n == 1) || (n == 2))
            {
                return 1;
            }
            else
            { 
                return Fibonacci(n - 1) + Fibonacci(n - 2);
            }
        }
        ///Final del calculo
    }
}
