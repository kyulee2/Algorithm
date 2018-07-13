/*
Given a 2D board and a list of words from the dictionary, find all words in the board.
Each word must be constructed from letters of sequentially adjacent cell, where "adjacent" cells are those horizontally or vertically neighboring. The same letter cell may not be used more than once in a word.
Example:
Input: 
words = ["oath","pea","eat","rain"] and board =
[
  ['o','a','a','n'],
  ['e','t','a','e'],
  ['i','h','k','r'],
  ['i','f','l','v']
]

Output: ["eat","oath"]
Note:
You may assume that all inputs are consist of lowercase letters a-z.
*/

// Comment: Use hashset instead of list to avoid duplication in words
public class Solution {
    public IList<string> FindWords(char[,] board, string[] words) {
        var map = new Dictionary<char, HashSet<string>>();
        foreach(var w in words) {
            if (!map.ContainsKey(w[0]))
                map[w[0]] = new HashSet<string>();
            map[w[0]].Add(w);
        }
        
        var ans = new HashSet<string>();
        int Row = board.GetLength(0);
        int Col = board.GetLength(1);
        var visited= new bool[Row, Col];
        bool Rec(int i, int j, string s, int d)
        {
            if (i<0||j<0||i>=Row||j>=Col) return false;
            if (visited[i,j]) return false;
            if (s[d] != board[i,j]) return false;
            if (s.Length == d + 1) {
                ans.Add(s);
                return true;
            }
            visited[i,j] = true;
            bool t = false;
            t |=Rec(i+1, j, s, d + 1);
            t |=Rec(i-1, j, s, d + 1);
            t |=Rec(i, j+1, s, d + 1);
            t |=Rec(i, j-1, s, d + 1);
            visited[i,j] = false;
            return t;
        }
        
        for(int i=0; i<Row; i++)
            for(int j=0; j<Col; j++) {
                if (!map.ContainsKey(board[i,j]))
                    continue;
                foreach(var s in map[board[i,j]])
                    Rec(i,j, s, 0);
            }
        
        return ans.ToList();
    }
}

