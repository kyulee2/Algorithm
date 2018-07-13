/*
A strobogrammatic number is a number that looks the same when rotated 180 degrees (looked at upside down).

Find all strobogrammatic numbers that are of length = n.

Example:

Input:  n = 2
Output: ["11","69","88","96"]
*/
// Comment: Think '0' case, which cannot be at the starting position since it won't meet the number of digits that are given.
// Hanlde odd input as well.

public class Solution {
    public IList<string> FindStrobogrammatic(int n) {
        var m1 = "01869";
        var m2 = "01896";

        var ans = new List<string>();
        if (n==1) {
            ans.Add("0");
            ans.Add("1");
            ans.Add("8");
            return ans;
        }
        if (n==2) {
            ans.Add("11");
            ans.Add("88");
            ans.Add("69");
            ans.Add("96");
            return ans;            
        }          
        
        
        var tans = new char[n];
        
        int m = n / 2;
        void Rec(int i, int j)
        {
            tans[i] = m1[j];
            tans[n-i-1] = m2[j];
            
            if (i==m-1) {
                if (n%2==0)
                    ans.Add(new String(tans));
                else {
                    tans[m] ='0';
                    ans.Add(new String(tans));                    
                    tans[m] ='1';
                    ans.Add(new String(tans));
                    tans[m] ='8';
                    ans.Add(new String(tans));
                }
                return;
            }
            
            for(int k=0; k<m1.Length; k++)
                Rec(i+1, k);
        }
        
        // Spoiler: First char shouln't be 0
        for(int l=1; l<m1.Length; l++)
            Rec(0, l);
        
        return ans;
    }
}

