/*
Given a string s1, we may represent it as a binary tree by partitioning it to two non-empty substrings recursively.
Below is one possible representation of s1 = "great":
    great
   /    \
  gr    eat
 / \    /  \
g   r  e   at
           / \
          a   t
To scramble the string, we may choose any non-leaf node and swap its two children.
For example, if we choose the node "gr" and swap its two children, it produces a scrambled string "rgeat".
    rgeat
   /    \
  rg    eat
 / \    /  \
r   g  e   at
           / \
          a   t
We say that "rgeat" is a scrambled string of "great".
Similarly, if we continue to swap the children of nodes "eat" and "at", it produces a scrambled string "rgtae".
    rgtae
   /    \
  rg    tae
 / \    /  \
r   g  ta  e
       / \
      t   a
We say that "rgtae" is a scrambled string of "great".
Given two strings s1 and s2 of the same length, determine if s2 is a scrambled string of s1.
Example 1:
Input: s1 = "great", s2 = "rgeat"
Output: true
Example 2:
Input: s1 = "abcde", s2 = "caebd"
Output: false
*/
// Comment: Trick to come up with recursion. Without anagram check, TLE
class Solution {
public:
    bool isScramble(string s1, string s2) {
        if (s1==s2) return true;
        if (s1.size() != s2.size()) return false;
        
        // check anagram
        auto a1 = s1;
        auto a2 = s2;
        sort(a1.begin(), a1.end());
        sort(a2.begin(), a2.end());
        if (a1!=a2) return false;
        
        int len = s1.size();
        for(int i=1; i<len; i++) { // spoiler: not len-1
            auto l1 = s1.substr(0,i);
            auto l2 = s1.substr(i);
            auto r1 = s2.substr(0,i);
            auto r2 = s2.substr(i);
            if (isScramble(l1,r1) && isScramble(l2,r2))
                return true;
            
            // Check the first substring of l1 and the last substring of r1 with i lenth
            // Check the second substring of l1 and the first substring of r1 with len -i length
            auto re1 = s2.substr(len-i,i);
            auto re2 = s2.substr(0, len-i);
            if (isScramble(l1,re1) && isScramble(l2,re2))
                return true;
        }
        return false;
    }
};