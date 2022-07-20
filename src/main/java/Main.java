import java.util.Scanner;
import java.io.File;
import java.util.HashMap;
import java.util.HashSet;
import java.util.List;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.println("Enter your sentence to search!");
        String query = scanner.nextLine();
        scanner.close();
        InvertedIndex index = new InvertedIndex();
        Tokenizer textTokenizer = new Tokenizer(TokenizerMode.TEXT);
        try {
            HashMap<String, String> docs = FileReader.readFolder(new File(".\\EnglishData"));
            HashMap<String, List<String>> tokenizedDocs = new HashMap<>();
            for (String key : docs.keySet()){
                tokenizedDocs.put(key, Stemmer.instance.stemList(textTokenizer.tokenize(docs.get(key))));
            }
            index.addToInvertedIndex(tokenizedDocs);
        } catch (Exception e) {
            e.printStackTrace();
        }
        QueryHandler handler = new QueryHandler(index);
        Tokenizer queryTokenizer = new Tokenizer(TokenizerMode.QUERY);
        long startTime = System.nanoTime();
        HashSet<String> out = handler.handleQuery(new Query(queryTokenizer.tokenize(query)));
        long endTime = System.nanoTime();
        System.out.println(out.toString());
        System.out.println((endTime-startTime)/1e9);
    }
}