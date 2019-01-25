/*
For a undirected graph with tree characteristics, we can choose any node as the root. The result graph is then a rooted tree. Among all possible rooted trees, those with minimum height are called minimum height trees (MHTs). Given such a graph, write a function to find all the MHTs and return a list of their root labels.

Format
The graph contains n nodes which are labeled from 0 to n - 1. You will be given the number n and a list of undirected edges (each edge is a pair of labels).

You can assume that no duplicate edges will appear in edges. Since all edges are undirected, [0, 1] is the same as [1, 0] and thus will not appear together in edges.

Example 1 :

Input: n = 4, edges = [[1, 0], [1, 2], [1, 3]]

        0
        |
        1
       / \
      2   3 

Output: [1]
Example 2 :

Input: n = 6, edges = [[0, 3], [1, 3], [2, 3], [4, 3], [5, 4]]

     0  1  2
      \ | /
        3
        |
        4
        |
        5 

Output: [3, 4]
Note:

According to the definition of tree on Wikipedia: Î tree is an undirected graph in which any two vertices are connected by exactly one path. In other words, any connected graph without simple cycles is a tree.Î
The height of a rooted tree is the number of edges on the longest downward path between the root and a leaf.
*/
// Comment: Navie recursion results in time-out. Should cache edge to distance where edge has a directed one.
// So, when we build graph, we actually add two different edges from s to e, and e to s.
// But considering distance (which resturns from the child node), consider the direction.
// This is quite interesting. Use edge graph map while useing node visited map to avoid duplicaiton.
// t3.cpp uses a node graph (with visited set too) while edge cache map. A bit simpler than t2.cpp
// The cache is queried and updated for each edge within child node loop.
class Solution {
public:
    map<int, set<int>> me; // start to set of child nodes
    map<pair<int, int>, int> m; // edge to min distance cache
    set<int> visited;  // node visited map
    int min;
    vector<int> ans;
    int Rec(int n) {
        visited.insert(n);
        
        int curr = 0;
        for(auto c : me[n]) {
            if (visited.find(c) != visited.end())
                continue;
            
            // Check the edge in cache
            auto e = make_pair(n,c);
            if (m.find(e)!=m.end())
                curr = max(curr, m[e]);
            else {
                int h= Rec(c) + 1;
                // Record the min height to the current edge map
                m[e] = h;
                curr = max(curr, h);
            }
        }
        return curr;
    }
    
    vector<int> findMinHeightTrees(int n, vector<pair<int, int>>& edges) {
        min = INT_MAX;
        // build graph
        for(auto edge : edges) {
            auto s = edge.first;
            auto e = edge.second;
            me[s].insert(e);
            me[e].insert(s);
        }
        for(int i =0; i<n; i++) {
            visited.clear();
            auto curr = Rec(i);

            if (curr<min) {
                min = curr;
                ans.clear();
                ans.push_back(i);
            } else if (curr==min) {
                ans.push_back(i);
            }            
        }
        return ans;
    }
};
