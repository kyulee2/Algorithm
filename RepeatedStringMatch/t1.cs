/*
Given two strings A and B, find the minimum number of times A has to be repeated such that B is a substring of it. If no such solution, return -1.

For example, with A = "abcd" and B = "cdabcdab".

Return 3, because by repeating A three times (“abcdabcdabcd”), B is a substring of it; and B is not a substring of A repeated two times ("abcdabcd").

Note:
The length of A and B will be between 1 and 10000.
*/
// Comment: O(N * (M+N)) for time and O(M+N) for space.
// Rabin-Karp/KMP should be done in O(M+N) for time
public class Solution {
    public int RepeatedStringMatch(string A, string B) {
        StringBuilder t = new StringBuilder(A);
        while(t.Length < B.Length)
            t.Append(A);
        string t1= t.ToString();
        if (t1.IndexOf(B) != -1)
            return t1.Length / A.Length;
        t1 += A;
        return t1.IndexOf(B) != -1 ? t1.Length/A.Length : -1;
    }
}
