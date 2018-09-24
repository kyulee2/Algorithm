void f(int v[], const int N, const int k);
N is size of v[]
0 < k < N-1

Move first k elements of v[] to the end of v[]
and move the remaining elements of v[] to the 
beginning of v[].

N = 5, k = 2
[1 2 3 4 5]
=>
[3 4 5 1 2]

reverse array
5 4 3 2 1
split array by searching k'th index from the end
5 4 3, 2 1  (index for 2 is 3 = 5 - 2)
reverse each part 
3 4 5, 1 2

// Helper for reversing elements in place
void Reverse(int v[], int i, int j)
{
    while(i<=j) {
        int t = v[i];
        v[i] = v[j];
        v[j] = t;
        i++;
        j--;
    }
}

void f(int v[], const int N, const int k)
{
    // Reverse the array -- [5 4 3 2 1]
    Reverse(v, 0, N-1);
    // Find split idx
    int idx = N- k; 
    // Reverse each part
    Reverse(v, 0, idx -1);
    Reverse(v, idx, N-1);
}

int f (v[], int N)
N is sized of v[]
for all i: 0 <= v[i] < N-1
Are duplicates in v[]?
If yes, return value of duplicate.
If no, return -1
N = 3 
0<=v[i]<2
[0 1 1]
return 1
Array size is 3. Valid input is 0 or 1.
// O(n) size. O(n) time
int f(v[], int N)
{
    var s = new HashSet<int>();
    for(int i=0; i<N; i++) {
        int t = v[i];
        if (s.Contains(t))
            return t;
        s.Add(t);
    }
    return -1;
}

// [0 1 1]
/ t = 0
// O(1) size, O(n) time
int f(v[], int N)
{
    int t =0 ;
    for(int i=0; i<N; i++) {
        t ^= v[i];
    }
    
}





void f(int v[], const int N, const int k);
N is size of v[]
0 < k < N-1

Move first k elements of v[] to the end of v[]
and move the remaining elements of v[] to the 
beginning of v[].

N = 5, k = 2
[1 2 3 4 5]
=>
[3 4 5 1 2]

reverse array
5 4 3 2 1
split array by searching k'th index from the end
5 4 3, 2 1  (index for 2 is 3 = 5 - 2)
reverse each part 
3 4 5, 1 2

// Helper for reversing elements in place
void Reverse(int v[], int i, int j)
{
    while(i<=j) {
        int t = v[i];
        v[i] = v[j];
        v[j] = t;
        i++;
        j--;
    }
}

void f(int v[], const int N, const int k)
{
    // Reverse the array -- [5 4 3 2 1]
    Reverse(v, 0, N-1);
    // Find split idx
    int idx = N- k; 
    // Reverse each part
    Reverse(v, 0, idx -1);
    Reverse(v, idx, N-1);
}

int f (v[], int N)
N is sized of v[]
for all i: 0 <= v[i] < N-1
Are duplicates in v[]?
If yes, return value of duplicate.
If no, return -1
N = 3 
0<=v[i]<2
[0 1 1]
return 1
Array size is 3. Valid input is 0 or 1.
// O(n) size. O(n) time
int f(v[], int N)
{
    var s = new HashSet<int>();
    for(int i=0; i<N; i++) {
        int t = v[i];
        if (s.Contains(t))
            return t;
        s.Add(t);
    }
    return -1;
}

// [0 1 1]
/ t = 0
// O(1) size, O(n) time
int f(v[], int N)
{
    int t =0 ;
    for(int i=0; i<N; i++) {
        t ^= v[i];
    }
    
}






