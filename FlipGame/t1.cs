/*
You are playing the following Flip Game with your friend: Given a string that contains only these two characters: + and -, you and your friend take turns to flip two consecutive "++" into "--". The game ends when a person can no longer make a move and therefore the other person will be the winner.
Write a function to compute all possible states of the string after one valid move.
Example:
Input: s = "++++"
Output: 
[
  "--++",
  "+--+",
  "++--"
]
Note: If there is no valid move, return an empty list [].
*/
// Comment: not much interesting. Just cautious about indexing
public class Solution {
    public IList<string> GeneratePossibleNextMoves(string s) {
        List<string> ans = new List<string>();
        int start = 0;
        int i = 0;
        int len = s.Length;
        while(start < len-1 && (i=s.IndexOf('+', start)) != -1) {
            if (i+1 >= len) break;
            if (s[i+1] != '+') {
                start = i + 2;
                continue;
            }
            ans.Add(s.Substring(0,i) + "--" + s.Substring(i+2));
            
            start = i + 1;
        }
        return ans;
    }
}

