/*
Serialization is the process of converting a data structure or object into a sequence of bits so that it can be stored in a file or memory buffer, or transmitted across a network connection link to be reconstructed later in the same or another computer environment.
Design an algorithm to serialize and deserialize an N-ary tree. An N-ary tree is a rooted tree in which each node has no more than N children. There is no restriction on how your serialization/deserialization algorithm should work. You just need to ensure that an N-ary tree can be serialized to a string and this string can be deserialized to the original tree structure.
For example, you may serialize the following 3-ary tree
 

 
 
as [1 [3[5 6] 2 4]]. You do not necessarily need to follow this format, so please be creative and come up with different approaches yourself.
 
Note:
N is in the range of [1, 1000]
Do not use class member/global/static variables to store states. Your serialize and deserialize algorithms should be stateless.
 
*/
// Comment: Similar to Binary tree, use a queue to traverse for either serialization/deserialization.
// The key part is to record val along with number of childrent. In partcular, for deserialization, when adding/creating a node, just creates children space and queue it along with the count.
// We actually register its children node when the parent node is poped.
/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;

    public Node(){}
    public Node(int _val,IList<Node> _children) {
        val = _val;
        children = _children;
}
*/
public class Codec {

    // Encodes a tree to a single string.
    public string serialize(Node root) {
        if (root== null) return "";
        var ans = new StringBuilder();
        var q = new Queue<Node>();
        q.Enqueue(root);
        while(q.Count != 0) {
            var n = q.Dequeue();
            var d = n.children.Count;
            ans.Append(" ");
            ans.Append(n.val);
            ans.Append(" ");
            ans.Append(d);
            foreach(var next in n.children)
                q.Enqueue(next);
        }
        return ans.ToString().Trim();
    }

    // Decodes your encoded data to tree.
    public Node deserialize(string data) {
        if (data=="") return null;
        var ins = data.Split(' ');
        int i=0;
        var val = Convert.ToInt32(ins[i++]);
        var cnt = Convert.ToInt32(ins[i++]);
        
        var q = new Queue<Tuple<Node,int>>();
        var root = new Node(val, new List<Node>());        
        q.Enqueue(new Tuple<Node,int>(root, cnt));
        while(q.Count != 0) {
            var n = q.Dequeue();
            var nr = n.Item1;
            var nc = n.Item2;
            for(int j=0; j<nc; j++) {
                var val2 = Convert.ToInt32(ins[i++]);
                var cnt2 = Convert.ToInt32(ins[i++]);
                var r2 = new Node(val2, new List<Node>());
                nr.children.Add(r2);// register it to root's child
                q.Enqueue(new Tuple<Node, int>(r2, cnt2));
            }
        }
        
        return root;
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.deserialize(codec.serialize(root));