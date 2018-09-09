/*
ou are given two integer arrays nums1 and nums2 sorted in ascending order and an integer k.

Define a pair (u,v) which consists of one element from the first array and one element from the second array.

Find the k pairs (u1,v1),(u2,v2) ...(uk,vk) with the smallest sums.

Example 1:

Input: nums1 = [1,7,11], nums2 = [2,4,6], k = 3
Output: [[1,2],[1,4],[1,6]] 
Explanation: The first 3 pairs are returned from the sequence: 
             [1,2],[1,4],[1,6],[7,2],[7,4],[11,2],[7,6],[11,4],[11,6]
Example 2:

Input: nums1 = [1,1,2], nums2 = [1,2,3], k = 2
Output: [1,1],[1,1]
Explanation: The first 2 pairs are returned from the sequence: 
             [1,1],[1,1],[1,2],[2,1],[1,2],[2,2],[1,3],[1,3],[2,3]
Example 3:

Input: nums1 = [1,2], nums2 = [3], k = 3
Output: [1,3],[2,3]
Explanation: All possible pairs are returned from the sequence: [1,3],[2,3]

*/
// Comment: Use a heap. 
// Key point is that the first k pairs comes either frorm K*K elements -- 0~k'th element from nums1 + 0-k'th elemnt from nums2.
// Initialize nums1[i] where i=0~k with nums2[0] to the heap.
// Whevenr the top element is popped from the heap, the next element form nums2 should be added/pushed to the heap. e.g,: (0,0) -> (0,1), (3,4)->(3,5)
// This ensures we cover all the pairs for the same nums1 elemnent with the nums2 moving right-forward -- the elements are sorted. The heap will maintain the lowest element from the given candidates. So, the heap element should be (nums1, nums2, idx to nums2). The comparision function/value should be nums1+ nums2 in the heap.
// Time complexity is O(kLogk) since heap size is k and the loop iterates at most k times.
class Heap {
    List<int[]> data;
    public Heap() {
        data = new List<int[]>();
        data.Add(new int[]{0,0,0});
    }
    public int Count {
        get { return data.Count - 1; }
    }
    public int[] Top() {
        int[] ans = data[1];
        Swap(1, Count);
        data.RemoveAt(Count);
        Down(1);
        return ans;
    }
    public void Add(int[] n) {
        data.Add(n);
        Up(Count);
    }
    int Val(int i) {
        if (i>Count) return int.MaxValue;
        return data[i][0] + data[i][1];
    }
    void Up(int i) {
        while(i/2 > 0) {
            if (Val(i/2) <= Val(i)) break;
            Swap(i/2, i);
            i = i/2;
        }
    }
    void Down(int i) {
        if (i>Count) return;
        int l = Val(i*2);
        int r = Val(i*2 + 1);
        if (l<r) {
            if (l<Val(i)) {
                Swap(i, i*2); Down(i*2);
            }
        } else if (r<Val(i)) {
            Swap(i, i*2+1); Down(i*2 + 1);
        }
    }
    void Swap(int i, int j) {
        var t = data[i];
        data[i] = data[j];
        data[j] = t;
    }
}
public class Solution {
    
    public IList<int[]> KSmallestPairs(int[] nums1, int[] nums2, int k) {
        var ans = new List<int[]>();        
        int len1 = nums1.Length;
        int len2 = nums2.Length;
        if (len1==0|| len2==0)
            return ans; // spoiler: about null input
        
        int l = 0;
        var p = new Heap();
        
        for(int i=0; i<len1; i++) {
                if (l++ == k) break;
                int left = nums1[i];
                int right = nums2[0];
                p.Add(new int[]{left, right, 0});
            }
        

        while(k-->0 && p.Count>0) { // spoiler: the latter ensures k <= total elements
            var t = p.Top();
            ans.Add(new int[]{t[0], t[1]});
            if (t[2]==len2-1) continue;
            ++t[2]; // move next element from nums2
            p.Add(new int[]{t[0], nums2[t[2]], t[2]});
        }
        
        return ans;
    }
} 
