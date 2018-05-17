/*

Implement a trie with insert, search, and startsWith methods.

Note:
You may assume that all inputs are consist of lowercase letters a-z.

Seen this question in a real interview before?  
*/

// Comment
// 1. Don't forget use Child reference (Curr.Child not Curr)
// 2. Initialize Child

public class Trie
{
    bool End;
    Dictionary<char, Trie> Child;

    /** Initialize your data structure here. */
    public Trie()
    {
        Child = new Dictionary<char, Trie>();
    }

    /** Inserts a word into the trie. */
    public void Insert(string word)
    {
        Trie Curr = this;
        foreach(var c in word)
        {
            if (!Curr.Child.ContainsKey(c))
                Curr.Child[c] = new Trie();
            Curr = Curr.Child[c];
        }
        Curr.End = true;
    }

    /** Returns if the word is in the trie. */
    public bool Search(string word)
    {
        Trie Curr = this;
        foreach (var c in word)
        {
            if (!Curr.Child.ContainsKey(c))
                return false;
            Curr = Curr.Child[c];
        }

        return Curr.End;
    }

    /** Returns if there is any word in the trie that starts with the given prefix. */
    public bool StartsWith(string prefix)
    {
        Trie Curr = this;
        foreach (var c in prefix)
        {
            if (!Curr.Child.ContainsKey(c))
                return false;
            Curr = Curr.Child[c];
        }

        return true;
    }
}

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */

