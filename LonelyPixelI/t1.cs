/*
Given a picture consisting of black and white pixels, find the number of black lonely pixels.
The picture is represented by a 2D char array consisting of 'B' and 'W', which means black and white pixels respectively. 
A black lonely pixel is character 'B' that located at a specific position where the same row and same column don't have any other black pixels.
Example:
Input: 
[['W', 'W', 'B'],
 ['W', 'B', 'W'],
 ['B', 'W', 'W']]

Output: 3
Explanation: All the three 'B's are black lonely pixels.

Note:
The range of width and height of the input 2D array is [1,500].
*/
// Comment: Straightfoward. Use two single array to record sum (with location value)
public class Solution {
    public int FindLonelyPixel(char[,] m) {
        int Row = m.GetLength(0);
        int Col = m.GetLength(1);
        int[] cmap = new int[Col];
        int[] rmap = new int[Row];
        for(int i=0; i<Row; i++)
            for(int j=0; j<Col; j++) {
                var val = m[i,j];
                cmap[j] += (val=='B') ? (i+1) : 0;
            }

        for(int j=0; j<Col; j++)
            for(int i=0; i<Row; i++) {
                var val = m[i,j];
                rmap[i] += (val=='B') ? (j+1) : 0;
            }

        int ans = 0;
        for(int i=0; i<Row; i++)
            for(int j=0; j<Col; j++)
                if (cmap[j] == i+1 && rmap[i] == j+1)
	                ans++;

        return ans;
    }
}
