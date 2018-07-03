/*
Design a data structure that supports the following two operations:

void addWord(word)
bool search(word)
search(word) can search a literal word or a regular expression string containing only letters a-z or .. A . means it can represent any one letter.

Example:

addWord("bad")
addWord("dad")
addWord("mad")
search("pad") -> false
search("bad") -> true
search(".ad") -> true
search("b..") -> true
Note:
You may assume that all words are consist of lowercase letters a-z.
*/
// Comment: Trie
public class WordDictionary {
    class Node {
        public bool isEnd;
        public Dictionary<char, Node> childs;
        public Node() {
            childs = new Dictionary<char, Node>();
        }
    }
    Node root;
    /** Initialize your data structure here. */
    public WordDictionary() {
        root = new Node();
    }
    
    /** Adds a word into the data structure. */
    public void AddWord(string word) {
        var curr = root;
        foreach(var c in word) {
            if (!curr.childs.ContainsKey(c)) {
                curr.childs[c] = new Node();
            }
            curr = curr.childs[c];
        }
        curr.isEnd = true;
    }
    
    bool Rec(Node n, String word, int i)
    {
        if (word.Length == i)
            return n.isEnd;
        char c = word[i];
        if (c != '.') {
            if (!n.childs.ContainsKey(c))
                return false;
            return Rec(n.childs[c], word, i+1);
        }
        // c == '.'
        bool ans = false;
        foreach(var next in n.childs.Values)
            ans |= Rec(next, word, i+1);
        return ans;
    }
    
    /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
    public bool Search(string word) {
        return Rec(root, word, 0);
    }
}

/**
 * Your WordDictionary object will be instantiated and called as such:
 * WordDictionary obj = new WordDictionary();
 * obj.AddWord(word);
 * bool param_2 = obj.Search(word);
 */
