/*
Given an integer array of size n, find all elements that appear more than Floor(n/3) times.
Note: The algorithm should run in linear time and in O(1) space.
Example 1:
Input: [3,2,3]
Output: [3]
Example 2:
Input: [1,1,1,3,3,2,2,2]
Output: [1,2]
*/
// Comment: Use two candidate. Increase on stay or decrease count on not.
// Later validate them.
public class Solution {
    public IList<int> MajorityElement(int[] nums) {
        int len = nums.Length;
        var ans = new List<int>();

        int a = 0;
        int b = 1;
        int acnt =0, bcnt=0;
        for(int i=0; i<len; i++) {
            var n = nums[i];
            if (a==n)
                acnt++;
            else if(b==n)
                bcnt++;
            else if (acnt==0) {
                acnt = 1;
                a = n;
            } else if (bcnt==0) {
                bcnt = 1;
                b =n;
            } else {
                acnt--;
                bcnt--;
            }
        }
        
        int cnt1 =0, cnt2=0;
        for(int i=0; i<len; i++)
            if (nums[i]==a)
                cnt1++;
            else if(nums[i]==b)
                cnt2++;
        if(cnt1>len/3)
            ans.Add(a);
        if (cnt2>len/3)
            ans.Add(b);
        return ans;
    }
}
