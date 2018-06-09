/*
Design a Snake game that is played on a device with screen size = width x height. Play the game online if you are not familiar with the game.
The snake is initially positioned at the top left corner (0,0) with length = 1 unit.
You are given a list of food's positions in row-column order. When a snake eats the food, its length and the game's score both increase by 1.
Each food appears one by one on the screen. For example, the second food will not appear until the first food was eaten by the snake.
When a food does appear on the screen, it is guaranteed that it will not appear on a block occupied by the snake.
Example:
Given width = 3, height = 2, and food = [[1,2],[0,1]].

Snake snake = new Snake(width, height, food);

Initially the snake appears at position (0,0) and the food at (1,2).

|S| | |
| | |F|

snake.move("R"); -> Returns 0

| |S| |
| | |F|

snake.move("D"); -> Returns 0

| | | |
| |S|F|

snake.move("R"); -> Returns 1 (Snake eats the first food and right after that, the second food appears at (0,1) )

| |F| |
| |S|S|

snake.move("U"); -> Returns 1

| |F|S|
| | |S|

snake.move("L"); -> Returns 2 (Snake eats the second food)

| |S|S|
| | |S|

snake.move("U"); -> Returns -1 (Game over because snake collides with border)

*/
// Comment: The missing condition here was to detect colision. Snake cannot be overlapped with itself.
// Using a queue is a key.. When move, delete the tail and add new head.
// One way to detect is to see if new location has one of member in the queue O(n) where n is the length of queue
// The other way below is simply to have a grid (cache/display) to see if new location has already 1 (snake body).
public class SnakeGame {
    int i;
    int j;
    int Row;
    int Col;
    int foodId;
    Queue<int[]> q;
    int[,] f;
    int[,] grid;
    
    /** Initialize your data structure here.
        @param width - screen width
        @param height - screen height 
        @param food - A list of food positions
        E.g food = [[1,1], [1,0]] means the first food is positioned at [1,1], the second is at [1,0]. */
    public SnakeGame(int width, int height, int[,] food) {
        q  = new Queue<int[]>();
        q.Enqueue(new int[]{0,0});
        f = food;
        Row =height;
        Col = width;
        grid = new int[Row, Col];
        grid[i,j] = 1;
    }
    
    /** Moves the snake.
        @param direction - 'U' = Up, 'L' = Left, 'R' = Right, 'D' = Down 
        @return The game's score after the move. Return -1 if game over. 
        Game over when snake crosses the screen boundary or bites its body. */
    public int Move(string direction) {
        if (direction=="U") --i;
        else if(direction=="D") ++i;
        else if (direction=="L") --j;
        else ++j;
        if (i<0||i>=Row||j<0||j>=Col)
            return -1;
        bool shouldDelete = true;;
        if (foodId != f.GetLength(0)) {
            int x = f[foodId, 0];
            int y = f[foodId, 1];
            if (i==x && j==y) {
                foodId++;
                shouldDelete = false;
            }
        }
        
        // Delete first
        if (shouldDelete) {
            int[] p = q.Dequeue();
            grid[p[0], p[1]] = 0;
        }
        
        // Detect colision 
        if (grid[i,j] == 1)
            return -1;
        
        // Handle new location
         q.Enqueue(new int[]{i,j});
         grid[i,j] = 1;
        
        return foodId;        
    }
}

/**
 * Your SnakeGame object will be instantiated and called as such:
 * SnakeGame obj = new SnakeGame(width, height, food);
 * int param_1 = obj.Move(direction);
 */