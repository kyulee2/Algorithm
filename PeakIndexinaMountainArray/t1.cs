/*
Let's call an array A a mountain if the following properties hold:

A.length >= 3
There exists some 0 < i < A.length - 1 such that A[0] < A[1] < ... A[i-1] < A[i] > A[i+1] > ... > A[A.length - 1]
Given an array that is definitely a mountain, return any i such that A[0] < A[1] < ... A[i-1] < A[i] > A[i+1] > ... > A[A.length - 1].

Example 1:

Input: [0,1,0]
Output: 1
Example 2:

Input: [0,2,1,0]
Output: 1
Note:

3 <= A.length <= 10000
0 <= A[i] <= 10^6
A is a mountain, as defined above.
*/
// Comment: Simple binary search. One spoiler about eqaulity.
public class Solution {
    public int PeakIndexInMountainArray(int[] A) {
        int len = A.Length;
        int i= 0, j=len-1;
        // Spoiler: not i<j
        while(i<=j) {
            int m = i+ (j-i)/2;
            int l = m-1<0 ? 0 : m-1;
            int r = m+1>=len ? len-1 : m+1;
            if (A[m]>A[l] && A[m]>A[r])
                return m;
            if (A[l]<A[m] || A[m]<A[r])
                i = m + 1;
            else
                j = m - 1;
        }
        return -1;
    }
}
