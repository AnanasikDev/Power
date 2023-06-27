using System.Collections;
using System.Collections.Generic;

public static class Utils
{
    public static List<int> Spread(int n, int count)
    {
        if (count == 0) return new List<int>();

        List<int> output = new List<int>();
        for (int i = 0; i < count; i++)
        {
            output.Add(n / count);
        }

        int remainder = n % count;
        for (int i = 0; i < remainder; i++)
        {
            output[i]++;
        }

        return output;
    }
}
