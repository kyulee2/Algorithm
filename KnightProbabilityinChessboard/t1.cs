/*
On an NxN chessboard, a knight starts at the r-th row and c-th column and attempts to make exactly K moves. The rows and columns are 0 indexed, so the top-left square is (0, 0), and the bottom-right square is (N-1, N-1). 
A chess knight has 8 possible moves it can make, as illustrated below. Each move is two squares in a cardinal direction, then one square in an orthogonal direction. 
 
Each time the knight is to move, it chooses one of eight possible moves uniformly at random (even if the piece would go off the chessboard) and moves there. 
The knight continues moving until it has made exactly K moves or has moved off the chessboard. Return the probability that the knight remains on the board after it has stopped moving. 
Example:
Input: 3, 2, 0, 0
Output: 0.0625
Explanation: There are two moves (to (1,2), (2,1)) that will keep the knight on the board.
From each of those positions, there are also two moves that will keep the knight on the board.
The total probability the knight stays on the board is 0.0625.

Note:
N will be between 1 and 25.
K will be between 0 and 100.
The knight always initially starts on the board.
*/
// Comment: Interesting DP problem. The key idea is to record valid move count for each cell at the origin. The valid count is intialized with 1.
// For each iteration in K moves, accumulate valid move count from dst to src.
// E.g, in the first move above, [0,0] <- count of [1,2] + count of [2,1] = 2.
// The answer is simply count divided by 8^K for the interersting cell.
// O(K N^2) time and O(N^2) space
public class Solution {
    public double KnightProbability(int N, int K, int r, int c) {
        // Initialized valid move count for each cell
        // For each iteration, sum up valid count for each origin
        // Divided by 8^k should be probability
        var moves = new int[8,2]{{2,1},{2,-1},{-2,-1},{-2,1},{1,2},{1,-2},{-1,2},{-1,-2}};
        bool isLegal(int i, int j) {
            if (i<0|| i>=N || j<0 || j>=N)
                return false;
            return true;
        }
      
        var dp = new double[N,N]; // spoiler: int/long is not enough due to overflow.   
        for(int i=0; i<N; i++)
            for(int j=0; j<N; j++)
                dp[i,j] = 1; // initially all cell is 1 valid move 

        
        for(int k=0; k<K; k++) { // O(8K N^2)
            var t = new double[N,N];
            for(int i=0; i<N; i++)
                for(int j=0; j<N; j++)
                    for(int l=0; l<8; l++) {
                        int x = i + moves[l,0];
                        int y = j + moves[l,1];
                        if (isLegal(x,y))
                            t[i,j] += dp[x,y];
                    }
            
            // Update dp from t, O(N^2)
            for(int i=0; i<N; i++)
                for(int j=0; j<N; j++)
                    dp[i,j] = t[i,j];
        }
        
        return dp[r, c] / Math.Pow(8, K);
    }
}
