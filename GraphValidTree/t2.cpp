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
// Comment: The graph is undirected map. So, I added both edges from src to tgt, vice-versa. THis is simpler than t1.cs.
// The key idea is to remove opposite edge -- we take one direction only.
// In case a same node is visited, it means not valid DAG.
class Solution {
public:
    set<int> visited;
    map<int, set<int>> m; // graph
    bool Rec(int n) {
        if (visited.find(n) != visited.end()) return false;
        visited.insert(n);
        
        for(auto t : m[n]) {
            // remove opposite edge
            m[t].erase(n);
            
            if (!Rec(t))
                return false;
        }
        
        return true;
    }
    
    bool validTree(int n, vector<pair<int, int>>& edges) {
        // BUild graph both edges
        for(auto e : edges) {
            auto s = e.first;
            auto t = e.second;
            m[s].insert(t);
            m[t].insert(s);
        }
        
        if (!Rec(0))
            return false;
        if (visited.size() != n)
            return false;
        
        return true;
    }
};


