/*
Given a string and a string dictionary, find the longest string in the dictionary that can be formed by deleting some characters of the given string. If there are more than one possible results, return the longest word with the smallest lexicographical order. If there is no possible result, return the empty string. 
Example 1:
Input:
s = "abpcplea", d = ["ale","apple","monkey","plea"]

Output: 
"apple"


Example 2:
Input:
s = "abpcplea", d = ["a","b","c"]

Output: 
"a"

Note:
All the strings in the input will only contain lower-case letters.
The size of the dictionary won't exceed 1,000.
The length of all the strings in the input won't exceed 1,000.
*/
// Comment: string comparision cannot be deleted for lexicographical order. Instead, use CompareTo
public class Solution {
    string ans;
    // Check if d can be driven from s by eliminating chars.
    void perform(string s, string d)
    {
        int start = 0;
        foreach(var c in d) {
            int i = s.IndexOf(c, start);
            if (i == -1) return;
            start = i + 1;
        }
        
        // d is valid
        if (d.Length < ans.Length)
            return;
        else if (d.Length > ans.Length)
            ans = d;
        else if (d.CompareTo(ans) <0)
            ans = d;        
    }
        
    public string FindLongestWord(string s, IList<string> d) {
        ans = "";
        
        foreach(var str in d)
            perform(s, str);
        
        return ans;
    }
}

