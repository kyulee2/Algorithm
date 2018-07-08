/*
Given a non-empty array of digits representing a non-negative integer, plus one to the integer.
The digits are stored such that the most significant digit is at the head of the list, and each element in the array contain a single digit.
You may assume the integer does not contain any leading zero, except the number 0 itself.
Example 1:
Input: [1,2,3]
Output: [1,2,4]
Explanation: The array represents the integer 123.
Example 2:
Input: [4,3,2,1]
Output: [4,3,2,2]
Explanation: The array represents the integer 4321.
*/
// Comment: Easy
public class Solution {
    public int[] PlusOne(int[] digits) {
        var ansl = new List<int>();
        Array.Reverse(digits);
        int c = 1;
        for(int i=0; i<digits.Length; i++) {
            int s = c + digits[i];
            c = s/ 10;
            ansl.Add(s%10);
        }
        if (c!=0)
            ansl.Add(c);
        ansl.Reverse();
        return ansl.ToArray();
    }
}
