import java.io.File;
import java.util.Objects;
import java.util.Scanner;
import java.util.HashMap;

public final class FileReader {
    public static String readFile(File file) throws Exception {
        StringBuilder contents = new StringBuilder();
        Scanner scanner = new Scanner(file);
        while (scanner.hasNextLine()) {
            contents.append(scanner.nextLine());
        }
        scanner.close();
        return contents.toString();
    }

    public static HashMap<String, String> readFolder(File folder) throws Exception {
        HashMap<String, String> docIdToContents = new HashMap<>();
        for (File file : Objects.requireNonNull(folder.listFiles())) {
            docIdToContents.put(file.getName(), readFile(file));
        }
        return docIdToContents;
    }
}