/*
Initially, there is a Robot at position (0, 0). Given a sequence of its moves, judge if this robot makes a circle, which means it moves back to the original place. 
The move sequence is represented by a string. And each move is represent by a character. The valid robot moves are R (Right), L (Left), U (Up) and D (down). The output should be true or false representing whether the robot makes a circle. 
Example 1:
Input: "UD"
Output: true

Example 2:
Input: "LL"
Output: false
 */
public class Solution {
    public bool JudgeCircle(string moves) {
        int i =0, j =0;
        foreach(var c in moves) {
            switch(c) {
                case 'U':i++;break;
                case 'D':i--;break;
                case 'L': j++; break;
                case 'R': j--;break;
            }
            
        }
        return i==0 && j==0;
    }
}
