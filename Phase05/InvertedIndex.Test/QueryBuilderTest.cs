using System.Globalization;
using FluentAssertions;
using InvertedIndex.Abstraction;

namespace InvertedIndex.Test;

public class QueryBuilderTest
{
    private readonly IQueryBuilder _queryBuilder;
    private readonly List<string> _query = new List<string>()
    {
        "+FOOD",
        "-EPFL",
        "NUMERICAL",
        "++CALCULATIONS",
        "MACHINE",
        "-LEARNING"
    };

    public QueryBuilderTest()
    {
        _queryBuilder = new QueryBuilder();
    }


    [Fact]
    public void AndWords_Should_Be_Empty()
    {
        // Arrange
        var expected = new List<string>()
        {
            "NUMERICAL",
            "MACHINE"
        };
        // Act
        var query = _queryBuilder.BuildQuery(_query);
        // Assert
        query.AndWords.Should().Equal(expected);
    }


    [Fact]
    public void OrWords_Should_Contain_Plus()
    {
        // Arrange
        var expected = new List<string>()
        {
            "FOOD",
            "+CALCULATIONS"
        };
        // Act
        var query = _queryBuilder.BuildQuery(_query);
        //Assert
        query.OrWords.Should().Equal(expected);
    }

    [Fact]
    public void NotWords_Should_Contain_Minus()
    {
        // Arrange
        var expected = new List<string>()
        {
            "EPFL",
            "LEARNING"
        };
        // Act
        var query = _queryBuilder.BuildQuery(_query);
        // Assert
        query.NotWords.Should().Equal(expected);
    }
}