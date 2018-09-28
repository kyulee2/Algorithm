/*
Given a non-empty 2D matrix matrix and an integer k, find the max sum of a rectangle in the matrix such that its sum is no larger than k.
Example:
Input: matrix = [[1,0,1],[0,-2,3]], k = 2
Output: 2 
Explanation: Because the sum of rectangle [[0, 1], [-2, 3]] is 2,
             and 2 is the max number no larger than k (k = 2).
Note:
The rectangle inside the matrix must have an area > 0.
What if the number of rows is much larger than the number of columns?
*/
// Comment: Similar to Kadane's.  Find the max sum no more than K in an array
// In the inner most loop, use a (tree)Set to record prefix sum of row. 
// Search current prefix sum - k in the set at ceiling -- equal to or greater.
// prefix - such value will be <= k. Find max of them.
// Since TreeSet is unavailable, use java.
// O(N^3 log N) where N is assumed to Row/Col
class Solution {
    int[][] s; // prefix sum for each row
    int Row;
    int Col;
    int sum(int i, int j1, int j2)//for given row, sum between j1 to j2 columns
    {
        if (j1==0)
            return s[i][j2];
        return s[i][j2] - s[i][j1-1];
    }    
    public int maxSumSubmatrix(int[][] matrix, int k) {
        Row = matrix.length;
        Col = matrix[0].length;
        s = new int[Row][Col];
        
        // init s[,]
        for(int i=0; i<Row; i++) {
            int t  =0;
            for(int j=0; j<Col; j++) {
                t += matrix[i][j];
                s[i][j] = t;
            }
        }
        
        // main loop. vary two columns
        int max = Integer.MIN_VALUE;
        for(int j1=0; j1<Col; j1++) {
            for(int j2=j1; j2<Col; j2++) {
                int rsum = 0;
                // Find row max <=k of contiguous range
                TreeSet<Integer> set = new TreeSet<Integer>();
                set.add(0); // spoiler?
                for(int i=0; i<Row; i++) {
                    int v = sum(i,j1,j2);
                    rsum += v;
                    Integer f = set.ceiling(rsum - k);
                    if (f!=null)
                        max = Math.max(max, rsum - f);
                    set.add(rsum);
                }
            }
        }
        
        return max;        
    }
}
