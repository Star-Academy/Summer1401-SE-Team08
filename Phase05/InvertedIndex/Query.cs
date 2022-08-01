using InvertedIndex.Enums;

namespace InvertedIndex;

public struct Query
{
    public List<string> AndWords { get; set; }
    public List<string> OrWords { get; set; }
    public List<string> NotWords { get; set; }
}