/*
Given an integer array with all positive numbers and no duplicates, find the number of possible combinations that add up to a positive integer target.

Example:

nums = [1, 2, 3]
target = 4

The possible combination ways are:
(1, 1, 1, 1)
(1, 1, 2)
(1, 2, 1)
(1, 3)
(2, 1, 1)
(2, 2)
(3, 1)

Note that different sequences are counted as different combinations.

Therefore the output is 7.
Follow up:
What if negative numbers are allowed in the given array?
How does it change the problem?
What limitation we need to add to the question to allow negative numbers?
*/
// Comment: This seems similar to the way of pay for the given coins value. This also allows different combinations.
// The below passes 16/17 - one last time-out.
// See other way
public class Solution {
    int ans;
    int[] n;
    int[] t;
    int len;
    
    void update(List<int> a) {
        a.Sort();
        a.Reverse();
        long p = 1;
        int l = a.Count;
        
        if (l==1) {
            ans += 1;
            return;
        }
        
        int sum = 0;
        HashSet<int> x = new HashSet<int>();
        List<int> y = new List<int>();
        foreach(var v in a) {
            sum+= v;
        }
        
        for(int i=1; i<=sum; i++) {
            x.Add(i);
        }
        
        foreach(var v in a) {
            for(int i=1; i<=v; i++) {
                if (x.Contains(i)) {
                    x.Remove(i);
                    continue;
                 }
                y.Add(i);
            }
        }
        
        // (a+b+c)!
        foreach(var v in x) {
            p *= v;
        }
                
        // a!b!c!
        long q= 1;
        foreach(var v in y) {
            q *= v;
        }
        
        long r = p/q;
        ans += (int)r;
    }
    
    void Rec(int target, int depth)
    {
        if (depth>=len)
            return;
        int p = target / n[depth];
        if (depth==len-1) {
            if (target % n[depth]!= 0)
                return;
            t[depth] = p;
            // update ans;
            // n!/a!/b!...
            List<int> a = new List<int>();
            for(int i=0; i<len;i++)
                if (t[i]!=0)
                    a.Add(t[i]);
            update(a);
            return;
            
        }
        for(int i=0; i<=p; i++) {
            t[depth] = i;
            Rec(target, depth + 1);
            target -= n[depth];
        }
    }
    
    public int CombinationSum4(int[] nums, int target) {
        // Init data
        ans = 0;
        n = nums;
        len = n.Length;
        t = new int[len];
        Array.Sort(nums);
        Array.Reverse(nums);
        
        Rec(target, 0);
        return ans;
    }
}


