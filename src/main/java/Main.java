import opennlp.tools.stemmer.PorterStemmer;

import java.io.FileNotFoundException;
import java.nio.file.NoSuchFileException;
import java.util.Arrays;
import java.util.Scanner;

public class Main {

    public static String text = "Marie was born in Paris.";

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        SearchEngine sE = SearchEngine.getInstance();
        FileReader fR = FileReader.getInstance();
        PorterStemmer porterStemmer = new PorterStemmer();
        try {
            fR.scanDocs();
            sE.initialize();
        } catch (FileNotFoundException e) {
            System.out.println(Arrays.toString(e.getStackTrace()));
        }

        System.out.println("Enter your sentence to search!");
        String search = scanner.nextLine().toLowerCase();
        String[] split = search.split("\\s");

        for(final String word : split) {
            System.out.println(sE.query(porterStemmer.stem(word)).toString());
        }
    }
}
