/*
Given a non-negative integer num, repeatedly add all its digits until the result has only one digit.

Example:

Input: 38
Output: 2 
Explanation: The process is like: 3 + 8 = 11, 1 + 1 = 2. 
             Since 2 has only one digit, return it.
Follow up:
Could you do it without any loop/recursion in O(1) runtime?
*/

// Comment: Interesting number trick. See below in wiki

/*
The digital root (also repeated digital sum) of a non-negative integer is the (single digit) value obtained by an iterative process of summing digits, on each iteration using the result from the previous iteration to compute a digit sum. The process continues until a single-digit number is reached.

For example, the digital root of 65,536 is 7, because 6 + 5 + 5 + 3 + 6 = 25 and 2 + 5 = 7.

Digital roots can be calculated with congruences in modular arithmetic rather than by adding up all the digits, a procedure that can save time in the case of very large numbers.

Digital roots can be used as a sort of checksum, to check that a sum has been performed correctly. If it has, then the digital root of the sum of the given numbers will equal the digital root of the sum of the digital roots of the given numbers. This check, which involves only single-digit calculations, can catch many errors in calculation.

Digital roots are used in Western numerology, but certain numbers deemed to have occult significance (such as 11 and 22) are not always completely reduced to a single digit.

The number of times the digits must be summed to reach the digital sum is called a number's additive persistence; in the above example, the additive persistence of 65,536 is 2.

Contents 
1	Significance and formula of the digital root
2	Abstract multiplication of digital roots
3	Formal definition
3.1	Example
3.2	Proof that a constant value exists
4	Congruence formula
5	Some properties of digital roots
6	In other bases
7	In popular culture
8	See also
9	References
10	External links
Significance and formula of the digital root
It helps to see the digital root of a positive integer as the position it holds with respect to the largest multiple of 9 less than the number itself. For example, the digital root of 11 is 2, which means that 11 is the second number after 9. Likewise, the digital root of 2035 is 1, which means that 2035 - 1 is a multiple of 9. If a number produces a digital root of exactly 9, then the number is a multiple of 9.

With this in mind the digital root of a positive integer {\displaystyle n} n may be defined by using floor function {\displaystyle \lfloor x\rfloor } \lfloor x\rfloor , as

{\displaystyle dr(n)=n-9\left\lfloor {\frac {n-1}{9}}\right\rfloor .} dr(n)=n-9\left\lfloor {\frac  {n-1}{9}}\right\rfloor .
*/

public class Solution {
    public int AddDigits(int num) {
        if (num==0) return  0;
        int d = num % 9;
        return d == 0? 9 : d;
    }
}
