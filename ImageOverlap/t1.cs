/*
Two images A and B are given, represented as binary, square matrices of the same size.  (A binary matrix has only 0s and 1s as values.)
We translate one image however we choose (sliding it left, right, up, or down any number of units), and place it on top of the other image.  After, the overlap of this translation is the number of positions that have a 1 in both images.
(Note also that a translation does not include any kind of rotation.)
What is the largest possible overlap?
Example 1:
Input: A = [[1,1,0],
            [0,1,0],
            [0,1,0]]
       B = [[0,0,0],
            [0,1,1],
            [0,0,1]]
Output: 3
Explanation: We slide A to right by 1 unit and down by 1 unit.
Notes: 
1 <= A.length = A[0].length = B.length = B[0].length <= 30
0 <= A[i][j], B[i][j] <= 1
*/
// Comment: Quite interesting. Naive is O(n^4).
// The below method is to convert 2D array to 1D mapping as i*100 + j
// 100 is driven which is greater than 2 * maxlen(30) + 1
// Use two list to contain the newly encoded index only for 1.
// Build a map to distance between A and B to the count.
// Max count of a partiuclar key (distance) becomes the answer
// since the overlapped elements would proce the same relative distance
// For sparse matrix where the count of 1 for A and B are count(A)/count(B)
// O(count(A)*count(B). For the worst case, it may be still O(n^4)
public class Solution {
    public int LargestOverlap(int[][] A, int[][] B) {
        int len = A.Length;
        // max len 30. Encode 2D -> 1D element (i * 100 + j).
        // 100 is picked which is greater than max len (30) * 2 + 1
        var la = new List<int>();
        var lb = new List<int>();
        for(int i=0; i<len; i++)
            for(int j=0; j<len; j++) {
                if (A[i][j]==1)
                    la.Add(i*100 + j);
                if (B[i][j]==1)
                    lb.Add(i*100 + j);
            }
        
        var map = new Dictionary<int, int>(); // dist : cnt
        int max = 0;
        foreach(var a in la)
            foreach(var b in lb) {
                var key = a-b;
                if (!map.ContainsKey(key))
                    map[key] = 0;
                max = Math.Max(max, ++map[key]);
            }
                
        return max;
    }
}