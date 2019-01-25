/*
You are given coins of different denominations and a total amount of money amount. Write a function to compute the fewest number of coins that you need to make up that amount. If that amount of money cannot be made up by any combination of the coins, return -1.

Example 1:

Input: coins = [1, 2, 5], amount = 11
Output: 3 
Explanation: 11 = 5 + 5 + 1
Example 2:

Input: coins = [2], amount = 3
Output: -1
Note:
You may assume that you have an infinite number of each kind of coin.
*/
// Comment: Good practice for recusrion + memoization. Careful about checking recursion return value before applying min operation below.
class Solution {
public:
    vector<int> data;
    map<int, int> m;
    int Rec(int n) {
        if (n==0) { return 0;}
        if (n<0) { return -1; }
        if (m.find(n)!=m.end()) return m[n];
        int curr = INT_MAX;
        for(int j=0; j<data.size(); j++) { // spoiler: not start from i but 0 always
            if (data[j]<=n) {
                int h = Rec(n-data[j]);
                if (h!=-1) // spoiler::
                    curr = min(curr, h+1);
            }
        }
        if (curr == INT_MAX)
            curr = -1;
        m[n] = curr;
        return curr;
    }
    int coinChange(vector<int>& coins, int amount) {
        sort(coins.begin(), coins.end());
        //reverse(coins.begin(), coins.end()); // This doesn't matter.
        data = coins;
        return Rec(amount);
    }
};
