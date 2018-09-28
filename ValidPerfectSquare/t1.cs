/*
Given a positive integer num, write a function which returns True if num is a perfect square else False.
Note: Do not use any built-in library function such as sqrt.
Example 1:
Input: 16
Output: true
Example 2:
Input: 14
Output: false
*/
// Comment: Use binary search. But tricky part is corner case with overflow.
// Just use long to solve this
public class Solution {
    public bool IsPerfectSquare(int num) {
        if (num==1) return true;
        long i=1, j=num;
        while(i<=j) {
            long m = (j-i)/2 + i;
            long t = m*m;
            //Console.WriteLine("{0} {1} {2}", i,j, m*m);            
            if (t==num)
                return true;
            else if (t >num)
                j = m - 1;
            else i= m+1;
        }
        return false;
    }
}