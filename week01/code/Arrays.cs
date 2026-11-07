public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Plan:
        // 1. Create an array with the requested number of entries.
        // 2. For each index, multiply the starting number by the index plus one.
        // 3. Store each product in the array, then return the completed array.
        double[] multiples = new double[length];
        for (int index = 0; index < length; index++)
        {
            multiples[index] = number * (index + 1);
        }

        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Plan:
        // 1. Find where the last 'amount' values begin: data.Count - amount.
        // 2. Copy those ending values and the values before them into separate lists.
        // 3. Clear the original list, then append the ending values followed by the earlier values.
        // This moves the ending section to the front while keeping the original list instance.
        int splitIndex = data.Count - amount;
        List<int> endingValues = data.GetRange(splitIndex, amount);
        List<int> earlierValues = data.GetRange(0, splitIndex);

        data.Clear();
        data.AddRange(endingValues);
        data.AddRange(earlierValues);
    }
}
