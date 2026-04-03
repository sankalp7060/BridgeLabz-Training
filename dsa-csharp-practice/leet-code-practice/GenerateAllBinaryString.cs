class GenerateAllBinaryString
{
    public List<string> binstr(int n)
    {
        List<string> result = new List<string>();
        Generate(result, "", n);
        return result;
    }

    public void Generate(List<string> l, string s, int n)
    {
        if (s.Length == n)
        {
            l.Add(s);
            return;
        }
        Generate(l, s + "0", n);
        Generate(l, s + "1", n);
    }
}
