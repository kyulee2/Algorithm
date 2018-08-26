/*
You have k lists of sorted integers in ascending order. Find the smallest range that includes at least one number from each of the k lists.

We define the range [a,b] is smaller than range [c,d] if b-a < d-c or a < c if b-a == d-c.

Example 1:
Input:[[4,10,15,24,26], [0,9,12,20], [5,18,22,30]]
Output: [20,24]
Explanation: 
List 1: [4, 10, 15, 24,26], 24 is in range [20,24].
List 2: [0, 9, 12, 20], 20 is in range [20,24].
List 3: [5, 18, 22, 30], 22 is in range [20,24].
Note:
The given list may contain duplicates, so ascending order means >= here.
1 <= k <= 3500
-105 <= value of elements <= 105.
For Java users, please note that the input type has been changed to List<List<Integer>>. And after you reset the code template, you'll see this point.
*/
// Comment: Use a SortedList instead of heap like merge sort.
// To handle duplication, use hashcode for breaking order in Comparer.
// O(kn) worst case. 
public class Solution {
   public class TupleComparer : IComparer  
   {
      // Call CaseInsensitiveComparer.Compare with the parameters reversed.
      int IComparer.Compare(Object x, Object y)  
      {
          var t1 = (Tuple<int, IList<int>>) x;
          var t2 = (Tuple<int, IList<int>>) y;
          int diff = t1.Item2[t1.Item1] - t2.Item2[t2.Item1];
          if (diff!=0) return diff;
          return t1.Item2.GetHashCode() - t2.Item2.GetHashCode();
      }
   }
    public int[] SmallestRange(IList<IList<int>> nums) {
        SortedList h = new SortedList(new TupleComparer());
        int k = nums.Count;
        if (k==0) return new int[0];
        foreach(var l in nums) {
            if (l.Count != 0) {
                var t = new Tuple<int, IList<int>>(0, l);
                h.Add(t, t);
            }
        }
        
        int minRange = Int32.MaxValue;
        int minx =0, miny = 0;
        while(h.Count ==k) { // 
            var smallest = (Tuple<int, IList<int>>)h.GetByIndex(0);
            var largest = (Tuple<int, IList<int>>)h.GetByIndex(h.Count-1);
            int l = largest.Item2[largest.Item1];
            int s = smallest.Item2[smallest.Item1];
            int range = l - s;
            if (range<minRange) {
                minx = s;
                miny = l;
                minRange = range;
            }
            
            h.RemoveAt(0);
            var t = new Tuple<int, IList<int>>(smallest.Item1+1, smallest.Item2);
            if (t.Item2.Count != t.Item1)
                h.Add(t, t);
        }
        return new int[]{minx, miny};
    }
}
