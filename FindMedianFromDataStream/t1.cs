/*

Median is the middle value in an ordered integer list. If the size of the list is even, there is no middle value. So the median is the mean of the two middle value.

For example,
[2,3,4], the median is 3

[2,3], the median is (2 + 3) / 2 = 2.5

Design a data structure that supports the following two operations:

void addNum(int num) - Add a integer number from the data stream to the data structure.
double findMedian() - Return the median of all elements so far.
Example:

addNum(1)
addNum(2)
findMedian() -> 1.5
addNum(3) 
findMedian() -> 2
*/
// Comment: Use two min/max heaps. Be careful the implementation of Down below.
class Heap
{
    List<int> data;
    bool isMin;
    public Heap(bool min) {
        data = new List<int>();
        data.Add(0); // dummy
        isMin = min;
    }
    public int Count {
        get {
            return data.Count-1;
        }
    }
    public void Add(int n) {
        data.Add(n);
        Up(Count);
    }
    void Swap(int i, int j) {
        var t = data[i];
        data[i] = data[j];
        data[j] = t;
    }
    void Up(int i) {
        while(i != 1) {
            int p = i /2;
            if (isMin) {
                if (data[p]>data[i])
                    Swap(i,p);
                else break;
            } else {
                if (data[p]<data[i])
                    Swap(i,p);                
                else break;
            }
            i = p;
        }
    }
    void Down(int i) {
        if (i>Count) return;
        int l = (i*2 <= Count) ? data[i*2] : (isMin ? int.MaxValue: int.MinValue);
        int r = (i*2+1 <=Count) ? data[i*2+1]: (isMin ? int.MaxValue: int.MinValue);
        int n = data[i];
        if (isMin) {
            if (l<r) {
                if (l<n) {
                    Swap(i, i*2);
                    Down(i*2);    
                }
            } else {
                if (r<n) {
                    Swap(i, i*2+1);
                Down(i*2+1);
                }
            }
        } else {
            if (l>r) {
                if (l>n) {
                Swap(i, i*2);
                Down(i*2);    
                }
            } else {
                if (r>n) {
                    Swap(i, i*2+1);
                Down(i*2+1);
                }
            }            
        }
    }
    public int Peek() {
        return data[1];
    }
    public int RemoveTop()
    {
        int ans = Peek();
        Swap(1, Count);
        data.RemoveAt(Count);
        Down(1);
        return ans;
    }
}
public class MedianFinder {
    Heap min;
    Heap max;
    /** initialize your data structure here. */
    public MedianFinder() {
        min = new Heap(true);
        max = new Heap(false);
    }
    
    public void AddNum(int num) {
        if (min.Count ==0 && max.Count==0) {
            min.Add(num);
        } else if (min.Count!=0 && max.Count==0) {
            if (min.Peek()<num) {
                min.Add(num);
                max.Add(min.RemoveTop());
            } else
                max.Add(num);
        } else if (min.Count==0 && max.Count!=0) {
            if (max.Peek()>num) {
                max.Add(num);
                min.Add(max.RemoveTop());
            } else min.Add(num);
        } else {
            if (min.Peek()<num) {
                min.Add(num);
                if (min.Count>max.Count+1) {
                    max.Add(min.RemoveTop());
                }
            } else if (max.Peek()>num) {
                max.Add(num);
                if (max.Count > min.Count+1) {
                    min.Add(max.RemoveTop());
                }
            } else if (min.Count<max.Count) {
                min.Add(num);
            } else {
                max.Add(num);
            }
        }
    }
    
    public double FindMedian() {
        if (min.Count>max.Count)
            return min.Peek();
        else if (min.Count<max.Count)
            return max.Peek();
        else
            return ((double)min.Peek() + (double)max.Peek())/(double)2;
    }
}

/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.AddNum(num);
 * double param_2 = obj.FindMedian();
 */

