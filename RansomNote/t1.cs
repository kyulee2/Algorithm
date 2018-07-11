/*
Pick One

Given an arbitrary ransom note string and another string containing letters from all the magazines, write a function that will return true if the ransom note can be constructed from the magazines ; otherwise, it will return false. 
Each letter in the magazine string can only be used once in your ransom note. 
Note:
You may assume that both strings contain only lowercase letters. 
canConstruct("a", "b") -> false
canConstruct("aa", "ab") -> false
canConstruct("aa", "aab") -> true
*/
// Comment: easy
public class Solution {
    public bool CanConstruct(string ransomNote, string magazine) {
        var map = new Dictionary<char, int>();
        foreach(var c in ransomNote)
            if (!map.ContainsKey(c)) map[c] = 1;
            else ++map[c];
        foreach(var c in magazine)
            if (map.ContainsKey(c)) {
                --map[c];
                if (map[c]==0)
                    map.Remove(c);
            }
        
        return map.Count==0;
    }
}
