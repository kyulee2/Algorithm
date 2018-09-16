/*
There is a special square room with mirrors on each of the four walls.  Except for the southwest corner, there are receptors on each of the remaining corners, numbered 0, 1, and 2.
The square room has walls of length p, and a laser ray from the southwest corner first meets the east wall at a distance q from the 0th receptor.
Return the number of the receptor that the ray meets first.  (It is guaranteed that the ray will meet a receptor eventually.)
 
Example 1:
Input: p = 2, q = 1
Output: 2
Explanation: The ray meets receptor 2 the first time it gets reflected back to the left wall.


Note:
1 <= p <= 1000
0 <= q <= p
*/
// Comment: Tricky about reflection condition. Note the reflection angle in south are north are same while east and west are the same, and they are reversed.
// One in p/q and the other is q/p. Since p>=q, the reflection on south/north always goes to either of east/west depending on rotation direction (clockwise vs. counter-clockwise).
// But the refecltion on east/west goes to either south/north without changing rotation direction, or directly either of west/east with chaning rotation direction.
// The below, (0,0) is cordinated at the starting position.
// Note there is a gcd solution which is faster using math. Try later.
public class Solution {
    public int MirrorReflection(int p, int q) {
        
        int Rec(double x, double y, int d, bool clockwise)
        {
            //Console.WriteLine("{0} {1} {2}", x, y, d);
            if (Math.Abs(x-p)<0.0001 && Math.Abs(y-p)<0.0001)
                return 1;
            if (Math.Abs(x-p)<0.0001 && Math.Abs(y)<0.0001)
                return 0;
            if (Math.Abs(x)<0.0001 && Math.Abs(y-p)<0.0001)
                return 2;
            double i, j;
            switch(d) {
                case 3: 
                    if (!clockwise) {
                        // south to east
                        i = p - x;
                        j = i * q / p;
                        return Rec(p, j, 0, clockwise);
                    } else {
                        j = x * q/ p;
                        return Rec(p, j, 2, clockwise);
                    }
                case 0: 
                    if (!clockwise) {
                        // east to north
                        j = p - y;
                        i = p - j * p / q;
                        if (i>=0)
                            return Rec(i, p, 1, clockwise);                    
                        else { // east to west directly
                            return Rec(0, y+q, 2, !clockwise);
                        }
                    } else {
                        // east to south
                        i = p - y * p / q;
                        if (i>=0)
                            return Rec(i, 0, 3, clockwise);
                        else {
                            // east to west directly
                            return Rec(0, y-q, 2, !clockwise);
                        }
                    }
                case 1: 
                    if (!clockwise) {
                        // north to west
                        j = p - x * q / p;
                        return Rec(0, j, 2, clockwise);
                    } else { // north to east
                        i = p - x;
                        j= p - i * q / p;
                        return Rec(p, j, 0, clockwise);
                    }
                case 2: 
                    if (!clockwise) {
                        i = y * p / q;
                        if (i<=p) {
                            // west to south
                            return Rec(i, 0, 3, clockwise);
                        } else {
                            // west to east directly
                            return Rec(p, y-q, 0, !clockwise);
                        }
                    } else {
                        j = p - y;
                        i = j * p / q;
                        if (i<=p)
                            // west to north
                            return Rec(i, p, 1, clockwise);
                        else // west to east directly
                            return Rec(p, y + q, 0, !clockwise);
                        
                    }
                default:
                    break;
            }
            return -1;
        }
        
        return Rec(0, 0, 3, false);
    }
}