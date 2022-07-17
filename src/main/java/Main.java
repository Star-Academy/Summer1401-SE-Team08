import opennlp.tools.stemmer.PorterStemmer;

import java.io.FileNotFoundException;
import java.util.Arrays;
import java.util.Scanner;
import java.util.TreeSet;

public class Main {

    public static String text = "Marie was born in Paris.";

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        InvertedIndex sE = InvertedIndex.getInstance();
        FileReader fR = FileReader.getInstance();
        PorterStemmer porterStemmer = new PorterStemmer();
        try {
            fR.scanDocs();
            sE.initialize();
        } catch (FileNotFoundException e) {
            System.out.println(Arrays.toString(e.getStackTrace()));
        }

        System.out.println("Enter your sentence to search!");
        String search = scanner.nextLine();
        // String[] split = search.split("\\s+");
        QueryHandler q = new QueryHandler(search);
        TreeSet<String> out = q.handleQuery(sE);
        System.out.println(out.toString());
        // for(final String word : split) {
        //     System.out.println(sE.query(porterStemmer.stem(word)).toString());
        // }
    }
}
