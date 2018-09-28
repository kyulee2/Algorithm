/*
Given an array nums, we call (i, j) an important reverse pair if i < j and nums[i] > 2*nums[j].
You need to return the number of important reverse pairs in the given array.
Example1: 
Input: [1,3,2,3,1]
Output: 2

Example2: 
Input: [2,4,3,5,1]
Output: 3

Note:
The length of the given array will not exceed 50,000.
All the numbers in the input array are in the range of 32-bit integer.
*/
// Comment: Use BST to record LE childs (smaller/equal value) counts.
// Note when searching query, use target -1 since we can't get < (LT) condition directly.
// When BST is balanced, the below is O(nlogn) but worst case O(n^2) for time.
// TLE due to C# should be passed with C++.
public class Solution {
    public class Node
    {
        public long val;
        public int cnt; // # of left/smaller/equal LE childs
        public Node(long v) {val = v; cnt = 1;}
        public Node left;
        public Node right;
    }
    void RecAdd(Node n, long t) { // add 2*a[j] value
        Node l = n.left;
        Node r = n.right;
        if (t==n.val) { // no add the same value node but increase count
            n.cnt++; // increase left child count while traversing left
        } else if (t<n.val) {
            n.cnt++; // increase left child count while traversing left
            if (l!= null)
                RecAdd(l, t);
            else
                n.left = new Node(t);
            
        } else {            
            if (r != null) {
                RecAdd(r, t);
            } else
                n.right = new Node(t);
        }
    }
    // Collecting smaller/left child count while traversing right side
    // Note + 1 to count the node itself
    int RecFind(Node n, long t)
    {
        Node l = n.left;
        Node r = n.right;
        //Console.WriteLine("{0} < {1} : {2}", t, n.val, t<n.val);
        if (t==n.val) {
            return n.cnt;
        } else if (t<n.val) {
            if (l!=null)
                return RecFind(l, t);
            else
                return 0;
        } else {
            if (r!= null)
                return n.cnt + RecFind(r, t);
            else
                return n.cnt;
        }
    }
    public int ReversePairs(int[] nums) {
        int len = nums.Length;
        if (len<=1) return 0;
        Node n = new Node((long)2*nums[len-1]);
        int ans = 0;
        for(int i=len-2; i>=0; i--) {
            var t = RecFind(n, nums[i] - 1);
            //Console.WriteLine("{0} for {1}", i, t);
            ans += t;
            RecAdd(n, (long)nums[i]*2);
        }
        
        return ans;
    }
}