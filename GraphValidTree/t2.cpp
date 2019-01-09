/*
Given n nodes labeled from 0 to n-1 and a list of undirected edges (each edge is a pair of nodes), write a function to check whether these edges make up a valid tree.
Example 1:
Input: n = 5, and edges = [[0,1], [0,2], [0,3], [1,4]]
Output: true
Example 2:
Input: n = 5, and edges = [[0,1], [1,2], [2,3], [1,3], [1,4]]
Output: false
Note: you can assume that no duplicate edges will appear in edges. Since all edges are undirected, [0,1] is the same as [1,0] and thus will not appear together in edges.
*/
// Comment: t1.cs seems so tricky to repro
// Here uses build graph with edge for undirect graph
// Use not visited set. For each visited, remove opposite edge so that we don't come back thru the same edge.
// WHen visiting finished, ensure all nodes are visited without cycle.
// Unlike topological sort where a schedule is needed, here we don't. so a visited set should be enough.

class Solution {
public:
    set<int> visited;
    map<int, set<pair<int,int>>> m; // graph
    bool Rec(int n) {
        if (visited.find(n) != visited.end()) return false;
        visited.insert(n);
        
        for(auto edge : m[n]) {
            // remove edge
            for(auto e : m[edge.second])
                if (e.second==n) {
                    m[edge.second].erase(e);
                    break;
                }
            if (!Rec(edge.second))
                return false;
        }
        
        return true;
    }
    
    bool validTree(int n, vector<pair<int, int>>& edges) {
        // BUild graph both edges
        for(auto e : edges) {
            m[e.first].insert(make_pair(e.first, e.second));
            m[e.second].insert(make_pair(e.second, e.first));
        }
        
        if (!Rec(0))
            return false;
        if (visited.size() != n)
            return false;
        
        return true;
    }
};