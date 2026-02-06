public class StringTransformer : IStringTransformer
{
    public string CleanseAndInvert(string input)
    {
        // Rule 1: null or length less than 6
        if (string.IsNullOrEmpty(input) || input.Length < 6)
            return string.Empty;

        // Rule 2: must contain only alphabets
        foreach (char ch in input)
        {
            if (!char.IsLetter(ch))
                return string.Empty;
        }

        // Convert to lowercase
        input = input.ToLower();

        // Remove characters with even ASCII values
        string filtered = "";
        foreach (char ch in input)
        {
            if ((int)ch % 2 != 0)
            {
                filtered += ch;
            }
        }

        // Reverse the remaining characters
        char[] reversedArray = filtered.ToCharArray();
        Array.Reverse(reversedArray);

        // Convert even-positioned characters to uppercase
        for (int i = 0; i < reversedArray.Length; i++)
        {
            if (i % 2 == 0)
            {
                reversedArray[i] = char.ToUpper(reversedArray[i]);
            }
        }

        return new string(reversedArray);
    }
}
