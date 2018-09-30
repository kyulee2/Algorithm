/*
We have two integer sequences A and B of the same non-zero length.
We are allowed to swap elements A[i] and B[i].  Note that both elements are in the same index position in their respective sequences.
At the end of some number of swaps, A and B are both strictly increasing.  (A sequence is strictly increasing if and only if A[0] < A[1] < A[2] < ... < A[A.length - 1].)
Given A and B, return the minimum number of swaps to make both sequences strictly increasing.  It is guaranteed that the given input always makes it possible.
Example:
Input: A = [1,3,5,4], B = [1,2,3,7]
Output: 1
Explanation: 
Swap A[3] and B[3].  Then the sequences are:
A = [1, 3, 5, 7] and B = [1, 2, 3, 4]
which are both strictly increasing.
Note:
A, B are arrays with the same length, and that length will be in the range [1, 1000].
A[i], B[i] are integer values in the range [0, 2000].
*/
// Comment: Interesting. O(n) solution. The below can reduce space to O(1) too.
/ Track swap/noswap at ith location, which is purely determined by i-1th location.
// Need to revisit this
public class Solution {
    public int MinSwap(int[] A, int[] B) {
        int len = A.Length;
        var swap = new int[len];
        var noswap = new int[len];
        swap[0] = 1;
        for(int i=1; i<len; i++) {
            swap[i] = noswap[i] = len;
            if (A[i-1]<A[i] && B[i-1]<B[i]) {
                swap[i] = swap[i-1] + 1;
                noswap[i] = noswap[i-1];
            }
            if (A[i-1]<B[i] && B[i-1]<A[i]) {
                swap[i] = Math.Min(swap[i], noswap[i-1] + 1);
                noswap[i] = Math.Min(noswap[i], swap[i-1]);
            }
        }
        return Math.Min(swap[len-1], noswap[len-1]);
    }
}