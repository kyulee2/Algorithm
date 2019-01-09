/*
Count the number of prime numbers less than a non-negative number, n.

Example:

Input: 10
Output: 4
Explanation: There are 4 prime numbers less than 10, they are 2, 3, 5, 7.
*/
// Comment: There are a few spoilers below. This is more concise than c1.cs
// No bookpeeing. To check whether isPrime for the given number i,
// iterate until j*j <=i to see if i can be divided by j -- then it has factor.
// O(n * sqrt(n))
class Solution {
public:
    int countPrimes(int n) {
        if (n<=2) return 0;
        
        int cnt = 1;
        for(int i=3; i<n; i++) {
            bool hasFactor = false;
            for(int j=2; j*j <=i; j++) {
                if (i%j==0) {
                    hasFactor = true;
                    break;
                }
            }
            
            if (!hasFactor)
                cnt++;
        }
        
        return cnt;
    }
};