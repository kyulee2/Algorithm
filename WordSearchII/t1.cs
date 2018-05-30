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
    char[,] b;
    string s;
    int Row;
    int Col;
    bool isValid(int i, int j) {
        if (i<0 || i>=Row) return false;
        if (j<0 || j>=Col) return false;
        return true;
    }
    bool Rec(int i, int j, int idx)
    {
        if (b[i,j] == s[idx]) {
            if (idx == s.Length -1)
                return true;
            char c = b[i,j];
            b[i,j] = '-';
            
            bool ans = false;
            if (isValid(i-1,j))
                ans = Rec(i-1, j, idx+1);
            if (!ans && isValid(i+1,j))
                ans = Rec(i+1, j, idx+1);
            if (!ans && isValid(i,j-1))
                ans = Rec(i, j-1, idx+1);
            if (!ans && isValid(i,j+1))
                ans = Rec(i, j+1, idx+1);
            // Restore
            b[i,j] = c;
            return ans;
        }
        
        return false;
    }
    public IList<string> FindWords(char[,] board, string[] words) {
        HashSet<string> ans = new HashSet<string>();
        b = board;
        Row = b.GetLength(0);
        Col = b.GetLength(1);
        foreach(var str in words) {
            s = str;
            bool found = false;
            for(int i=0; i<Row; i++) {
                for(int j=0; j<Col; j++)
                    if(Rec(i,j,0)) {
                        found = true;
                        break;
                    }
                if (found) break;
            }
            if (found) ans.Add(s);           
        }
        return ans.ToList();
    }
}

