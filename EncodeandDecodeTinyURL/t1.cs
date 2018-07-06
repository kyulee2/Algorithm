/*
Note: This is a companion problem to the System Design problem: Design TinyURL.
TinyURL is a URL shortening service where you enter a URL such as https://leetcode.com/problems/design-tinyurl and it returns a short URL such as http://tinyurl.com/4e9iAk.
Design the encode and decode methods for the TinyURL service. There is no restriction on how your encode/decode algorithm should work. You just need to ensure that a URL can be encoded to a tiny URL and the tiny URL can be decoded to the original URL.
*/
// Comment: The problem itself is simple but need to do for SystemDesign
public class Codec {
    string encodeID(int i)
    {
        var b = new StringBuilder();
        while(i!=0) {
            int r = i%58;
            if (r<24)
                b.Append((char)('a'+ r));
            else if (r<48)
                b.Append((char)('A'+(r-24)));
            else
                b.Append((char)('0'+(r-48)));
            i = i/58;
        }
        return b.ToString();
    }
    int decodeID(string s)
    {
        int id = 0;
        foreach(var c in s) {
            id *= 58;
            if (c>='a' && c<='z')
                id += (int)(c - 'a');
            else if (c>='A' && c<='Z')
                id += (int)(c-'A'+24);
            else 
                id += (int)(c-'0' + 48);
        }
        return id;
    }
    
    List<string> data = new List<string>();
    Dictionary<string, int> map = new Dictionary<string, int>();
    
    // Encodes a URL to a shortened URL
    public string encode(string longUrl) {
        if (map.ContainsKey(longUrl)) 
            return data[map[longUrl]];
        int Id = data.Count;
        string ans = encodeID(Id);
        map[longUrl] = Id;
        data.Add(longUrl);
        
        return "http://tinyurl.com/" + ans;
    }

    // Decodes a shortened URL to its original URL.
    public string decode(string shortUrl) {
        if (shortUrl.IndexOf("http://tinyurl.com/") != 0)
            return "";
        int Id = decodeID(shortUrl.Substring(19));
        return data[Id];
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.decode(codec.encode(url));
