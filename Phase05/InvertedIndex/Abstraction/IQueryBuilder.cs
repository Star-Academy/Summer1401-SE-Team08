namespace InvertedIndex.Abstraction;

public interface IQueryBuilder
{
    public Query BuildQuery(List<string> query);
}