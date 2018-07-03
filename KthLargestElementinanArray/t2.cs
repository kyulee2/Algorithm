/*
Find the kth largest element in an unsorted array. Note that it is the kth largest element in the sorted order, not the kth distinct element.
Example 1:
Input: [3,2,1,5,6,4] and k = 2
Output: 5
Example 2:
Input: [3,2,3,1,2,4,5,5,6] and k = 4
Output: 4
Note: 
You may assume k is always valid, 1 = k = array's length.
*/
// Comment: Use a heap. Extra k elements from the top.
// hepify(push down) from 2/n to 0 elements to build a heap.
public class Solution {
    int[] n;
    int nlen;
    
    int getLeft(int i) {
        int next = i * 2 + 1;
        if (next>=nlen) return -1;
        return next;
    }
    int getRight(int i) {
        int next = i * 2 + 2;
        if (next>=nlen) return -1;
        return next;
    }
    void swap(int i, int j)
    {
        int t= n[i];
        n[i] = n[j];
        n[j] = t;
    }
    void heapify(int i) {
        if (i>=nlen) return;
        int l = getLeft(i);
        int r = getRight(i);
        
        int nc = n[i];
        int nl = l==-1 ? Int32.MinValue : n[l];
        int nr = r==-1 ? Int32.MinValue : n[r];
        if (nc >= nl && nc >= nr) return;
        if (nl > nr) {
            swap(i, l);
            heapify(l);                
        } else {
            swap(i, r);
            heapify(r);
        }
    }

    public int FindKthLargest(int[] nums, int k) {
        // Build head
        int len = nums.Length;
        n = nums;
        /* Method1: push down from n/2 to 1*/
        for(int i=(len-1)/2; i>= 0; i--) {
            heapify(i);
        }

        /* Method2: push up by inserting element */
        /*
        int getParent(int i) { return (i-1)/2;}
        void updateParent(int j) {
            if (j==0) return;
            int p = getParent(j);
            if (n[j] > n[p]) {
                swap(j, p);
                updateParent(p);
            }   
        }
        for(int i=0; i<len; i++) {
            nlen = i + 1;
            updateParent(i);
        }
        */
        
        int max = 0;
        for(int i=0; i<k; i++) {
            max = nums[0];
            
            // swap the top to end
            nums[0] = Int32.MinValue;
            swap(0, len -1 );
            len--;
            
            heapify(0);
        }
        
        return max;
    }
}
