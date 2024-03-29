﻿using FluentAssertions;
using InvertedIndex.Abstraction;


namespace InvertedIndex.Test;

public class QueryHandlerTest
{
    private readonly Dictionary<string, List<string>> _docIdSet;

    public QueryHandlerTest()
    {
        _docIdSet = new Dictionary<string, List<string>>()
        {
            ["1"] = new List<string>() { "ARYA", "LOVED", "TO", "TAKE", "LONG", "WALKS", "IN", "THE", "PARK." },
            ["2"] = new List<string>() { "KHOSRO", "IS", "CHANGING", "ROOMS" },
            ["3"] = new List<string>() { "REZA", "LOVES", "MOCKING." },
            ["4"] = new List<string>() { "BOZORGMEHR", "PLEASE", "APPROVE", "THIS", "PULL", "REQUEST" },
            ["5"] = new List<string>() { "ONE", "LAST", "ONE", "FOR", "THE", "HOMEBOYS" }
        };
    }

    [Fact]
    public void HandleQueryTest_ShouldReturnCorrectIntersectionOfFiles_WhenGivenAQueryWithDifferentWordTypes()
    {
        // Arrange
        var engineMock = new Mock<ISearchEngine>();
        engineMock.Setup(x => x.DocIdToContents).Returns(_docIdSet);
        engineMock.Setup(x => x.SearchForWord("ARYA")).Returns(new HashSet<string>()
        {
            "1", "2", "3", "4"
        });
        engineMock.Setup(x => x.SearchForWord("KHOSRO")).Returns(new HashSet<string>()
        {
            "3"
        });
        engineMock.Setup(x => x.SearchForWord("ZIA")).Returns(new HashSet<string>()
        {
            "2", "40"
        });
        engineMock.Setup(x => x.SearchForWord("REZA")).Returns(new HashSet<string>()
        {
            "120"
        });
        var query = new Query();
        query.AndWords = new List<string>()
        {
            "ARYA"
        };
        query.NotWords = new List<string>()
        {
            "KHOSRO"
        };
        query.OrWords = new List<string>()
        {
            "ZIA",
            "REZA"
        };

        var handler = new QueryHandler(engineMock.Object);
        var expected = new HashSet<string>()
        {
            "2"
        };
        // Act
        var result = handler.HandleQuery(query);
        // Assert
        result.Should().Equal(expected);
    }
}