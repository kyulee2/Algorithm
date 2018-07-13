/*
Given a set of words (without duplicates), find all word squares you can build from them.
A sequence of words forms a valid word square if the kth row and column read the exact same string, where 0 = k < max(numRows, numColumns).
For example, the word sequence ["ball","area","lead","lady"] forms a word square because each word reads the same both horizontally and vertically.
b a l l
a r e a
l e a d
l a d y
Note:
There are at least 1 and at most 1000 words.
All words will have the exact same length.
Word length is at least 1 and at most 5.
Each word contains only lowercase English alphabet a-z.

Example 1: 
Input:
["area","lead","wall","lady","ball"]

Output:
[
  [ "wall",
    "area",
    "lead",
    "lady"
  ],
  [ "ball",
    "area",
    "lead",
    "lady"
  ]
]

Explanation:
The output consists of two word squares. The order of output does not matter (just the order of words in each word square matters).

Example 2: 
Input:
["abat","baba","atan","atal"]

Output:
[
  [ "baba",
    "abat",
    "baba",
    "atan"
  ],
  [ "baba",
    "abat",
    "baba",
    "atal"
  ]
]

Explanation:
The output consists of two word squares. The order of output does not matter (just the order of words in each word square matters).
*/
// Comment: Build prefix (starting char) to words map.
// Trying pick the next word using the map, but make sure chars from left and from up identical.
// Initially, I thought visited to avoid duplication and speed-up, but actually this test allow duplication -- one element in dictionary can be used in multiple times
// There may be memoization??
public class Solution {
    public IList<IList<string>> WordSquares(string[] words) {
        var map = new Dictionary<char, List<string>>();
        var len = words[0].Length;
        // build map
        foreach(var w in words) {
            if (!map.ContainsKey(w[0]))
                map[w[0]] = new List<string>();
            map[w[0]].Add(w);
        }
        
        var tans = new string[len];
        var ans = new List<IList<string>>();
        void Rec(string s, string n, int i)
        {
            // search up and left to see if they are identical
            for(int j=1; j<i; j++) {
                if (n[j] != tans[j][i])
                    return;
            }
            
            tans[i] = n;
            if (i==len-1) {
                ans.Add(new List<string>(tans));
                return;
            }

            char c = s[i+1];
            if (!map.ContainsKey(c)) return;
            foreach(var next in map[c]) {
                Rec(s, next, i+1);
            }
        }
        

        foreach(var w in words) {
            Rec(w, w, 0);
        }
        
        return ans;
    }
}