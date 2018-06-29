/*
*/
// Comment: Quite interesting. Should review this again.
// The first one is bruthforce which is O(n^2). The next ons is O(n).
// Precompute sum and hash it. current sum - k = sums(j) - sum(i). Just
// Count such thing exists in the prior computation
public class Solution {
    /* O(n^2)
    public int SubarraySum(int[] nums, int k) {
        int len = nums.Length;
        var sums = new int[len];
        int sum =0;
        for(int i=0; i<len; i++) {
            sum+= nums[i];
            sums[i] = sum;
        }
        
        int getSum(int i, int j) {
            if (i==0) return sums[j];
            return sums[j] - sums[i-1];
        }
        
        int ans=0;
        for(int i=0; i<len; i++) {
            for(int j=i; j<len; j++) {
                if (getSum(i,j) == k)
                    ans++;
            }
        }
        
        return ans;
    }
    */
     public int SubarraySum(int[] nums, int k) {
        var cnt = new Dictionary<int, int>();
        int sum = 0, res = 0;
        int n = nums.Length;
        cnt[0] = 1;
        for(int i = 0 ; i < n; i++){
            sum += nums[i];
            if(cnt.ContainsKey(sum-k)){
                res += cnt[sum-k];
            }
            if (cnt.ContainsKey(sum))
                cnt[sum]++;
            else cnt[sum] = 1;
        }
        return res;
    }   
}

