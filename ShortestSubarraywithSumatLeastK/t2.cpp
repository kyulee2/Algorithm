/*
Return the length of the shortest, non-empty, contiguous subarray of A with sum at least K.
If there is no non-empty subarray with sum at least K, return -1.
 

Example 1:
Input: A = [1], K = 1
Output: 1
Example 2:
Input: A = [1,2], K = 4
Output: -1
Example 3:
Input: A = [2,-1,2], K = 3
Output: 3
 
Note:
1 <= A.length <= 50000
-10 ^ 5 <= A[i] <= 10 ^ 5
1 <= K <= 10 ^ 9
*/
// Comment: Hard. Appear simple below, but not.
// Use a linkedlist/queue to maintain two things
// the head (sum[i]) is poped until sum (sum[j]-sum[i]) is greater than K
// the tail (sum[j]) is poped if it is not contigously incasesed
class Solution {
public:
    int shortestSubarray(vector<int>& A, int K) {
        int ans = INT_MAX;
        int len = A.size();
        int j=0, curr = 0;
        vector<int> sum(len+1);
        // build prefix sum
        for(int i=0; i<len; i++) {
            curr += A[i];
            sum[i+1] = curr;
        }
        
        list<int> l;
        for(int i=0; i<len+1; i++) {
            while(l.size()) {
                curr = sum[i] - sum[l.front()];
                if (curr>=K) {
                    ans = min(ans, i-l.front());
                    l.pop_front();
                } else break;
            }
            while(l.size()) {
                //cout<<"chk"<< sum[l.back()] <<" " << sum[i] <<" "<<i<<endl;
                if (sum[l.back()]>=sum[i])
                    l.pop_back();
                else break;
            }
            l.push_back(i);
        }
        return ans==INT_MAX ? -1 : ans;
    }
};