/*
Your task is to calculate ab mod 1337 where a is a positive integer and b is an extremely large positive integer given in the form of an array.

Example1:

a = 2
b = [3]

Result: 8
Example2:

a = 2
b = [1,0]

Result: 1024
*/
// Comment: Interesting math problem
public class Solution {
    // ab % p = (a%p * b%p) %p
    // a^b % p = (a%p * a%p .... ) %p
    // a^123 % p = ((a^12%p)^10%p)*(a^3%p) %p
    public int SuperPow(int a, int[] b) {
        int len = b.Length;
        // aa^c % p
        int PowMod(int aa, int c)
        {
            int result = 1;
            int bb = aa % 1337;
            for(int i = 0; i<c; i++) {
                result *= bb;
                result %= 1337;
            }
            return result;
        }

        int lastDigit = b[len-1];
        int lastRes = PowMod(a, lastDigit);
        if (len==1)
            return lastRes;
        var nextB = new int[len-1];
        Array.Copy(b, nextB, len-1);
        return PowMod(SuperPow(a, nextB),10) * lastRes % 1337;
    }
}
