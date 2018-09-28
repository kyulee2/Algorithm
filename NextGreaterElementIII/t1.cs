/*
Given a positive 32-bit integer n, you need to find the smallest 32-bit integer which has exactly the same digits existing in the integer n and is greater in value than n. If no such positive 32-bit integer exists, you need to return -1.

Example 1:

Input: 12
Output: 21
 

Example 2:

Input: 21
Output: -1
*/
// Comment: It's finding next permutation order.
// backward/forward search followed by reverse.
// Try with examples to see how they work.
// O(n) time and O(1) space where n is # of digits.
// One spoiler about checking validity of int32.
public class Solution {
    public int NextGreaterElement(int n) {
        var s= n.ToString().ToCharArray();
        int len =s.Length;
        int i = len - 1;
        // backward search that breaks <
        for(; i>=1; i--) {
            if (s[i-1]>=s[i]) continue;
            int j= i-1;
            int k = i;
            // forward search until breaks >= to pick smallest one that is larger than current one
            while(k<len && s[j]<s[k])
                k++;
            k--;
            var t = s[j];
            s[j] = s[k];
            s[k] = t;
            
            // reverse the rest to get the least order
            Array.Reverse(s, i, len -i);
            // Spoiler: check validity of int32
            int m;
            if (!int.TryParse(new String(s), out m))
                return -1;
            return m;
        }
        
        return -1;
    }
}
