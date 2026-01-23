/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.  
///
/// If there is a wall, then throw an InvalidOperationException with the message "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    // TODO Problem 4 - ADD YOUR CODE HERE
    /// <summary>
    /// Check to see if you can move left.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveLeft()
    {
        // FILL IN CODE
         // Check if current position exists in maze map
        if (!_mazeMap.TryGetValue((_currX, _currY), out bool[] directions))
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        // directions array: [left, right, up, down]
        // Check if we can move left (index 0)
        if (directions[0])
        {
            _currX--; // Move left decreases x coordinate
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Check to see if you can move right.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveRight()
    {
        // FILL IN CODE
         if (!_mazeMap.TryGetValue((_currX, _currY), out bool[] directions))
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        // Check if we can move right (index 1)
        if (directions[1])
        {
            _currX++; // Move right increases x coordinate
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Check to see if you can move up.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveUp()
    {
        // FILL IN CODE
         if (!_mazeMap.TryGetValue((_currX, _currY), out bool[] directions))
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        // Check if we can move up (index 2)
        if (directions[2])
        {
            _currY--; // Move up decreases y coordinate
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Check to see if you can move down.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveDown()
    {
        // FILL IN CODE
         if (!_mazeMap.TryGetValue((_currX, _currY), out bool[] directions))
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        // Check if we can move down (index 3)
        if (directions[3])
        {
            _currY++; // Move down increases y coordinate
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}