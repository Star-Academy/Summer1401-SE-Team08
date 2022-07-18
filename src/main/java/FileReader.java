import java.io.File;
import java.util.HashMap;
import java.util.Scanner;

public final class FileReader {
    public static String readFile(File file) throws Exception{
        String contents = "";
        Scanner scanner = new Scanner(file);
        while(scanner.hasNextLine()){
            contents += scanner.nextLine();
        }
        scanner.close();
        return contents;
    }

    public static HashMap<String, String> readFolder(File folder) throws Exception{
        HashMap<String,String> docIdToContents = new HashMap<>();
        for(File file : folder.listFiles()){
            docIdToContents.put(file.getName(), readFile(file));
        }
        return docIdToContents;
    }
}