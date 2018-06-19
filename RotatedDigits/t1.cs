/*
X is a good number if after rotating each digit individually by 180 degrees, we get a valid number that is different from X.  Each digit must be rotated - we cannot choose to leave it alone.
A number is valid if each digit remains a digit after rotation. 0, 1, and 8 rotate to themselves; 2 and 5 rotate to each other; 6 and 9 rotate to each other, and the rest of the numbers do not rotate to any other number and become invalid.
Now given a positive number N, how many numbers X from 1 to N are good?
Example:
Input: 10
Output: 4
Explanation: 
There are four good numbers in the range [1, 10] : 2, 5, 6, 9.
Note that 1 and 10 are not good numbers, since they remain unchanged after rotating.
Note:
N  will be in range [1, 10000].
*/
// The key idea is to get all number using "0,1,8,2,5,6,9" digits within the range.
// Then subtract the numbers using "0,1,8" digits oonly from the above.
// This ways we can obtain the number that has at least one number from "2,5,6,9", which is valid.
public class Solution {
    public int RotatedDigits(int N) {
        int NumDigit(int n)
        {
            int d = 1;
            while(n>=10) {
                d *= 10;
                n /= 10;
            }
            return d;
        }
        
        int[] R = new int[]{0,1,8,2,5,6,9};
        int[] L = new int[]{0,1,8};
        int Rec(int d, int sum, int[] data)
        {
            if (d==0) {
                return sum>=1 && sum<=N ? 1 : 0;
            }
            int cnt = 0;
            foreach(var v in data) {
                int t = sum + v * d;
                if (t>N) continue;
                cnt += Rec(d/10, t, data);
            }
            return cnt;
        }
        
        // Main recursion
        int dd = NumDigit(N);
        int total = Rec(dd, 0, R);
        int sub = Rec(dd, 0, L);
        return total-sub;
    }
}

