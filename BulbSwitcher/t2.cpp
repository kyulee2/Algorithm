/*
There are n bulbs that are initially off. You first turn on all the bulbs. Then, you turn off every second bulb. On the third round, you toggle every third bulb (turning on if it's off or turning off if it's on). For the i-th round, you toggle every i bulb. For the n-th round, you only toggle the last bulb. Find how many bulbs are on after n rounds.
Example:
Input: 3
Output: 1 
Explanation: 
At first, the three bulbs are [off, off, off].
After first round, the three bulbs are [on, on, on].
After second round, the three bulbs are [on, off, on].
After third round, the three bulbs are [on, off, off]. 

So you should return 1, because there is only one bulb is on.
*/
// Comment: Key point is n^2 is off.
class Solution {
public:
    int bulbSwitch(int n) {
        // 1 3 5 15 -> off
        // Number which has even factors would be off
        // Number which has odd factors would be on -->
        // This is the case only with n^2 number -- 1, n, n^2
        // E.g, 4(1,2,4), 9(1,3,9), 16(1,2,4,8,16)
        int cnt = 0;
        for(int i=1; i*i<=n; i++)
            cnt++;
        return cnt;
   }
};
