namespace InvertedIndex.Abstraction;

public interface IHandler
{
    public HashSet<string> HandleQuery(Query query);
}