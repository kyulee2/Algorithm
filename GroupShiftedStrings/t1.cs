/*
Given a string, we can "shift" each of its letter to its successive letter, for example: "abc" -> "bcd". We can keep "shifting" which forms the sequence:

"abc" -> "bcd" -> ... -> "xyz"
Given a list of strings which contains only lowercase alphabets, group all strings that belong to the same shifting sequence.

Example:

Input: ["abc", "bcd", "acef", "xyz", "az", "ba", "a", "z"],
Output: 
[
  ["abc","bcd","xyz"],
  ["az","ba"],
  ["acef"],
  ["a","z"]
]
*/
// Comment: Encode shift amount (right/positive) to string, and use it as key to group strings. There were two spoilers below.
public class Solution {
    string Encode(string s)
    {
        // Spoiler: "0" is not good since "aa" maps "0"
        if (s.Length == 1) return "-1";
        char c = s[0];
        StringBuilder b = new StringBuilder();
        for(int i=1; i<s.Length; i++) {
            int d = (int)(s[i]-c);
            // Spoiler: Ensure all positive (right) shift
            if (d<0)
                d += 26;
            b.Append(d);
            c = s[i];
        }
        return b.ToString();
    }
    
    public IList<IList<string>> GroupStrings(string[] strings) {
        // Initialize data
        Dictionary<string, IList<string>> map = new Dictionary<string, IList<string>>();
        List<IList<string>> ans = new List<IList<string>>();
        
        // Main loop
        foreach(var s in strings) {
            string key = Encode(s);
            if (!map.ContainsKey(key))
                map[key] = new List<string>();
            map[key].Add(s);
        }
        
        // Output
        foreach(var g in map.Values)
            ans.Add(g);
        
        return ans;
    }
}

