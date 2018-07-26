/*
Given a n x n matrix where each of the rows and columns are sorted in ascending order, find the kth smallest element in the matrix.

Note that it is the kth smallest element in the sorted order, not the kth distinct element.

Example:

matrix = [
   [ 1,  5,  9],
   [10, 11, 13],
   [12, 13, 15]
],
k = 8,

return 13.
Note: 
You may assume k is always valid, 1 <= k <= n^2

*/
// Comment: Similar to N way merge sort.
public class Heap {
    List<int[]> data;
    public Heap() {
        data = new List<int[]>();
        data.Add(new int[]{0,0,0}); // dummy
    }
    public int Count {
        get {
            return data.Count - 1 ;
        }
    }
    public void Add(int[] n) {
        data.Add(n);
        Up(Count);
    }
    public int[] Peek() {
        return data[1];
    }
    public int[] Top() {
        var ans = Peek();
        Swap(1, Count);
        data.RemoveAt(Count);
        Down(1);
        return ans;
    }
    void Down(int i) {
        if (i>Count) return; // Spoiler: This check is needed or exception
        int left = i*2 <= Count ? data[i*2][0] : int.MaxValue;
        int right = (i*2+1 <= Count) ? data[i*2 +1][0] : int.MaxValue;
        if (left < right) {
            if (left<data[i][0]) {
                Swap(i*2, i);
                Down(i*2);
            }
        } else if (right<data[i][0]) {
            Swap(i*2+1, i);
            Down(i*2+1);
        }
    }
    void Up(int i) {
        while(i/2>0) {
            if (data[i/2][0]<=data[i][0]) break;
            Swap(i/2, i);
            i = i/2;
        }
    }
    void Swap(int i, int j) {
        var t = data[i];
        data[i]= data[j];
        data[j] = t;
    }   
}

public class Solution {
    public int KthSmallest(int[,] matrix, int k) {
        int n = matrix.GetLength(0);
        var h = new Heap();
        for(int i=0; i<k && i<n; i++)
            h.Add(new int[]{matrix[0,i],0,i});
        int ans = -1;
        while(k-->0) {
            var t = h.Top();
            ans = t[0];
            if (t[1] == n-1) continue;
            // Get next row element
            t[0] = matrix[++t[1], t[2]];
            h.Add(t);
        }
        return ans;
    }
}
