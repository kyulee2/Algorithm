/*
Given many words, words[i] has weight i. 
Design a class WordFilter that supports one function, WordFilter.f(String prefix, String suffix). It will return the word with given prefix and suffix with maximum weight. If no word exists, return -1. 
Examples:
Input:
WordFilter(["apple"])
WordFilter.f("a", "e") // returns 0
WordFilter.f("b", "") // returns -1

Note:
words has length in range [1, 15000].
For each test case, up to words.length queries WordFilter.f may be made.
words[i] has length in range [1, 10].
prefix, suffix have lengths in range [0, 10].
words[i] and prefix, suffix queries consist of lowercase letters only.
*/
// Comment: Keep the weight in the list while adding word
// For search, use a binary search from the lagest value.
// Initially I used HashSet followed by a sort, which causes TLE
public class WordFilter {
    public class Node {
        public Dictionary<char, Node> next;
        public Node() {
            next = new Dictionary<char, Node>();
            weight = new List<int>();
        }
        public List<int> weight;
    }
    Node prefix;
    Node suffix;
    void BuildPrefix(string s, int w)
    {
        Node curr = prefix;
        curr.weight.Add(w);
        foreach(var c in s) {
            if (!curr.next.ContainsKey(c))
                curr.next[c] = new Node();
            curr = curr.next[c];
            curr.weight.Add(w);
        }
    }
    void BuildSuffix(string s, int w)
    {
        Node curr = suffix;
        curr.weight.Add(w);
        for(int i=s.Length-1; i>=0; i--) {
            var c = s[i];
            if (!curr.next.ContainsKey(c))
                curr.next[c] = new Node();
            curr = curr.next[c];
            curr.weight.Add(w);
        }
    }
    List<int> findPrefixWeight(string s)
    {
        Node curr = prefix;
        foreach(var c in s) {
            if (!curr.next.ContainsKey(c))
                return new List<int>();
            curr = curr.next[c];
        }
        return curr.weight;
    }
    List<int> findSuffixWeight(string s)
    {
        Node curr = suffix;
        for(int i=s.Length-1; i>=0; i--) {
            var c = s[i];
            if (!curr.next.ContainsKey(c))
                return new List<int>();
            curr = curr.next[c];
        }
        return curr.weight;
    }

    public WordFilter(string[] words) {
        prefix = new Node();
        suffix = new Node();
        for(int i=0; i<words.Length; i++) {
            var w = words[i];
            BuildPrefix(w, i);
            BuildSuffix(w, i);
        }
    }
    
    public int F(string prefix, string suffix) {
        var p = findPrefixWeight(prefix);
        var s = findSuffixWeight(suffix);
        int max = -1;
        if (p.Count < s.Count) {
            for(int i=p.Count-1; i>=0; i--) {
                var j = p[i];
                int idx = s.BinarySearch(j);
                if (idx>=0)
                    return j;
            }
        } else {
            for(int i=s.Count-1; i>=0; i--) {
                var j = s[i];
                int idx = p.BinarySearch(j);
                if (idx>=0)
                    return j;
            }
        }

        return max;
    }
}

/**
 * Your WordFilter object will be instantiated and called as such:
 * WordFilter obj = new WordFilter(words);
 * int param_1 = obj.F(prefix,suffix);
 */