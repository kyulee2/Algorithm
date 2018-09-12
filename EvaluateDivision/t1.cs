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
// Comment: another practice
public class Solution {
    public double[] CalcEquation(string[,] e, double[] values, string[,] queries) {
        var map = new Dictionary<string, Dictionary<string, double>>();
        int len = e.GetLength(0);
        // build vertex
        for(int i=0; i<len; i++) {
            if (!map.ContainsKey(e[i,0]))
                map[e[i,0]] = new Dictionary<string, double>();
            if (!map.ContainsKey(e[i,1]))
                map[e[i,1]] = new Dictionary<string, double>();
        }
        // build edge
        for(int i=0; i<len; i++) {
            map[e[i,0]][e[i,1]] = values[i];
            if (values[i]!=0.0)
                map[e[i,1]][e[i,0]] = 1.0/values[i];
        }
        
        int lenq = queries.GetLength(0);
        var ans = new double[lenq];
        for(int i=0; i<lenq; i++) {
            var start = queries[i,0];
            var end = queries[i,1];
            var visited = new HashSet<string>();
            double tans = -1;
            bool Rec(string n, double s) {
                // Spoiler: x/x.. Need to check if it exists in the map
                if (!map.ContainsKey(n))
                    return false;
                
                if (visited.Contains(n)) return false;
                visited.Add(n);
                if (n==end) {
                    tans = s;
                    return true;
                }
                else {
                    foreach(var next in map[n].Keys) {
                        if (Rec(next, s * map[n][next]))
                            return true;
                    }
                }
                return false;
            }
            Rec(start, 1.0);
            ans[i] = tans;
        }
        
        return ans;
    }
}
