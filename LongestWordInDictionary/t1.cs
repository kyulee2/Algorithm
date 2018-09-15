/*
Given a list of strings words representing an English Dictionary, find the longest word in words that can be built one character at a time by other words in words. If there is more than one possible answer, return the longest word with the smallest lexicographical order.
If there is no answer, return the empty string. 
Example 1:
Input: 
words = ["w","wo","wor","worl", "world"]
Output: "world"
Explanation: 
The word "world" can be built one character at a time by "w", "wo", "wor", and "worl".

Example 2:
Input: 
words = ["a", "banana", "app", "appl", "ap", "apply", "apple"]
Output: "apple"
Explanation: 
Both "apply" and "apple" can be built from other words in the dictionary. However, "apple" is lexicographically smaller than "apply".

Note: 
All the strings in the input will only contain lowercase letters.
The length of words will be in the range [1, 1000].
The length of words[i] will be in the range [1, 30].
*/
// Comment: Need to understand problem first. "building one character at a time by other words" means more precisely "appending one character at a time"
// So, "a", "b", "ab", the output is not "ab" but "a".
// The candidate answer should be the one whose all prefixes exist in this words set.
// Trie is good for space, but still complexity is sum of all words length.
// The below is another approaceh uses sorted array that naturally orderes prefixes and lexicographical order.
public class Solution {
    public string LongestWord(string[] words) {
        // shorter words comes first. Find prefix exist
        Array.Sort(words);
        var s = new HashSet<string>();
        string ans = "";
        foreach(var w in words) {
            if ((w.Length == 1) || s.Contains(w.Substring(0, w.Length-1))) {
                ans = ans.Length < w.Length ? w : ans;
		s.Add(w); // spoiler: This should be insider if.
            }
        }
        return ans;
    }
}
