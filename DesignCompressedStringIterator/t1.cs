/*

Design and implement a data structure for a compressed string iterator. It should support the following operations: next and hasNext.

The given compressed string will be in the form of each letter followed by a positive integer representing the number of this letter existing in the original uncompressed string.

next() - if the original string still has uncompressed characters, return the next letter; Otherwise return a white space.
hasNext() - Judge whether there is any letter needs to be uncompressed.

Note:
Please remember to RESET your class variables declared in StringIterator, as static/class variables are persisted across multiple test cases. Please see here for more details.

Example:

StringIterator iterator = new StringIterator("L1e2t1C1o1d1e1");

iterator.next(); // return 'L'
iterator.next(); // return 'e'
iterator.next(); // return 'e'
iterator.next(); // return 't'
iterator.next(); // return 'C'
iterator.next(); // return 'o'
iterator.next(); // return 'd'
iterator.hasNext(); // return true
iterator.next(); // return 'e'
iterator.hasNext(); // return false
iterator.next(); // return ' '
*/
// Comment: A bit straight-forward.
// Run hasNext() always in next to ensure availablity.
public class StringIterator {
    char currChar;
    int currCount;
    int i;
    string str;
    int len;
    char getNextChar()
    {
        return str[i++];
    }
    int getNextInt()
    {
        int sum = 0;
        char c;
        while(i<len && (c=str[i])>='0' && c<='9') {
            sum *= 10;
            sum += (int)(c - '0');
            i++;
        }
        return sum;
    }    
    
    public StringIterator(string compressedString) {
        str = compressedString;
        len = str.Length;        
    }
    
    public char Next() {
        if (!HasNext()) return ' ';
        currCount--;
        return currChar;
    }
    
    public bool HasNext() {
        if (currCount>0)
            return true;
        if (i==len)
            return false;
        currChar = getNextChar();
        currCount = getNextInt();
        return true;
    }
}

/**
 * Your StringIterator object will be instantiated and called as such:
 * StringIterator obj = new StringIterator(compressedString);
 * char param_1 = obj.Next();
 * bool param_2 = obj.HasNext();
 */

