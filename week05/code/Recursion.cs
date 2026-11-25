
using System.Collections;

public static class Recursion
{
    /// <summary>
    /// Problem 1: Recursive Squares Sum
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        // Base case
        if (n <= 0)
            return 0;

        // Recursive calculation
        return (n * n) + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// Problem 2: Permutations Choose
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // Base case
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        // Try each letter
        foreach (char letter in letters)
        {
            if (!word.Contains(letter))
            {
                PermutationsChoose(
                    results,
                    letters,
                    size,
                    word + letter
                );
            }
        }
    }

    /// <summary>
    /// Problem 3: Climbing Stairs
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        // Base cases
        if (s == 0)
            return 0;

        if (s == 1)
            return 1;

        if (s == 2)
            return 2;

        if (s == 3)
            return 4;

        // Initialize dictionary
        if (remember == null)
        {
            remember = new Dictionary<int, decimal>();
        }

        // Check if answer is already remembered
        if (remember.ContainsKey(s))
        {
            return remember[s];
        }

        // Recursive calculation using memoization
        decimal ways =
            CountWaysToClimb(s - 1, remember) +
            CountWaysToClimb(s - 2, remember) +
            CountWaysToClimb(s - 3, remember);

        // Store calculated result
        remember[s] = ways;

        return ways;
    }

    /// <summary>
    /// Problem 4: Wildcard Binary Patterns
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        // Find the first wildcard
        int index = pattern.IndexOf('*');

        // Base case: No wildcards remain
        if (index == -1)
        {
            results.Add(pattern);
            return;
        }

        // Replace wildcard with 0
        string zeroPattern =
            pattern[..index] + "0" + pattern[(index + 1)..];

        WildcardBinary(zeroPattern, results);

        // Replace wildcard with 1
        string onePattern =
            pattern[..index] + "1" + pattern[(index + 1)..];

        WildcardBinary(onePattern, results);
    }

    /// <summary>
    /// Problem 5: Maze
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        // Initialize current path
        if (currPath == null)
        {
            currPath = new List<ValueTuple<int, int>>();
        }

        // Add current position
        currPath.Add((x, y));

        // Check if we reached the end
        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());

            // Backtrack
            currPath.RemoveAt(currPath.Count - 1);
            return;
        }

        // Explore right
        if (maze.IsValidMove(currPath, x + 1, y))
        {
            SolveMaze(results, maze, x + 1, y, currPath);
        }

        // Explore down
        if (maze.IsValidMove(currPath, x, y + 1))
        {
            SolveMaze(results, maze, x, y + 1, currPath);
        }

        // Explore left
        if (maze.IsValidMove(currPath, x - 1, y))
        {
            SolveMaze(results, maze, x - 1, y, currPath);
        }

        // Explore up
        if (maze.IsValidMove(currPath, x, y - 1))
        {
            SolveMaze(results, maze, x, y - 1, currPath);
        }

        // Backtrack: remove current position
        currPath.RemoveAt(currPath.Count - 1);
    }
}
