/*
Pick One

Given a 2D grid, each cell is either a wall 'W', an enemy 'E' or empty '0' (the number zero), return the maximum enemies you can kill using one bomb.
The bomb kills all the enemies in the same row and column from the planted point until it hits the wall since the wall is too strong to be destroyed.
Note that you can only put the bomb at an empty cell. 
Example:
For the given grid

0 E 0 0
E 0 W E
0 E 0 0

return 3. (Placing a bomb at (1,1) kills 3 enemies)
*/
// Comment: Use a extra space to aggregate cost/enemy counts. 
// Don't forget adding cost of col/row both.
public class Solution {
    int[,] cost;
    char[,] g;
    int Row;
    int Col;
    void buildCost() {
        // Row
        for(int i=0; i<Row; i++) {
            int j=0, k=0;
            int sum = 0;
            while(j<Col) {
                if (g[i,j] =='W') {
                    for(int p = k; p <j; p++)
                        cost[i,p] = sum;
                    k = j+1;
                    sum = 0;
                }
                else if (g[i,j]=='E') sum++;
                j++;                
            }
            for(int q = k; q <Col; q++)
                cost[i,q] = sum;            
        }
        // Col
        for(int j=0; j<Col; j++) {
            int i=0, k=0;
            int sum = 0;
            while(i<Row) {
                if (g[i,j] =='W') {
                    for(int p = k; p <i; p++)
                        cost[p,j] += sum; // spoiler: adding cost
                    k = i+1;
                    sum = 0;
                }
                else if (g[i,j]=='E') sum++;
                i++;                
            }
            for(int q = k; q <Row; q++)
                cost[q, j] += sum;  // spoiler: adding cost
        }
    }
    public int MaxKilledEnemies(char[,] grid) {
        g = grid;
        Row = g.GetLength(0);
        Col = g.GetLength(1);
        cost = new int[Row,Col];
        
        buildCost();
        int max = 0;
        for(int i=0; i<Row; i++)
            for(int j=0; j<Col; j++)
                if (g[i,j]=='0')
                    if (cost[i,j] > max)
                        max = cost[i,j];
        return max;
    }
}

