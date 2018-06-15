/*
Given string S and a dictionary of words words, find the number of words[i] that is a subsequence of S.

Example :
Input: 
S = "abcde"
words = ["a", "bb", "acd", "ace"]
Output: 3
Explanation: There are three words in words that are a subsequence of S: "a", "acd", "ace".
Note:

All words in words and S will only consists of lowercase letters.
The length of S will be in the range of [1, 50000].
The length of words will be in the range of [1, 5000].
The length of words[i] will be in the range of [1, 50].
*/
// Comment: Use IndexOf to check the next search index
public class Solution {
    bool IsSubseq(string S, string T)
    {
        int lenS = S.Length;
        int lenT = T.Length;
        if (lenT>lenS) return false;
        int i =0; // index for T
        int j = 0; // start index of S
        for(;i<lenT; i++) {
            char c = T[i];
            int newJ = S.IndexOf(c, j);
            if (newJ==-1) return false;
            j = newJ+1; // set next index search
        }
        return true;
    }
    public int NumMatchingSubseq(string S, string[] words) {
        int sum = 0;
        foreach(var t in words)
            if (IsSubseq(S, t))
                ++sum;
        
        return sum;
    }
}

