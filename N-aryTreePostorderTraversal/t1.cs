/*
Given an n-ary tree, return the postorder traversal of its nodes' values.

 
For example, given a 3-ary tree:



 
Return its postorder traversal as: [5,6,3,2,4,1].

 
Note: Recursive solution is trivial, could you do it iteratively?
*/
// Comment: Easy
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
public class Solution {
    public IList<int> Postorder(Node root) {
        var ans = new List<int>();
        void Rec(Node n)
        {
            if(n==null) return;
            foreach(var c in n.children)
                Rec(c);
            ans.Add(n.val);
        }
        Rec(root);
        return ans;
    }
}
