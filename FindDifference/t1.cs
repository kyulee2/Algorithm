/*
Given two strings s and t which consist of only lowercase letters.

String t is generated by random shuffling string s and then add one more letter at a random position.

Find the letter that was added in t.
*/
// Comment: We could use array[26] index by chark
public class Solution {
    public char FindTheDifference(string s, string t) {
        Dictionary<char, int> map = new Dictionary<char, int>();
        foreach(var c in s)
            if (!map.ContainsKey(c)) map[c] = 1;
            else ++map[c];
        foreach(var c in t) {
            if (!map.ContainsKey(c)) return c;
            if (map[c] == 0) return c;
            --map[c];
        }
            
        return ' ';
    }
}
