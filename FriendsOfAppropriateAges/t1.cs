/*
Some people will make friend requests. The list of their ages is given and ages[i] is the age of the ith person. 

Person A will NOT friend request person B (B != A) if any of the following conditions are true:

age[B] <= 0.5 * age[A] + 7
age[B] > age[A]
age[B] > 100 && age[A] < 100
Otherwise, A will friend request B.

Note that if A requests B, B does not necessarily request A.  Also, people will not friend request themselves.

How many total friend requests are made?

Example 1:

Input: [16,16]
Output: 2
Explanation: 2 people friend request each other.
Example 2:

Input: [16,17,18]
Output: 2
Explanation: Friend requests are made 17 -> 16, 18 -> 17.
Example 3:

Input: [20,30,100,110,120]
Output: 
Explanation: Friend requests are made 110 -> 100, 120 -> 110, 120 -> 100.
 

Notes:

1 <= ages.length <= 20000.
1 <= ages[i] <= 120.
*/
// Comment: The key idea is using a sort of count since the range of value is limited 1~120
// So, instead of O(n^2), its O(A^2 + N)
// Spce O(A) where A is # of Ages and N is # of people
public class Solution {
    public int NumFriendRequests(int[] ages) {
        // Think about counting sort. The range of ages are only 1 ~ 120
        // So, instead of O(n^2), O(120 * 120)
        // The combination is count of ageA * count of ageB
        var count = new int[121];
        foreach(var a in ages)
            count[a]++;
        
        int ans = 0;
        int len = ages.Length;
        for(int i=1; i<121; i++) {
            int a = count[i];
            for(int j=1; j<121; j++) {
                int b = count[j];
                if (j<=0.5*i + 7) continue;
                if (j>i) continue;
                // The third condition is usesless
                    
                ans += a * b;
                if (i==j) // same age needs to be subtracted by itself friendship
                    ans -= a;
            }
        }
        
        return ans;
    }
}
