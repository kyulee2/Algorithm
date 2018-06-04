/*
A strobogrammatic number is a number that looks the same when rotated 180 degrees (looked at upside down).

Find all strobogrammatic numbers that are of length = n.

Example:

Input:  n = 2
Output: ["11","69","88","96"]
*/
// Comment: Think '0' case, which cannot be at the starting position since it won't meet the number of digits that are given.
// Hanlde odd input as well.

public class Solution {
    
    char[] TNums = new char[] {'0','1','8'};
    char[] SNums = new char[] {'0','1','6','8','9'};
    char getPair(char c)
    {
        if (c=='6') return '9';
        else if(c=='9') return '6';
        return c;
    }
    IList<string> ans;
    int len;
    char[] t;
    
    void Rec(int i)
    {
        if (2 * i >= len) {
            ans.Add(new string(t));
            return;
        }
        
        if (2*i+1==len) {
            foreach(var c in TNums) {
                t[i] = c;
                Rec(i+1);
            }
        } else {
            foreach(var c in SNums) {
                // spoiler:
                if (i==0 && c == '0') continue;
                t[i] = c;
                t[len-i-1] = getPair(c);
                Rec(i+1);
            }
        }
    }
    
    public IList<string> FindStrobogrammatic(int n) {
        // Initialize data
        ans = new List<string>();
        len = n;
        t = new char[n];
                    
        // Recursion
        Rec(0);
        
        return ans;
    }
}

