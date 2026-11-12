
public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    // Move left if there is no wall
    public void MoveLeft()
    {
        // Check whether moving left is allowed
        if (_mazeMap[(_currX, _currY)][0])
        {
            // Decrease the X coordinate to move left
            _currX--;
        }
        else
        {
            // Throw an exception if a wall blocks the way
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    // Move right if there is no wall
    public void MoveRight()
    {
        // Check whether moving right is allowed
        if (_mazeMap[(_currX, _currY)][1])
        {
            // Increase the X coordinate to move right
            _currX++;
        }
        else
        {
            // Throw an exception if a wall blocks the way
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    // Move up if there is no wall
    public void MoveUp()
    {
        // Check whether moving up is allowed
        if (_mazeMap[(_currX, _currY)][2])
        {
            // Decrease the Y coordinate to move up
            _currY--;
        }
        else
        {
            // Throw an exception if a wall blocks the way
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    // Move down if there is no wall
    public void MoveDown()
    {
        // Check whether moving down is allowed
        if (_mazeMap[(_currX, _currY)][3])
        {
            // Increase the Y coordinate to move down
            _currY++;
        }
        else
        {
            // Throw an exception if a wall blocks the way
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    // Display the current maze coordinates
    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}
