/*
Given a string array words, find the maximum value of length(word[i]) * length(word[j]) where the two words do not share common letters. You may assume that each word will contain only lower case letters. If no such two words exist, return 0.
Example 1:
Input: ["abcw","baz","foo","bar","xtfn","abcdef"]
Output: 16 
Explanation: The two words can be "abcw", "xtfn".
Example 2:
Input: ["a","ab","abc","d","cd","bcd","abcd"]
Output: 4 
Explanation: The two words can be "ab", "cd".
Example 3:
Input: ["a","aa","aaa","aaaa"]
Output: 0 
Explanation: No such pair 
*/
// Comment: Use map [str:bitvector] to detect overlap
public class Solution {
    Dictionary<string, int> map;
    void buildMap(string s)
    {
        if (map.ContainsKey(s))
            return;

        int val = 0;
        foreach(var c in s) {
            int pos = (int)(c - 'a');
            val |= (1 << pos);
        }
        map[s] = val;        
    }
    
    public int MaxProduct(string[] words) {
        // map[string:int(bitvector)]
        // Init data
        map = new Dictionary<string, int>();
        
        // build map
        foreach(var s in words)
            buildMap(s);
        
        // main loop
        int max = 0;
        int len = words.Length;
        for(int i=0; i<len-1; i++)
            for(int j=i+1; j<len; j++) {
                string s1 = words[i];
                string s2 = words[j];
                if ((map[s1]&map[s2])==0) { // no common
                    if (s1.Length * s2.Length > max)
                        max = s1.Length * s2.Length;
                }
            }
        return max;
    }
}