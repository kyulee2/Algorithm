/*
Design an algorithm to encode a list of strings to a string. The encoded string is then sent over the network and is decoded back to the original list of strings.
Machine 1 (sender) has the function: 
string encode(vector<string> strs) {
  // ... your code
  return encoded_string;
}
Machine 2 (receiver) has the function: 
vector<string> decode(string s) {
  //... your code
  return strs;
}

So Machine 1 does: 
string encoded_string = encode(strs);

and Machine 2 does: 
vector<string> strs2 = decode(encoded_string);

strs2 in Machine 2 should be the same as strs in Machine 1. 
Implement the encode and decode methods. 
Note:
The string may contain any possible characters out of 256 valid ascii characters. Your algorithm should be generalized enough to work on any possible characters.
Do not use class member/global/static variables to store states. Your encode and decode algorithms should be stateless.
Do not rely on any library method such as eval or serialize methods. You should implement your own encode/decode algorithm.
*/
// Comment: Use the schema Count$Char ending with 0 per line.
// For instance, Hello -> 1$H1$e2$l1$o0
// Without '$', it fails to parse [["0"]] since it is "100" 

public class Codec {
    string encodeStr(string str) {
        // count char
        StringBuilder b = new StringBuilder();
        for(int i=0; i<str.Length; i++) {
            int j=i;
            char c =str[j];
            while(j<str.Length && str[j] == c)
                j++;
            b.Append(j-i);
            b.Append('$'); // spoiler: without this, it fails [['0']]
            b.Append(c);
            i = j - 1;
        }
        return b.ToString();
    }
    // Encodes a list of strings to a single string.
    public string encode(IList<string> strs) {
        StringBuilder b = new StringBuilder();
        foreach(var s in strs) {
            b.Append(encodeStr(s));
            b.Append(0);            
        }
        return b.ToString();
    }

    // Decodes a single string to a list of strings.
    public IList<string> decode(string s) {
        List<string> ans = new List<string>();
        StringBuilder b = new StringBuilder();
        for(int i=0; i<s.Length; i++) {
            char c = s[i];
            if (c=='0') {
                ans.Add(b.ToString());
                b.Clear();
                continue;
            }
            // assert c: numbers
            int n = (int)(c - '0');
            int j= i+1;
            while(s[j]!='$') {
                n *= 10;
                n += (int)(c - '0');
                j++;
            }
            i = j+1;
            char ch = s[i];
            for(int k=0; k<n; k++)
                b.Append(ch);
        }
        return ans;        
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.decode(codec.encode(strs));

