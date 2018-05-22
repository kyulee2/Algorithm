/*
Given an array of integers where 1 <= a[i] <= n(n = size of array), some elements appear twice and others appear once.
Find all the elements of [1, n] inclusive that do not appear in this array.
Could you do it without extra space and in O(n) runtime? You may assume the returned list does not count as extra space.
Example: 
Input:
[4,3,2,7,8,2,3,1]

Output:
[5,6]

*/
// Comment: The key idea is to place the expected value (i) into i-1 in place of array.
// Then in the second iteration to identify whether there are mismatched value against index.
// Spoiler: Initial point/expected value should be deriven first (not Rec(i-1,i) but Rec(n[i-1], n[i])
// This is because the Rec function below overrides (expected) val in place 
public class Solution {
    
    void Rec(int start, int val)
    {
        if (n[start] == val) // already match
            return;
        int nextVal = n[start];
        n[start] = val; // Update the expected val in place
        Rec(nextVal -1, nextVal);        
    }
    int[] n;
    public IList<int> FindDisappearedNumbers(int[] nums) {
        n = nums;
        int Len = n.Length;
        List<int> ans = new List<int>();
        if (Len == 0) return ans;
        for(int i=0; i<Len; i++) {
            // Skip if it is already in place
            if (n[i] == i + 1)
                continue;            
            Rec(n[i]-1, n[i]); // Not Rec(i-1, i)
        }
        
        for(int i=0; i<Len; i++)
            if (n[i] != i + 1)
                ans.Add(i+1);
        return ans;
    }
}

