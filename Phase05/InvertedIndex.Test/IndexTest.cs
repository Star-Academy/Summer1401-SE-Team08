using FluentAssertions;
using InvertedIndex.Abstraction;

namespace InvertedIndex.Test;

public class InvertedIndexTest
{
    private Index Index;

    [Fact]
    public void HandleQueryTest_ShouldReturnRelatedDocuments_WhenANewQueryComes()
    {
        // Arrange
        var builderMock = new Mock<IQueryBuilder>();
        builderMock.Setup(x => x.BuildQuery(new List<string>()
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
        var handlerMock = new Mock<IHandler>();
        handlerMock.Setup(x => x.HandleQuery(new Query())).Returns(new HashSet<string>()
        {
            "12", "13", "15"
        });

        Index = new Index(null);
        Index.QueryBuilder = builderMock.Object;
        Index.Tokenizer = tokenizer.Object;
        Index.QueryHandler = handlerMock.Object;
        var expected = new HashSet<string>()
        {
            "12", "13", "15"
        };
        // Act
        var actual = Index.HandleQuery("test");
        // Assert
        actual.Should().Equal(expected);
    }
}