/*
Given an encoded string, return it's decoded string.

The encoding rule is: k[encoded_string], where the encoded_string inside the square brackets is being repeated exactly k times. Note that k is guaranteed to be a positive integer.

You may assume that the input string is always valid; No extra white spaces, square brackets are well-formed, etc.

Furthermore, you may assume that the original data does not contain any digits and that digits are only for those repeat numbers, k. For example, there won't be input like 3a or 2[4].

Examples:

s = "3[a]2[bc]", return "aaabcbc".
s = "3[a2[c]]", return "accaccacc".
s = "2[abc]3[cd]ef", return "abcabccdcdcdef".

*/
// Comment: checking lower/uppwer case both.
// Use two stacks (one for # and the other for string".
// Make sure the parsed string is either appended to the top of string stakc (if it's not empty), or simply appended to the output.

public class Solution {
    StringBuilder b;
    int i;
    String str;
    Stack<string> ss;
    Stack<int> si;
    bool isNumber() {
        return str[i]>='0' && str[i]<='9' ;
    }
    int getNumber() {
        int sum = 0;
        while(i<str.Length && isNumber()) {
            sum *= 10;
            sum += (int)(str[i++] - '0');
        }
        return sum;
    }
    string getStr() {
        int j = i;
        while(i<str.Length && isAlpha()) i++;
        return str.Substring(j, i-j);
    }
    bool isAlpha() {
        char c = str[i];
        return (c>='a' && c<='z') || (c>='A' && c<= 'Z') ;
    }
    
    public string DecodeString(string s) {
        b = new StringBuilder();
        ss = new Stack<string>();
        si = new Stack<int>();
        str = s;
        i = 0;
        while(i < s.Length) {
            if (s[i]==']') {
                i++;
                StringBuilder t = new StringBuilder();
                String s1 = ss.Pop();
                int i1 = si.Pop();
                for(int j=0; j<i1; j++)
                    t.Append(s1);
                if (ss.Count != 0) {
                    String s2 = ss.Pop();
                    t.Insert(0, s2);
                    ss.Push(t.ToString());
                } else {
                    b.Append(t.ToString());
                }
            }
            else if (s[i]=='[') {
                i++;
                String s1 = getStr();
                ss.Push(s1);
            } else if (isNumber()) {
                int n1 = getNumber();
                si.Push(n1);
            } else {
                // assert isAlpha
                string s3 = getStr();
                if (ss.Count != 0) {
                    ss.Push(ss.Pop()+s3);
                } else {
                    b.Append(s3);
                }
            }
        }
        return b.ToString();
    }
}

