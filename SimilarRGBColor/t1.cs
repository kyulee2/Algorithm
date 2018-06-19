/*
In the following, every capital letter represents some hexadecimal digit from 0 to f.
The red-green-blue color "#AABBCC" can be written as "#ABC" in shorthand.  For example, "#15c" is shorthand for the color "#1155cc".
Now, say the similarity between two colors "#ABCDEF" and "#UVWXYZ" is -(AB - UV)^2 - (CD - WX)^2 - (EF - YZ)^2.
Given the color "#ABCDEF", return a 7 character color that is most similar to #ABCDEF, and has a shorthand (that is, it can be represented as some "#XYZ"
Example 1:
Input: color = "#09f166"
Output: "#11ee66"
Explanation:  
The similarity is -(0x09 - 0x11)^2 -(0xf1 - 0xee)^2 - (0x66 - 0x66)^2 = -64 -9 -0 = -73.
This is the highest among any shorthand color.
Note:
color is a string of length 7.
color is a valid RGB color: for i > 0, color[i] is a hexadecimal digit from 0 to f
Any answer which has the same (highest) similarity as the best answer will be accepted.
All inputs and outputs should use lowercase letters, and the output is 7 characters.
*/
// Comment: Straightfoward, all about getting number from char/str for hexa-decimal.
public class Solution {
    public string SimilarRGB(string color) {
        char[] getNext(char[] str)
        {
            var ret = new char[2];
            char c = str[0];
            if (c=='9') c = 'a';
            else if (c!= 'f') ++c;
            ret[0] = c; ret[1] = c;
            
            return ret;            
        }
        char[] getPrev(char[] str)
        {
            var ret = new char[2];
            char c= str[0];
            if (c=='a') c = '9';
            else if (c!='0') --c;
            ret[0] = c; ret[1] = c;
            return ret;  
        }
        char[] getMin(char[] prev, char[] next, char[] tgt)
        {
            char[] curr = new char[2];
            curr[0] = tgt[0]; curr[1] = tgt[0];
            
            int p = getNum(prev);
            int n = getNum(next);
            int c = getNum(curr);
            int t = getNum(tgt);
            int d1 = Math.Abs(p-t);
            int d2 = Math.Abs(n-t);
            int d3 = Math.Abs(c-t);
            if (d1<=d2 && d1<=d3)
                return prev;
            if (d2<=d1 && d2<=d3)
                return next;
            return curr;
        }
        
        int getNum(char[] str)
        {
            // Spoiler: Don't forget adding 10 for 'a' case below.
            int h = str[0]>='a' ? (str[0] - 'a' + 10) : str[0] - '0';
            int l = str[1] >='a' ? (str[1] -'a' + 10): str[1] - '0';
            return h*16 + l;
        }
        
        StringBuilder b = new StringBuilder();
        b.Append('#');
        for(int i=1; i<=5; i+= 2) {
            char[] tgt = color.Substring(i, 2).ToCharArray();
            var prev = getPrev(tgt);
            var next = getNext(tgt);
            var min = getMin(prev, next, tgt);
            b.Append(min[0]);
            b.Append(min[1]);
        }
        return b.ToString();
    }
}

