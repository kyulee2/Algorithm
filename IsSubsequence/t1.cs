/*
Given a string s and a string t, check if s is subsequence of t. 
You may assume that there is only lower case English letters in both s and t. t is potentially a very long (length ~= 500,000) string, and s is a short string (<=100). 
A subsequence of a string is a new string which is formed from the original string by deleting some (can be none) of the characters without disturbing the relative positions of the remaining characters. (ie, "ace" is a subsequence of "abcde" while "aec" is not). 
Example 1:
s = "abc", t = "ahbgdc" 
Return true. 
Example 2:
s = "axc", t = "ahbgdc" 
Return false. 
Follow up:
If there are lots of incoming S, say S1, S2, ... , Sk where k >= 1B, and you want to check one by one to see if T has its subsequence. In this scenario, how would you change your code?
*/
// Comment: 1) Naive one O(n).
// Use IndexOf. Keep searching next char of s in t to see if they exist.
// 2) For follow-up. O(w log(n)) where w is the lenth of s.
// Build a map from t where key is char and value is list of the index in t.
// For each char in t, search/update next index from the list using a binary search (log n). 
// Key part is how to use BinarySearch. When minus value, it points to complement of the next larger element: -j - 1
// O(n)
public class Solution {
    public bool IsSubsequence(string s, string t) {
        int idx = 0;
        foreach(var c in s){
            if ((idx=t.IndexOf(c, idx))==-1)
                return false;
            idx++;
        }
        return true;
    }
}
// O(w log n)
public class Solution {
    public bool IsSubsequence(string s, string t) {
        // Build map -- sorted index list for each char
        var map = new List<int>[26];
        for(int i=0; i < t.Length; i++) {
            int key = t[i] -'a';
            if (map[key] == null)
                map[key] = new List<int>();
            map[key].Add(i);
        }
        
        int idx = 0;
        foreach(var c in s) {
            int key = c - 'a';
            if (map[key] == null)
                return false;
            var l = map[key];
            var tIdx = l.BinarySearch(idx);
            if (tIdx < 0)
                tIdx = -tIdx -1;
            if (tIdx == l.Count)
                return false;
            idx = l[tIdx] + 1;
        }
        return true;
    }
}

