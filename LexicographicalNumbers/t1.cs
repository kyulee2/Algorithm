/*
Given an integer n, return 1 - n in lexicographical order.

For example, given 13, return: [1,10,11,12,13,2,3,4,5,6,7,8,9].

Please optimize your algorithm to use less time and space. The input size may be as large as 5,000,000.
*/
// Comment: Initially appears a bit hard, but turns out pretty simple.
// Only thing missed is to iterate initial condition 1-9 in the main loop since the recursion starts with multiple of 10.
public class Solution {
    public IList<int> LexicalOrder(int n) {
        List<int> ans = new List<int>();
        void Rec(int num)
        {
            if (num>n) return;
            ans.Add(num);
            num *= 10;
            for(int i=0; i<10; i++)
                Rec(num+i);
        }
        for(int j=1; j<10; j++)
          Rec(j);
        return ans;
    }
}
