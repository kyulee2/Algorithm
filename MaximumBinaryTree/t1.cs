/*
Given an integer array with no duplicates. A maximum tree building on this array is defined as follow:

The root is the maximum number in the array.
The left subtree is the maximum tree constructed from left part subarray divided by the maximum number.
The right subtree is the maximum tree constructed from right part subarray divided by the maximum number.
Construct the maximum tree by the given array and output the root node of this tree.

Example 1:
Input: [3,2,1,6,0,5]
Output: return the tree root node representing the following tree:

      6
    /   \
   3     5
    \    / 
     2  0   
       \
        1
Note:
The size of the given array will be in the range [1,1000].

*/
// Comment: Straightfoward. Careful about i>j condition below to bail-out.
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
    public TreeNode ConstructMaximumBinaryTree(int[] nums) {
        int len = nums.Length;
        TreeNode Rec(int i, int j) {
//            if (i<0||i>=len||j<0||j>=len||i>j)
	      if (i>j)
                return null;
            int maxi = i;
            int max = nums[i];
            for(int k=i+1; k<=j; k++) {
                if (nums[k] > max) {
                    max = nums[k];
                    maxi = k;
                }
            }
            TreeNode root = new TreeNode(max);
            root.left = Rec(i, maxi-1);
            root.right = Rec(maxi+1, j);
            return root;
        }
        
        return Rec(0, len-1);
    }
}

