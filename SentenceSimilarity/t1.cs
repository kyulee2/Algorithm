/*
Given two sentences words1, words2 (each represented as an array of strings), and a list of similar word pairs pairs, determine if two sentences are similar.

For example, "great acting skills" and "fine drama talent" are similar, if the similar word pairs are pairs = [["great", "fine"], ["acting","drama"], ["skills","talent"]].

Note that the similarity relation is not transitive. For example, if "great" and "fine" are similar, and "fine" and "good" are similar, "great" and "good" are not necessarily similar.

However, similarity is symmetric. For example, "great" and "fine" being similar is the same as "fine" and "great" being similar.

Also, a word is always similar with itself. For example, the sentences words1 = ["great"], words2 = ["great"], pairs = [] are similar, even though there are no specified similar word pairs.

Finally, sentences can only be similar if they have the same number of words. So a sentence like words1 = ["great"] can never be similar to words2 = ["doubleplus","good"].

Note:

The length of words1 and words2 will not exceed 1000.
The length of pairs will not exceed 2000.
The length of each pairs[i] will be 2.
The length of each words[i] and pairs[i][j] will be in the range [1, 20].

*/
// Comment: Easy and striaghtforward. But use map with hashset to has multiple mapping
public class Solution {
    public bool AreSentencesSimilar(string[] words1, string[] words2, string[,] pairs) {
        int len1 = words1.Length;
        int len2 = words2.Length;
        if (len1!=len2)
            return false;
        //build map
        var map = new Dictionary<string, HashSet<string>>();
        for(int i=0; i<pairs.GetLength
            (0); i++) {
            string p1 = pairs[i,0];
            string p2 = pairs[i,1];
            if (!map.ContainsKey(p1))
                map[p1] = new HashSet<string>();
            map[p1].Add(p2);
            if (!map.ContainsKey(p2))
                map[p2] = new HashSet<string>();
            map[p2].Add(p1);
        }
        
        for(int i=0; i<len1; i++) {
            string s1 = words1[i];
            string s2 = words2[i];
            if (s1==s2)
                continue;
            if (!map.ContainsKey(s1))
                return false;
            if (!map[s1].Contains(s2))
                return false;
        }
        return true;
    }
}

