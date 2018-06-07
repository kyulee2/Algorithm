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
// Comment: Idea is to compare two consecutive string.
// When the comparision is broken (different char at the same index), put edge between two node/char
// From each parent (no child/next) node, visit all node recursively and update the maximum distance on each node.
// The tricky part is to detect cycle where we should return "" (no order).
// Should make sure all nodes are reachable from parent -- think about GC. If total nodes visited from all parents are different than total node, it's a cycle.
// Other good practice is to create all node initially instead of making them on demand -- see initNode
public class Solution {
    class Node {
        public int dist;
        public char c;
        public HashSet<Node> next;
        public Node(char ch) {
            c = ch;
            next = new HashSet<Node>();
        }
        public void ComputeDist(int d)
        {
            dist = Math.Max(d, dist);
        }
    }
    HashSet<Node> parents; // node without child
    Dictionary<char, Node> map;
    HashSet<Node> visited;
    HashSet<Node> output; // Node all visited node from parent
    
    void buildMap(string s1, string s2)
    {
        int len1 = s1.Length;
        int len2 = s2.Length;
        int i = 0, j = 0;
        while(i<len1 && j<len2) {
            char c1 = s1[i++];
            char c2 = s2[j++];
            if (c1 == c2) continue;
            
            Node n1 = map[c1];
            Node n2 = map[c2];
            n1.next.Add(n2);
            parents.Remove(n2);
            break;
        }
    }
    
    void initNode(string[] words)
    {
        foreach(var s in words)
            foreach(var c in s) {
                if (!map.ContainsKey(c)) {
                    Node n = new Node(c);
                    map[c] = n;
                    parents.Add(n);
                }
            }
    }
    
    bool Rec(Node n, int d)
    {
        // Circular detection which means no order
        if(visited.Contains(n)) return false;
        
        visited.Add(n);
        // Spoiler: keep track of all nodes visited
        output.Add(n);
        n.ComputeDist(d);
        
        // visit next nodes
        bool ans = true;
        foreach(var c in n.next) {
            ans &= Rec(c, d+1);
            // Spoiler: Do not forget remove this
            if (!ans) {
                visited.Remove(n);
                return false;
            }
        }
        // Spoiler: Be sure remove this
        visited.Remove(n);
        
        return ans;
    }
    
    public string AlienOrder(string[] words) {
        // Initialize data
        parents = new HashSet<Node>();
        map = new Dictionary<char, Node>();
        visited = new HashSet<Node>();
        output = new HashSet<Node>();
        
        // Build node/map
        initNode(words);
        string prev = words[0];        
        for(int i=1; i<words.Length; i++) {
            string curr = words[i];
            buildMap(prev, curr);
            prev = curr;
        }
        
        // Recursion to update dist from parents (max value)
        foreach(var p in parents) {
            bool ans = Rec(p, 0);
            if (!ans) return "";
        }
        
        // Sort values of map by dist
        List<Node> l = map.Values.ToList();
        if (l.Count != output.Count) // not all visited found from parents -cycle
            return "";        
        l.Sort((x,y) => (x.dist - y.dist));
        
        // Output
        StringBuilder b = new StringBuilder();
        foreach(var n in l)
            b.Append(n.c);
        return b.ToString();
    }
}

