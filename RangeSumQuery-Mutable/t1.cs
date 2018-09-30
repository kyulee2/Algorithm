/*
Given an integer array nums, find the sum of the elements between indices i and j (i = j), inclusive.
The update(i, val) function modifies nums by updating the element at index i to val.
Example:
Given nums = [1, 3, 5]

sumRange(0, 2) -> 9
update(1, 2)
sumRange(0, 2) -> 8
Note:
The array is only modifiable by the update function.
You may assume the number of calls to update and sumRange function is distributed evenly.
*/
// Comment: Use a segment tree to contain sum of a range.
// Build O(n). Update/GetSum is O(logn)
// Need to revisit for BinaryIndexTree
public class NumArray {
    // segment tree
    public class Tree {
        public Tree left, right;
        public int sum;
        public int start, end;
        public Tree(int a, int b) {
            start = a; end = b;
        }
    }
    Tree root;
    Tree buildTree(int[] nums, int start, int end)
    {
        if (start > end)
            return null;
        var r = new Tree(start, end);
        if (start == end)
            r.sum = nums[start];
        else {
            int mid = start + (end-start)/2;
            r.left = buildTree(nums, start, mid);
            r.right = buildTree(nums, mid+1, end);
            r.sum = r.left.sum + r.right.sum;
        }
        return r;
    }
    
    public NumArray(int[] nums) {
        root = buildTree(nums, 0, nums.Length-1);
    }
    
    public void Update(int i, int val) {
        update(root, i, val);
    }
    void update(Tree n, int pos, int val) {
        if (n.start == n.end)
            n.sum = val;
        else {
            int mid = n.start + (n.end-n.start)/2;
            if (pos<=mid)
                update(n.left, pos, val);
            else
                update(n.right, pos, val);
            n.sum = n.left.sum + n.right.sum;
        }
    }
    
    public int SumRange(int i, int j) {
        return sum(root, i, j);
    }
    int sum(Tree n, int s, int e) {
        if (n.start ==s && n.end == e)
            return n.sum;
        int mid = n.start + (n.end-n.start)/2;
        if (e<=mid)
            return sum(n.left, s, e);
        else if (s>mid)
            return sum(n.right, s, e);
        else
            return sum(n.left, s, mid) + sum(n.right, mid+1, e);
    }
}

/**
 * Your NumArray object will be instantiated and called as such:
 * NumArray obj = new NumArray(nums);
 * obj.Update(i,val);
 * int param_2 = obj.SumRange(i,j);
 */
