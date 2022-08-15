namespace InvertedIndex.Abstraction;
public interface ITokenizer
{
    public List<string> Tokenize(string contents);
}