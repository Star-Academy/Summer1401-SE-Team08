import opennlp.tools.stemmer.PorterStemmer;

import java.util.HashMap;
import java.util.TreeSet;

public class InvertedIndex {

    private static InvertedIndex instance;
    private final PorterStemmer porterStemmer;
    private final FileReader fileReader;
    private final HashMap<String, TreeSet<String>> database;

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
            String[] tokens = tokenize(docs.get(doc));
            addToDatabase(doc, tokens);
        }
        System.out.println();
    }

    public String[] tokenize(String contents){
        contents = contents.replaceAll("[^\\w\\s]", " ");
        contents = contents.toUpperCase();
        return contents.split("[\\s]+");
    }

    private void addToDatabase(final String docName, final String[] tokens) {
        for (final String word : tokens) {
            String stemWord = porterStemmer.stem(word);
            if (database.containsKey(stemWord)) {
                database.get(stemWord).add(docName);
            } else {
                TreeSet<String> docs = new TreeSet<>();
                docs.add(docName);
                database.put(stemWord, docs);
            }
        }
    }


    public TreeSet<String> query(String word) {
        return database.get(word) != null ? database.get(word) : new TreeSet<>();
    }


}
