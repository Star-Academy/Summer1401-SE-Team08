import java.util.Scanner;
import java.io.File;
import java.util.HashSet;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.println("Enter your sentence to search!");
        String query = scanner.nextLine();
        scanner.close();
        InvertedIndex index = InvertedIndex.getInstance();
        try {
            index.addFolderToDatabase(new File(".\\EnglishData"));
        } catch (Exception e) {
            e.printStackTrace();
        }
        long startTime = System.nanoTime();
        QueryHandler handler = new QueryHandler(query, index);
        HashSet<String> out = handler.handleQuery();
        long endTime = System.nanoTime();
        System.out.println(out.toString());
        System.out.println((endTime-startTime)/1e9);
    }
}
