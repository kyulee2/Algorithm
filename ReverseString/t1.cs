/*
Write a function that takes a string as input and returns the string reversed.

Example:
Given s = "hello", return "olleh".
*/
// Comment: Easy. Not worth.
public class Solution {
    public string ReverseString(string s) {
        var v = s.ToCharArray();
        Array.Reverse(v);
        return new String(v);
    }
}

