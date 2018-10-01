/*
The API: int read4(char *buf) reads 4 characters at a time from a file.

The return value is the actual number of characters read. For example, it returns 3 if there is only 3 characters left in the file.

By using the read4 API, implement the function int read(char *buf, int n) that reads n characters from the file.

Example 1:

Input: buf = "abc", n = 4
Output: "abc"
Explanation: The actual number of characters read is 3, which is "abc".
Example 2:

Input: buf = "abcde", n = 5 
Output: "abcde"
Note:
The read function will only be called once for each test case.
*/
// Comment: Straighforwrad. Careful about n<3 case to pikc min of n or r below.
/* The Read4 API is defined in the parent class Reader4.
      int Read4(char[] buf); */
public class Solution : Reader4 {
    /**
     * @param buf Destination buffer
     * @param n   Maximum number of characters to read
     * @return    The number of characters read
     */
    public int Read(char[] buf, int n) {
        var b = new char[4];
        for(int i=0; i< (n/4)*4; i+= 4) {
            var r = Read4(b);
            Array.Copy(b, 0, buf, i, r);
            if (r<4)
                return i + r;
        }
        var t = n%4;
        if (t!=0) {
            int j = n - t;// 1 2 3
            var r = Read4(b);
            Array.Copy(b, 0, buf, j, Math.Min(r, t));
            return j + Math.Min(r, t);
        }
        return n;
    }
}

public class Solution : Reader4 {
    /**
     * @param buf Destination buffer
     * @param n   Maximum number of characters to read
     * @return    The number of characters read
     */
    public int Read(char[] buf, int n) {
        int i =0;
        var b = new char[4];
        while(n>4) {            
            int r = Read4(b);
            for(int j=i; j<i+r; j++) {
                buf[j] = b[j-i];
            }
            i += r;
            if (r<4)
                return i;
            n -= 4;
        }
        
        if (n>0) {
            int r = Read4(b);
            r = Math.Min(r, n);
            for(int j=i; j<i+r; j++) {
                buf[j] = b[j-i];
            }
            i += r;
        }
        return i;
    }
}

