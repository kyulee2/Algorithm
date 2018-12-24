/*
Given a non-empty list of words, return the k most frequent elements.
Your answer should be sorted by frequency from highest to lowest. If two words have the same frequency, then the word with the lower alphabetical order comes first.
Example 1:
Input: ["i", "love", "leetcode", "i", "love", "coding"], k = 2
Output: ["i", "love"]
Explanation: "i" and "love" are the two most frequent words.
    Note that "i" comes before "love" due to a lower alphabetical order.

Example 2:
Input: ["the", "day", "is", "sunny", "the", "the", "the", "sunny", "is", "is"], k = 4
Output: ["the", "is", "sunny", "day"]
Explanation: "the", "is", "sunny" and "day" are the four most frequent words,
    with the number of occurrence being 4, 3, 2 and 1 respectively.

Note:
You may assume k is always valid, 1 = k = number of unique elements.
Input words contain only lowercase letters.

Follow up:
Try to solve it in O(n log k) time and O(n) extra space.
*/
// Comment: Should be similar to TopKFrequentElements (integer) which can be solved using partition o(n)
// Here PriorityQueue/heap + map is used. O(n logk) time with O(n) space
class Compare
{
public:
    bool operator() (pair<string,int>& a, pair<string,int>& b)
    {
        if (a.second!=b.second)
            return a.second>b.second;
        return a.first.compare(b.first) < 0;
    }
};

class Solution {
public:
    vector<string> topKFrequent(vector<string>& words, int k) {
        map<string, int> m;
        for(auto w : words)
            m[w]++;
        
        priority_queue<pair<string,int>, vector<pair<string,int>>, Compare> p;
        for(auto t: m) {
            auto w  =t.first;
            auto cnt = t.second;
            p.push(pair<string, int>(w, cnt));
            if (p.size()>k)
                p.pop();
        }
        
        vector<string> ans;
        while(p.size()>0) {
            auto w = p.top().first;
            p.pop();
            ans.push_back(w);
        }
        reverse(ans.begin(), ans.end());
        
        return ans;
        
    }
};