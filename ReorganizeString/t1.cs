/*
Given a string S, check if the letters can be rearranged so that two characters that are adjacent to each other are not the same.
If possible, output any possible result.  If not possible, return the empty string.
Example 1:
Input: S = "aab"
Output: "aba"
Example 2:
Input: S = "aaab"
Output: ""
Note:
S will consist of lowercase letters and have length in range [1, 500].
*/
// Comment: It's about scheduling problem
// Build a map with char : cnt
// Build a sorted list by count in a decreasing order
// Use linkedlist so that it's easy to insert the scheduled/consumed letter
//
// Looking a solution, should be able to use a PriorityQueue. TODO: the key part is to
// take two elements from the top, ensure the top elements are not back-to-back.
public class Solution {
    public string ReorganizeString(string S) {
        // build map
        var map = new Dictionary<char, int>(); // char to cnt
        foreach(var c in S)
            if (map.ContainsKey(c))
                ++map[c];
            else map[c] = 1;
        // build a sorted list
        var tl = new List<Tuple<char,int>>();
        foreach(var t in map.Keys)
            tl.Add(new Tuple<char,int>(t, map[t]));
        tl.Sort((x,y)=>(-x.Item2 + y.Item2)); // decreasing order by count
        // LinkedList can be constructed from list. but can't be sorted directly
        var l = new LinkedList<Tuple<char,int>>(tl);
        
        var ans = new StringBuilder();
        char prev = ' ';
        while(l.Count > 0) {
            var first = l.First;
            var curr = first.Value.Item1;
            var cnt = first.Value.Item2;
            l.RemoveFirst();
            //Console.WriteLine("{0} {1}", curr, cnt);
            if (curr == prev)
                return "";
            prev = curr;
            ans.Append(curr);
            if (cnt>1) {
                var n = new Tuple<char, int>(curr, cnt-1);
                // insert new entry to the sorted list
                var m = l.First;
                // Start from the next element
                if (m==null)
                    return "";
                m = m.Next;
                while(m != null && m.Value.Item2 >n.Item2)
                    m = m.Next;
                if (m == null)
                    l.AddLast(n);
                else l.AddBefore(m, n);
            }
        }
        
        return ans.ToString();
    }
}