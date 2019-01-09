/*
Given an array w of positive integers, where w[i] describes the weight of index i, write a function pickIndex which randomly picks an index in proportion to its weight.

Note:

1 <= w.length <= 10000
1 <= w[i] <= 10^5
pickIndex will be called at most 10000 times.
Example 1:

Input: 
["Solution","pickIndex"]
[[[1]],[]]
Output: [null,0]
Example 2:

Input: 
["Solution","pickIndex","pickIndex","pickIndex","pickIndex","pickIndex"]
[[[1,3]],[],[],[],[],[]]
Output: [null,0,1,1,1,0]
Explanation of Input Syntax:

The input is two lists: the subroutines called and their arguments. Solution's constructor has one argument, the array w. pickIndex has no arguments. Arguments are always wrapped with a list, even if there aren't any.
*/
// Comment: Quite interesting. Use a sum array. Produce a random number 0~sum-1.
// Maintain sum array with the same size of weight array.
// Generate target sum which is 0 ~ sum-1
// The goal is to find the first index, idx where s[idx] > target sum
// because our target is 1 less than the actual target..
// So, when found the exact target, answhere should n + 1
// when found greater than target, cache n as the candidate answer
// Binary search to find the index.
class Solution {
public:
    vector<int> s;
    Solution(vector<int> w) {
        int sum = 0;
        for(auto e : w) {
            sum += e;
            s.push_back(sum);
        }
    }
    
    int pickIndex() {
        int target = rand() % s.back(); // target 0 ~ sum-1. search idx where s[idx]>target
        int i=0, j=s.size()-1;

        int ans;
        while(i<=j) {
            int n = (j-i)/2 + i;
            if (s[n]> target){
                ans = n; // cache the idx
                j = n-1;
            } else if (s[n]==target) {
                return n+1 ;
            }
            else { // s[n]< target
                i = n+1;                
            }
        }
        
        return ans;
    }
};

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(w);
 * int param_1 = obj.pickIndex();
 */
