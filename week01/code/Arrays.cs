
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.
    /// </summary>
    public static double[] MultiplesOf(double number, int length)
    {
        // Plan:
        // 1. Create a new double array with the specified length.
        // 2. Use a for loop to visit every index in the array, starting at index 0.
        // 3. Multiply the starting number by the index plus one to calculate each multiple.
        // 4. Store each calculated multiple at the current index.
        // 5. Continue until all positions in the array have been filled.
        // 6. Return the completed array.

        double[] multiples = new double[length];

        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }

        return multiples;
    }

    /// <summary>
    /// Rotate the data to the right by the specified amount.
    /// The function modifies the existing list instead of returning a new list.
    /// </summary>
  
public static void RotateListRight(List<int> data, int amount)
{
    // Plan:
    // 1. Calculate the index where the last 'amount' elements begin.
    // 2. Create a new list containing the last 'amount' elements.
    // 3. Create another list containing the elements before those last elements.
    // 4. Clear the original list.
    // 5. Add the last elements to the original list first.
    // 6. Add the remaining elements after the last elements.
    // 7. The original list is now rotated to the right.

    int splitIndex = data.Count - amount;

    List<int> lastElements = data.GetRange(splitIndex, amount);
    List<int> firstElements = data.GetRange(0, splitIndex);

    data.Clear();

    data.AddRange(lastElements);
    data.AddRange(firstElements);
}

}
