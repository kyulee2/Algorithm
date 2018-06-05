/*
Design a hit counter which counts the number of hits received in the past 5 minutes.
Each function accepts a timestamp parameter (in seconds granularity) and you may assume that calls are being made to the system in chronological order (ie, the timestamp is monotonically increasing). You may assume that the earliest timestamp starts at 1.
It is possible that several hits arrive roughly at the same time.
Example:
HitCounter counter = new HitCounter();

// hit at timestamp 1.
counter.hit(1);

// hit at timestamp 2.
counter.hit(2);

// hit at timestamp 3.
counter.hit(3);

// get hits at timestamp 4, should return 3.
counter.getHits(4);

// hit at timestamp 300.
counter.hit(300);

// get hits at timestamp 300, should return 4.
counter.getHits(300);

// get hits at timestamp 301, should return 3.
counter.getHits(301); 

Follow up:
What if the number of hits per second could be very large? Does your design scale? 
Credits:
Special thanks to @elmirap for adding this problem and creating all test cases.
*/
// Comment: Array for circular queue. The key point is to remove invalid items regardless of hit() or getHits().
// As below, always calls getHits() within hit() to update i as nextI while clearing all counts from i+1 until nextI.
// Bail-out early when nextI is not changed.
public class HitCounter {

    int pTime;
    int[] data;
    int i;
    int cnt;
    
    /** Initialize your data structure here. */
    public HitCounter() {
        data = new int[300];
        i = 0;
        pTime = 1;
        cnt = 0;
    }
    
    /** Record a hit.
        @param timestamp - The current timestamp (in seconds granularity). */
    public void Hit(int timestamp) {
        GetHits(timestamp);
        cnt++;
        data[i]++;
    }
    
    /** Return the number of hits in the past 5 minutes.
        @param timestamp - The current timestamp (in seconds granularity). */
    public int GetHits(int timestamp) {
        if (pTime == timestamp) {
             return cnt;
         }
         int delta = timestamp - pTime;
         if (delta >= 300) {
             // reset
             data = new int[300];
             i = 0;
             pTime = timestamp;
             cnt = 0;
             return cnt;
         }

        int nextI = i + delta;
        if (nextI >= 300) {
            for(int j = i + 1; j < 300; j++) {
                cnt -= data[j];
                data[j] = 0;
            }
            nextI = nextI % 300;
            for (int j=0; j <=nextI; j++) {
                cnt -= data[j];
                data[j] = 0;
            }
        }
        else {
            for(int j= i+1; j<=nextI; j++) {
                cnt -= data[j];
                data[j] = 0;
            }
        }

        pTime = timestamp;
        i = nextI;

        return cnt;
    }
}

/**
 * Your HitCounter object will be instantiated and called as such:
 * HitCounter obj = new HitCounter();
 * obj.Hit(timestamp);
 * int param_2 = obj.GetHits(timestamp);
 */

