/*
You have a number of envelopes with widths and heights given as a pair of integers (w, h). One envelope can fit into another if and only if both the width and height of one envelope is greater than the width and height of the other envelope.

What is the maximum number of envelopes can you Russian doll? (put one inside other)

Example:
Given envelopes = [[5,4],[6,4],[6,7],[2,3]], the maximum number of envelopes you can Russian doll is 3 ([2,3] => [5,4] => [6,7]).

*/
// Comment: Similar to Longest Increasing Subsequence. Only difference is to sort them first before DP to consider only prior indexes.
public class Solution {
    public int MaxEnvelopes(int[,] envelopes) {
        int len = envelopes.GetLength(0);
        if (len==0) return 0;
        var n = new int[len][];
        for(int i=0; i<len; i++)
            n[i] = new int[]{envelopes[i,0], envelopes[i,1]};
        Array.Sort(n, (x,y)=>{ if (x[0]!=y[0]) return x[0]-y[0];
                              return x[1] -y[1];});
        
        var d = new int[len];
        for(int i=0; i<len; i++) d[i] = 1;
        
        int max = 1;
        for(int i=1; i<len; i++) {
            for(int j=0; j<i; j++)
                if (n[i][0]>n[j][0] && n[i][1]>n[j][1])
                    d[i] = Math.Max(d[i], d[j] + 1);
            max = Math.Max(max, d[i]);
        }
        
        return max;
    }
}
