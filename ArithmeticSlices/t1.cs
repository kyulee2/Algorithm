/*
A sequence of number is called arithmetic if it consists of at least three elements and if the difference between any two consecutive elements is the same.

For example, these are arithmetic sequence:

1, 3, 5, 7, 9
7, 7, 7, 7
3, -1, -5, -9
The following sequence is not arithmetic.

1, 1, 2, 5, 7

A zero-indexed array A consisting of N numbers is given. A slice of that array is any pair of integers (P, Q) such that 0 <= P < Q < N.

A slice (P, Q) of array A is called arithmetic if the sequence:
A[P], A[p + 1], ..., A[Q - 1], A[Q] is arithmetic. In particular, this means that P + 1 < Q.

The function should return the number of arithmetic slices in the array A.


Example:

A = [1, 2, 3, 4]

return: 3, for 3 arithmetic slices in A: [1, 2, 3], [2, 3, 4] and [1, 2, 3, 4] itself.
*/
// Comment: It's rather math problem. First identify the sequnce range by comparing delta with previous one.
// If there are more than two delta, then # of slices for such range is simply sum of such deltas - 1.
// E.g, [1,2,3,4] there are 3 deltas are identical. Count = 1 + 2
public class Solution {
    public int NumberOfArithmeticSlices(int[] A) {
        int len = A.Length;
        if (len<=2) return 0;
        int ans = 0;
        int d = A[1] -A[0];
        int start = 0;
        for(int i=2; i<len; i++) {
            int currd = A[i] - A[i-1];
            if (currd == d) continue;
            d = currd;
            int end = i - 1;
            int n= end-start;
            if (n >= 2)  {
                ans += (n)*(n-1)/2;
            }
            start = i-1;// Spoiler: New start from i-1
        }
        // Last entry
        int nn= len-1-start;
        if (nn >= 2)
            ans += (nn)*(nn-1)/2;

        return ans;
    }
}
