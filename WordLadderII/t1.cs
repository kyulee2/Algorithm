/*
Given two words (beginWord and endWord), and a dictionary's word list, find all shortest transformation sequence(s) from beginWord to endWord, such that:
Only one letter can be changed at a time
Each transformed word must exist in the word list. Note that beginWord is not a transformed word.
Note:
Return an empty list if there is no such transformation sequence.
All words have the same length.
All words contain only lowercase alphabetic characters.
You may assume no duplicates in the word list.
You may assume beginWord and endWord are non-empty and are not the same.
Example 1:
Input:
beginWord = "hit",
endWord = "cog",
wordList = ["hot","dot","dog","lot","log","cog"]

Output:
[
  ["hit","hot","dot","dog","cog"],
  ["hit","hot","lot","log","cog"]
]
Example 2:
Input:
beginWord = "hit"
endWord = "cog"
wordList = ["hot","dot","dog","lot","log"]

Output: []

Explanation: The endWord "cog" is not in wordList, therefore no possible transformation.
*/
// Comment: BFS + DFS. Using just a DFS with min check is TLE. Also passing duplicated list with BFS causes TME.
// Use backtracing/rmap to trim a right edges (DAG) and then apply DFS backward to get answers.
public class Solution {
    public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList) {
        var map = new Dictionary<string, List<string>>();
        var visited = new Dictionary<string, int>();
        var ans = new List<IList<string>>();
        // convert list to set
        var wordsList = new HashSet<string>();
        foreach(var w in wordList)
            wordsList.Add(w);
        // bail-out trivial case
        if (!wordsList.Contains(endWord))
            return ans;
        wordsList.Add(beginWord);
        
        // build map
        foreach(var w in wordsList) {
            map[w] = new List<string>();
            var str = w.ToArray();
            for(int j=0; j<w.Length; j++) {
                char origc = str[j];
                for(char c = 'a'; c <='z'; c++) {
                    if (c==origc) continue;
                    str[j] = c;                    
                    var newstr = new string(str);                
                    if (!wordsList.Contains(newstr)) continue;
                    map[w].Add(newstr);
                }
                str[j] = origc;
            }
        }

        // BFS to find the shorted paths
        var q = new Queue<Tuple<string, int>>();
        var rmap = new Dictionary<string, HashSet<string>>(); // child to parent
        foreach(var w in wordsList) {
            rmap[w] = new HashSet<string>();
            visited[w] = Int32.MaxValue;
        }
        
        q.Enqueue(new Tuple<string, int>(beginWord, 0));
        visited[beginWord] = 0; 
        
        while(q.Count != 0) {
            var n  = q.Dequeue();
            var nw = n.Item1;
            var nd = n.Item2;

            if (nw == endWord) {
                continue;
            }
            
            nd++;
            // Update visited before adding childrens.
            // Otherwise TLE
            foreach(var next in map[nw]) {
                if (visited[next] > nd) {
                  q.Enqueue(new Tuple<string, int>(next, nd));
                  visited[next] = nd;
                }
                if (visited[next] >= nd) // include equal to allow an edge
                 rmap[next].Add(nw);
            }
        }
        
        // DFS backward. No need another visited check
        // since it's a DAG
        var t = new List<string>();
        void Rec(string n)
        {
            t.Add(n);
            if (n==beginWord) {
                var t1 = new List<string>(t);
                t1.Reverse();
                ans.Add(t1);
            } else {
                foreach(var next in rmap[n])
                    Rec(next);
            }

            // flush back
            t.RemoveAt(t.Count - 1);
        }
        Rec(endWord);
        return ans;
    }
}
