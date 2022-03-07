using System;
using System.Diagnostics;

namespace FunctionSorts
{
    class Program
    {
        static void Main(string[] args)
        {
            Sorts C1 = new Sorts(1000);

           
            C1.Menu();

            //C1.Menu();
            
            
            /*Tuple<string, int>[] T1 = new Tuple<string, int>[100];
            Tuple<string, int> Time1;
            Tuple<string, int> Time2;
            
            Time1 = new Tuple<string, int>("Burble", 4);
            Time2 = new Tuple<string, int>("Seleccion", 4);
            T1[0] = Time1;
            T1[1] = Time2;
            for (int i = 0; i < T1.Length; i++)
                Console.WriteLine(T1[i].Item2);*/

          /*  Stopwatch T1 = new Stopwatch();
            T1.Start();
            for(int i = 0; i < 1000; i++)
                Console.WriteLine(i);

            T1.Stop();
            
            Console.WriteLine(T1.ElapsedMilliseconds);*/

            
        }
    }
}