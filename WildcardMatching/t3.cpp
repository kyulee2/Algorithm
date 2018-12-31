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
// Comment: Simpler than t1.cs and t2.cs
// Bail-out corner case where # of non-null chars in p < # of chars in s
// On matching '*', either j (for null str match) or i (any match) is increased.
// So, when the last condition, we should consume any '* patterns that remain in p (for the last null str match).
// Don't forget using cache, otherwise TLE.
class Solution {
public:
    int lens;
    int lenp;
    string str;
    string pat;
    map<pair<int, int>, bool> m;
    
    bool Rec(int i, int j) {
        if (i==lens) {
            // Spoiler: try match any remaining null pattern
            while(j<lenp && pat[j]=='*') j++;
            return j==lenp;
        }
        if (j==lenp) return false;
        
        auto key = make_pair(i,j);
        if (m.find(key)!=m.end())
            return m[key];
        
        bool ans = false;
        char s = str[i];
        char p = pat[j];
        if (s==p || p=='?'){
            ans = Rec(i+1, j+1);
        } else if (p=='*') {
            ans |= Rec(i, j+1); // nullstr match
            ans |= Rec(i+1, j); // anystr match
        }
        
        m[key] = ans;
        return ans;
    }
    
    bool isMatch(string s, string p) {
        lens = s.length();
        lenp = p.length();
        str = s;
        pat = p;
        int ncnt = 0; // * count
        for(auto t : p)
            if (t=='*') ncnt++;
        if (lenp - ncnt > lens)
            return false;
        return Rec(0, 0);
    }
};