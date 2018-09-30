/*
Given two arrays, write a function to compute their intersection.
Example 1:
Input: nums1 = [1,2,2,1], nums2 = [2,2]
Output: [2,2]
Example 2:
Input: nums1 = [4,9,5], nums2 = [9,4,9,8,4]
Output: [4,9]
Note:
Each element in the result should appear as many times as it shows in both arrays.
The result can be in any order.
Follow up:
What if the given array is already sorted? How would you optimize your algorithm?
What if nums1's size is small compared to nums2's size? Which algorithm is better?
What if elements of nums2 are stored on disk, and the memory is limited such that you cannot load all elements into the memory at once?
*/
// Comment: Use a map to track count
public class Solution {
    public int[] Intersect(int[] nums1, int[] nums2) {
        if (nums1.Length < nums2.Length)
            return Intersect(nums2, nums1);
        // hash nums2
        var map = new Dictionary<int, int>();
        foreach(var v in nums2)
            if (map.ContainsKey(v))
                ++map[v];
            else map[v] = 1;
        
        List<int> ans = new List<int>();
        foreach(var v in nums1) {
            if (map.ContainsKey(v)) {
                ans.Add(v);
                --map[v];
                if (map[v] == 0)
                    map.Remove(v);
            }
        }
        
        return ans.ToArray();
    }
}
