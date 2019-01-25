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
class WordDictionary {
public:
    /** Initialize your data structure here. */
    bool isEnd;
    map<char, WordDictionary> m;
    WordDictionary() {
        isEnd = false;
    }
    
    /** Adds a word into the data structure. */
    void addWord(string word) {
        Rec(word, 0, *this);
    }
    void Rec(string &s, int i, WordDictionary& w) {
        if (s.length()==i) {
            w.isEnd = true;
            return;
        }
        char c = s[i];
        if (w.m.find(c) == w.m.end())
            w.m[c] = WordDictionary();
        
        Rec(s, i+1, w.m[c]);
    }
    
    /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
    bool search(string word) {
        return Rec2(word, 0, *this);
    }
    bool Rec2(string &s, int i, WordDictionary& w) {
        if (s.length()==i)
            return w.isEnd;
        char c = s[i];
        if (c!='.') {
            if (w.m.find(c)==w.m.end())
                return false;
            return Rec2(s, i+1, w.m[c]);
        }        
        for(auto &tup : w.m)
            if (Rec2(s, i+1, tup.second))
                return true;
        return false;
    }
};

/**
 * Your WordDictionary object will be instantiated and called as such:
 * WordDictionary obj = new WordDictionary();
 * obj.addWord(word);
 * bool param_2 = obj.search(word);
 */f
