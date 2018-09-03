/*
Given a list of unique words, find all pairs of distinct indices (i, j) in the given list, so that the concatenation of the two words, i.e. words[i] + words[j] is a palindrome.
Example 1:
Input: ["abcd","dcba","lls","s","sssll"]
Output: [[0,1],[1,0],[3,2],[2,4]] 
Explanation: The palindromes are ["dcbaabcd","abcddcba","slls","llssssll"]
Example 2:
Input: ["bat","tab","cat"]
Output: [[0,1],[1,0]] 
Explanation: The palindromes are ["battab","tabbat"]
*/
// Comment: O(n K^2). It's interesting. It should be better than O(k n^2)
public class Solution {
    public IList<IList<int>> PalindromePairs(string[] words) {
        var map = new Dictionary<string, int>(); // string to index
        for(int i=0; i<words.Length; i++)
            map[words[i]] = i;
        bool IsPalindrome(string s) {
            int i=0, j=s.Length-1;
            while(i<j)
                if (s[i++]!=s[j--])
                    return false;

            return true;
        }
        
        var ans = new List<IList<int>>();
        for(int j=0; j<words.Length; j++) {
            var w = words[j];
            for(int i=0; i<=w.Length; i++) { // spoiler: see <= to cover "", itself case
                var str1 = w.Substring(0,i);
                var str2 = w.Substring(i);
                var rev1 = str1.ToCharArray();
                Array.Reverse(rev1);
                var revstr1 = new string(rev1);
                var rev2 = str2.ToCharArray();
                Array.Reverse(rev2);
                var revstr2 = new string(rev2);
                if (IsPalindrome(str1) && map.ContainsKey(revstr2) && map[revstr2] != j) {
                    var l = new List<int>(){map[revstr2], j};
                    ans.Add(l);
                }
                // spoiler: str2.Length check below is to avoid duplication
                if (str2.Length>0 && IsPalindrome(str2) && map.ContainsKey(revstr1) && map[revstr1] != j) {
                    var l = new List<int>() {j, map[revstr1]};               
                    ans.Add(l);
                }
            }
        }
        
        return ans;
    }
}