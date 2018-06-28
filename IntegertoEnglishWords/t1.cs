/*
Convert a non-negative integer to its english words representation. Given input is guaranteed to be less than 231 - 1.

Example 1:

Input: 123
Output: "One Hundred Twenty Three"
Example 2:

Input: 12345
Output: "Twelve Thousand Three Hundred Forty Five"
Example 3:

Input: 1234567
Output: "One Million Two Hundred Thirty Four Thousand Five Hundred Sixty Seven"
Example 4:

Input: 1234567891
Output: "One Billion Two Hundred Thirty Four Million Five Hundred Sixty Seven Thousand Eight Hundred Ninety One"
*/
// Comment: Straighforward, but a bit tedious
public class Solution {
    public string NumberToWords(int num) {
        // bail out special case
        if (num==0) return "Zero";
        
       var map19 = new string[]{"Zero","One","Two","Three","Four","Five","Six","Seven","Eight","Nine","Ten",
"Eleven","Twelve","Thirteen","Fourteen","Fifteen","Sixteen","Seventeen","Eighteen","Nineteen"};
        var map20 =new string[]{"Twenty","Thirty","Forty","Fifty","Sixty","Seventy","Eighty","Ninety"};
        string parseHundred(int n) {
            int h = n/ 100;
            int d = n % 100;
            StringBuilder b = new StringBuilder();
            if (h != 0) {
                b.Append(map19[h]);
                b.Append(" Hundred");
                if (d!=0)
                    b.Append(" ");
            }
            if (d<20 && d>0)
                b.Append(map19[d]);
            else if(d>=20) {
                int t = d/10-2;
                b.Append(map20[t]);
                if (d%10 != 0) {
                    b.Append(" ");
                    b.Append(map19[d%10]);
                }
            }
            return b.ToString();
        }
        
        StringBuilder ans = new StringBuilder();
        // bilion
        int bb = num / 1000000000;
        int bbr = num % 1000000000;
        if (bb>0) {
            ans.Append(parseHundred(bb));
            ans.Append(" Billion");
            if (bbr!=0)
                ans.Append(" ");
        }
        // million
        int mm = bbr/1000000;
        int mmr = bbr % 1000000;
        if (mm>0) {
            ans.Append(parseHundred(mm));
            ans.Append(" Million");
            if (mmr!=0)
                ans.Append(" ");
        }
        // thousand
        int tt = mmr/1000;
        int ttr = mmr%1000;
        if (tt>0)  {
            ans.Append(parseHundred(tt));
            ans.Append(" Thousand");
            if (ttr!=0) 
                ans.Append(" ");
        }
        ans.Append(parseHundred(ttr));
        return ans.ToString();
    }
}

