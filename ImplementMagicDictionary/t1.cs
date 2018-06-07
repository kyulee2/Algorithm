/*
Implement a magic directory with buildDict, and search methods. 
For the method buildDict, you'll be given a list of non-repetitive words to build a dictionary. 
For the method search, you'll be given a word, and judge whether if you modify exactly one character into another character in this word, the modified word is in the dictionary you just built. 
Example 1:
Input: buildDict(["hello", "leetcode"]), Output: Null
Input: search("hello"), Output: False
Input: search("hhllo"), Output: True
Input: search("hell"), Output: False
Input: search("leetcoded"), Output: False

Note:
You may assume that all the inputs are consist of lowercase letters a-z.
For contest purpose, the test data is rather small by now. You could think about highly efficient algorithm after the contest.
Please remember to RESET your class variables declared in class MagicDictionary, as static/class variables are persisted across multiple test cases. Please see here for more details.
*/
// Comment: Initially, I bail-out (return false) if I found the same word in dictionary.
// This problem actually should search to see if there is any word with one char diff.
// So, should alter one char per index, and to see if all chars at other indexs are matched.
// And also there is one spoiler where two loop variable might colide -- see curr vs nextcurr

public class MagicDictionary {

    class Node {
        public bool IsEnd;
        public Dictionary<char, Node> next;
        public Node() {
            next = new Dictionary<char, Node>();
        }
    }
    Node root;
    
    /** Initialize your data structure here. */
    public MagicDictionary() {
        root = new Node();
    }

    void buildWord(string s)
    {
        int len = s.Length;
        Node curr = root;        
        for(int i=0; i<len; i++) {
            char c = s[i];
            if (!curr.next.ContainsKey(c))
                curr.next[c] = new Node();
            curr = curr.next[c];
        }
        curr.IsEnd = true;
    }
    
    /** Build a dictionary through a list of words */
    public void BuildDict(string[] dict) {
        foreach(var s in dict)
            buildWord(s);
    }

    // char at idx expects to be unmatched.
    bool hasDiff(string word, int idx)
    {
        int len = word.Length;
        Node curr = root;
        for(int i=0; i<idx ;i++) {
            char c = word[i];
            if (!curr.next.ContainsKey(c))
                return false;
            curr = curr.next[c];
        }
        
        char f = word[idx];
        foreach(var ch in curr.next.Keys) {
            if (ch == f) continue; // no interest to the same char
            // Spoiler: should use nextcurr instead of curr since it's the first loop variable
            Node nextcurr = curr.next[ch];
            for(int j = idx + 1; j<len; j++) {
                char c = word[j];
                if (!nextcurr.next.ContainsKey(c))
                    return false;
                nextcurr = nextcurr.next[c];           
            }
            if (nextcurr.IsEnd)
                return true;
        }
        return false;
    }
    
    /** Returns if there is any word in the trie that equals to the given word after modifying exactly one character */
    public bool Search(string word) {
        int len = word.Length;
        for(int i=0; i<len; i++)
            if (hasDiff(word, i))
                return true;
        return false;
    }
}

/**
 * Your MagicDictionary object will be instantiated and called as such:
 * MagicDictionary obj = new MagicDictionary();
 * obj.BuildDict(dict);
 * bool param_2 = obj.Search(word);
 */

