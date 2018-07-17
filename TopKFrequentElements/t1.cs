/*
Given a non-empty array of integers, return the k most frequent elements.
For example,
Given [1,1,1,2,2,3] and k = 2, return [1,2]. 
Note: 
You may assume k is always valid, 1 <= k <= number of unique elements.
Your algorithm's time complexity must be better than O(n log n), where n is the array's size.
*/
// Comment: Use partition (O(n)) on frequency array.
public class Solution {
    int partition(int[] n, int i, int j)
    {
        int pj = j;
        int p = n[j];
        int t =0;
        while(i<j) {
            if (n[i]<p) {
                i++;
            } else if (n[--j]<p) {
                t = n[i];
                n[i++] = n[j];
                n[j] = t;
            }
        }
        n[pj] = n[i];
        n[i] = p;
        return i;
    }
    int findTopK(int[] n, int k) {
        k = n.Length - k;
        int i=0, j= n.Length-1;
        while(i<j) {
            int t = partition(n, i, j);
            if (t == k) return n[t];
            else if (t<k) i = t + 1;
            else j = t - 1;
        }
        return n[i];
    }
    public IList<int> TopKFrequent(int[] nums, int k) {        
        var ans = new List<int>();
        var map = new Dictionary<int, int>(); // num : cnt
        var map2 = new Dictionary<int, List<int>>(); // cnt : nums
        foreach(var num in nums)
            if (map.ContainsKey(num))
                ++map[num];
            else map[num] = 1;
        foreach(var key in map.Keys) {
            if (!map2.ContainsKey(map[key]))
                map2[map[key]] = new List<int>();
            map2[map[key]].Add(key);
        }
        
        var n = new int[nums.Length];
        int i=0;
        foreach(var key in map2.Keys)
            foreach(var v in map2[key])
                n[i++] = key;
       
        int topi = findTopK(n, k);
        foreach(var key in map2.Keys)
            if (key>=topi) {
                foreach(var a in map2[key]) {
                    ans.Add(a);
                }
            }
        
        return ans;
    }
}
