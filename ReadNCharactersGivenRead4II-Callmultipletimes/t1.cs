/*
The API: int read4(char *buf) reads 4 characters at a time from a file.

The return value is the actual number of characters read. For example, it returns 3 if there is only 3 characters left in the file.

By using the read4 API, implement the function int read(char *buf, int n) that reads n characters from the file.

Note:
The read function may be called multiple times.

Example 1: 

Given buf = "abc"
read("abc", 1) // returns "a"
read("abc", 2); // returns "bc"
read("abc", 1); // returns ""
Example 2: 

Given buf = "abc"
read("abc", 4) // returns "abc"
read("abc", 1); // returns ""
*/
// Comment: Devise ReadOne. This is way cleaner and can be a solution for the priori one I.
/* The Read4 API is defined in the parent class Reader4.
      int Read4(char[] buf); */

public class Solution : Reader4 {
    /**
     * @param buf Destination buffer
     * @param n   Maximum number of characters to read
     * @return    The number of characters read
     */

    char[] b = new char[4];
    int end = -1;
    int start = -1;
    bool ReadOne(ref char c) {
        if (start == end) {
            int r = Read4(b);
            if (r==0)
                return false;
            else {
                start = 0;
                end = r;
            }
        }
        c = b[start++];
        return true;
    }

    public int Read(char[] buf, int n) {
        int i=0;
        char c =' ';
        while(n > 0 && ReadOne(ref c)) {
            n--;
            buf[i++] = c;
        }
        return i;
    }
}
