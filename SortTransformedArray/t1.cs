/*
Given a sorted array of integers nums and integer values a, b and c. Apply a quadratic function of the form f(x) = ax2 + bx + c to each element x in the array. 
The returned array must be in sorted order.
Expected time complexity: O(n)
Example:
nums = [-4, -2, 2, 4], a = 1, b = 3, c = 5,

Result: [3, 9, 15, 33]

nums = [-4, -2, 2, 4], a = -1, b = 3, c = 5

Result: [-23, -5, 1, 7]

Credits:
Special thanks to @elmirap for adding this problem and creating all test cases.
*/
// Comment: Two spoilers below. Idea is not hard, but compare is a bit tricky

public class Solution {
    int[] ans;
    int[] num;
    bool isReverse;
    int aa;
    int bb;
    int cc;
    int len;
    
    int function(int n)
    {
        return aa * n* n + bb * n + cc;
    }
    
    void reverse()
    {
        for(int i=0; i<len/2; i++) {
            int t = ans[len - i -1];
            ans[len-i-1] = ans[i];
            ans[i] = t;
        }
    }
    
    void merge(int mid)
    {
        int k =0;
        int iEnd = 0;
        int i = mid -1;
        int j = mid;
        int jEnd = len - 1;
        while(i>=iEnd && j <=jEnd) {
            // Spoiler: check two ways either reverse or not
            // Also use function not just index for comparision.
            if ((isReverse && (function(num[i]) > function(num[j]))) || (!isReverse && (function(num[i])<function(num[j]))))
                ans[k++] = function(num[i--]);
            else
                ans[k++] = function(num[j++]);
        }
        if (k < len) {
            if (i>=iEnd)
                while(k<len) ans[k++] = function(num[i--]);
            else
                while(k<len) ans[k++] = function(num[j++]);
        }
    }
    
    int findMid()
    {
        double center = -bb / 2 / aa;        
        int i=0;
        for(i=0; i<len; i++) {
            // Spoiler: equal condition
            if ((double)num[i] >= center)
                return i;
        }
        return i;
    }
    
    public int[] SortTransformedArray(int[] nums, int a, int b, int c) {
        // Initialize data
        num = nums;
        len = num.Length;        
        ans = new int[len];
        
        // check reverse
        isReverse = a <0 || (a==0 && b<0);
        aa = a;
        bb = b;
        cc = c;
        
        if (a==0) {
            // trivial case
            for(int i=0; i<len; i++)
                ans[i] = function(num[i]);
        }
        else {
            // find mid point
            int mid = findMid();
            // merge
            merge(mid);
        }
        
        // reverse any if needed.
        if (isReverse)
            reverse();
        
        return ans;
    }
}
