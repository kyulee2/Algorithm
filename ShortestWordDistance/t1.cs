/*
Given a list of words and two words word1 and word2, return the shortest distance between these two words in the list.
Example:
Assume that words = ["practice", "makes", "perfect", "coding", "makes"].
Input: word1 = “coding”, word2 = “practice”
Output: 3
Input: word1 = "makes", word2 = "coding"
Output: 1
Note:
You may assume that word1 does not equal to word2, and word1 and word2 are both in the list.
*/
// Comment: Easy and striaghtforward
public class Solution {
    public int ShortestDistance(string[] words, string word1, string word2) {
        var map = new Dictionary<string, List<int>>();
        for(int i=0; i<words.Length; i++) {
            var s = words[i];
            if (!map.ContainsKey(s))
                map[s] = new List<int>();
            map[s].Add(i);
        }
        
        int min = words.Length;
        foreach(var i in map[word1])
            foreach(var j in map[word2])
                min = Math.Min(min, Math.Abs(i-j));
        
        return min;
    }
}