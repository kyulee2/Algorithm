/*
Given a sorted array, two integers k and x, find the k closest elements to x in the array. The result should also be sorted in ascending order. If there is a tie, the smaller elements are always preferred.

Example 1:
Input: [1,2,3,4,5], k=4, x=3
Output: [1,2,3,4]
Example 2:
Input: [1,2,3,4,5], k=4, x=-1
Output: [1,2,3,4]
Note:
The value k is positive and will always be smaller than the length of the sorted array.
Length of the given array is positive and will not exceed 104
Absolute value of elements in the array and x will not exceed 104
UPDATE (2017/9/19):
The arr parameter had been changed to an array of integers (instead of a list of integers). Please reload the code definition to get the latest changes.
*/
// Comment: Use binary search to find equal or greater than target, x. 
// Use two pointers to grow output buffer up th k elements
// O(logn + k)
public class Solution {
    public IList<int> FindClosestElements(int[] arr, int k, int x) {
        int len = arr.Length;
        int idx = Array.BinarySearch(arr, x);
        if (idx<0)
            idx = -idx - 1;
        if (idx >= len-1) { // just last k elements
            var ans = new List<int>();
            for(int i=len-k; i<len; i++)
                ans.Add(arr[i]);
            return ans;
        }
        if (idx==0) { // first k elements
            var ans = new List<int>();
            for(int i=0; i<k; i++)
                ans.Add(arr[i]);
            return ans;
        }
        var tans = new LinkedList<int>();
        int j, l;
        // Consume first entry
        k--;
        if (Math.Abs(x-arr[idx-1]) <= Math.Abs(x-arr[idx])) {
            tans.AddLast(arr[idx-1]);
            j = idx - 2;
            l = idx;
        } else {
            tans.AddLast(arr[idx]);
            j = idx - 1;
            l = idx + 1;
        }
            
        while(k>0) {
            if (j>=0 && l<len) {
                if (Math.Abs(x-arr[j]) <= Math.Abs(x-arr[l]))
                    tans.AddFirst(arr[j--]);
                else
                    tans.AddLast(arr[l++]);
            } else if (j<0 && l <len) {
                tans.AddLast(arr[l++]);
            } else { // j>=0 && j >
                tans.AddFirst(arr[j--]);
            }
            k--; 
        }
                                     
        {
            var ans = new List<int>();
            foreach(var e in tans)
                ans.Add(e);
            return ans;
        }
    }
}
