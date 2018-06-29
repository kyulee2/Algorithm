/*
Given a string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

An input string is valid if:

Open brackets must be closed by the same type of brackets.
Open brackets must be closed in the correct order.
Note that an empty string is also considered valid.

Example 1:

Input: "()"
Output: true
Example 2:

Input: "()[]{}"
Output: true
Example 3:

Input: "(]"
Output: false
Example 4:

Input: "([)]"
Output: false
Example 5:

Input: "{[]}"
Output: true
*/
// Comment: Straightforward. Use stack.
public class Solution {
    public bool IsValid(string s) {
        var stk = new Stack<char>();
        foreach(var c in s) {
            char match = '.';
            switch(c) {
                case '(':
                case '[':
                case '{':
                    stk.Push(c);
                    continue;
                case ')':
                    match = '(';
                    break;
                case ']':
                    match = '[';
                    break;
                case '}':
                    match = '{';
                    break;
            }
            if (stk.Count >0 && stk.Peek() == match) {
                stk.Pop(); // consume it to close
            } else
                return false;
        }
        return stk.Count == 0;
    }
}
