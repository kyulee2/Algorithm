/*
Given scores of N athletes, find their relative ranks and the people with the top three highest scores, who will be awarded medals: "Gold Medal", "Silver Medal" and "Bronze Medal".

Example 1:
Input: [5, 4, 3, 2, 1]
Output: ["Gold Medal", "Silver Medal", "Bronze Medal", "4", "5"]
Explanation: The first three athletes got the top three highest scores, so they got "Gold Medal", "Silver Medal" and "Bronze Medal". 
For the left two athletes, you just need to output their relative ranks according to their scores.
Note:
N is a positive integer and won't exceed 10,000.
All the scores of athletes are guaranteed to be unique.
*/
// Comment: Easy map indexing.
public class Solution {
    public string[] FindRelativeRanks(int[] nums) {
        int len = nums.Length;
        List<int[]> p = new List<int[]>();
        for(int i=0; i<len; i++) {
            p.Add(new int[]{nums[i],i});
        }
        p.Sort((x,y)=>(y[0] - x[0]));
        string[] ans = new string[len];
        for(int i=0; i<len; i++) {
            var v = p[i];
            string t = null;
            switch(i) {
                default: t = (i+1).ToString();
                    break;
                case 0: t = "Gold Medal";
                    break;
                case 1: t = "Silver Medal";
                    break;
                case 2: t = "Bronze Medal";
                    break;
            }
            ans[v[1]] = t;
        }
        return ans;
    }
}

