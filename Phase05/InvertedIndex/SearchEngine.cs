﻿using InvertedIndex.Abstraction;


namespace InvertedIndex;

public class SearchEngine : ISearchEngine
{

    public Dictionary<string, List<string>> DocIdToContents { get; set; }
    private readonly Dictionary<string, HashSet<string>> _wordToDocId ;


    public SearchEngine()
    {
        DocIdToContents = new Dictionary<string, List<string>>();
        _wordToDocId = new Dictionary<string, HashSet<string>>();
    }

    public void AddToSearchEngine(Dictionary<string, List<string>> newDocs)
    {
        DocIdToContents = DocIdToContents.Union(newDocs).ToDictionary
            (s => s.Key, s => s.Value);

        foreach (var doc in newDocs)
        {
            AddToWordToDocId(doc.Key,doc.Value);
        }
    }

    private void AddToWordToDocId(string docId, List<string> words)
    {
        foreach(var word in words)
        {
            if (!_wordToDocId.ContainsKey(word))
            {
                _wordToDocId.Add(word, new HashSet<string>());
            }

            _wordToDocId[word].Add(docId);
        }
    }

    public HashSet<string> SearchForWord(string word)
    {
        return _wordToDocId.ContainsKey(word) ? _wordToDocId[word] : new HashSet<string>();
    }
    
}