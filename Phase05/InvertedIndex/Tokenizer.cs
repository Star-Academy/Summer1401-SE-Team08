using System.Text.RegularExpressions;

namespace InvertedIndex;

public class Tokenizer : ITokenizer
{

    private TokenizerMode _mode;

    private const string QueryRegex = "[^+\\-\\w\\s]";
    private const string TextRegex = "[^\\w\\s]";


    public Tokenizer(TokenizerMode mode)
    {
        SetMode(mode);
    }

    public void SetMode(TokenizerMode mode)
    {
        this._mode = mode;
    }

    private string GetRegex()
    {
        return this._mode == TokenizerMode.Query ? QueryRegex : TextRegex;
    }
    
    
    public List<string> Tokenize(string contents)
    {
        contents = Regex.Replace(contents, GetRegex(), "").ToUpper();
        return new List<string>(Regex.Split(contents,"[\\s]+"));
    }
}