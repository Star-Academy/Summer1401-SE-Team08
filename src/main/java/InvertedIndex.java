import java.util.Map;
import java.util.Set;
import java.util.List;
import java.util.HashMap;
import java.util.HashSet;

public class InvertedIndex {
    private final HashMap<String, List<String>> docIdToContents;
    private final HashMap<String, Set<String>> wordToDocId;

    public InvertedIndex() {
        docIdToContents = new HashMap<>();
        wordToDocId = new HashMap<>();
    }

    public HashMap<String, List<String>> getDocIdToContents() {
        return docIdToContents;
    }


    public void addToInvertedIndex(HashMap<String, List<String>> newDocs) {
        docIdToContents.putAll(newDocs);
        for (Map.Entry<String, List<String>> entry : newDocs.entrySet()) {
            addToWordToDocID(entry.getKey(), entry.getValue());
        }
    }

    private void addToWordToDocID(String docId, List<String> words) {
        for (String word : words) {
            if (!wordToDocId.containsKey(word)) {
                wordToDocId.put(word, new HashSet<>());
            }
            wordToDocId.get(word).add(docId);
        }
    }

    public Set<String> search(String word) {
        // Create a blank set for a new encountered word, and adding the document to the set otherwise.
        return wordToDocId.get(word) != null ? wordToDocId.get(word) : new HashSet<>();
    }
}