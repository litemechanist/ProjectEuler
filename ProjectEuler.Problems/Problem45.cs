﻿using System;

namespace ProjectEuler.Problems
{
    public class Problem45 : ProblemBase
    {
        public override string Title => "Triangular, pentagonal, and hexagonal";

        public override string Description => @"
Triangle, pentagonal, and hexagonal numbers are generated by the following formulae:
Triangle 	  	Tn=n(n+1)/2 	  	1, 3, 6, 10, 15, ...
Pentagonal 	  	Pn=n(3n−1)/2 	  	1, 5, 12, 22, 35, ...
Hexagonal 	  	Hn=n(2n−1) 	  	1, 6, 15, 28, 45, ...

It can be verified that T285 = P165 = H143 = 40755.

Find the next triangle number that is also pentagonal and hexagonal.
            ";

        public override string GetAnswer()
        {
            // First hexagonal number after 40755, which is the first number to fit the rule.
            int n = 144;

            // every hexagonal number is triangular, so no need to test for that.
            long number = GetHexagonNumber(n);

            while (!IsPentagonalNumber(number))
            {
                ++n;
                number = GetHexagonNumber(n);
            }

            return number.ToString();
        }

        private static long GetHexagonNumber(int n)
        {
            return n * (2 * n - 1);
        }

        private static bool IsPentagonalNumber(long number)
        {
            double n = (Math.Sqrt(24 * number + 1) + 1) / 6;
            return Math.Abs(n % 1) < 0.000000001d;
        }
    }
}