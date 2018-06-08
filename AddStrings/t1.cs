/*
Given two non-negative integers num1 and num2 represented as string, return the sum of num1 and num2.
Note: 
The length of both num1 and num2 is < 5100.
Both num1 and num2 contains only digits 0-9.
Both num1 and num2 does not contain any leading zero.
You must not use any built-in BigInteger library or convert the inputs to integer directly.
*/
// Comment: Easy. Set Reverse using Array.Reverse and ToCharArray

public class Solution {
    int Add(char a, char b, int c)
    {
        int i= (int)(a-'0');
        int j = (int)(b-'0');
        return i+j+c;
    }
    
    string Reverse(string s)
    {
        var ans = s.ToCharArray();
        Array.Reverse(ans);
        return new String(ans);      
    }
    public string AddStrings(string num1, string num2) {
        int len1 = num1.Length;
        int len2 = num2.Length;
        if (len1 < len2) return AddStrings(num2, num1);
        num1 = Reverse(num1);
        num2 = Reverse(num2);
        StringBuilder b = new StringBuilder();
        int i= 0;
        int c = 0;
        for(; i<len2; i++) {
            int n = Add(num1[i], num2[i], c);
            b.Append(n % 10);
            c = n / 10;
        }
        for(; i<len1; i++) {
            int n = Add(num1[i], '0', c);
            b.Append(n % 10);
            c = n / 10;
        }
        if (c!=0)
            b.Append(c);
        
        // Reverse
        return Reverse(b.ToString());  
    }
}
