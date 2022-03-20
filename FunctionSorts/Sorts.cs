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
        private int burbuja = 0;
        private int insercion;
        private int seleccion;
        private int quicksort;
        private int mergesort;
        private int heapsort;
        private int allSorts;
        
        public Sorts(int lenghtA)
        {
            arrayInt = new int[lenghtA];
            timeOfSorts = new Tuple<string, TimeSpan>[18];
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
            Console.WriteLine("------------------------------------");
            Console.WriteLine("       Sort Burble");
            Console.WriteLine("------------------------------------");

            printArray(Distribucion1);

            T1.Start();
            SortBurble(Distribucion1);
            T1.Stop();

            timeOfSort("Burble", T1.Elapsed);
            printArray(Distribucion1);

            Console.WriteLine("------------------------------------");
            Console.WriteLine("       Sort insercion");
            Console.WriteLine("------------------------------------");

            printArray(Distribucion2);

            T2.Start();
            SortInsercion(Distribucion2);
            T2.Stop();

            timeOfSort("Inserción", T2.Elapsed);
            printArray(Distribucion2);

            Console.WriteLine("------------------------------------");
            Console.WriteLine("       Sort selección");
            Console.WriteLine("------------------------------------");

            printArray(Distribucion3);

            T3.Start();
            SortBurble(Distribucion3);
            T3.Stop();

            timeOfSort("Selección", T3.Elapsed);
            printArray(Distribucion3);

            Console.WriteLine("------------------------------------");
            Console.WriteLine("       QuickSort");
            Console.WriteLine("------------------------------------");

            printArray(Distribucion4);

            T4.Start();
            QuickSort(Distribucion4, 0, Distribucion4.arrayInt.Length - 1);
            T4.Stop();

            timeOfSort("QuickSort", T4.Elapsed);
            printArray(Distribucion4);

            Console.WriteLine("------------------------------------");
            Console.WriteLine("       MergeSort");
            Console.WriteLine("------------------------------------");

            printArray(Distribucion5);

            T5.Start();
            MergeSort(Distribucion5.arrayInt, 0, Distribucion5.arrayInt.Length - 1);
            T5.Stop();

            timeOfSort("MergeSort", T5.Elapsed);
            printArray(Distribucion5);

            Console.WriteLine("------------------------------------");
            Console.WriteLine("       HeapSort");
            Console.WriteLine("------------------------------------");

            printArray(Distribucion6);

            T6.Start();
            HeapSort(Distribucion6);
            T6.Stop();

            timeOfSort("HeapSort", T6.Elapsed);
            printArray(Distribucion6);

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
                            Console.Write("How many numbers do you want?: ");
                            try
                            {
                                n = int.Parse(Console.ReadLine());
                                if (!IsFull())
                                    InsertNumbersA(n);
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

                                    timeOfSort("Burble", T1.Elapsed);
                                    printArray(Distribucion1);
                                    burbuja++;
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

                                timeOfSort("Inserción", T2.Elapsed);
                                printArray(Distribucion2);
                                insercion++;
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

                                timeOfSort("Selección", T3.Elapsed);
                                printArray(Distribucion3);
                                seleccion++;
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
                                timeOfSort("QuickSort", T4.Elapsed);
                                printArray(Distribucion4);
                                quicksort++;
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
                                timeOfSort("MergeSort", T5.Elapsed);
                                printArray(Distribucion5);
                                mergesort++;
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
                                timeOfSort("HeapSort", T6.Elapsed);
                                printArray(Distribucion6);
                                heapsort++;
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
                                    AllSorts();
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
