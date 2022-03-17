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
        private Tuple <string, TimeSpan>[] timeOfSorts;
        private int counterTime;
        private int max;
        
        public Sorts(int lenghtA)
        {
            arrayInt = new int[lenghtA];
            timeOfSorts = new Tuple<string, TimeSpan>[20];
            max = lenghtA;
            counter = 0;
            counterTime = 0;
        }
        public Sorts(Sorts Aux)
        {
            
            this.arrayInt = new int[Aux.counter];
            this.counter = 0;
            for (int i = 0; i < Aux.counter; i++)
                this.arrayInt[this.counter++] = Aux.arrayInt[i];

        }
        public bool IsEmpty()
        {
            return counter == 0;
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
        public void timeOfSort(string name, TimeSpan time)
        {
            Tuple<string, TimeSpan> addTime = new Tuple<string, TimeSpan>(name, time);
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
        public void SortBurble(Sorts Aux)
        {
            

            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine();
            bool stopIsSort = false;
            for (int i = 0; i < Aux.counter; i++)
            {
                stopIsSort = false;
                for (int j = 0; j < Aux.counter - (i + 1); j++)
                {
                    if (Aux.arrayInt[j] > Aux.arrayInt[j + 1])
                    {
                        int temp = Aux.arrayInt[j + 1];
                        Aux.arrayInt[j + 1] = Aux.arrayInt[j];
                        Aux.arrayInt[j] = temp;
                        stopIsSort = true;
                    }
                }
                if (!stopIsSort)
                {
                    return;
                }
                    
            }
            
          
        }

        public void SortInsercion(Sorts Aux)
        {
            

            for (int i = 1; i < Aux.counter; i++)
            {
                int clave = Aux.arrayInt[i];
                for (int j = i - 1; j >= 0; j--)
                {
                    if (Aux.arrayInt[j] > clave)
                    {
                        Aux.arrayInt[j + 1] = Aux.arrayInt[j];
                        Aux.arrayInt[j] = clave;
                    }

                }
            }
            Console.WriteLine();
            Console.WriteLine();
            
        }

        public void SortSeleccion(Sorts Aux)
        {
            

            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------");
            
            for (int i = 0; i < Aux.counter - 1; i++)
            {
                
                int menor = i;
                for (int j = i + 1; j < Aux.counter; j++)
                {
                    // int lessNumber = Element[j - 1];
                    if (Aux.arrayInt[menor] > Aux.arrayInt[j])
                    {
                        
                        menor = j;
                        
                    }
                }
                
                int temp = Aux.arrayInt[i];
                Aux.arrayInt[i] = Aux.arrayInt[menor];
                Aux.arrayInt[menor] = temp;
            }

            
        }

        // Sorts a (portion of an) array, divides it into partitions, then sorts those
        public void QuickSort(Sorts A, int lo, int hi)
        {
            int p = 0;

            //Ensure indices are in correct order
            if (lo >= hi || lo < 0)
                return;

            //Partition array and get the pivot index
            p = Partition(A, lo, hi);

            //Sort the two partitions
            QuickSort(A, lo, p - 1);
            QuickSort(A, p + 1, hi);
        }

        public int Partition(Sorts A, int lo, int hi)
        {
            int pivot = 0, i = 0;
            pivot = A.arrayInt[hi];//Choose the last element as the pivot

            //Tempory pivot index
            i = lo - 1;
            
            for (int j = lo; j < (hi); j++)
            {
                int Aux;
                //If the current element is less than or equal to the pivot
                if (A.arrayInt[j] <= pivot)
                {
                    i = i + 1;
                    //Swap the current element with the element at the temporary pivot index
                    Aux = A.arrayInt[i];
                    A.arrayInt[i] = A.arrayInt[j];
                    A.arrayInt[j] = Aux;

                }
            }
            //move the pivot element to the correct pivot position (between the smaller and larger elements
            i = i + 1;
            int Aux2;
            Aux2 = A.arrayInt[i];
            A.arrayInt[i] = A.arrayInt[hi];
            A.arrayInt[hi] = Aux2;
            return i;

        }



        public void printArray(Sorts Aux)
        {
            for (int i = 0; i < Aux.counter; i++)
                Console.Write(Aux.arrayInt[i] + " ");
        }
        public void AllSorts()
        {
            Stopwatch Times = new Stopwatch();
            Sorts Distribucion1 = new Sorts(this);
            Sorts Distribucion2 = new Sorts(this);
            Sorts Distribucion3 = new Sorts(this);
            Sorts Distribucion4 = new Sorts(this);
            Sorts Distribucion5 = new Sorts(this);
            Console.WriteLine("------------------------------------");
            Console.WriteLine("       Sort Burble");
            Console.WriteLine("------------------------------------");

            printArray(Distribucion1);

            Times.Start();
            SortBurble(Distribucion1);
            Times.Stop();

            timeOfSort("Burble", Times.Elapsed);
            printArray(Distribucion1);

            Console.WriteLine("------------------------------------");
            Console.WriteLine("       Sort insercion");
            Console.WriteLine("------------------------------------");

            printArray(Distribucion2);

            Times.Start();
            SortInsercion(Distribucion2);
            Times.Stop();

            timeOfSort("Inserción", Times.Elapsed);
            printArray(Distribucion2);

            Console.WriteLine("------------------------------------");
            Console.WriteLine("       Sort selección");
            Console.WriteLine("------------------------------------");

            printArray(Distribucion3);

            Times.Start();
            SortBurble(Distribucion3);
            Times.Stop();

            timeOfSort("Selección", Times.Elapsed);
            printArray(Distribucion3);

            Console.WriteLine();
            Console.WriteLine();
            printTimeOfSorts();

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
                    Console.WriteLine("5. QuickSort");
                    Console.WriteLine("6. Show the array");
                    Console.WriteLine("7. See time of Sort in each sort");
                    Console.WriteLine("8. All Sorts");
                    Console.WriteLine("9. Exit");
                    Console.WriteLine("-----------------------------------------");
                    Console.Write("Choose one of the options: ");
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
                        Console.Write("How many numbers do you want?: ");
                        try
                        {
                            n = int.Parse(Console.ReadLine());
                            InsertNumbersA(n);

                        }
                        catch(Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 2:
                        if (IsEmpty())
                            Console.WriteLine("The array is empty");
                        else
                        {
                            Sorts Distribucion1 = new Sorts(this);
                            Stopwatch T1 = new Stopwatch();

                            printArray(Distribucion1);

                            T1.Start();
                            SortBurble(Distribucion1);
                            T1.Stop();

                            timeOfSort("Burble", T1.Elapsed);
                            printArray(Distribucion1);
                        }
                        break;
                    case 3:
                        if (IsEmpty())
                            Console.WriteLine("The array is empty");
                        else
                        {
                            Sorts Distribucion2 = new Sorts(this);
                            Stopwatch T2 = new Stopwatch();

                            printArray(Distribucion2);

                            T2.Start();
                            SortInsercion(Distribucion2);
                            T2.Stop();

                            timeOfSort("Inserción", T2.Elapsed);
                            printArray(Distribucion2);
                        } 
                        break;
                    case 4:
                        if (IsEmpty())
                            Console.WriteLine("The array is empty");
                        else
                        {
                            Sorts Distribucion3 = new Sorts(this);
                            Stopwatch T3 = new Stopwatch();

                            printArray(Distribucion3);

                            T3.Start();
                            SortSeleccion(Distribucion3);
                            T3.Stop();

                            timeOfSort("Selección", T3.Elapsed);
                            printArray(Distribucion3);
                        }
                        break;
                    case 5:
                        if (IsEmpty())
                            Console.WriteLine("The array is empty");
                        else
                        {
                            Sorts Distribucion4 = new Sorts(this);
                            Stopwatch T4 = new Stopwatch();

                            printArray(Distribucion4);

                            T4.Start();
                            QuickSort(Distribucion4, 0, Distribucion4.arrayInt.Length-1);
                            T4.Stop();
                            Console.WriteLine();
                            timeOfSort("QuickSort", T4.Elapsed);
                            printArray(Distribucion4);
                        }
                        break;
                    case 6:
                        Console.WriteLine("---------------------------------");
                        if (IsEmpty())
                            Console.WriteLine("The array is empty");
                        else
                            PrintArray();
                            break;
                    case 7:
                        if (IsEmpty())
                            Console.WriteLine("The array is empty");
                        else
                            printTimeOfSorts();
                        break;
                    case 8:
                        AllSorts();
                        break;
                    case 9:
                        Console.WriteLine("See you");
                        break;
                    default:
                        Console.WriteLine("That option not exist");
                        break;
                    }
            } while (option != 9);
            
        }
    }
}
