/*
Reverse bits of a given 32 bits unsigned integer.
Example:
Input: 43261596
Output: 964176192
Explanation: 43261596 represented in binary as 00000010100101000001111010011100, 
             return 964176192 represented in binary as 00111001011110000010100101000000.
Follow up:
If this function is called many times, how would you optimize it?
*/
// Comment: Striaghtforward using bit manipulation.
public class Solution {
    public uint reverseBits(uint n) {
        // 1 bit
        n  = ((n & (uint)0x55555555) << 1) | ((n & (uint)0xaaaaaaaa) >> 1);
        // 2 bit
        n  = ((n & (uint)0x33333333) << 2 )| ((n & (uint)0xCCCCCCCC) >> 2);
        // 4 bit
        n  = ((n & (uint)0x0f0f0f0f) << 4 )| ((n & (uint)0xf0f0f0f0) >> 4);
        // 8 bit
        n  = ((n & (uint)0x00ff00ff) << 8 )| ((n & (uint)0xff00ff00) >> 8);
        // 16 bit
        n  = ((n & (uint)0x0000ffff) << 16 )| ((n & (uint)0xffff0000) >> 16);
        return n;        
    }
}
