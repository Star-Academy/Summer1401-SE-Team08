import opennlp.tools.stemmer.PorterStemmer;

import java.util.HashMap;

public class InvertedIndex {

    private static InvertedIndex instance;
    private final PorterStemmer porterStemmer;
    private final FileReader fileReader;
    private final HashMap<String, Word> database;

    public InvertedIndex() {
        porterStemmer = new PorterStemmer();
        fileReader = FileReader.getInstance();
        database = new HashMap<>();
    }

    public static InvertedIndex getInstance() {
        if (instance == null)
            instance = new InvertedIndex();
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
