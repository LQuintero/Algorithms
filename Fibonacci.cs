using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmLib
{
    public class FibonacciNumbers
    {
        /* 
        * Fibonacci Sequence - a series of numbers in which each number 
        *       is the sum of the two preceding ones. 
        */

        public string AllFib(int n)
        {
            int[] memo = new int[n + 1];
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                if(sb.Length > 0)
                {
                    sb.Append(", ");
                }
                sb.Append(fib(i,memo));
            }

            return sb.ToString();
        }

        public int Fibonacci(int n)
        {
            int[] memo = new int[n + 1];

            return fib(n, memo);
        }

        private int fib(int n, int[] memo)
        {
            if (n <= 0) { return 0;  }
            else if (n == 1) { return 1; }
            else if (memo[n] > 0) { return memo[n]; }

            memo[n] = fib(n - 1, memo) + fib(n - 2, memo);

            return memo[n];
        }
    }
}
