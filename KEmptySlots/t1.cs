/*
There is a garden with N slots. In each slot, there is a flower. The N flowers will bloom one by one in N days. In each day, there will be exactly one flower blooming and it will be in the status of blooming since then. 
Given an array flowers consists of number from 1 to N. Each number in the array represents the place where the flower will open in that day. 
For example, flowers[i] = x means that the unique flower that blooms at day i will be at position x, where i and x will be in the range from 1 to N. 
Also given an integer k, you need to output in which day there exists two flowers in the status of blooming, and also the number of flowers between them is k and these flowers are not blooming. 
If there isn't such day, output -1. 
Example 1:
Input: 
flowers: [1,3,2]
k: 1
Output: 2
Explanation: In the second day, the first and the third flower have become blooming.

Example 2:
Input: 
flowers: [1,2,3]
k: 1
Output: -1

Note:
The given array will be in the range [1, 20000].
*/

// COMMENT: It appears hard initially. I thought each node has two refernece (left/right) to form a range.
// For given key, find the range that contains key.
// Or, a priority queue. By inserting flower in sequence, we can compute distance in between neighbors as new flower/key is inserted. But insertion itself would be O(n). So overall complexity would be O(n^2)
// In fact, we can solve this by building BST (insertion O(log(n), overall O(nlogn)) as below.
// TODO: there may be the better/simpler solution given the problem is restricted for integer [1,20000] while the BST solution below wouldn't care such range. I haven't searched/thought about it.

// Spoiler: The distance should have -1 (not +1 ) between two numbers. 

public class Solution
{
   class Node
   {
      public Node left;
      public Node right;
      public int key;
      public Node(int k) { key = k; }
   }

   class Solver
   {
      int[] flowers;
      int k;
      Node min;
      Node max;
      Node nil = new Node(0);
      public Solver(int[] f, int key)
      {
         flowers = f;
         k = key;
      }

      public int perform()
      {
         if (flowers.Length <= 1)
            return -1;
         Node root = new Node(flowers[0]);

         for (int i = 1; i < flowers.Length; i++)
         {
            min = nil;
            max = nil;
            bool ans = rec(root, flowers[i]);
            if (ans) return i + 1;
         }
         return -1;
      }

      bool check(Node n)
      {
         if (min != nil)
         {
            if (n.key - min.key - 1 == k)
               return true;
         }
         if (max != nil)
         {
            if (max.key - n.key - 1 == k)
               return true;
         }
         return false;
      }

      bool rec(Node n, int key)
      {
         if (key < n.key)
         {
            Node l = n.left;
            max = n;
            if (l != null)
            {
               return rec(l, key);
            }
            n.left = new Node(key);
            return check(n.left);
         }
         // assert key> n.key
         Node r = n.right;
         min = n;
         if (r != null)
         {
            return rec(r, key);
         }
         n.right = new Node(key);
         return check(n.right);
      }
   }

   public int KEmptySlots(int[] flowers, int k)
   {
      Solver s = new Solver(flowers, k);
      return s.perform();
   }
}

