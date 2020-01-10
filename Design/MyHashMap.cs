using System.Collections.Generic;

public class MyHashMap
{
    private const int MaxCapacity = 1_000_000;
    private const int SplitValue = 10_000;

    // so, what are doing here- init a
    private readonly List<int>[] b;
    private readonly List<int>[] k;

    private readonly int splitSize;
    private int zeroVal = -1;

    /**
     * Initialize your data structure here.
     */
    public MyHashMap()
    {
        splitSize = MaxCapacity / SplitValue;
        b = new List<int>[splitSize];
        k = new List<int>[splitSize];
    }

    /**
     * value will always be non-negative.
     */
    public void Put(int key, int value)
    {
        if (key == 0)
        {
            zeroVal = value;
            return;
        }

        int index = key / 10_000;
        List<int> container = b[index];
        List<int> vContainer = k[index];
        if (container == null)
        {
            container = b[index] = new List<int>();
            vContainer = k[index] = new List<int>();
        }

        if (container.Contains(key))
        {
            vContainer[container.IndexOf(key)] = value;
        }
        else
        {
            container.Add(key);
            vContainer.Add(value);
        }
    }

    /**
     * Returns the value to which the specified key is mapped, or -1 if this map contains no mapping for the key
     */
    public int Get(int key)
    {
        if (key == 0) return zeroVal;

        int index = key / 10_000;
        List<int> container = b[index];
        List<int> vContainer = k[index];

        if (container != null && container.Contains(key)) return vContainer[container.IndexOf(key)];

        return -1;
    }

    /**
     * Removes the mapping of the specified value key if this map contains a mapping for the key
     */
    public void Remove(int key)
    {
        if (key == 0)
        {
            zeroVal = -1;
            return;
        }

        int index = key / 10_000;
        List<int> container = b[index];
        List<int> vContainer = k[index];

        if (container != null && container.Contains(key))
        {
            int keyDex = container.IndexOf(key);
            vContainer.RemoveAt(keyDex);
            container.RemoveAt(keyDex);
        }
    }
}