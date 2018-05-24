/*
Serialization is the process of converting a data structure or object into a sequence of bits so that it can be stored in a file or memory buffer, or transmitted across a network connection link to be reconstructed later in the same or another computer environment.

Design an algorithm to serialize and deserialize a binary tree. There is no restriction on how your serialization/deserialization algorithm should work. You just need to ensure that a binary tree can be serialized to a string and this string can be deserialized to the original tree structure.

Example: 

You may serialize the following tree:

    1
   / \
  2   3
     / \
    4   5

as "[1,2,3,null,null,4,5]"
Clarification: Just the same as how LeetCode OJ serializes a binary tree. You do not necessarily need to follow this format, so please be creative and come up with different approaches yourself.

Note: Do not use class member/global/static variables to store states. Your serialize and deserialize algorithms should be stateless.

*/

// Comment: tried this code " 1 2 3 null null 4 5 null null null null"
// On serialization, use a queue to traverse tree per line. Always append empty space to break. When adding "null" string, no more processing childs.
// On deserialization. also use a queue. Had a getNext to get next string.
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Codec {

    // Encodes a tree to a single string.
    public string serialize(TreeNode root) {
        if (root == null) return "null";
        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);
        TreeNode nil = new TreeNode(0);
        StringBuilder ans = new StringBuilder();
        while(q.Count != 0) {
            TreeNode n = q.Dequeue();
            ans.Append(' ');
            if (n == nil) {
                ans.Append("null");
                continue; // No child process
            }
            else ans.Append(n.val.ToString());
            
            if (n.left == null) q.Enqueue(nil);
            else q.Enqueue(n.left);
            if (n.right == null) q.Enqueue(nil);
            else q.Enqueue(n.right);
        }
        return ans.ToString();
    }

    int i;
    int len;
    string d;
    string getNext()
    {
        int j = i;
        while(i < len && d[i] !=' ') i++;
        string sub = d.Substring(j, i-j);
        // skip white space
        while(i < len && d[i] == ' ') i++;
        return sub;
    }
    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) {
        if(data==null) return null;
        i = 0;
        len = data.Length;
        d = data;
        while(data[i] ==' ') {i++;}
        if (i==len) return null;
        string r2 = getNext();
        if (r2=="null") return null;
        TreeNode root = new TreeNode(Convert.ToInt32(r2));
        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);
        while(i < len) {
            TreeNode n = q.Dequeue();
            
            string l = getNext();
            if (l != "null") {
                TreeNode left = new TreeNode(Convert.ToInt32(l));
                q.Enqueue(left);
                n.left = left;
            }
            
            string r = getNext();
            if (r != "null") {
                TreeNode right = new TreeNode(Convert.ToInt32(r));
                q.Enqueue(right);
                n.right = right;
            }
        }
        
        return root;
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.deserialize(codec.serialize(root));

