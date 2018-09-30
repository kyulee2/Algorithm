/*
In a 2D grid from (0, 0) to (N-1, N-1), every cell contains a 1, except those cells in the given list mines which are 0. What is the largest axis-aligned plus sign of 1s contained in the grid? Return the order of the plus sign. If there is none, return 0. 
An "axis-aligned plus sign of 1s of order k" has some center grid[x][y] = 1 along with 4 arms of length k-1 going up, down, left, and right, and made of 1s. This is demonstrated in the diagrams below. Note that there could be 0s or 1s beyond the arms of the plus sign, only the relevant area of the plus sign is checked for 1s. 

Examples of Axis-Aligned Plus Signs of Order k:
Order 1:
000
010
000

Order 2:
00000
00100
01110
00100
00000

Order 3:
0000000
0001000
0001000
0111110
0001000
0001000
0000000

Example 1:
Input: N = 5, mines = [[4, 2]]
Output: 2
Explanation:
11111
11111
11111
11111
11011
In the above grid, the largest plus sign can only be order 2.  One of them is marked in bold.

Example 2:
Input: N = 2, mines = []
Output: 1
Explanation:
There is no plus sign of order 2, but there is of order 1.

Example 3:
Input: N = 1, mines = [[0, 0]]
Output: 0
Explanation:
There is no plus sign, so return 0.

Note:
N will be an integer in the range [1, 500].
mines will have length at most 5000.
mines[i] will be length 2 and consist of integers in the range [0, N-1].
(Additionally, programs submitted in C, C++, or C# will be judged with a slightly smaller time limit.)
*/
// Comment: Interesting. The key idea is to assign number in increaseing order from each side for the contiguous region -- either starts from edge or mines. Then take min of such sequence on each cell
// E.g, 1,2,3,4,5 (left), 5,4,3,2,1 (right) will lead to 1,2,3,2,1 from min of these sequence.
// Similarily, doing these in row for both directions and taking minium, the maximum cell value is answer.
// O(n^2) time and space
public class Solution {
    public int OrderOfLargestPlusSign(int N, int[,] mines) {
        var map = new int[N, N];
        for(int i=0; i<N; i++)
            for(int j=0; j<N; j++)
                map[i,j] = N;
        for(int i=0; i<mines.GetLength(0); i++)
            map[mines[i,0], mines[i,1]] = 0;
        
        // update map in a way 1 2 3 ...in a increasing order from edge or mines from four directino
        // get min of such sequence. Finally the max cell is the largest plus sign length
        int max = 0;
        for(int i=0; i<N; i++) {
            int count =0 ;
            for(int j=0; j<N; j++) { // left to right
                if (map[i,j]==0) {
                    count = 0;
                } else {
                    count++;
                    map[i,j] = Math.Min(map[i,j], count);
                }
            }
            count = 0;
            for(int j=N-1; j>=0; j--) { // right to left
                if (map[i,j]==0) {
                    count = 0;
                } else {
                    count++;
                    map[i,j] = Math.Min(map[i,j], count);
                }
            }            
        }
        for(int j=0; j<N; j++) {
            int count =0 ;
            for(int i=0; i<N; i++) { // top to bottom
                if (map[i,j]==0) {
                    count = 0;
                } else {
                    count++;
                    map[i,j] = Math.Min(map[i,j], count);
                }
            }
            count = 0;
            for(int i=N-1; i>=0; i--) { // bottom to top
                if (map[i,j]==0) {
                    count = 0;
                } else {
                    count++;
                    map[i,j] = Math.Min(map[i,j], count);
                    // Update max
                    max = Math.Max(map[i,j], max);
                }
            }            
        }
        
        return max;
    }
}