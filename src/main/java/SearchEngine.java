import opennlp.tools.stemmer.PorterStemmer;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

public class SearchEngine {

    private static SearchEngine instance;
    private final PorterStemmer porterStemmer;
    private final FileReader fileReader;
    private final HashMap<String, Word> database;

    public SearchEngine() {
        porterStemmer = new PorterStemmer();
        fileReader = FileReader.getInstance();
        database = new HashMap<>();
    }

    public static SearchEngine getInstance() {
        if (instance == null)
            instance = new SearchEngine();
        return instance;

    }


    public void initialize() {
        HashMap<String, String> docs = fileReader.getDocs();
        for (String doc : docs.keySet()) {
            addToDatabase(doc, docs.get(doc));
        }
        System.out.println();
    }

    private void addToDatabase(final String docName, final String content) {
        String[] split = content.split("[\\W]+");
        for (final String word : split) {
            String stemWord = porterStemmer.stem(word);
            if (database.containsKey(stemWord)) {
                Word currentWord = database.get(stemWord);
                if (!currentWord.hasParentDoc(docName)) {
                    currentWord.addDoc(docName);
                }
            } else {
                Word newWord = new Word(word);
                newWord.addDoc(docName);
                database.put(stemWord, newWord);
            }
        }
    }


    public Word query(String word) {
        return database.get(word) != null ? database.get(word) : new Word("empty");
    }


}
