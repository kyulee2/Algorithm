/*
largest number.
Example 1:
Input: [10,2]
Output: "210"
Example 2:
Input: [3,30,34,5,9]
Output: "9534330"
Note: The result may be very large, so you need to return a string instead of an integer.
*/
// Comment: A bit tricky to get the right lambda function.
// When comparing two string, allow compare with the same length only.
// Otherwise, substr of the longer string. Compare against with the shorter string.
// This should be done repeatedly in while loop until either the small string comparision is broken or the same length remains as with small string.
class Solution {
public:
    vector<string> v;
    string ans;
    
    string largestNumber(vector<int>& nums) {
        for(auto n : nums)
            v.push_back(to_string(n));
        auto cmp = [](string a, string b) {
            while(a.size() != b.size()) {
                int len1 = a.size();
                int len2 = b.size();
                int m = min(len1, len2);
                auto s1 = a.substr(0, m);
                auto s2 = b.substr(0, m);
                if (s1!=s2) return s1 > s2;
                if (len1 < len2)
                    b = b.substr(m);
                else a = a.substr(m);
            }
            
            return a > b;
        };
        sort(v.begin(), v.end(), cmp);
        for(auto e : v) {
            // Spoiler: [0 0]
            if (!ans.empty() && ans[0]=='0')
                continue;
            ans += e;
        }
        
        return ans;
    }
};