/*
Given a non-empty string s and a dictionary wordDict containing a list of non-empty words, determine if s can be segmented into a space-separated sequence of one or more dictionary words.

Note:

The same word in the dictionary may be reused multiple times in the segmentation.
You may assume the dictionary does not contain duplicate words.
Example 1:

Input: s = "leetcode", wordDict = ["leet", "code"]
Output: true
Explanation: Return true because "leetcode" can be segmented as "leet code".
Example 2:

Input: s = "applepenapple", wordDict = ["apple", "pen"]
Output: true
Explanation: Return true because "applepenapple" can be segmented as "apple pen apple".
             Note that you are allowed to reuse a dictionary word.
Example 3:

Input: s = "catsandog", wordDict = ["cats", "dog", "sand", "and", "cat"]
Output: false 
*/
// Comment: Could be done by checking prior word from the current index.
public class Solution {
    public bool WordBreak(string s, IList<string> wordDict) {
        int len = s.Length;
        var c = new bool[len+1];
        c[0] = true;
        for(int i=1; i<=len; i++) {
            if (!c[i-1]) continue;
            foreach(var w in wordDict) {
                int idx;
                if ((idx = s.IndexOf(w,i-1)) != i-1)
                    continue;
                c[i + w.Length -1] = true;
                //Console.WriteLine("true for {0}", i +w.Length-1);
            }
        }
        return c[len];
    }
}
