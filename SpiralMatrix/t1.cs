/*
Given a matrix of m x n elements (m rows, n columns), return all elements of the matrix in spiral order.
Example 1:
Input:
[
 [ 1, 2, 3 ],
 [ 4, 5, 6 ],
 [ 7, 8, 9 ]
]
Output: [1,2,3,6,9,8,7,4,5]
Example 2:
Input:
[
  [1, 2, 3, 4],
  [5, 6, 7, 8],
  [9,10,11,12]
]
Output: [1,2,3,4,8,12,11,10,9,5,6,7]
*/
// Comment: Ensure min/max setting before Recursion.
public class Solution {
    enum Dir {
        Up,
        Down,
        Left,
        Right
    }
    public IList<int> SpiralOrder(int[,] matrix) {
        var ans = new List<int>();
        int Row = matrix.GetLength(0);
        int Col = matrix.GetLength(1);
        int len = Row*Col;
        int mini =1, maxi = Row-1, minj = 0, maxj = Col-1;
        void Rec(int i, int j, Dir d)
        {
            if (ans.Count == len)
                return;
            ans.Add(matrix[i,j]);
            switch(d) {
                case Dir.Right:
                    if (j==maxj) {
                        maxj--;
                        Rec(i+1, j, Dir.Down);
                    } else
                        Rec(i, j+1, d);
                    break;
                case Dir.Down:
                    if (i==maxi) {
                        maxi--;
                        Rec(i, j-1, Dir.Left);
                    } else
                        Rec(i+1, j, d);
                    break;
                case Dir.Left:
                    if (j==minj) {
                        minj++;
                        Rec(i-1,j, Dir.Up);
                    } else
                        Rec(i, j-1, d);
                    break;
                case Dir.Up:
                    if (i==mini) {
                        mini++;
                        Rec(i, j+1, Dir.Right);
                    } else
                        Rec(i-1, j, d);
                    break;
            }
            
        }
        
        Rec(0,0,Dir.Right);
        return ans;
    }
}
