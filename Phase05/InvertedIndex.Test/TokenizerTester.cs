namespace InvertedIndex.Test;

public class TokenizerTester
{   
    [Theory]
    public void QueryTokenizerTest(string contents, List<string> expected)
    {
        ITokenizer tokenizer = new Tokenizer(TokenizerMode.Query);
        var actual = tokenizer.Tokenize(contents);
        //actual.Should().
    }



    [Theory]
    public void TextTokenizerTest(string contents, string expected) {
        ITokenizer tokenizer = new Tokenizer(TokenizerMode.Query);
        var actual = tokenizer.Tokenize(contents);
        Assert.equal(actual,expected);
    }

}