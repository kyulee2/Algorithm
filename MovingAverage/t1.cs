/*
Given a stream of integers and a window size, calculate the moving average of all integers in the sliding window.
For example,
MovingAverage m = new MovingAverage(3);
m.next(1) = 1
m.next(10) = (1 + 10) / 2
m.next(3) = (1 + 10 + 3) / 3
m.next(5) = (10 + 3 + 5) / 3
*/
// Comment: Type cast to double to get real number of average
public class MovingAverage {

    int s;
    Queue<int> q;
    int curr;
    /** Initialize your data structure here. */
    public MovingAverage(int size) {
        s = size;
        q = new Queue<int>();
        curr = 0;
    }
    
    public double Next(int val) {
        if (q.Count == s) {
            int h = q.Dequeue();
            curr -= h;
        }
        q.Enqueue(val);
        curr += val;
        return (double)curr / q.Count;
    }
}

/**
 * Your MovingAverage object will be instantiated and called as such:
 * MovingAverage obj = new MovingAverage(size);
 * double param_1 = obj.Next(val);
 */
