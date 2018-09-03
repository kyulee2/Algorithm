/*
Given an array nums, there is a sliding window of size k which is moving from the very left of the array to the very right. You can only see the k numbers in the window. Each time the sliding window moves right by one position. Return the max sliding window.
Example:
Input: nums = [1,3,-1,-3,5,3,6,7], and k = 3
Output: [3,3,5,5,6,7] 
Explanation: 

Window position                Max
---------------               -----
[1  3  -1] -3  5  3  6  7       3
 1 [3  -1  -3] 5  3  6  7       3
 1  3 [-1  -3  5] 3  6  7       5
 1  3  -1 [-3  5  3] 6  7       5
 1  3  -1  -3 [5  3  6] 7       6
 1  3  -1  -3  5 [3  6  7]      7
Note: 
You may assume k is always valid, 1<=k<=input array's size for non-empty array.
Follow up:
Could you solve it in linear time?
*/
// Comment: Quite interesting. Once top/max value is found, we're not interested in left hand value.
// Before adding new value to the sorted list, remove old/left value.
// Familiarize with LinkedList APIs.
public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        int len = nums.Length;
        var ans = new List<int>();
        // Spoiler: null input
        if (k==0)
            return ans.ToArray();
        
        var q = new LinkedList<int>();        
        // Init q -- keep sorted list starting from top to right elements only.
        for(int i=0; i<k; i++) {
            while(q.Count != 0 && nums[q.Last.Value] < nums[i])
                q.RemoveLast();
            q.AddLast(i);
        }
        ans.Add(nums[q.First.Value]);
            
        // Main loop
        for(int i=k; i<len; i++) {
            // Remove smaller left elements that are not candidates
            while(q.Count !=0  && nums[q.Last.Value] < nums[i])
                q.RemoveLast();
            // Remove top if it is out of range
            if (q.Count != 0 && q.First.Value <= i-k)
                q.RemoveFirst();
            q.AddLast(i);
            ans.Add(nums[q.First.Value]);
        }
        
        return ans.ToArray();
    }
}
// Comment: Another one try similar to one -- factoring out Insert
public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        var ans = new List<int>();
        if (k==0) return ans.ToArray(); // spoiler
        
        var w = new LinkedList<int>(); // index
        // Insert t to window, w which is a sorted one -- left/prior smaller ones are elided.
        void Insert(int idx) {
            if (w.Count !=0){
                while(w.Count>0 && nums[w.Last.Value] <= nums[idx]) {
                    w.RemoveLast();
                }
            }
            w.AddLast(idx);
        }
        // Init the first k elements
        for(int i=0; i<k; i++)
            Insert(i);
        ans.Add(nums[w.First.Value]);
        
        // Main loop
        for(int i=k; i<nums.Length; i++) {
            // Remove the first element if it's out of range
            if (w.First.Value<= i- k)
                w.RemoveFirst();
            Insert(i);
            ans.Add(nums[w.First.Value]);
        }
        
        return ans.ToArray();
    }
}