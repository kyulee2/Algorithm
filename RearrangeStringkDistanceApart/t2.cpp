/*
*/
// Comment: This is task scheduling.
// Use a priority queue to pull out k tasks
// O(n log n) for time and O(n) space
class Solution {
public:
    string rearrangeString(string s, int k) {
        // spoiler: k<=0
        if (k==0) return s;
        if (k<0) return "";
        
        // Spoiler: enforce lexical order as well
        auto cmp = [](string a, string b){
            if (a.size() == b.size())
                return a[0] < b[0];
            return a.size() < b.size();
        };

        priority_queue<string, vector<string>, decltype(cmp)> q(cmp);
        vector<string> v;
        map<char, int> m;
        for(auto c : s)
            ++m[c];
        for(auto &tup : m)
            q.push(string(tup.second, tup.first));

        string ans;
        for (int i=0; i<s.size(); i+= k) {
            // spoiler: do push back to q for every k
            for(auto e : v)
                q.push(e);
            v.clear();
            for(int j=0; j<k && i+j<s.size(); j++) {
                if(q.size()==0) return "";
                auto n = q.top(); q.pop();
                ans += n[0];
                n.resize(n.size()-1);

                if (n.size()!=0)
                    v.push_back(n);
            }
        }
        
        return ans;
        
    }
};