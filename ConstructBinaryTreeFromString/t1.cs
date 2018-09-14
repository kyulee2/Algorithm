/*
You need to construct a binary tree from a string consisting of parenthesis and integers.

The whole input represents a binary tree. It contains an integer followed by zero, one or two pairs of parenthesis. The integer represents the root's value and a pair of parenthesis contains a child binary tree with the same structure.

You always start to construct the left child node of the parent first if it exists.

Example:
Input: "4(2(3)(1))(6(5))"
Output: return the tree root node representing the following tree:

       4
     /   \
    2     6
   / \   / 
  3   1 5   
Note:
There will only be '(', ')', '-' and '0' ~ '9' in the input string.
An empty tree is represented by "" instead of "()".
*/
// Comment: Spoiler matching '-'
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public TreeNode Str2tree(string s) {
        if (s=="") return null;
        int i=0, len = s.Length;
        TreeNode Rec()
        {
            if (i==len) return null;
            int j = i;
            for(; j<len; j++)
                if (s[j]=='(' || s[j]==')')
                    break;
            //Console.WriteLine("{0}", s.Substring(i, j-i));
            int n = Convert.ToInt32(s.Substring(i, j-i));
            i = j;
            var r = new TreeNode(n);
            if (i<len && s[i]=='(') {
                i++;
                r.left = Rec();
                i++; // match ')'
            }
            if (i<len && s[i]=='(') {
                i++;
                r.right = Rec();
                i++;  // match ')'
            }
            return r;
        }
        return Rec();
    }
}
