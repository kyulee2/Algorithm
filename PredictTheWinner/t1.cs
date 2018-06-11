/*
Given an array of scores that are non-negative integers. Player 1 picks one of the numbers from either end of the array followed by the player 2 and then player 1 and so on. Each time a player picks a number, that number will not be available for the next player. This continues until all the scores have been chosen. The player with the maximum score wins. 
Given an array of scores, predict whether player 1 is the winner. You can assume each player plays to maximize his score. 
Example 1:
Input: [1, 5, 2]
Output: False
Explanation: Initially, player 1 can choose between 1 and 2. 
If he chooses 2 (or 1), then player 2 can choose from 1 (or 2) and 5. If player 2 chooses 5, then player 1 will be left with 1 (or 2). 
So, final score of player 1 is 1 + 2 = 3, and player 2 is 5. 
Hence, player 1 will never be the winner and you need to return False.

Example 2:
Input: [1, 5, 233, 7]
Output: True
Explanation: Player 1 first chooses 1. Then player 2 have to choose between 5 and 7. No matter which number player 2 choose, player 1 can choose 233.
Finally, player 1 has more score (234) than player 2 (12), so you need to return True representing player1 can win.

Note:
1 <= length of the array <= 20. 
Any scores in the given array are non-negative integers and will not exceed 10,000,000.
If the scores of both players are equal, then player 1 is still the winner.
*/
// Comment: Think two players with given range of numbers.
// Let P1ij = Player 1 (max) score at index between i to j for the given array
// Let P2ij = Player 2 (max) score at index between 1 to j for the given array
// P1ij means Player1 either picks nums[i] or nums[j] to maximize his score.
// For the former, player2 had to pick his best at index between i+1, j.
// Otherwise, player2 had to pick his best at index between i, j-1.
// s1 = nums[i] + P2i+1j
// s2 = nums[j] + P2ij-1
// if (s1>s2) P1ij = s1, P2ij = P1i+1j
// else P1ij = s2, P2ij = P1ij-1
// i derive from i+1 while j dervive from j-1. So i decreases while j increase (i < j)
public class Solution {
    int[,] P1;
    int[,] P2; 
    int len;
    public bool PredictTheWinner(int[] nums) {
        len = nums.Length;
        // Bail-out trivial case
        if (len<=2) return true;
        
        P1 = new int[len, len];
        P2 = new int[len, len];
        for(int i=0; i<len; i++)
            P1[i,i] = nums[i];

        for(int i=len-2; i>=0; i--) {
            for(int j=i+1; j<len; j++) {
                int s1 = nums[i] + P2[i+1, j];
                int s2 = nums[j] + P2[i, j-1];
                if (s1>s2) {
                    P1[i,j] = s1;
                    P2[i,j] = P1[i+1, j];
                }
                else {
                    P1[i,j] = s2;
                    P2[i,j] = P1[i,j-1];
                }
            }
        }
        
        return P1[0,len-1] >= P2[0,len-1];
    }
}


