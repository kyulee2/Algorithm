/*
Given two words (beginWord and endWord), and a dictionary's word list, find the length of shortest transformation sequence from beginWord to endWord, such that:

Only one letter can be changed at a time.
Each transformed word must exist in the word list. Note that beginWord is not a transformed word.
Note:

Return 0 if there is no such transformation sequence.
All words have the same length.
All words contain only lowercase alphabetic characters.
You may assume no duplicates in the word list.
You may assume beginWord and endWord are non-empty and are not the same.
Example 1:

Input:
beginWord = "hit",
endWord = "cog",
wordList = ["hot","dot","dog","lot","log","cog"]

Output: 5

Explanation: As one shortest transformation is "hit" -> "hot" -> "dot" -> "dog" -> "cog",
return its length 5.
Example 2:

Input:
beginWord = "hit"
endWord = "cog"
wordList = ["hot","dot","dog","lot","log"]

Output: 0

Explanation: The endWord "cog" is not in wordList, therefore no possible transformation.
*/
// Use BFS: Instead of visited, delete the visited on as soon as it's found as a next element. We could use a separate map, but doing the above is better since we can dynamically bail-out/trim unnecessary words quickly.
Use a single queue with string. We could use a queue with string/dist(int), but using the simple queue while iterating the number of the current level would be way more efficient.
class Solution {
public:
    int ladderLength(string beginWord, string endWord, vector<string>& wordList) {
        unordered_set<string> s;
        for(auto w:wordList)
            s.insert(w);
        s.insert(beginWord);
        unordered_set<string> visited;
        int len = beginWord.length();
        auto next = [&s,len](string& word, queue<string>& qt)->void {
            string temp = word;
            for(int i=0; i<len; i++) {
                char c = word[i];
                for(char d = 'a' ; d<='z'; d++) {
                    if (c==d) continue;
                    temp[i] = d;
                    if (s.find(temp) == s.end()) continue;
                      qt.push(temp);
                      s.erase(temp); // This is the key to performance
                }
                temp[i] = c; // restore
            }
        };

        queue<string> q;
        int dist = 0;
        q.push(beginWord);
        s.erase(beginWord);
        while(q.size()!= 0) {
            dist++;
            int size = q.size();
            // Only cover the current distance/level
            for(int i=0; i<size; i++) {
              auto n = q.front();
              q.pop();
            
              if (n == endWord)
                return dist;
        
              // Update the next neighbors
              next(n, q);
            }
        }
        
        return 0;
    }
};
