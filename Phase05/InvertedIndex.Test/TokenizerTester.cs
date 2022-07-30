using InvertedIndex;

namespace InvertedIndex.Test;

public class TokenizerTester
{   
    [Fact]
    public void QueryTokenizerTest()
    {
        IEnumerable<string> expected = new List<string>()
        {
            "HELLO",
            "MONO",
            "WO123123RLD"
        };
        ITokenizer tokenizer = new Tokenizer(TokenizerMode.Query);
        IEnumerable<string> actual = tokenizer.Tokenize("Hello Mono Wo123123rld%%%");
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TextTokenizerTest() {
        IEnumerable<string> expected = new List<string>()
        {
            "HELLO",
            "MONO",
            "WO123123RLD"
        };
        ITokenizer tokenizer = new Tokenizer(TokenizerMode.Text);
        IEnumerable<string> actual = tokenizer.Tokenize("+Hello -Mono Wo123123rld%%%");
        Assert.Equal(expected, actual);
    }

}