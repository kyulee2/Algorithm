/*
There is a new alien language which uses the latin alphabet. However, the order among letters are unknown to you. You receive a list of non-empty words from the dictionary, where words are sorted lexicographically by the rules of this new language. Derive the order of letters in this language.

Example 1:

Input:
[
  "wrt",
  "wrf",
  "er",
  "ett",
  "rftt"
]

Output: "wertf"
Example 2:

Input:
[
  "z",
  "x"
]

Output: "zx"
Example 3:

Input:
[
  "z",
  "x",
  "z"
] 

Output: "" 

Explanation: The order is invalid, so return "".
Note:

You may assume all letters are in lowercase.
You may assume that if a is a prefix of b, then a must appear before b in the given dictionary.
If the order is invalid, return an empty string.
There may be multiple valid order of letters, return any one of them is fine.
*/
// Comment: Build a graph/map using different character order in adjacent words
// Use a DFS to perform topooligcal sort.
// Ensure visit all node from each parent and ensure all nodes are visited to detect a cycle (no reachable from the root)
public class Solution {
    public string AlienOrder(string[] words) {
        // Build map
        var map = new Dictionary<Char, HashSet<Char>>();
        var status = new Dictionary<char, int>(); // 0 unvisited, 1 gray, 2 black
        var parents = new HashSet<char>(); // no incoming edge
        foreach(var w in words)
            foreach(var c in w)
                if (!map.ContainsKey(c)) {
                    map[c] = new HashSet<char>();
                    status[c] = 0;
                    parents.Add(c);
                }
        for(int i=1; i<words.Length; i++) {
            var w1= words[i-1];
            var w2 = words[i];
            for(int j=0; j<Math.Min(w1.Length, w2.Length); j++) {
                var c1 = w1[j];
                var c2 = w2[j];
                if (c1==c2) continue;
                map[c1].Add(c2);
                parents.Remove(c2);
                break;
            }
        }
         
        var ans = "";
        var t = new List<char>();
        int cnt = 0;
        
        bool Rec(char n)
        {
            if (status[n]==2)
                return true;
            if (status[n]==1) // gray, not a DAG
                return false;
            status[n] = 1;
            foreach(var next in map[n])
                if (!Rec(next))
                    return false;
            status[n] = 2;
            t.Add(n);
            cnt++;
            return true;
        }
        
        // starts from all parent (no incoming edge)
        foreach(var p in parents) {
            if (!Rec(p))
                return "";
            t.Reverse();
            var tstr = new StringBuilder();
            foreach(var c in t) tstr.Append(c);
            ans = tstr.ToString() + ans;// prepend
            t.Clear();
        }
        // Ensure all nodes are visited
        if (cnt != map.Count)
            return "";
        
        return ans;
    }
}

