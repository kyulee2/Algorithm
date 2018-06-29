/*
A self-dividing number is a number that is divisible by every digit it contains.

For example, 128 is a self-dividing number because 128 % 1 == 0, 128 % 2 == 0, and 128 % 8 == 0.

Also, a self-dividing number is not allowed to contain the digit zero.

Given a lower and upper number bound, output a list of every possible self dividing number, including the bounds if possible.

Example 1:
Input: 
left = 1, right = 22
Output: [1, 2, 3, 4, 5, 6, 7, 8, 9, 11, 12, 15, 22]
Note:

The boundaries of each input argument are 1 <= left <= right <= 10000.
*/
// Comment: Straighforward. Didn't look up math formula yet.
public class Solution {
    public IList<int> SelfDividingNumbers(int left, int right) {
       bool IsSelfDiv(int mask, int n)
       {
           int curr = n;
           while(mask > 0) {
               int q = curr  / mask;
               if (q==0 || (n%q) != 0)
                   return false;
               curr = curr % mask;
               mask /= 10;
           }
           return true;
       }
       var ans = new List<int>();
        for(int i = left; i<= right; i++) {
            int mask = 1;
            if (i>=10 && i<100)
                mask = 10;
            else if(i>=100 && i<1000)
                mask = 100;
            else if (i>=1000 && i<10000)
                mask = 1000;
            else if (i>=10000)
                mask = 10000;
            if (IsSelfDiv(mask, i))
                ans.Add(i);
        }
        return ans;
    }
}


