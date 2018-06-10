/*
Given a list of airline tickets represented by pairs of departure and arrival airports [from, to], reconstruct the itinerary in order. All of the tickets belong to a man who departs from JFK. Thus, the itinerary must begin with JFK.

Note:

If there are multiple valid itineraries, you should return the itinerary that has the smallest lexical order when read as a single string. For example, the itinerary ["JFK", "LGA"] has a smaller lexical order than ["JFK", "LGB"].
All airports are represented by three capital letters (IATA code).
You may assume all tickets form at least one valid itinerary.
Example 1:

Input: tickets = [["MUC", "LHR"], ["JFK", "MUC"], ["SFO", "SJC"], ["LHR", "SFO"]]
Output: ["JFK", "MUC", "LHR", "SFO", "SJC"]
Example 2:

Input: tickets = [["JFK","SFO"],["JFK","ATL"],["SFO","ATL"],["ATL","JFK"],["ATL","SFO"]]
Output: ["JFK","ATL","JFK","SFO","ATL","SFO"]
Explanation: Another possible reconstruction is ["JFK","SFO","ATL","JFK","ATL","SFO"]. But it is larger in lexical order.
*/
// Comment: There are many spoilers
// 1. Should check it's a valid itinerary -- should consume all tickets
// 2. Should handle multiple same tickets (same src/dst)
// Basically track edges not node. One naive way is to visit all cases and record results
// and sort them later to get the first element. This will fail due to time-out.
// To handle duplication, instead of hashset use list per start/city.
// Also sort such list so that we visit the least order city first and as soon as we find a valid result, and stop recursion. Note we might not get a valid result with the least order city, so use a visited boolean array to detect such case, and continue next candidate.
public class Solution {
    Dictionary<string, List<string>> map;
    Dictionary<string, bool[]> visited;
    int len;
    string[] tans;
    string[] ans;
    bool Rec(int idx, string start)
    {
        tans[idx] = start;
        if (idx==len) {
            ans = new string[len+1];
            Array.Copy(tans, ans, len+1);
            return true;
        }
        
        List<string> next = map[start];
        bool[] v = visited[start];
        for(int i=0; i<next.Count; i++) {
            if (v[i]) continue;
            v[i]= true;
            if (Rec(idx+1, next[i]))
                return true;
            v[i] =false;
        }
        return false;
    }
    
    public IList<string> FindItinerary(string[,] tickets) {
        // Init data
        map = new Dictionary<string, List<string>>();
        visited = new Dictionary<string, bool[]>();
        len = tickets.GetLength(0);
        tans = new string[len+1];
        
        // build map
        for(int i=0; i<len; i++) {
            string start = tickets[i,0];
            string end = tickets[i,1];
            if (!map.ContainsKey(start))
                map[start] = new List<string>();
            if (!map.ContainsKey(end))
                map[end] = new List<string>();
            map[start].Add(end);
        }
        // Sort values and allocate visited
        foreach(var s in map.Keys) {
            var v = map[s];
            v.Sort();
            visited[s] = new bool[v.Count];
        }
        
        // main loop. Rec
        Rec(0, "JFK");
        
        return ans;
    }
}

