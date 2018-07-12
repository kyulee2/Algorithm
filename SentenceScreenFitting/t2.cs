/*
Given a rows x cols screen and a sentence represented by a list of non-empty words, find how many times the given sentence can be fitted on the screen.

Note:

A word cannot be split into two lines.
The order of words in the sentence must remain unchanged.
Two consecutive words in a line must be separated by a single space.
Total words in the sentence won't exceed 100.
Length of each word is greater than 0 and won't exceed 10.
1 Î
o, cols Î
, cols Î mple 1:

Input:
rows = 2, cols = 8, sentence = ["hello", "world"]

Output: 
1

Explanation:
hello---
world---

The character '-' signifies an empty space on the screen.
Example 2:

Input:
rows = 3, cols = 6, sentence = ["a", "bcd", "e"]

Output: 
2

Explanation:
a-bcd- 
e-a---
bcd-e-

The character '-' signifies an empty space on the screen.
Example 3:

Input:
rows = 4, cols = 5, sentence = ["I", "had", "apple", "pie"]

Output: 
1

Explanation:
I-had
apple
pie-I
had--

The character '-' signifies an empty space on the screen.
// Comment: Need to revisit due to TLE
public class Solution {
    public int WordsTyping(string[] sentence, int rows, int cols) {
        // Spoiler: Bailout early for short cols
        foreach(var s in sentence)
            if (s.Length>cols)
                return 0;
        
        var map = new int[cols+1][]; // col to lines/row, col
/*        
        int Rec(int row, int col, int cnt)
        {
            if (row>=rows)
                return col==-1 ? cnt : cnt - 1;
            if (map[col+1] != null)
                return Rec(row + map[col+1][0], map[col+1][1], cnt+1);
            
            int startCol = col + 1;
            int r = 0;
            foreach(var s in sentence) {
                col++; // space
                int len = s.Length;
                if (col+len>cols) {
                    col = 0;
                    r++;
                }
                col += len;
                if (col==cols) {
                    col = -1;
                    r++;
                }
            }
            map[startCol] = new int[2];
            map[startCol][0] = r;
            map[startCol][1] = col;
            return Rec(row + r, col, cnt + 1);
        }
        
        return Rec(0, -1, 0);
        */
        int row = 0;
        int col = -1;
        int cnt = 0;
        

        while(row<rows) {
            //Console.WriteLine("row {0} col{1} cnt {2}", row, col, cnt);
            if (map[col+1] != null) {
                row = row + map[col+1][0];
                col = map[col+1][1];
                if (row < rows || (row ==rows && col ==-1))
                    cnt++;
                continue;
            }
            
            int startCol = col + 1;
            int r = 0;
            foreach(var s in sentence) {
                col++; // space
                int len = s.Length;
                if (col+len>cols) {
                    col = 0;
                    r++;
                }
                col += len;
                if (col==cols) {
                    col = -1;
                    r++;
                }
            }
            map[startCol] = new int[2];
            map[startCol][0] = r;
            map[startCol][1] = col;
            row = row + r;
            if (row < rows || (row ==rows && col ==-1))
               cnt++;
             //Console.WriteLine("after row {0} col{1} cnt {2}", row, col, cnt);
        }

        return cnt;
    }
}
