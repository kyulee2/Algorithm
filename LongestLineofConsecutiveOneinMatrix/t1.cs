/*
Given a 01 matrix M, find the longest line of consecutive one in the matrix. The line could be horizontal, vertical, diagonal or anti-diagonal. 
Example:
Input:
[[0,1,1,0],
 [0,1,1,0],
 [0,0,0,1]]
Output: 3

Hint: The number of elements in the given matrix will not exceed 10,000. 
*/
// Comment: A bit of coding. Left/Right/Diag/AntiDiag search. Use hasNext and getNext apis.

public class Solution {
    int i;
    int j;
    int Row;
    int Col;
    int[,] m;
    int max;
    bool hasNextCol() {
        while(j < Col) {
            if (m[i,j] == 1) return true;
            j++;
        }
        return false;
    }
    int getNextCol()
    {
        int dist = 0;
        while(j<Col && m[i,j] == 1) {
            dist++;
            j++;
        }
        if (dist > max) max = dist;
        return dist;
    }
    bool hasNextRow() {
        while(i < Row) {
            if (m[i,j] == 1) return true;
            i++;
        }
        return false;
    }
    int getNextRow()
    {
        int dist = 0;
        while(i<Row && m[i,j] == 1) {
            dist++;
            i++;
        }
        if (dist > max) max = dist;
        return dist;
    }    

    bool hasNextDiag() {
        while(i<Row && j<Col) {
            if (m[i,j]== 1) return true;
            i++;
            j++;
        }
        return false;
    }
    bool getNextDiag() {
        int dist = 0;
        while(i<Row && j<Col && m[i,j]==1) {
            dist++;
            i++;
            j++;
        }
        if (dist>max) max = dist;
        return false;
    }    

    bool hasNextAntiDiag() {
        while(i<Row && j>=0) {
            if (m[i,j]== 1) return true;
            i++;
            j--;
        }
        return false;
    }
    bool getNextAntiDiag() {
        int dist = 0;
        while(i<Row && j>=0 && m[i,j]==1) {
            dist++;
            i++;
            j--;
        }
        if (dist>max) max = dist;
        return false;
    }    
    
    public int LongestLine(int[,] M) {
        // Initialize data
        m = M;
        Row = m.GetLength(0);
        Col = m.GetLength(1);
        max = 0;
        
        // Col
        for(int k=0; k<Row; k++) {
            i = k;
            j = 0;
            while(hasNextCol())
                getNextCol();
        }
        // Row
        for(int k=0; k<Col; k++) {
            i = 0;
            j = k;
            while(hasNextRow())
                getNextRow();
        }
        
        // Diagonal
        for(int k=0; k<Col; k++) {
            i = 0;
            j = k;
            while(hasNextDiag())
                getNextDiag();
        }
        for(int k=1; k<Row; k++) {
            i = k;
            j = 0;
            while(hasNextDiag())
                getNextDiag();
        }
        
        // AntiDiagonal
        for(int k=0; k<Col; k++) {
            i = 0;
            j = k;
            while(hasNextAntiDiag())
                getNextAntiDiag();
        }
        for(int k=1; k<Row; k++) {
            i = k;
            j = Col - 1;
            while(hasNextAntiDiag())
                getNextAntiDiag();
        }        
        return max;
    }
}
