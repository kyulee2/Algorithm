/*
Implement function ToLowerCase() that has a string parameter str, and returns the same string in lowercase.

 

Example 1:

Input: "Hello"
Output: "hello"
Example 2:

Input: "here"
Output: "here"
Example 3:

Input: "LOVELY"
Output: "lovely"

*/
// Comment: Not worth
public class Solution {
    public string ToLowerCase(string str) {
        var b = new StringBuilder();
        foreach(var c in str)
            b.Append(Char.ToLower(c));
        return b.ToString();
    }
}
