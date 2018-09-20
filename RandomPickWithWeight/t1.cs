/*
Given an array w of positive integers, where w[i] describes the weight of index i, write a function pickIndex which randomly picks an index in proportion to its weight.

Note:

1 <= w.length <= 10000
1 <= w[i] <= 10^5
pickIndex will be called at most 10000 times.
Example 1:

Input: 
["Solution","pickIndex"]
[[[1]],[]]
Output: [null,0]
Example 2:

Input: 
["Solution","pickIndex","pickIndex","pickIndex","pickIndex","pickIndex"]
[[[1,3]],[],[],[],[],[]]
Output: [null,0,1,1,1,0]
Explanation of Input Syntax:

The input is two lists: the subroutines called and their arguments. Solution's constructor has one argument, the array w. pickIndex has no arguments. Arguments are always wrapped with a list, even if there aren't any.
*/
// Comment: Use a sum array. Produce a random number 0~sum-1.
// Binary search to find the index.
public class Solution {
    int[] s;
    Random r ;
    int sum;
    int len;
    public Solution(int[] w) {
        int len = w.Length;
        s = new int[w.Length];
        sum = 0;
        int i =0;
        foreach(var e in w) {
            sum += e;
            s[i++] = sum;
        }
        r = new Random();
    }
    
    public int PickIndex() {
        int n = r.Next(sum);
        int idx = Array.BinarySearch(s, n);
       // Console.WriteLine("{0} {1}",n, idx);
        return (idx<0) ? -idx - 1 : idx + 1;
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(w);
 * int param_1 = obj.PickIndex();
 */
