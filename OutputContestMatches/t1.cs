/*
During the NBA playoffs, we always arrange the rather strong team to play with the rather weak team, like make the rank 1 team play with the rank nth team, which is a good strategy to make the contest more interesting. Now, you're given n teams, you need to output their final contest matches in the form of a string. 
The n teams are given in the form of positive integers from 1 to n, which represents their initial rank. (Rank 1 is the strongest team and Rank n is the weakest team.) We'll use parentheses('(', ')') and commas(',') to represent the contest team pairing - parentheses('(' , ')') for pairing and commas(',') for partition. During the pairing process in each round, you always need to follow the strategy of making the rather strong one pair with the rather weak one.
Example 1:
Input: 2
Output: (1,2)
Explanation: 
Initially, we have the team 1 and the team 2, placed like: 1,2.
Then we pair the team (1,2) together with '(', ')' and ',', which is the final answer.

Example 2:
Input: 4
Output: ((1,4),(2,3))
Explanation: 
In the first round, we pair the team 1 and 4, the team 2 and 3 together, as we need to make the strong team and weak team together.
And we got (1,4),(2,3).
In the second round, the winners of (1,4) and (2,3) need to play again to generate the final winner, so you need to add the paratheses outside them.
And we got the final answer ((1,4),(2,3)).

Example 3:
Input: 8
Output: (((1,8),(4,5)),((2,7),(3,6)))
Explanation: 
First round: (1,8),(2,7),(3,6),(4,5)
Second round: ((1,8),(4,5)),((2,7),(3,6))
Third round: (((1,8),(4,5)),((2,7),(3,6)))
Since the third round will generate the final winner, you need to output the answer (((1,8),(4,5)),((2,7),(3,6))).

Note:
The n is in range [2, 212].
We ensure that the input n can be converted into the form 2k, where k is a positive integer.
*/
// Comment: Build a tree by recursively creating half array elements
// Node has either string or next (two child) nodes
// Appears simple, but intially thought about using Stack.
// buildTree below can be done a two nested loop.
public class Solution {
    class Node {
        public int num;
        public Node n1;
        public Node n2;
        public Node(int n)
        {
            num = n;
        }
        public Node(Node c1, Node c2)
        {
            num = 0;
            n1 = c1; n2 =c2;
        }
    }
    
    Node root;
    StringBuilder b;
    
    void buildTree(Node[] arr)
    {
        int len = arr.Length;
        if (len==1) {
            root = arr[0];
            return;
        }
        
        Node[] ans = new Node[len/2];
        for(int i=0; i < len/2; i++) {
            ans[i] = new Node(arr[i], arr[len-i-1]);
        }
        buildTree(ans);
    }

    void Rec(Node n)
    {
        if (n.num != 0) {
            b.Append(n.num);
            return;
        }
        b.Append('(');
        Rec(n.n1);
        b.Append(',');
        Rec(n.n2);
        b.Append(')');
    }
    
    public string FindContestMatch(int n) {
        // Initialize data
        root = null;
        b = new StringBuilder();
        Node[] data = new Node[n];
        for(int i=0; i<n; i++)
            data[i] = new Node(i+1);
        
        // build tree
        buildTree(data);
        
        // recursion
        Rec(root);
        
        return b.ToString();
    }
}