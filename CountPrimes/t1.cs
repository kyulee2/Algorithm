/*
Count the number of prime numbers less than a non-negative number, n.

Example:

Input: 10
Output: 4
Explanation: There are 4 prime numbers less than 10, they are 2, 3, 5, 7.
*/
// Comment: There are a few spoilers below.
public class Solution
{
    public int CountPrimes(int n)
    {
        // spoiler: early bail-out <=3 
        if (n<=2) return 0;
        if (n==3) return 1;
        
        var map = new bool[n + 1]; // not prime is true
        for (int i = 4; i <= n; i++)
        {
            if (i % 2 == 0 || i % 3 == 0) {
                map[i] = true;
                continue;
            }

            bool hasFactor = false;
            // spoiler: less than and equal to
            for(int j= 2; j*j <= i; j++)
            {
                if (i%j == 0)
                {
                    hasFactor = true;
                    break;
                }
            }
            if (hasFactor)
                map[i] = true;

        }

        int cnt = 0;
        // spoiler: less than (not less than and equal to)
        for(int i= 2; i < n; i++)
            if (!map[i]) cnt++;
        return cnt;
    }
}
