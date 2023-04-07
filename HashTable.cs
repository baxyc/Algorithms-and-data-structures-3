public class HashTable<TKey, TValue>
{
    private readonly int size;
    private readonly LinkedList<(TKey key, TValue value)>[] data;

    public HashTable(int size)
    {
        this.size = size;
        this.data = new LinkedList<(TKey, TValue)>[size];
    }

    private int GetHash(TKey key)
    {
        int hashCode = key.GetHashCode();
        return hashCode % size;
    }

    public void Add(TKey key, TValue value)
    {
        int index = GetHash(key);
        if (data[index] == null)
        {
            data[index] = new LinkedList<(TKey, TValue)>();
        }

        var entries = data[index];
        foreach (var entry in entries)
        {
            if (entry.key.Equals(key))
            {
                throw new ArgumentException("An item with the same key has already been added.");
            }
        }

        entries.AddLast((key, value));
    }

    public TValue Get(TKey key)
    {
        int index = GetHash(key);
        if (data[index] == null)
        {
            throw new KeyNotFoundException();
        }

        var entries = data[index];
        foreach (var entry in entries)
        {
            if (entry.key.Equals(key))
            {
                return entry.value;
            }
        }

        throw new KeyNotFoundException();
    }
}
