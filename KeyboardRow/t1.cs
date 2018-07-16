/*
Given a List of words, return the words that can be typed using letters of alphabet on only one row's of American keyboard like the image below. 

 

Example 1:
Input: ["Hello", "Alaska", "Dad", "Peace"]
Output: ["Alaska", "Dad"]

Note:
You may use one character in the keyboard more than once.
You may assume the input string will only contain letters of alphabet.
*/
// Comment: Easy
public class Solution {
    public string[] FindWords(string[] words) {
        var map = new Dictionary<char, int>();
        string up = "qwertyuiop";
        string mid = "asdfghjkl";
        string down = "zxcvbnm";
        foreach(var c in up) {
            map[c] = 1;
            map[Char.ToUpper(c)] = 1;
        }
        foreach(var c in mid) {
            map[c] = 2;
            map[Char.ToUpper(c)] = 2;
        }
        foreach(var c in down) {
            map[c] = 3;
            map[Char.ToUpper(c)] = 3;
        }
        var ans = new List<string>();
        foreach(var w in words) {
            var map2 = new HashSet<int>();
            foreach(var d in w) {
                map2.Add(map[d]);
            }
            if (map2.Count==1)
                ans.Add(w);
        }
        return ans.ToArray();
    }
}
