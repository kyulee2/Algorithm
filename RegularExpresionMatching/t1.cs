/*
*/
// Comment: rec + memoization -- DP with top-down.
// Split two cases -- when * following in pattern or not.
// Need to check pattern length for termination condition -- think "" vs ".*" 
public class Solution {
    public bool IsMatch(string s, string p) {
        int slen = s.Length;
        int plen = p.Length;
        var map = new Dictionary<Tuple<int, int>, bool>();
        
        bool Rec(int i, int j)
        {
            var key = new Tuple<int, int>(i,j);
            if (map.ContainsKey(key))
                return map[key];
            
            bool tans = false;
            if(j==plen) {
                tans = slen==i;
            } else {
                var d= p[j];
                if (j+1==plen || p[j+1]!='*') { // no following *
                    if (i<slen && (s[i]==d || d=='.')) // match
                        tans = Rec(i+1, j+1); // move both p and s
                    else
                        tans = false;
                } else {    // following *
                    if (i<slen && (d==s[i] || d=='.')) // match
                        tans |= Rec(i + 1, j); // just move s leaving more match in the next
                    tans |= Rec(i, j+2);// match with * by just moving p including *
                }
            }
            
            map[key] = tans;
            return tans;
        }
        
        return Rec(0,0);
    }
}
