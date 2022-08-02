using FluentAssertions;
using InvertedIndex.Abstraction;

namespace InvertedIndex.Test;

public class InvertedIndexTest
{
    private Index Index;

    [Fact]
    public void HandleQuery_Should_ProduceResult()
    {
        var builder = new Mock<IQueryBuilder>();
        builder.Setup(x => x.BuildQuery(new List<string>()
        {
            "ARYA",
            "KHOSRO"
        })).Returns(new Query());
        var tokenizer = new Mock<ITokenizer>();
        tokenizer.Setup(x => x.Tokenize("test")).Returns(new List<string>()
        {
            "ARYA",
            "KHOSRO"
        });
        var handler = new Mock<IHandler>();
        handler.Setup(x => x.HandleQuery(new Query())).Returns(new HashSet<string>()
        {
            "12", "13", "15"
        });

        Index = new Index(null);
        Index.QueryBuilder = builder.Object;
        Index.Tokenizer = tokenizer.Object;
        Index.QueryHandler = handler.Object;

        var actual = Index.HandleQuery("test");
        var expected = new HashSet<string>()
        {
            "12", "13", "15"
        };
        actual.Should().Equal(expected);
    }
}