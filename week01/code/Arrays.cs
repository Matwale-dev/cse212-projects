
public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  
    /// Assume that length is a positive integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // --- PLAN ---
        // 1) Create a double[] of the specified length to hold the result.
        // 2) Fill the array so that:
        //    - The first element (index 0) is 'number' * 1
        //    - The second element (index 1) is 'number' * 2
        //    - ...
        //    - The i-th element is 'number' * (i + 1)
        // 3) Return the populated array.
        //
        // Notes:
        // - 'number' can be any double (including 0 or negative).
        // - 'length' is guaranteed > 0 per the problem statement.
        // - Using a simple for-loop is clear and efficient: O(length) time.

        // 1) Allocate the result array
        double[] result = new double[length];

        // 2) Populate with consecutive multiples of 'number'
        for (int i = 0; i < length; i++)
        {
            // (i + 1) because the first value should be 'number' * 1
            result[i] = number * (i + 1);
        }

        // 3) Return
        return result;
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
        // --- PLAN ---
        // Goal: Rotate the list to the RIGHT by 'amount' places, in place.
        // Example: [1,2,3,4,5,6,7,8,9], amount=3 -> [7,8,9,1,2,3,4,5,6]
        //
        // Approaches:
        // A) Slice & Rebuild:
        //    - tail = last 'amount' items
        //    - head = first 'count - amount' items
        //    - data = tail + head  (requires Clear + AddRange)
        // B) In-place reversal trick (no extra lists, O(n)):
        //    - Reverse entire list
        //    - Reverse first 'amount' items
        //    - Reverse remaining 'count - amount' items
        // We'll implement approach B for in-place efficiency.
        //
        // Steps:
        // 1) If amount == 0 or data.Count <= 1, nothing to do.
        // 2) Normalize amount: amount %= data.Count (helps if amount == data.Count, though constraints say 1..Count).
        // 3) Reverse the entire list.
        // 4) Reverse the first 'amount' elements.
        // 5) Reverse the remaining 'count - amount' elements.

        int n = data.Count;
        if (n <= 1 || amount == 0) return;

        amount %= n; // normalizes amount in case of full rotations

        // Helper local function to reverse a segment [start, end] inclusive
        void ReverseRange(int start, int end)
        {
            while (start < end)
            {
                int tmp = data[start];
                data[start] = data[end];
                data[end] = tmp;
                start++;
                end--;
            }
        }

        // 3) Reverse entire list
        ReverseRange(0, n - 1);

        // 4) Reverse first 'amount' elements
        ReverseRange(0, amount - 1);

        // 5) Reverse remaining 'n - amount' elements
        ReverseRange(amount, n - 1);
    }
}
