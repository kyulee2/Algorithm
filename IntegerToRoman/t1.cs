/*
Medium: Integer to Roman
Given an integer, convert it to a roman numeral. 
Input is guaranteed to be within the range from 1 to 3999
*/

public class Solution
{
    public string IntToRoman(int num)
    {
        Dictionary<int, string> m = new Dictionary<int, string>()
        {{1, "I"}, {2,"II"}, {3,"III"}, {4, "IV"}, {5, "V"}, {6, "VI"}, {7,"VII"}, {8, "VIII"}, {9, "IX"},
         {10, "X"}, {20, "XX"}, {30, "XXX"}, {40, "XL"}, {50, "L"}, {60, "LX"}, {70, "LXX"}, {80, "LXXX"}, {90, "XC"},
         {100, "C"}, {200, "CC"}, {300, "CCC"}, {400, "CD"}, {500, "D"}, {600, "DC"}, {700, "DCC"}, {800, "DCCC"}, {900, "CM"},
         {1000, "M"}, {2000, "MM"}, {3000, "MMM"}
        };

        StringBuilder a = new StringBuilder();
        // No prepend available for StringBuilder.
        // Iterate from top digit to bottom.
        int div = 1000;
        while (div > 0)
        {
            int r = (num / div) * div;
            if (r != 0)
                a.Append(m[r]);
            num = num % div;
            div = div / 10;
        }

        return a.ToString();
    }
}
