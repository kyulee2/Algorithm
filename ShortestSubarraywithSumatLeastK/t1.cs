/*
Return the length of the shortest, non-empty, contiguous subarray of A with sum at least K.
If there is no non-empty subarray with sum at least K, return -1.
 

Example 1:
Input: A = [1], K = 1
Output: 1
Example 2:
Input: A = [1,2], K = 4
Output: -1
Example 3:
Input: A = [2,-1,2], K = 3
Output: 3
 
Note:
1 <= A.length <= 50000
-10 ^ 5 <= A[i] <= 10 ^ 5
1 <= K <= 10 ^ 9
*/
// Comment: Hard. Appear simple below, but not.
// Use a linkedlist/queue to maintain two things
// the head (sum[i]) is poped until sum (sum[j]-sum[i]) is greater than K
// the tail (sum[j]) is poped if it is not contigously incasesed
public class Solution {
    public int ShortestSubarray(int[] A, int K) {
        int len = A.Length;
        var sum = new int[len+1];
        int s =0;
        // Init prefix sum
        for(int i=0; i<len; i++) {
            s += A[i];
            sum[i+1] = s;
        }
        
        var l = new LinkedList<int>();
        int ans = len +1;
        for(int i=0; i<=len; i++) {
            while(l.Count > 0) {
                int curr = sum[i]-sum[l.First.Value];
                if (curr >= K) {
                    ans = Math.Min(ans, i - l.First.Value);
                    l.RemoveFirst();
                } else break;
            }
            while(l.Count > 0) {
                if (sum[l.Last.Value] >= sum[i])
                    l.RemoveLast();
                else break;
            }
            l.AddLast(i);
        }
        return ans == len+1 ? -1 : ans;
        
    }
}
