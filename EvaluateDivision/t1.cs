/*
Equations are given in the format A / B = k, where A and B are variables represented as strings, and k is a real number (floating point number). Given some queries, return the answers. If the answer does not exist, return -1.0.

Example:
Given a / b = 2.0, b / c = 3.0. 
queries are: a / c = ?, b / a = ?, a / e = ?, a / a = ?, x / x = ? . 
return [6.0, 0.5, -1.0, 1.0, -1.0 ].

The input is: vector<pair<string, string>> equations, vector<double>& values, vector<pair<string, string>> queries , where equations.size() == values.size(), and the values are positive. This represents the equations. Return vector<double>.

According to the example above:

equations = [ ["a", "b"], ["b", "c"] ],
values = [2.0, 3.0],
queries = [ ["a", "c"], ["b", "a"], ["a", "e"], ["a", "a"], ["x", "x"] ]. 
The input is always valid. You may assume that evaluating the queries will result in no division by zero and there is no contradiction.
*/
// Comment: Build directed graph using a map. Edge is a tuple, "string, double".
// Use boolean for Rec return value so that we can add -1.0 to the result when the target is not found.
public class Solution {
    public double[] CalcEquation(string[,] equations, double[] values, string[,] queries) {
        // Init map
        var map = new Dictionary<string, List<Tuple<string, double>>>();
        for(int i=0; i<values.Length; i++) {
            var es = equations[i,0];
            var ee = equations[i,1];
            var v = values[i];
            if (!map.ContainsKey(es)) map[es] = new List<Tuple<string, double>>();
            if (!map.ContainsKey(ee)) map[ee] = new List<Tuple<string, double>>();
            map[es].Add(new Tuple<string, double>(ee, v));
            if (v!= 0.0)
                map[ee].Add(new Tuple<string, double>(es, 1/v));
        }
        var ans = new List<double>();
        var visited = new HashSet<string>();
        bool Rec(string s, string e, double d) {
            if (!map.ContainsKey(s))
                return false;            
            if (s==e) {
                ans.Add(d);
                return true;
            }
            if (visited.Contains(s))
                return false;
            visited.Add(s);

            bool t = false;
            foreach(var c in map[s]) {
                t |= Rec(c.Item1, e, d * c.Item2);
            }
            return t;
        }
        
        for(int i=0; i<queries.GetLength(0); i++) {
            visited.Clear();
            bool t = Rec(queries[i,0], queries[i,1], 1.0);
            if (!t) ans.Add(-1.0);
        }
        return ans.ToArray();
    }
}
