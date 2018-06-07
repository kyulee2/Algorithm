/*
Design a logger system that receive stream of messages along with its timestamps, each message should be printed if and only if it is not printed in the last 10 seconds.

Given a message and a timestamp (in seconds granularity), return true if the message should be printed in the given timestamp, otherwise returns false.

It is possible that several messages arrive roughly at the same time.

Example:

Logger logger = new Logger();

// logging string "foo" at timestamp 1
logger.shouldPrintMessage(1, "foo"); returns true; 

// logging string "bar" at timestamp 2
logger.shouldPrintMessage(2,"bar"); returns true;

// logging string "foo" at timestamp 3
logger.shouldPrintMessage(3,"foo"); returns false;

// logging string "bar" at timestamp 8
logger.shouldPrintMessage(8,"bar"); returns false;

// logging string "foo" at timestamp 10
logger.shouldPrintMessage(10,"foo"); returns false;

// logging string "foo" at timestamp 11
logger.shouldPrintMessage(11,"foo"); returns true;
Credits:
Special thanks to @memoryless for adding this problem and creating all test cases.
*/
// Comment: Circular queue using an array. For duplication as follow-up, use List<int>[]. This is similar to getHitCount(). The difference/spoiler here is that start time is 0 not 1.
public class Logger {
    int curr;
    List<string>[] data;
    int idx;
    int len;
    HashSet<string> map;
    /** Initialize your data structure here. */
    public Logger() {
        curr = 0; // Spoiler: timestamp starts from 0 (not 1)
        len = 10;
        idx = 0;
        map = new HashSet<string>();
        data = new List<string>[10];
        for(int i=0; i<len; i++)
            data[i] = new List<string>();
    }
    
    void Remove(int i, int j)
    {
        for(int k=i; k<=j; k++) {
           foreach(var s in data[k])
               map.Remove(s);
            data[k].Clear();         
        }
    }
    /** Returns true if the message should be printed in the given timestamp, otherwise returns false.
        If this method returns false, the message will not be printed.
        The timestamp is in seconds granularity. */
    public bool ShouldPrintMessage(int timestamp, string message) {
        int delta = timestamp - curr;
        if (delta == 0) {
            if (map.Contains(message)) return false;
            map.Add(message);
            data[idx].Add(message);
            return true;
        }

        if (delta>=len) {
            // Reset all queue
            Remove(0, len-1);
            curr = timestamp;
            idx = 0;
        }
        else {
            int oldidx = idx;
            idx += delta;
            if (idx >= len) {
                Remove(oldidx+1, len-1);
                idx = idx % len;
                Remove(0, idx);
            } else {
                Remove(oldidx+1, idx);
            }
            curr = timestamp;
        }
        if (map.Contains(message))
            return false;
        map.Add(message);
        data[idx].Add(message);
        return true;
    }
}

/**
 * Your Logger object will be instantiated and called as such:
 * Logger obj = new Logger();
 * bool param_1 = obj.ShouldPrintMessage(timestamp,message);
 */

