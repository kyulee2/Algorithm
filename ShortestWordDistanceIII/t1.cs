/*
Given a list of words and two words word1 and word2, return the shortest distance between these two words in the list.
word1 and word2 may be the same and they represent two individual words in the list.
Example:
Assume that words = ["practice", "makes", "perfect", "coding", "makes"].
Input: word1 = “makes”, word2 = “coding”
Output: 1
Input: word1 = "makes", word2 = "makes"
Output: 3
Note:
You may assume word1 and word2 are both in the list.
*/
// Comment: Easy and straightforward. Skip for the same word on the same index
public class Solution {
    public int ShortestWordDistance(string[] words, string word1, string word2) {
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
                if (word1 == word2 && i==j) continue;
                else
                min = Math.Min(min, Math.Abs(i-j));
        return min;
    }
}