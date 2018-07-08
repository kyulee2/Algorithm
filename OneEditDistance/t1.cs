/*
Given two strings s and t, determine if they are both one edit distance apart.
Note: 
There are 3 possiblities to satisify one edit distance apart:
Insert a character into s to get t
Delete a character from s to get t
Replace a character of s to get t
Example 1:
Input: s = "ab", t = "acb"
Output: true
Explanation: We can insert 'c' into s to get t.
Example 2:
Input: s = "cab", t = "ad"
Output: false
Explanation: We cannot get t from s by only one step.
Example 3:
Input: s = "1203", t = "1213"
Output: true
Explanation: We can replace '0' with '1' to get t.
*/
// Comment: Can't use LCS since replace is one operation not two.
// Enforce s <= t below to simplify condition in the main loop
public class Solution {
    public bool IsOneEditDistance(string s, string t) {
        int edit = 0;
        int slen = s.Length;
        int tlen = t.Length;
        if (slen>tlen)
            return IsOneEditDistance(t, s);
        
        bool Rec(int i, int j) {
            if (i==slen || j == tlen) {
                if (i==slen && j==tlen&& edit==1)
                    return true;
                // Spoiler: think "a" vs. "". 1 different length with edit = 0 meets condition
                if (i==slen && j+1 == tlen && edit == 0)
                    return true;
                return false;
            }
            var c = s[i];
            var d= t[j];
            if (c==d)
                return Rec(i+1, j+1);
            if (edit>=1) return false;
            edit++;
            var cr = slen - i;
            var dr = tlen - j;
            if (cr == dr)
                return Rec(i+1, j+1);
            else // only t > s case since IsOneEditDistance is eneforced in scuh order.
                return  Rec(i,j+1);

            return true; // unreached
        }
        
        return Rec(0,0);
    }
}
