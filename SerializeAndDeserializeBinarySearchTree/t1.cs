/*
Serialization is the process of converting a data structure or object into a sequence of bits so that it can be stored in a file or memory buffer, or transmitted across a network connection link to be reconstructed later in the same or another computer environment. 
Design an algorithm to serialize and deserialize a binary search tree. There is no restriction on how your serialization/deserialization algorithm should work. You just need to ensure that a binary search tree can be serialized to a string and this string can be deserialized to the original tree structure.
The encoded string should be as compact as possible. 
Note: Do not use class member/global/static variables to store states. Your serialize and deserialize algorithms should be stateless. 

*/
// Comment: We could use a queue to do this like a binary tree.
// Since it's a BST, we could simply use a preorder walk.
// When restroing it, the key part is to find the partition of the input.
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
        var ans = new StringBuilder();
        void Rec(TreeNode n) {
            if (n==null)
                return;
            ans.Append(" ");
            ans.Append(n.val);
            Rec(n.left);
            Rec(n.right);
        }
        
        Rec(root);
        return ans.ToString().Trim();
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) {
        if (data == "") return null;
        var ins = data.Split(' ');
        int len = ins.Length;
        TreeNode Rec(int i, int j) { // reconstruct preorder from i to j (not inclusive)
            if (i>=j)
                return null;
            var ans = new TreeNode(Convert.ToInt32(ins[i]));
            int k = i + 1;
            while(k<j && Convert.ToInt32(ins[k])<ans.val) // spoiler: convert here not string
                k++;
            ans.left = Rec(i+1, k);
            ans.right = Rec(k, j);
            return ans;
        }
        //Console.WriteLine(data);
        return Rec(0, len);            
    }

    // Another way using BinarySearch
    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) {
        if (data == "") return null;
        var ins = data.Split(' ');
        int len = ins.Length;
        var input = new List<int>();
        foreach(var s in ins)
            input.Add(Convert.ToInt32(s));
        
        TreeNode Rec(int i, int j) { // reconstruct preorder from i to j (not inclusive)
            if (i>j)
                return null;
            var ans = new TreeNode(input[i]);
            // Search index at which is greater than the current value
            var k = input.BinarySearch(i+1, j-i, ans.val, Comparer<int>.Create((x, y) =>x-y));
            if (k<0)
                k = -k - 1;
            ans.left = Rec(i+1, k-1);
            ans.right = Rec(k, j);
            return ans;
        }
        //Console.WriteLine(data);
        return Rec(0, len-1);            
    }


}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.deserialize(codec.serialize(root));
