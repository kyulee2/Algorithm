/*
Given a list accounts, each element accounts[i] is a list of strings, where the first element accounts[i][0] is a name, and the rest of the elements are emails representing emails of the account.

Now, we would like to merge these accounts. Two accounts definitely belong to the same person if there is some email that is common to both accounts. Note that even if two accounts have the same name, they may belong to different people as people could have the same name. A person can have any number of accounts initially, but all of their accounts definitely have the same name.

After merging the accounts, return the accounts in the following format: the first element of each account is the name, and the rest of the elements are emails in sorted order. The accounts themselves can be returned in any order.

Example 1:
Input: 
accounts = [["John", "johnsmith@mail.com", "john00@mail.com"], ["John", "johnnybravo@mail.com"], ["John", "johnsmith@mail.com", "john_newyork@mail.com"], ["Mary", "mary@mail.com"]]
Output: [["John", 'john00@mail.com', 'john_newyork@mail.com', 'johnsmith@mail.com'],  ["John", "johnnybravo@mail.com"], ["Mary", "mary@mail.com"]]
Explanation: 
The first and third John's are the same person as they have the common email "johnsmith@mail.com".
The second John and Mary are different people as none of their email addresses are used by other accounts.
We could return these lists in any order, for example the answer [['Mary', 'mary@mail.com'], ['John', 'johnnybravo@mail.com'], 
['John', 'john00@mail.com', 'john_newyork@mail.com', 'johnsmith@mail.com']] would still be accepted.
Note:

The length of accounts will be in the range [1, 1000].
The length of accounts[i] will be in the range [1, 10].
The length of accounts[i][j] will be in the range [1, 30].

*/
// Comment: use graph that links email to emails.
// group them by connected ones.
 
class Solution {
public:
    void Rec(map<string, set<string>>& g, set<string>& group, string email) {
        if (g.find(email) == g.end()) return; // already visited
        if (group.find(email) != group.end())
            return;
        group.insert(email);
        for(auto next : g[email])
            Rec(g, group, next);
        
        g.erase(email); // remove current email
    }
    vector<vector<string>> accountsMerge(vector<vector<string>>& accounts) {
        map<string, string> s; // email to name
        map<string, set<string>> g; // email to set of email

        for(auto a : accounts) {
            auto name = a[0];
            s[a[1]] = name;
            g[a[1]].insert(a[1]);      
            for(int i=1; i<a.size()-1; i++) {
                s[a[i]] = name;
                g[a[i]].insert(a[i+1]);
                g[a[i+1]].insert(a[i]);
            }
        }
        
        vector<vector<string>> ans;
        // group/merge
        for(auto t : s) {
            auto email = t.first;
            auto name = t.second;
            set<string> group;
            // DFS
            Rec(g, group, email);
            if (group.size()>0) {
                vector<string> t1;
                t1.push_back(name);
                for(auto e : group)
                    t1.push_back(e);
                ans.push_back(t1);
            }
        }
        
        return ans;
    }
};
