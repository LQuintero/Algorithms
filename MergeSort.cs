using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmLib
{
    public class MergeSort
    {

        /*
         * Merge Sort - Recursive algorithm that continually splits the array in 
         *      halves and then combines them in a sorted manner.  If the array is 
         *      empty or has one item, it is sorted by definition (the base case). 
         *      If the array has more than one item, we split the array and 
         *      recursively invoke a merge sort on both halves. Once the two halves 
         *      are sorted, the fundamental operation, called a merge, is performed.  
         *      
         * Performance: O(n log n)
         */

        public void Merge_Sort(int[] array)
        {
            Merge_Sort(array, new int[array.Length], 0, array.Length - 1);
        }

        private void Merge_Sort(int[] array, int[] temp, int leftStart, int rightEnd)
        {
            if (leftStart >= rightEnd)
            {
                return;
            }
            int middle = (leftStart + rightEnd) / 2;
            Merge_Sort(array, temp, leftStart, middle);
            Merge_Sort(array, temp, middle + 1, rightEnd);
            mergeHalves(array, temp, leftStart, rightEnd);

        }

        private void mergeHalves(int[] array, int[] temp, int leftStart, int rightEnd)
        {
            int leftEnd = (rightEnd + leftStart) / 2;
            int rightStat = leftEnd + 1;
            int size = rightEnd - leftStart + 1;

            int left = leftStart;
            int right = rightStat;
            int index = leftStart;

            while (left <= leftEnd && right <= rightEnd)
            {
                if (array[left] <= array[right])
                {
                    temp[index] = array[left];
                    left++;
                }
                else
                {
                    temp[index] = array[right];
                    right++;
                }
                index++;
            }

            Array.Copy(array, left, temp, index, leftEnd - left + 1);
            Array.Copy(array, right, temp, index, rightEnd - right + 1);
            Array.Copy(temp, leftStart, array, leftStart, size);
        }
    }
}
