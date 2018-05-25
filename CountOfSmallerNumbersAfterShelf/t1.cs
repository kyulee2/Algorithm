/*
You are given an integer array nums and you have to return a new counts array. The counts array has the property where counts[i] is the number of smaller elements to the right of nums[i].

Example:

Input: [5,2,6,1]
Output: [2,1,1,0] 
Explanation:
To the right of 5 there are 2 smaller elements (2 and 1).
To the right of 2 there is only 1 smaller element (1).
To the right of 6 there is 1 smaller element (1).
To the right of 1 there is 0 smaller element.
*/

// Comment: The key idea is to use BST.
// This problem finds the smaller number to the right.
// So, we should construct BST by traversing input backward.
// When new node traverse to the left child (smaller than the existing node), then book-keep such smaller count to the root/current node.
// When new ndoe traverse to the right child, update/add the root's left child count to the cnt of the current node which would be the answer -- note this won't change while the left child count might change. Two properties are the key.

public class Solution
{
    class Node
    {
        public Node(int v) { val = v; }
        public int val;
        public int cnt;
        public int lcnt; // small childs
        public Node left;
        public Node right;
    }
    void Rec(Node r, Node n)
    {
        if (r.val > n.val)
        {
            r.lcnt++;
            if (r.left == null)
            {
                r.left = n;
                return;
            }
            Rec(r.left, n);
        }
        else
        {
            n.cnt += r.lcnt;
            if (r.val < n.val)
            {
                ++n.cnt;
            }

            if (r.right == null)
            {
                r.right = n;
                return;
            }
            Rec(r.right, n);
        }
    }
    public IList<int> CountSmaller(int[] nums)
    {
        List<int> ans = new List<int>();
        int len = nums.Length;
        Node[] map = new Node[len];
        if (len == 0) return ans;
        Node r = new Node(nums[len-1]);
        map[len-1] = r;

        // main loop
        for(int i=len-2; i>=0; i--)
        {
            Node n = new Node(nums[i]);
            map[i] = n;
            Rec(r, n);
        }

        // build ans from map
        foreach (var n in map)
            ans.Add(n.cnt);

        return ans;
    }
}

