/*
Let's call any (contiguous) subarray B (of A) a mountain if the following properties hold:

B.length >= 3
There exists some 0 < i < B.length - 1 such that B[0] < B[1] < ... B[i-1] < B[i] > B[i+1] > ... > B[B.length - 1]
(Note that B could be any subarray of A, including the entire array A.)

Given an array A of integers, return the length of the longest mountain. 

Return 0 if there is no mountain.

Example 1:

Input: [2,1,4,7,3,2,5]
Output: 5
Explanation: The largest mountain is [1,4,7,3,2] which has length 5.
Example 2:

Input: [2,2,2]
Output: 0
Explanation: There is no mountain.
Note:

0 <= A.length <= 10000
0 <= A[i] <= 10000
Follow up:

Can you solve it using only one pass?
Can you solve it in O(1) space?
*/
// Comment: Use 3 status. Spoiler: the last iteration condtion where the mountain ends.
public class Solution {
    public int LongestMountain(int[] A) {
        int status = 0;
        int len = A.Length;
        if (len<3) return 0;
        int prev = A[0];
        int max = 0;
        int sum =0;
        for(int i=1; i<len; i++) {
            int curr=A[i];
            if (status==0) {
                if (prev<curr) {
                    sum++;
                    status=1;
                }
            } else if (status==1) {
                if (prev<curr)
                    sum++;
                else if(prev>curr) {
                    sum++;
                    status=-1;
                } else {
                    status = 0;
                    sum = 0;
                }
            } else { // status=-1
                if (prev>curr)
                    sum++;
                else if(prev<curr) {
                    max = Math.Max(max, sum+1);
                    sum = 1;
                    status = 1;
                } else {
                    max = Math.Max(max, sum+1);
                    sum = 0;
                    status = 0;
                }
            }
            prev = curr;
        }
        
        if (status<0)
            max = Math.Max(max, sum+1);
        
        return max;
    }
}
