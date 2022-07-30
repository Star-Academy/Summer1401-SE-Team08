namespace InvertedIndex;

public interface IHandler
{
    public HashSet<string> HandleQuery(Query query);
}