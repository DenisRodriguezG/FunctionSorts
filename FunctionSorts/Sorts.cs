using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionSorts
{
    class Sorts
    {
        private int[] arrayInt;
        private int counter;
        private Tuple <string, double>[] timeOfSorts;
        private int counterTime;
        
        
        public Sorts(int lenghtA)
        {
            arrayInt = new int[lenghtA];
            timeOfSorts = new Tuple<string, double>[20];
            
            counter = 0;
            counterTime = 0;
        }
        public void InsertNumbersA(int size)
        {
            
            
            for (int i = 0; i < size; i++)
            {
                Random numbers = new Random();
                int number = numbers.Next(0, size);
                arrayInt[counter++] = number;
            }

        }
        public void PrintArray()
        {
            
            Console.WriteLine(this);
        }
        public override string ToString()
        {
            string aux = "";
            for (int i = 0; i < counter; i++)
                aux += arrayInt[i] + "  ";
            return aux;
        }
        public void showTime()
        {
            for(int i = 0; i < counterTime; i++)
            {
                Console.WriteLine(timeOfSorts[i].Item2);
            }
        }
        public void timeOfSort(string name, double time)
        {
            Tuple<string, double> addTime = new Tuple<string, double>(name, time);
            timeOfSorts[counterTime++] = addTime;
        }
        public void printTimeOfSorts()
        {
            int menor = 0;
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("                List of sorts");
            Console.WriteLine("-------------------------------------------------");
            for (int i = 0; i < counterTime; i++)
                Console.WriteLine("name: " + timeOfSorts[i].Item1 + ". Time: " + timeOfSorts[i].Item2);

            Console.WriteLine("-------------------------------------------------");
            for (int i = 0; i < counterTime - 1; i++)
            {
                if (timeOfSorts[menor].Item2 > timeOfSorts[i + 1].Item2)
                    menor = i + 1;
            }
            Console.WriteLine("El menor tiempo es: ");
            Console.WriteLine("name: " + timeOfSorts[menor].Item1 + ". Time: " + timeOfSorts[menor].Item2);
        }
        public void SortBurble(int [] Element)
        {
            

            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine();
            bool stopIsSort = false;
            for (int i = 0; i < counter; i++)
            {
                stopIsSort = false;
                for (int j = 0; j < counter - (i + 1); j++)
                {
                    if (Element[j] > Element[j + 1])
                    {
                        int aux = Element[j + 1];
                        Element[j + 1] = Element[j];
                        Element[j] = aux;
                        stopIsSort = true;
                    }
                }
                if (!stopIsSort)
                {
                    return;
                }
                    
            }
            
          
        }

        public void SortInsercion(int [] Element)
        {
            

            for (int i = 1; i < counter; i++)
            {
                int clave = Element[i];
                for (int j = i - 1; j >= 0; j--)
                {
                    if (Element[j] > clave)
                    {
                        Element[j + 1] = Element[j];
                        Element[j] = clave;
                    }

                }
            }
            Console.WriteLine();
            Console.WriteLine();
            
        }

        public void SortSeleccion(int [] Element)
        {
            

            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------");
            
            for (int i = 0; i < counter - 1; i++)
            {
                
                int menor = i;
                for (int j = i + 1; j < counter; j++)
                {
                    // int lessNumber = Element[j - 1];
                    if (Element[menor] > Element[j])
                    {
                        
                        menor = j;
                        
                    }
                }
                
                int aux = Element[i];
                Element[i] = Element[menor];
                Element[menor] = aux;
            }

            
        }

        public void Menu()
        {
                int option = 0;
                do
                {

                Console.WriteLine();
                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine("                  Sorts");
                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine("1. Enter the count of numbers do you want");
                    Console.WriteLine("2. Sort Burble");
                    Console.WriteLine("3. Sort Inserción");
                    Console.WriteLine("4. Sort Selección");
                    Console.WriteLine("5. Show the array");
                Console.WriteLine("6. See time of Sort in each sort");
                    Console.WriteLine("7. Exit");
                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine("Choose one of the options: ");
                try
                {
                    option = int.Parse(Console.ReadLine());
                }catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                
                
                    switch (option)
                    {
                        case 1:
                            int n;
                            Console.WriteLine("How many numbers do you want?: ");
                            n = int.Parse(Console.ReadLine());
                            InsertNumbersA(n);
                            break;
                    case 2:
                        int[] Element = new int[counter];
                        Stopwatch T1 = new Stopwatch();
                        

                        for (int i = 0; i < counter; i++)
                            Element[i] = arrayInt[i];

                        for (int i = 0; i < counter; i++)
                            Console.Write(Element[i] + " ");
                        T1.Start();
                        SortBurble(Element);
                        T1.Stop();
                        
                        timeOfSort("Burble", T1.ElapsedTicks);
                        for (int i = 0; i < Element.Length; i++)
                            Console.Write(Element[i] + " ");
                        break;
                    case 3:
                        int[] Element2 = new int[counter];
                        Stopwatch T2 = new Stopwatch();

                        for (int i = 0; i < counter; i++)
                            Element2[i] = arrayInt[i];

                        for (int i = 0; i < counter; i++)
                            Console.Write(Element2[i] + " ");

                        T2.Start();
                        SortInsercion(Element2);
                        T2.Stop();
                        timeOfSort("Inserción", T2.ElapsedTicks);
                        for (int i = 0; i < Element2.Length; i++)
                            Console.Write(Element2[i] + " ");
                        break;
                    case 4:
                        int[] Element3 = new int[counter];

                        Stopwatch T3 = new Stopwatch();

                        for (int i = 0; i < counter; i++)
                            Element3[i] = arrayInt[i];

                        for (int i = 0; i < counter; i++)
                            Console.Write(Element3[i] + " ");

                        T3.Start();
                        SortSeleccion(Element3);
                        T3.Stop();

                        timeOfSort("Selección", T3.ElapsedTicks);

                        for (int i = 0; i < Element3.Length; i++)
                            Console.Write(Element3[i] + " ");
                        break;
                        case 5:
                            PrintArray();
                            break;
                    case 6:
                        printTimeOfSorts();
                        break;
                        case 7:
                            Console.WriteLine("See you");
                            break;
                    }
            } while (option != 7);
            
        }
    }
}
