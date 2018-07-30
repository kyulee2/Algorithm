/*
Design a class which receives a list of words in the constructor, and implements a method that takes two words word1 and word2 and return the shortest distance between these two words in the list. Your method will be called repeatedly many times with different parameters. 
Example:
Assume that words = ["practice", "makes", "perfect", "coding", "makes"].
Input: word1 = �coding�, word2 = �practice�
Output: 3
Input: word1 = "makes", word2 = "coding"
Output: 1
Note:
You may assume that word1 does not equal to word2, and word1 and word2 are both in the list.
*/
// Comment: Easy and straightforward
public class WordDistance {
    Dictionary<string, List<int>> map;
    public WordDistance(string[] words) {
        map = new Dictionary<string, List<int>>();
        for(int i=0; i<words.Length; i++) {
            string w = words[i];
            if (!map.ContainsKey(w))
                map[w]= new List<int>();
            map[w].Add(i);
        }
    }
    
    public int Shortest(string word1, string word2) {
            int min = int.MaxValue;
            foreach(var i in map[word1])
                foreach(var j in map[word2])
                    min = Math.Min(min, Math.Abs(i-j));
            return min;
    }
}

/**
 * Your WordDistance object will be instantiated and called as such:
 * WordDistance obj = new WordDistance(words);
 * int param_1 = obj.Shortest(word1,word2);
 */