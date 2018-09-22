/*
S and T are strings composed of lowercase letters. In S, no letter occurs more than once.
S was sorted in some custom order previously. We want to permute the characters of T so that they match the order that S was sorted. More specifically, if x occurs before y in S, then x should occur before y in the returned string.
Return any permutation of T (as a string) that satisfies this property.
Example :
Input: 
S = "cba"
T = "abcd"
Output: "cbad"
Explanation: 
"a", "b", "c" appear in S, so the order of "a", "b", "c" should be "c", "b", and "a". 
Since "d" does not appear in S, it can be at any position in T. "dcba", "cdba", "cbda" are also valid outputs.
 
Note:
S has length at most 26, and no character is repeated in S.
T has length at most 200.
S and T consist of lowercase letters only.
*/
// Comment: Straightforward. Use map to track count of repeated chars in T.
// See 4 steps below.
public class Solution {
    public string CustomSortString(string S, string T) {
        var ansb = new StringBuilder();
        var map = new Dictionary<char, int>();
        // build map
        foreach(var sc in S)
            map[sc] = 0;
        // Count occurrence in T
        foreach(var pc in T)
            if (map.ContainsKey(pc))
                map[pc]++;
        // First outputing the chars sorted in S, appearing in T
        foreach(var sc in S)
            if (map[sc] != 0)
                ansb.Append(new String(sc, map[sc]));
        // Append the remaing chars not in S but in T
        foreach(var pc in T)
            if (!map.ContainsKey(pc))
                ansb.Append(pc);
        return ansb.ToString();
    }
}
