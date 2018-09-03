/*
Given a robot cleaner in a room modeled as a grid.
Each cell in the grid can be empty or blocked.
The robot cleaner with 4 given APIs can move forward, turn left or turn right. Each turn it made is 90 degrees.
When it tries to move into a blocked cell, its bumper sensor detects the obstacle and it stays on the current cell.
Design an algorithm to clean the entire room using only the 4 given APIs shown below.
interface Robot {
  // returns true if next cell is open and robot moves into the cell.
  // returns false if next cell is obstacle and robot stays on the current cell.
  boolean move();

  // Robot will stay on the same cell after calling turnLeft/turnRight.
  // Each turn will be 90 degrees.
  void turnLeft();
  void turnRight();

  // Clean the current cell.
  void clean();
}
Example:
Input:
room = [
  [1,1,1,1,1,0,1,1],
  [1,1,1,1,1,0,1,1],
  [1,0,1,1,1,1,1,1],
  [0,0,0,1,0,0,0,0],
  [1,1,1,1,1,1,1,1]
],
row = 1,
col = 3

Explanation:
All grids in the room are marked by either 0 or 1.
0 means the cell is blocked, while 1 means the cell is accessible.
The robot initially starts at the position of row=1, col=3.
From the top left corner, its position is one row below and three columns right.
Notes:
The input is only given to initialize the room and the robot's position internally. You must solve this problem "blindfolded". In other words, you must control the robot using only the mentioned 4 APIs, without knowing the room layout and the initial robot's position.
The robot's initial position will always be in an accessible cell.
The initial direction of the robot will be facing up.
All accessible cells are connected, which means the all cells marked as 1 will be accessible by the robot.
Assume all four edges of the grid are all surrounded by wall.
*/
// Comment: The key idea is to track whether locations are visited using two dimensional Dictoionary for termination.
// Robot always returns back to the original location/direction. Then try to move other direction in clock-wise (right turn in this case).
/**
 * // This is the robot's control interface.
 * // You should not implement it, or speculate about its implementation
 * interface Robot {
 *     // Returns true if the cell in front is open and robot moves into the cell.
 *     // Returns false if the cell in front is blocked and robot stays in the current cell.
 *     public bool Move();
 *
 *     // Robot will stay in the same cell after calling turnLeft/turnRight.
 *     // Each turn will be 90 degrees.
 *     public void TurnLeft();
 *     public void TurnRight();
 *
 *     // Clean the current cell.
 *     public void Clean();
 * }
 */
class Solution {
    int i = 0;
    int j = 0;
    int dir = 0;
    Dictionary<int, Dictionary<int, bool>> visited = new Dictionary<int, Dictionary<int, bool>>();
    public void CleanRoom(Robot robot) {
        if (!visited.ContainsKey(i))
            visited[i] = new Dictionary<int, bool>();
        else if (!visited[i].ContainsKey(j))
            visited[i][j] = false;
        else if (visited[i][j])
            return;
        visited[i][j] = true;
        robot.Clean();
        for(int k=0; k<4; k++) {
            if (robot.Move()) {
                switch(dir) {
                    case 0: --i; break;
                    case 1: j++; break;
                    case 2: ++i; break;
                    case 3: --j; break;                    
                }
                CleanRoom(robot);
                // Restore to the original location/direction
                robot.TurnLeft();
                robot.TurnLeft();
                robot.Move();
                robot.TurnLeft();
                robot.TurnLeft();
                switch(dir) {
                    case 0: ++i; break;
                    case 1: j--; break;
                    case 2: --i; break;
                    case 3: ++j; break;                    
                }
            }
            // Turn/search right direction
            robot.TurnRight();
            dir++;
            dir%=4;
        }
    }
}