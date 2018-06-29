/*
Given two arrays, write a function to compute their intersection.

Example:
Given nums1 = [1, 2, 2, 1], nums2 = [2, 2], return [2].

Note:
Each element in the result must be unique.
The result can be in any order.
*/
// Comment: Easy. Not worth.
public class Solution {
    public int[] Intersection(int[] nums1, int[] nums2) {
        if (nums1.Length < nums2.Length)
            return Intersection(nums2, nums1);
        var set = new HashSet<int>();
        foreach(var n in nums2)
            set.Add(n);
        var ans = new HashSet<int>();
        foreach(var n in nums1)
            if (set.Contains(n))
                ans.Add(n);
        return ans.ToList().ToArray();
    }
}

