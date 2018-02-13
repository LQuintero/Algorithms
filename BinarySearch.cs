using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmLib
{
    public class BinarySearch
    {
        /*
         * Binary Search - Works by repeatedly dividing in half the portion of 
         *      the list that could contain the item, until narrowing down the 
         *      possible locations to just one. 
         *      
         * Performance: best case: O(1), worst case: O(log n)
         */

        public bool BinarySearchIterative(int[] array, int x)
        {
            int left = 0;
            int right = array.Length - 1;
            while(left <= right)
            {
                int mid = left + ((right - left) / 2);
                if(array[mid] == x)
                {
                    return true;
                }
                else if (x < array[mid])
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return false;
        }

        public bool BinarySearchRecursive(int[] array, int x, int left, int right)
        {
            if(left > right)
            {
                return false;
            }

            int mid = (left + right) / 2;
            if(array[mid] == x)
            {
                return true;
            }
            else if (x < array[mid])
            {
                return BinarySearchRecursive(array, x, left, mid - 1);
            } else
            {
                return BinarySearchRecursive(array, x, mid + 1, right);
            }
        }
    }
}
