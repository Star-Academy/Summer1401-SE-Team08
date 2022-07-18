import opennlp.tools.stemmer.PorterStemmer;

import java.io.File;
import java.util.Map;
import java.util.HashMap;
import java.util.HashSet;

public class InvertedIndex {
    private static InvertedIndex instance;
    private final PorterStemmer porterStemmer;
    private HashMap<String, String> docIdToContents;
    private HashMap<String, HashSet<String>> wordToDocId;

    public InvertedIndex() {
        porterStemmer = new PorterStemmer();
        docIdToContents = new HashMap<>();
        wordToDocId = new HashMap<>();
    }

    public static InvertedIndex getInstance() {
        if (instance == null)
            instance = new InvertedIndex();
        return instance;
    }

    public HashMap<String, String> getDocIdToContents() {
        return docIdToContents;
    }

    public HashMap<String, HashSet<String>> getWordToDocId() {
        return wordToDocId;
    }

    public void addFileToDatabase(File file) throws Exception{
        String docId = file.getName();
        String contents = FileReader.readFile(file);
        docIdToContents.put(docId, contents);
        updateWordToDocID(docId, Tokenizer.tokenize(contents, TokenizerMode.TEXT));
    }

    public void addFolderToDatabase(File folder) throws Exception{
        HashMap<String, String> map = FileReader.readFolder(folder);
        docIdToContents.putAll(map);
        for(Map.Entry<String,String> entry : map.entrySet()){
            updateWordToDocID(entry.getKey(), Tokenizer.tokenize(entry.getValue(), TokenizerMode.TEXT));
        }
    }

    private void updateWordToDocID(String docID, String[] tokens){
        for (final String token : tokens) {
            String word = porterStemmer.stem(token);
            if(!wordToDocId.containsKey(word)){
                HashSet<String> docIds = new HashSet<>();
                wordToDocId.put(word, docIds);
            } 
            wordToDocId.get(word).add(docID);
        }
    }

    public HashSet<String> search(String word) {
        return wordToDocId.get(word) != null ? wordToDocId.get(word) : new HashSet<>();
    }
}