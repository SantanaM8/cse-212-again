using System;
using System.Collections.Generic;

public static class Recursion
{
    /// <summary>
    /// Problem 1: Return 1^2 + 2^2 + ... + n^2 using recursion.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0)
            return 0;

        return (n * n) + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// Problem 2: Add all permutations of the requested size to results.
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        for (int i = 0; i < letters.Length; i++)
        {
            string nextWord = word + letters[i];
            string remainingLetters = letters.Remove(i, 1);

            PermutationsChoose(results, remainingLetters, size, nextWord);
        }
    }

    /// <summary>
    /// Problem 3: Count ways to climb s stairs using 1, 2, or 3 steps.
    /// Memoization prevents repeated recursive calculations.
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        remember ??= new Dictionary<int, decimal>();

        if (s == 0)
            return 0;
        if (s == 1)
            return 1;
        if (s == 2)
            return 2;
        if (s == 3)
            return 4;

        if (remember.TryGetValue(s, out decimal remembered))
            return remembered;

        decimal ways =
            CountWaysToClimb(s - 1, remember) +
            CountWaysToClimb(s - 2, remember) +
            CountWaysToClimb(s - 3, remember);

        remember[s] = ways;
        return ways;
    }

    /// <summary>
    /// Problem 4: Add every binary string represented by the wildcard pattern.
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        WildcardBinaryHelper(pattern, "", results);
    }

    private static void WildcardBinaryHelper(
        string pattern,
        string current,
        List<string> results)
    {
        if (pattern.Length == 0)
        {
            results.Add(current);
            return;
        }

        if (pattern[0] == '*')
        {
            WildcardBinaryHelper(pattern.Substring(1), current + "0", results);
            WildcardBinaryHelper(pattern.Substring(1), current + "1", results);
        }
        else
        {
            WildcardBinaryHelper(
                pattern.Substring(1),
                current + pattern[0],
                results);
        }
    }

    /// <summary>
    /// Problem 5: Find every path from (0,0) to the end of the maze.
    /// </summary>
    public static void SolveMaze(
        List<string> results,
        Maze maze,
        int x = 0,
        int y = 0,
        List<(int, int)>? currPath = null)
    {
        currPath ??= new List<(int, int)>();
        currPath.Add((x, y));

        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
            return;
        }

        int[] dx = { 0, 0, -1, 1 };
        int[] dy = { -1, 1, 0, 0 };

        for (int i = 0; i < 4; i++)
        {
            int newX = x + dx[i];
            int newY = y + dy[i];

            if (maze.IsValidMove(currPath, newX, newY))
            {
                SolveMaze(
                    results,
                    maze,
                    newX,
                    newY,
                    new List<(int, int)>(currPath));
            }
        }
    }
}
