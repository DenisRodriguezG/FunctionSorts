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
        private Tuple <string ,string, TimeSpan>[] timeOfSorts;
        private int counterTime;
        private int max;
        private int burbuja = 0;
        private int insercion;
        private int seleccion;
        private int quicksort;
        private int mergesort;
        private int heapsort;
        private int allSorts;
        private int seleccionado = 0;
        
        public Sorts(int lenghtA)
        {
            arrayInt = new int[lenghtA];
            timeOfSorts = new Tuple<string ,string, TimeSpan>[18];
            max = lenghtA;
            counter = 0;
            counterTime = 0;
            burbuja = 0;
            insercion = 0;
            seleccion = 0;
            quicksort = 0;
            mergesort = 0;
            heapsort = 0;
            allSorts = 0;
            seleccionado = 0;
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
        public bool IsFull()
        {
            return counter == max;
        }
        public bool IsFullTime()
        {
            return counterTime == 18;
        }
        public void InsertNumbersA(int size, int opcion)
        {

            if (opcion == 1)
            {
                for (int i = 0; i < size; i++)
                {
                    Random numbers = new Random();
                    int number = numbers.Next(0, size);
                    arrayInt[counter++] = number;

                }
                for (int i = 1; i < counter; i++)
                {
                    for (int j = 0; j < counter - 1; j++)
                    {
                        if (arrayInt[j] > arrayInt[j + 1])
                        {
                            int aux = arrayInt[j + 1];
                            arrayInt[j + 1] = arrayInt[j];
                            arrayInt[j] = aux;
                        }
                    }
                }
            }
            else if (opcion == 2)
            {
                for (int i = 0; i < size; i++)
                {
                    Random numbers = new Random();
                    int number = numbers.Next(0, size);
                    arrayInt[counter++] = number;

                }
                for (int i = 1; i < counter; i++)
                {
                    for (int j = 0; j < counter - 1; j++)
                    {
                        if (arrayInt[j] < arrayInt[j + 1])
                        {
                            int aux = arrayInt[j + 1];
                            arrayInt[j + 1] = arrayInt[j];
                            arrayInt[j] = aux;
                        }
                    }
                }
            }
            else if (opcion == 3)
            {
                for (int i = 0; i < size; i++)
                {
                    Random numbers = new Random();
                    int number = numbers.Next(0, size);
                    arrayInt[counter++] = number;

                }
            }
            else
                Console.WriteLine("It´s not exist that option");
            

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
        public void timeOfSort(string pasada,string name, TimeSpan time)
        {
            Tuple<string, string, TimeSpan> addTime = new Tuple<string,string, TimeSpan>(pasada,name, time);
            timeOfSorts[counterTime++] = addTime;
        }
        public void printTimeOfSorts(string todos = "none")
        {
            int menor = 0;
            int mayor = 0;
            int menor2 = 0;
            int mayor2 = 0;
            bool existe2 = false;
            bool existe1 = false;
            int pasada1 = 0;
            if (todos == "todos")
            {
                mayor = seleccionado;
                menor = seleccionado;
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("                List of sorts");
                Console.WriteLine("-------------------------------------------------");
                for (int i = 0; i < counterTime; i++)
                    if(timeOfSorts[i].Item1 == "Pasada2")
                         Console.WriteLine(timeOfSorts[i].Item1 +  ". name: " + timeOfSorts[i].Item2 + ". Time: " + timeOfSorts[i].Item3);
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine(seleccionado);
                for (int i = seleccionado; i < counterTime - 1; i++)
                {
                    
                    if (timeOfSorts[i].Item1 == "Pasada2")
                    {
                        if (timeOfSorts[i + 1].Item1 == "Pasada2")
                        {
                            if (timeOfSorts[menor].Item3 > timeOfSorts[i + 1].Item3)
                                menor = i + 1;
                            if ((timeOfSorts[mayor].Item3 < timeOfSorts[i + 1].Item3))
                                mayor = i + 1;
                        }
                    }
                   
                }
                Console.WriteLine("El menor tiempo es: ");
                Console.WriteLine(timeOfSorts[menor].Item1 + " . Name: " + timeOfSorts[menor].Item2 + ". Time: " + timeOfSorts[menor].Item3);
                Console.WriteLine("El mayor tiempo es: ");
                Console.WriteLine(timeOfSorts[mayor].Item1 + " . Name: " + timeOfSorts[mayor].Item2 + ". Time: " + timeOfSorts[mayor].Item3);
                return;
            }
            

            
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("                List of sorts");
            Console.WriteLine("-------------------------------------------------");
            for (int i = 0; i < counterTime; i++)
                Console.WriteLine(timeOfSorts[i].Item1 + " .name: " + timeOfSorts[i].Item2 + ". Time: " + timeOfSorts[i].Item3);

            Console.WriteLine("-------------------------------------------------");
            for (int i = 0; i < counterTime - 1; i++)
            {
                if (timeOfSorts[i].Item1 == "Pasada1")
                {
                    existe1 = true;
                    if (timeOfSorts[i + 1].Item1 == "Pasada1")
                    {
                        if (timeOfSorts[menor].Item3 > timeOfSorts[i + 1].Item3)
                            menor = i + 1;
                        if (timeOfSorts[mayor].Item3 < timeOfSorts[i + 1].Item3)
                            mayor = i + 1;
                    }
                    pasada1++;
                }
            }
            for (int i = 0; i < counterTime - 1; i++)
            {
                if (timeOfSorts[i].Item1 == "Pasada2" )
                {
                    existe2 = true;
                    if (timeOfSorts[menor2].Item3 > timeOfSorts[i + 1].Item3)
                        menor2 = i + 1;
                    if (timeOfSorts[mayor2].Item3 < timeOfSorts[i + 1].Item3)
                        mayor2 = i + 1;
                }
            }
            if (existe1)
            {   
                    
                
                    Console.WriteLine("Pasada 1");
                    Console.WriteLine("El menor tiempo es: ");
                    Console.WriteLine(timeOfSorts[menor].Item1 + " .name: " + timeOfSorts[menor].Item2 + ". Time: " + timeOfSorts[menor].Item3);
                    Console.WriteLine("El mayor tiempo es: ");
                    Console.WriteLine(timeOfSorts[menor].Item1 + " .name: " + timeOfSorts[mayor].Item2 + ". Time: " + timeOfSorts[mayor].Item3);
                    Console.WriteLine();
                
            }
            if (existe2)
            {
                Console.WriteLine("Pasada 2");
                Console.WriteLine("El menor tiempo es: ");
                Console.WriteLine(timeOfSorts[menor2].Item1 + " .name: " + timeOfSorts[menor2].Item2 + ". Time: " + timeOfSorts[menor2].Item3);
                Console.WriteLine("El mayor tiempo es: ");
                Console.WriteLine(timeOfSorts[mayor2].Item1 + " .name: " + timeOfSorts[mayor2].Item2 + ". Time: " + timeOfSorts[mayor2].Item3);
            }

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
        

        public void MergeSort(int[] arrayInt, int l, int r)
        {
            if(l < r)
            {
                // m is the point where the array is divided into two subarrays
                int m = (l + r) / 2;

                MergeSort(arrayInt, l, m);
                MergeSort(arrayInt, m + 1, r);

                // Merge the sorted subarrays
                Merge(arrayInt, l, m, r);

            }

        }
        public void Merge(int[] arrayInt, int p, int q, int r)
        {
            // Create L ← A[p..q] and M ← A[q+1..r]
            int n1 = q - p + 1;
            int n2 = r - q;

            int[] L = new int[n1];
            int[] M = new int[n2];

            for (int inc = 0; inc < n1; inc++)
                L[inc] = arrayInt[p + inc];
            for (int jinc = 0; jinc < n2; jinc++)
                M[jinc] = arrayInt[q + 1 + jinc];

            // Maintain current index of sub-arrays and main array
            int i, j, k;
            i = 0;
            j = 0;
            k = p;

            // Until we reach either end of either L or M, pick larger among
            // elements L and M and place them in the correct position at A[p..r]
            while (i < n1 && j < n2)
            {
                if (L[i] <= M[j])
                {
                    arrayInt[k] = L[i];
                    i++;
                }
                else
                {
                    arrayInt[k] = M[j];
                    j++;
                }
                k++;
            }

            // When we run out of elements in either L or M,
            // pick up the remaining elements and put in A[p..r]
            while (i < n1)
            {
                arrayInt[k] = L[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                arrayInt[k] = M[j];
                j++;
                k++;
            }
        }

        public void HeapSort(Sorts Aux)
        {
            int n = Aux.arrayInt.Length;

            // Build max heap
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                HeapIfy(Aux.arrayInt, n, i);
            }

            // Heap sort
            for (int i = n - 1; i >= 0; i--)
            {
                int temp = Aux.arrayInt[0];
                Aux.arrayInt[0] = Aux.arrayInt[i];
                Aux.arrayInt[i] = temp;

                // Heapify root element
                HeapIfy(Aux.arrayInt, i, 0);
            }
        }

        void HeapIfy(int []arr, int n, int i)
        {
            // Find largest among root, left child and right child
            int largest = i;
            int l = 2 * i + 1;
            int r = 2 * i + 2;

            if (l < n && arr[l] > arr[largest])
                largest = l;

            if (r < n && arr[r] > arr[largest])
                largest = r;

            // Swap and continue heapifying if root is not largest
            if (largest != i)
            {
                int swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;

                HeapIfy(arr, n, largest);
            }
        }


        public void printArray(Sorts Aux)
        {
            for (int i = 0; i < Aux.counter; i++)
                Console.Write(Aux.arrayInt[i] + " ");
        }
        public void AllSorts()
        {
            Sorts Distribucion1 = new Sorts(this);
            Sorts Distribucion2 = new Sorts(this);
            Sorts Distribucion3 = new Sorts(this);
            Sorts Distribucion4 = new Sorts(this);
            Sorts Distribucion5 = new Sorts(this);
            Sorts Distribucion6 = new Sorts(this);
            Stopwatch T1 = new Stopwatch();
            Stopwatch T2 = new Stopwatch();
            Stopwatch T3 = new Stopwatch();
            Stopwatch T4 = new Stopwatch();
            Stopwatch T5 = new Stopwatch();
            Stopwatch T6 = new Stopwatch();
            string all = "todos";
            Console.WriteLine("------------------------------------");
            Console.WriteLine("       Sort Burble");
            Console.WriteLine("------------------------------------");

            printArray(Distribucion1);

            T1.Start();
            SortBurble(Distribucion1);
            T1.Stop();

            timeOfSort("Pasada2","Burble", T1.Elapsed);
            printArray(Distribucion1);

            Console.WriteLine("------------------------------------");
            Console.WriteLine("       Sort insercion");
            Console.WriteLine("------------------------------------");

            printArray(Distribucion2);

            T2.Start();
            SortInsercion(Distribucion2);
            T2.Stop();

            timeOfSort("Pasada2", "Inserción", T2.Elapsed);
            printArray(Distribucion2);

            Console.WriteLine("------------------------------------");
            Console.WriteLine("       Sort selección");
            Console.WriteLine("------------------------------------");

            printArray(Distribucion3);

            T3.Start();
            SortBurble(Distribucion3);
            T3.Stop();

            timeOfSort("Pasada2", "Selección", T3.Elapsed);
            printArray(Distribucion3);

            Console.WriteLine("------------------------------------");
            Console.WriteLine("       QuickSort");
            Console.WriteLine("------------------------------------");

            printArray(Distribucion4);

            T4.Start();
            QuickSort(Distribucion4, 0, Distribucion4.arrayInt.Length - 1);
            T4.Stop();

            timeOfSort("Pasada2", "QuickSort", T4.Elapsed);
            printArray(Distribucion4);

            Console.WriteLine("------------------------------------");
            Console.WriteLine("       MergeSort");
            Console.WriteLine("------------------------------------");

            printArray(Distribucion5);

            T5.Start();
            MergeSort(Distribucion5.arrayInt, 0, Distribucion5.arrayInt.Length - 1);
            T5.Stop();

            timeOfSort("Pasada2","MergeSort", T5.Elapsed);
            printArray(Distribucion5);

            Console.WriteLine("------------------------------------");
            Console.WriteLine("       HeapSort");
            Console.WriteLine("------------------------------------");

            printArray(Distribucion6);

            T6.Start();
            HeapSort(Distribucion6);
            T6.Stop();

            timeOfSort("Pasada2", "HeapSort", T6.Elapsed);
            printArray(Distribucion6);

            Console.WriteLine();
            Console.WriteLine();

            printTimeOfSorts(all);
            

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
                    Console.WriteLine("6. MergeSort");
                    Console.WriteLine("7. HeapSort");
                    Console.WriteLine("8. Show the array");
                    Console.WriteLine("9. See time of Sort in each sort");
                    Console.WriteLine("10. All Sorts");
                    Console.WriteLine("11. Exit");
                    Console.WriteLine("-----------------------------------------");
                    Console.Write("Choose one of the options: ");
                    try
                    {
                        option = int.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }


                    switch (option)
                    {
                        case 1:
                            int n;
                            int op;
                            Console.Write("How many numbers do you want?: ");
                            try
                            {
                                n = int.Parse(Console.ReadLine());
                            if (!IsFull())
                            {
                                Console.WriteLine("Choose one of option");
                                Console.WriteLine("1. Ascendente");
                                Console.WriteLine("2. Descendente");
                                Console.WriteLine("3. Aleatorio");
                                Console.Write("Enter...: ");
                                op = int.Parse(Console.ReadLine());
                                InsertNumbersA(n, op);
                            }
                            else
                                throw new ArgumentException("It's full");

                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                        case 2:
                            if (IsEmpty())
                                Console.WriteLine("The array is empty. You neee to enter the numbers");
                            else
                            {
                                if (burbuja == 0)
                                {
                                    Sorts Distribucion1 = new Sorts(this);
                                    Stopwatch T1 = new Stopwatch();

                                    printArray(Distribucion1);

                                    T1.Start();
                                    SortBurble(Distribucion1);
                                    T1.Stop();

                                    timeOfSort("Pasada1","Burble", T1.Elapsed);
                                    printArray(Distribucion1);
                                    burbuja++;
                                    seleccionado++;
                                }
                                else
                                {
                                    Console.WriteLine("You've already click");
                                }

                            }
                            break;
                        case 3:
                            if (IsEmpty())
                                Console.WriteLine("The array is empty");
                            else
                            { 
                            if(insercion == 0)
                            {
                                Sorts Distribucion2 = new Sorts(this);
                                Stopwatch T2 = new Stopwatch();

                                printArray(Distribucion2);

                                T2.Start();
                                SortInsercion(Distribucion2);
                                T2.Stop();

                                timeOfSort("Pasada1", "Inserción", T2.Elapsed);
                                printArray(Distribucion2);
                                insercion++;
                                seleccionado++;
                            }
                            else
                                Console.WriteLine("You've already click");
                            
                            }
                            break;
                        case 4:
                            if (IsEmpty())
                                Console.WriteLine("The array is empty");
                            else
                            {
                            if (seleccion == 0)
                            {
                                Sorts Distribucion3 = new Sorts(this);
                                Stopwatch T3 = new Stopwatch();

                                printArray(Distribucion3);

                                T3.Start();
                                SortSeleccion(Distribucion3);
                                T3.Stop();

                                timeOfSort("Pasada1", "Selección", T3.Elapsed);
                                printArray(Distribucion3);
                                seleccion++;
                                seleccionado++;
                            }
                            else
                                Console.WriteLine("You've already click");
                            }
                            break;
                        case 5:
                            if (IsEmpty())
                                Console.WriteLine("The array is empty");
                            else
                            {
                            if(quicksort == 0)
                            {
                                Sorts Distribucion4 = new Sorts(this);
                                Stopwatch T4 = new Stopwatch();

                                printArray(Distribucion4);

                                T4.Start();
                                QuickSort(Distribucion4, 0, Distribucion4.arrayInt.Length - 1);
                                T4.Stop();
                                Console.WriteLine();
                                timeOfSort("Pasada1", "QuickSort", T4.Elapsed);
                                printArray(Distribucion4);
                                quicksort++;
                                seleccionado++;
                            }
                            else Console.WriteLine("You've already click");
                               
                            }
                            break;
                        case 6:
                            if (IsEmpty())
                                Console.WriteLine("The array is empty");
                            else
                            {
                            if(mergesort == 0)
                            {
                                Sorts Distribucion5 = new Sorts(this);
                                Stopwatch T5 = new Stopwatch();

                                printArray(Distribucion5);
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine();
                                T5.Start();
                                MergeSort(Distribucion5.arrayInt, 0, Distribucion5.arrayInt.Length - 1);
                                T5.Stop();
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine();
                                timeOfSort("Pasada1", "MergeSort", T5.Elapsed);
                                printArray(Distribucion5);
                                mergesort++;
                                seleccionado++;
                            }
                            else
                                Console.WriteLine("You've already click");
                           
                            }
                            break;
                        case 7:
                            if (IsEmpty())
                                Console.WriteLine("The array is empty");
                            else
                            {
                            if(heapsort == 0)
                            {
                                Sorts Distribucion6 = new Sorts(this);
                                Stopwatch T6 = new Stopwatch();

                                printArray(Distribucion6);
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine();
                                T6.Start();
                                HeapSort(Distribucion6);
                                T6.Stop();
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine();
                                timeOfSort("Pasada1", "HeapSort", T6.Elapsed);
                                printArray(Distribucion6);
                                heapsort++;
                                seleccionado++;
                            }
                            else
                                Console.WriteLine("You've already click");
                            
                            }
                            break;
                        case 8:
                            Console.WriteLine("---------------------------------");
                            if (IsEmpty())
                                Console.WriteLine("The array is empty");
                            else
                                PrintArray();
                            break;
                        case 9:
                            if (IsEmpty())
                                Console.WriteLine("The array is empty");
                            else
                                printTimeOfSorts();
                            break;
                        case 10:
                            if (!IsEmpty())
                            {
                            if (!IsFullTime())
                                if (allSorts == 0)
                                {
                                    AllSorts();
                                    allSorts++;
                                }
                                    
                                else
                                    Console.WriteLine("You've already click");
                            }
                            else
                                Console.WriteLine("A lot of retries");
                            break;
                        case 11:
                            Console.WriteLine("See you");
                            break;
                        default:
                            Console.WriteLine("That option not exist");
                            break;
                    }
                } while (option != 11);
                
            
        }
    }
}
