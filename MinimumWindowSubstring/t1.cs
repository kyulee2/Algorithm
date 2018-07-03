/*
Given a string S and a string T, find the minimum window in S which will contain all the characters in T in complexity O(n).

Example:

Input: S = "ADOBECODEBANC", T = "ABC"
Output: "BANC"
Note:

If there is no such window in S that covers all characters in T, return the empty string "".
If there is such window, you are guaranteed that there will always be only one unique minimum window in S.
*/
// Comment: Use queue and map. Remove redundant head in queue.
// Allow negative count on map to identify redundancy
public class Solution {
    public string MinWindow(string s, string t) {
        var q = new Queue<int>();
        var map = new Dictionary<char, int>();
        int slen = s.Length;
        int tlen = t.Length;
        int min = slen+1;// Spoiler
        string ans = "";
        
        // build map
        foreach(var c in t)
            if(!map.ContainsKey(c))
                map[c] = 1;
            else map[c]++;
    
        int cnt = 0;
        for(int i=0; i<slen; i++) {
            var c = s[i];
            if (!map.ContainsKey(c))
                continue;       
            if (map[c]>0) cnt++;
            map[c]--;
            q.Enqueue(i);
            if (cnt!=tlen)
                continue;
            // Minimize the window by removing head char which has redundancy (<0)
            while(q.Count>0 && map[s[q.Peek()]]<0)
                ++map[s[q.Dequeue()]];
            
            // Check minimum
            if (q.Count>0) {
                int len = i - q.Peek() + 1;
                if (len<min) {
                    min = len;
                    ans = s.Substring(q.Peek(), len);
                }
            }
        }
        
        return ans;
    }
}
