public class Combinations
{
    public IList<IList<int>> Combine(int n, int k)
    {
        IList<IList<int>> l = new List<IList<int>>();
        IList<int> l1 = new List<int>();
        Generate(l, l1, n, k, 1);
        return l;
    }

    public void Generate(IList<IList<int>> l, IList<int> l1, int n, int k, int index)
    {
        if (l1.Count() == k)
        {
            l.Add(new List<int>(l1));
            return;
        }
        for (int i = index; i <= n; i++)
        {
            l1.Add(i);
            Generate(l, l1, n, k, i + 1);
            l1.RemoveAt(l1.Count() - 1);
        }
    }
}
