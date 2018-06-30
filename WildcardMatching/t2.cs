/*
Given an input string (s) and a pattern (p), implement wildcard pattern matching with support for '?' and '*'.
'?' Matches any single character.
'*' Matches any sequence of characters (including the empty sequence).
The matching should cover the entire input string (not partial).
Note:
s could be empty and contains only lowercase letters a-z.
p could be empty and contains only lowercase letters a-z, and characters like ? or *.
Example 1:
Input:
s = "aa"
p = "a"
Output: false
Explanation: "a" does not match the entire string "aa".
Example 2:
Input:
s = "aa"
p = "*"
Output: true
Explanation: '*' matches any sequence.
Example 3:
Input:
s = "cb"
p = "?a"
Output: false
Explanation: '?' matches 'c', but the second letter is 'a', which does not match 'b'.
Example 4:
Input:
s = "adceb"
p = "*a*b"
Output: true
Explanation: The first '*' matches the empty sequence, while the second '*' matches the substring "dce".
Example 5:
Input:
s = "acdcb"
p = "a*c?b"
Output: false
*/
// Comment: Hard to deal with corner cases. Look-ahead matching under '*' is the key part.
// Also handle duplication of '*' below.
public class Solution {
    public bool IsMatch(string s, string p) {

        // Bail-out
        // 1. matching pattern (non-*) count should not be larger than slen
        int pcnt = 0;
        foreach(var d in p)
            if (d!='*') pcnt++;
        if (pcnt>s.Length)
            return false;
        
        // 2. Remove duplicated * (back-to-back). Without this, loop-ahead check above doesn't work
        StringBuilder b = new StringBuilder();
        char prev =' ';
        foreach(var d in p) {
            if (d=='*' && prev== '*')
                continue;
            b.Append(d);
            prev = d;
        }
        p = b.ToString();
        
        int lens = s.Length;
        int lenp = p.Length;
        var map = new Dictionary<Tuple<int, int>, bool>();
        
        bool Rec(int i, int j) {
            if (i==lens) {
                if (j==lenp)
                    return true;
                if ((j==lenp-1) && p[j]=='*') // last '*' match
                    return true;
                return false;
            } else if(j==lenp)
                return false;
            
            var key = new Tuple<int, int>(i,j);
            if (map.ContainsKey(key))
                return map[key];
            
            bool ans = false;
            var c = s[i];
            var d = p[j];
            if (c==d || d=='?') {
                ans = Rec(i+1, j+1);
            } else if (d!='*') {
                ans = false;                
            } else {// d=='*' match case
                // Be sure if we can match with ahead pattern to move forward p possible
                if (j+1 < lenp && (p[j+1]==s[i] || p[j+1]=='?'))
                    ans  = Rec(i, j+1);
                // Normal pass with matching *
                ans |= Rec(i+1, j);
            }
            map[key] = ans;
            return ans;
        }
        
        return Rec(0,0);
    }
}