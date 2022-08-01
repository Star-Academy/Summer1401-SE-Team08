using System.Text.RegularExpressions;
using InvertedIndex.Abstraction;
using InvertedIndex.Enums;

namespace InvertedIndex;

public class Tokenizer : ITokenizer
{

    private readonly TokenizerMode _mode;

    private const string QueryRegex = "[^+\\-\\w\\s]";
    private const string TextRegex = "[^\\w\\s]";


    public Tokenizer(TokenizerMode mode)
    {
        _mode = mode;
    }

    private string GetRegex()
    {
        return _mode == TokenizerMode.Query ? QueryRegex : TextRegex;
    }
    
    
    public List<string> Tokenize(string contents)
    {
        contents = Regex.Replace(contents, GetRegex(), "").ToUpper().Trim();
        return new List<string>(Regex.Split(contents,"[\\s]+"));
    }
}