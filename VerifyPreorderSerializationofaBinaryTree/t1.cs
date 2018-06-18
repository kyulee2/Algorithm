/*
One way to serialize a binary tree is to use pre-order traversal. When we encounter a non-null node, we record the node's value. If it is a null node, we record using a sentinel value such as #.

     _9_
    /   \
   3     2
  / \   / \
 4   1  #  6
/ \ / \   / \
# # # #   # #
For example, the above binary tree can be serialized to the string "9,3,4,#,#,1,#,#,2,#,6,#,#", where # represents a null node.

Given a string of comma separated values, verify whether it is a correct preorder traversal serialization of a binary tree. Find an algorithm without reconstructing the tree.

Each comma separated value in the string must be either an integer or a character '#' representing null pointer.

You may assume that the input format is always valid, for example it could never contain two consecutive commas such as "1,,3".

Example 1:

Input: "9,3,4,#,#,1,#,#,2,#,6,#,#"
Output: true
Example 2:

Input: "1,#"
Output: false
Example 3:

Input: "9,#,#,1"
Output: false
*/
// Comment: A bit straightforward by Preorder visiting.
// But be sure when index (i) is increased.
// Below, created list<char> which is easier for indexing.
public class Solution {
    bool Rec() {
        if (i>=len)
            return false;
        char c = s[i++];
        if (c=='#') return true;
        bool l = Rec();
        if (!l) return false;
        return Rec();
    }
    int i;
    int len;
    List<char> s;
    public bool IsValidSerialization(string preorder) {
        // Init data
        s = new List<char>();
        if (preorder.Length==0) return true;
        int j = -1; int start = 0;
        while(start<preorder.Length-1 && (j=preorder.IndexOf(',',start)) != -1) {
            char c = preorder[j-1];
            s.Add(c);
            start = j+1;
        }
        char d = preorder[preorder.Length-1];
        s.Add(d);
        len = s.Count;
        i = 0;
        
        // Main Rec
        bool ans = Rec();
        
        return ans && i==len;
    }
}
 
