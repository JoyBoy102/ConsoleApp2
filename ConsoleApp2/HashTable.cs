using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp2
{
    public class HashTable
    {
        private int m = 54;
        public HashSet<int> s;
        public int t;
        public int[] arr;
        private Random r;
        private double sr;
        public int elementsCount;
        private double sum = 0;
        public HashTable()
        {
            t = (int)(m * 3);
            arr = new int[t];
            r = new Random();
            s = new HashSet<int>();
            HashTableInit();
            GenerateRandomNumbers();
            FillHashTable();
        }

        public void HashTableInit()
        {
            for (int i = 0; i < t; i++)
            {
                arr[i] = -1;
            }
        }

        /*
        public void CollisionsArrInit()
        {
            for (int i = 0; i < t; i++)
            {
                collisionsArr[i] = false;
            }
        }
        */
        public int HashFunction(int k)
        {
            int firstNum = k / 10000;
            int last2NumSum = k % 100 / 10 + k % 10;
            return firstNum + last2NumSum;
        }

        private void GenerateRandomNumbers()
        {
            while (s.Count != m)
            {
                s.Add(r.Next(10000, 99999 + 1));
            }
        }

        public int ConflictSolution(int a0, int element)
        {
            int k = 0;
            int index = 1;
            int newIndex;
            bool flag = false;
            while (true)
            {
                /*
                k++;
                if (k < 10)
                    newIndex = a0 + index * index;
                else
                {

                    if (flag == false)
                    {
                        index = 1;
                        flag = true;
                    }

                    newIndex = a0 + index;
                }
                */
                newIndex = a0 + index * index;
                k++;
                if (arr[newIndex % t] == -1)
                {
                    arr[newIndex % t] = element;
                    break;
                }
                index++;
            }
            return k;
        }

        public int Insert(int element)
        {
            int k = 0;
            int a0 = HashFunction(element);
            if (arr[a0] != -1)
            {
                k += ConflictSolution(a0, element);
            }
            else
            {
                arr[a0] = element;
                k++;
            }
            sum += k;
            elementsCount++;
            sr = sum / elementsCount;
            return k;//Возвращение кол-ва произошедших итераций для вставки элемента
        }

        public void FillHashTable()
        {
            int k = 0;

            foreach (var elem in s)
            {
                Insert(elem);
                k++;
            }
            elementsCount = k;
            sr = sum / elementsCount;
        }

        /*
        public Dictionary<int, int> GetHashTable()
        {
            if (!isFilled)
                FillHashTable();
            Dictionary<int, int> HashTableDict = new Dictionary<int, int>();
            for (int i = 0; i < t; i++)
            {
                HashTableDict[i] = arr[i];
            }
            return HashTableDict;
        }
        public Dictionary<int, int> GetTable()
        {
            Dictionary<int, int> TableDict = new Dictionary<int, int>();
            int index = 0;
            foreach (var elem in s)
            {
                TableDict[index + 1] = elem;
                index++;
            }
            return TableDict;
        }
        */
        public double getA()
        {
            double k = 0;
            foreach (var elem in arr)
            {
                if (elem != -1) k++;
            }
            return k / (double)t;
        }

        public double getSR()
        {
            return sr;
        }

        /*
        public void DeleteFromArr(int index)
        {
            for (int i = 0; i < t; i++)
            {
                if (i == index)
                {
                    arr[i] = -1;
                    collisionsArr[i] = false;
                }
            }
            elementsCount--;
        }
        */
    }
}
