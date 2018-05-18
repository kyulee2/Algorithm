/*
 city's skyline is the outer contour of the silhouette formed by all the buildings in that city when viewed from a distance. Now suppose you are given the locations and height of all the buildings as shown on a cityscape photo (Figure A), write a program to output the skyline formed by these buildings collectively (Figure B).

The geometric information of each building is represented by a triplet of integers [Li, Ri, Hi], where Li and Ri are the x coordinates of the left and right edge of the ith building, respectively, and Hi is its height. It is guaranteed that 0 < Hi <= INT_MAX, and Ri - Li > 0. You may assume all buildings are perfect rectangles grounded on an absolutely flat surface at height 0.

For instance, the dimensions of all buildings in Figure A are recorded as: [ [2 9 10], [3 7 15], [5 12 12], [15 20 10], [19 24 8] ] .

The output is a list of "key points" (red dots in Figure B) in the format of [ [x1,y1], [x2, y2], [x3, y3], ... ] that uniquely defines a skyline. A key point is the left endpoint of a horizontal line segment. Note that the last key point, where the rightmost building ends, is merely used to mark the termination of the skyline, and always has zero height. Also, the ground in between any two adjacent buildings should be considered part of the skyline contour.

For instance, the skyline in Figure B should be represented as:[ [2 10], [3 15], [7 12], [12 0], [15 10], [20 8], [24, 0] ].

Notes:

The number of buildings in any input list is guaranteed to be in the range [0, 10000].
The input list is already sorted in ascending order by the left x position Li.
The output list must be sorted by the x position.
There must be no consecutive horizontal lines of equal height in the output skyline. For instance, [...[2 3], [4 5], [7 5], [11 5], [12 7]...] is not acceptable; the three lines of height 5 should be merged into one in the final output as such: [...[2 3], [4 5], [12 7], ...]
*/

// Comment
// Key idea is when building appears (Start), add its height to Priority queue. When building disappears (End), remove its height from the queue. At each Start/End time point, make sure the current Max height of the queue is changed. If so, output such (time, max) pair to the list.
//
// 1. PriQ (either a Heap) is required. Should we use an existing data structure?
//    Current implementation is Add (O(n)) but Remove(O(1))
// 2. Set to Sorted array to keep track of unique time (start/end)
// 3. Use two maps to maintain Start and End respectively. 
// 4. ArrayList<Node> cannot be used -- No generic form ArrayList. Instead, use List<Node>
using System;
using System.Collections;
public class Solution
{
    class Node
    {
        public int Height; // key
        public Node Next;
        public Node Prev;
        public Node() { }
        public Node(int Key)
        {
            Height = Key;
        }
    }

    class PriQ
    {
        Node Head, Tail;
        public PriQ()
        {
            Head = new Node();
            Tail = new Node();
            Head.Next = Tail;
            Tail.Prev = Head;
        }
        public void Add(Node n)
        {
            Node Curr = Head.Next;
            while (Curr != Tail)
            {
                if (n.Height > Curr.Height)
                    break;
                Curr = Curr.Next;
            }

            Node Prev = Curr.Prev;
            Prev.Next = n;
            n.Prev = Prev;
            n.Next = Curr;
            Curr.Prev = n;
        }

        public void Remove(Node n)
        {
            Node Prev = n.Prev;
            Prev.Next = n.Next;
            n.Next.Prev = Prev;
        }

        public int GetMax()
        {
            return Head.Next.Height;
        }
    }

    public IList<int[]> GetSkyline(int[,] buildings)
    {
        // Initialize a set to list unique time (either start/end)
        // Two maps : start/end pointint to a node (with height as a key)
        HashSet<int> S = new HashSet<int>();
        Dictionary<int, List<Node>> MapS = new Dictionary<int, List<Node>>();
        Dictionary<int, List<Node>> MapE = new Dictionary<int, List<Node>>();
        int Len = buildings.GetLength(0);
        for(int i=0; i<Len; i++)
        {
            int Start = buildings[i, 0];
            int End = buildings[i, 1];
            int Height = buildings[i, 2];
            Node n = new Node(Height);
            if (!MapS.ContainsKey(Start))
                MapS[Start] = new List<Node>();
            if (!MapE.ContainsKey(End))
                MapE[End] = new List<Node>();
            MapS[Start].Add(n);
            MapE[End].Add(n);
            S.Add(Start);
            S.Add(End);
        }

        // Convert the set to sorted array
        int[] Arr = new int[S.Count];
        S.CopyTo(Arr);
        Array.Sort(Arr);

        // The main loop
        // Initialize PriQ to maintain the order of building
        PriQ Q = new PriQ();
        List<int[]> O = new List<int[]>();
        int Max = 0;
        foreach(var time in Arr)
        {
            if (MapS.ContainsKey(time))
                foreach(var n in MapS[time])
                    Q.Add(n);
            if (MapE.ContainsKey(time))
                foreach (var n in MapE[time])
                    Q.Remove(n);
            int Curr = Q.GetMax();
            if (Curr != Max)
            {
                Max = Curr;
                O.Add(new int[2] { time, Max });
            }
        }

        return O;
    }
}

