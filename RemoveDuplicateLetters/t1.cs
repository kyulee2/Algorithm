/*
Given a string which contains only lowercase letters, remove duplicate letters so that every letter appear once and only once. You must make sure your result is the smallest in lexicographical order among all possible results.
Example 1:
Input: "bcabc"
Output: "abc"
Example 2:
Input: "cbacdcbc"
Output: "acdb"
*/
// Comment: Using stack/map/set. Interesting. Track letter counts after the current char to see if we can remove such past chars that are larger than current char.
public class Solution {

    public string RemoveDuplicateLetters(string str) {
        var map = new Dictionary<char, int>();
        foreach(var c in str)
            if (map.ContainsKey(c))
                ++map[c];
            else map[c] = 1;
        
        var s = new Stack<char>();
        var visited = new HashSet<char>();
        foreach(var c in str) {
            --map[c];
            if (visited.Contains(c))
                continue;

            // If the last char is smaller than current char and the same char
            // exists in the laster index, then remove it from visited so that
            // we can select it later
            while(s.Count>0 && c < s.Peek() && map[s.Peek()] > 0)
                visited.Remove(s.Pop());
            
            s.Push(c);
            visited.Add(c);
        }
        
        var ans = new char[map.Count];
        for(int i= s.Count-1; i>=0; i--)
            ans[i] = s.Pop();
        return new String(ans);
    }
}
