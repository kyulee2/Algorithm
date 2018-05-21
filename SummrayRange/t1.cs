/*
Given a sorted integer array without duplicates, return the summary of its ranges.
Example 1:
Input:  [0,1,2,4,5,7]
Output: ["0->2","4->5","7"]
Explanation: 0,1,2 form a continuous range; 4,5 form a continuous range.
Example 2:
Input:  [0,2,3,4,6,8,9]
Output: ["0","2->4","6","8->9"]
Explanation: 2,3,4 form a continuous range; 8,9 form a continuous range.
*/

// Comment: 
// 1. Check contiguous number (n[i-1] + 1 == n[i]), not the same number (n[i-1]==n[i])
// 2. Learn String.Format() to get a formatted string at once
// 3. int.ToString() to get converted string from int
public class Solution {
    int[] n;
    string getRange(int start, int curr)
    {
        if (start == curr)
            return n[start].ToString();
        return String.Format("{0}->{1}",n[start], n[curr]);
    }
    
    public IList<string> SummaryRanges(int[] nums) {
        List<string> ans = new List<string>();
        int Len = nums.Length;
        n = nums;
        if (Len==0) return ans;
        int start = 0;
        for(int i= 1; i<Len; i++) {
            if (n[i-1] + 1 != n[i]) {
                ans.Add(getRange(start, i-1));
                start = i;
            }
        }
        // Handle the last iteration
        ans.Add(getRange(start, Len-1));
        
        return ans;
    }
}

