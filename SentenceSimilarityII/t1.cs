/*
Given two sentences words1, words2 (each represented as an array of strings), and a list of similar word pairs pairs, determine if two sentences are similar. 
For example, words1 = ["great", "acting", "skills"] and words2 = ["fine", "drama", "talent"] are similar, if the similar word pairs are pairs = [["great", "good"], ["fine", "good"], ["acting","drama"], ["skills","talent"]]. 
Note that the similarity relation is transitive. For example, if "great" and "good" are similar, and "fine" and "good" are similar, then "great" and "fine" are similar. 
Similarity is also symmetric. For example, "great" and "fine" being similar is the same as "fine" and "great" being similar. 
Also, a word is always similar with itself. For example, the sentences words1 = ["great"], words2 = ["great"], pairs = [] are similar, even though there are no specified similar word pairs. 
Finally, sentences can only be similar if they have the same number of words. So a sentence like words1 = ["great"] can never be similar to words2 = ["doubleplus","good"]. 
Note: 
The length of words1 and words2 will not exceed 1000.
The length of pairs will not exceed 2000.
The length of each pairs[i] will be 2.
The length of each words[i] and pairs[i][j] will be in the range [1, 20].
*/
// Comment: Read condition carefully. Similarity consider individual word at the same index in words1/words2 respectively. Only when all the similiarity meets for each index, the sentence is similar.
public class Solution {
    class Node {
        public Node(string s) {
            str = s;
            next = new HashSet<Node>();
        }
        public string str;
        public HashSet<Node> next;
    }
    
    HashSet<Node> visited;
    Dictionary<string, Node> map;
    
    void buildNode(string[,] pairs) {
        for(int i=0; i<pairs.GetLength(0); i++) {
            string l = pairs[i,0];
            string r = pairs[i,1];
            if (!map.ContainsKey(l))
                map[l] = new Node(l);
            if (!map.ContainsKey(r))
                map[r] = new Node(r);
            map[l].next.Add(map[r]);
            map[r].next.Add(map[l]);
        }        
    }
    bool isSimilar(string s1, string s2) {
        // Trivial case for the same string
        if (s1 == s2) return true;
        
        visited.Clear();
        if (!map.ContainsKey(s1)) return false;
        if (!map.ContainsKey(s2)) return false;
        
        return Rec(map[s1], map[s2]);
    }
    bool Rec(Node n1, Node n2) {
        if (visited.Contains(n1))
            return false;
        if (n1 == n2) return true;
        visited.Add(n1);
        
        // visit neighbors
        foreach(var r in n1.next)
            if (Rec(r, n2))
                return true;
        
        return false;
    }
    public bool AreSentencesSimilarTwo(string[] words1, string[] words2, string[,] pairs) {
        if (words1.Length != words2.Length) return false;
        
        // Build node/map
        map = new Dictionary<string, Node>();
        visited = new HashSet<Node>();
        buildNode(pairs);
        
        // Main loop
        for(int i=0; i<words1.Length; i++)
            if (!isSimilar(words1[i], words2[i]))
                return false;
        return true;
    }
}

