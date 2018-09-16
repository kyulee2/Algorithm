/*
Given an array arr that is a permutation of [0, 1, ..., arr.length - 1], we split the array into some number of "chunks" (partitions), and individually sort each chunk.  After concatenating them, the result equals the sorted array.
What is the most number of chunks we could have made?
Example 1:
Input: arr = [4,3,2,1,0]
Output: 1
Explanation:
Splitting into two or more chunks will not return the required result.
For example, splitting into [4, 3], [2, 1, 0] will result in [3, 4, 0, 1, 2], which isn't sorted.
Example 2:
Input: arr = [1,0,2,3,4]
Output: 4
Explanation:
We can split into two chunks, such as [1, 0], [2, 3, 4].
However, splitting into [1, 0], [2], [3], [4] is the highest number of chunks possible.
Note:
arr will have length in range [1, 10].
arr[i] will be a permutation of [0, 1, ..., arr.length - 1].
*/
// Comment: Think about ranges that spans between current index and original index. And merge ranges. 
// Whenever a range are closed, count as a chunk. In this particular problem, actually ranges are just 0~n-1 as well.
// So, technically no need to sort ranges. Instead, just count +1/-1 for the range would be enough.
public class Solution {
    public int MaxChunksToSorted(int[] arr) {
        // Build range. Use a map to count +1/-1
        int len = arr.Length;
        var map = new int[len];
        for(int i=0; i<len; i++) {
            int min = Math.Min(i, arr[i]);
            int max = Math.Max(i, arr[i]);
            ++map[min];
            --map[max];
        }
        
        // Sort range
        // Merge range
        // Count ranges
        int ans = 0;
        int sum = 0;
        for(int i=0; i<len; i++) {
            sum += map[i];
            if (sum==0)
                ans++;
        }
        return ans;
    }
}
