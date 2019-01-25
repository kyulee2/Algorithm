/*
Given a string containing only digits, restore it by returning all possible valid IP address combinations.
Example:
Input: "25525511135"
Output: ["255.255.11.135", "255.255.111.35"]
*/
// Comment: exercise string. stoi, substr
class Solution {
public:
    vector<string> ans;
    int len;
    string str;
    
    void Rec(int i, int n, string curr) {
        if (i==len) {
            if (n==4)
                ans.push_back(curr);
            return;
        }
        if (n>=4) return;
        if (!curr.empty()) curr += ".";
        if (str[i]=='0')
            Rec(i+1, n+1, curr+"0");
        else {
            // try 1,2 or 3 substring
            for(int j=1; j<=3; j++) {
                if (i+j>len) break;
                string w;
                if (i+j == len)
                    w = str.substr(i);
                else
                    w = str.substr(i,j);
                int val = stoi(w);
                if (val>0 && val<=255)
                    Rec(i+j, n+1, curr+w);
            }
        }
    }
    vector<string> restoreIpAddresses(string s) {
        len = s.length();
        str = s;
        Rec(0, 0, "");
        return ans;
    }
};