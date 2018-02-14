using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmLib
{
    public class BubbleSort
    {
        /*
         * BubbleSort - steps through the list to be sorted, compares each pair of 
         *      adjacent items and swaps them if they are in the wrong order
         * 
         * Performance: best case: O(n), worst case: O(n^2)
         */

        public void Bubble_Sort(int[] array)
        {
            bool isSorted = false;
            while(!isSorted)
            {
                isSorted = true;
                int lastUnsorted = array.Length - 1;
                for (int i = 0; i < lastUnsorted; i++)
                {
                    if(array[i] > array[i + 1]) {
                        Swap(array, i, i + 1);
                        isSorted = false;
                    }
                }
                lastUnsorted--;
            }
        }

        public void Swap(int[] array, int i, int j)
        {
            int tmp = array[i];
            array[i] = array[j];
            array[j] = tmp;
        }
    }
}
