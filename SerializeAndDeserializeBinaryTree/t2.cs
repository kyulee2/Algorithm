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
        if (root==null) return "null";
        var ansb = new StringBuilder();
        TreeNode nil = new TreeNode(0);
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        while(q.Count != 0) {
            var n = q.Dequeue();
            if (n==nil)
                ansb.Append("null");
            else
                ansb.Append(n.val.ToString());
            
            ansb.Append(" ");
            if (n==nil)
                continue;
            
            var left = n.left;
            if (left==null) q.Enqueue(nil);
            else q.Enqueue(left);
            var right = n.right;
            if (right ==null) q.Enqueue(nil);
            else q.Enqueue(right);
        }
        return ansb.ToString();
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) {
        if (data=="null") return null;
        var q = new Queue<TreeNode>();
        var l = data.Split(' ');
        int i=0;
        var ans = new TreeNode(Convert.ToInt32(l[i++]));
        q.Enqueue(ans);
        while(q.Count != 0) {
            var n = q.Dequeue();
            var left = l[i++];
            if (left!="null") {
                n.left = new TreeNode(Convert.ToInt32(left));
                q.Enqueue(n.left);
            }
            var right = l[i++];
            if  (right!="null") {
                n.right = new TreeNode(Convert.ToInt32(right));
                q.Enqueue(n.right);
            }
        }
        return ans;
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.deserialize(codec.serialize(root));
