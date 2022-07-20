import java.util.Map;
import java.util.Set;
import java.util.List;
import java.util.HashMap;
import java.util.HashSet;

public class InvertedIndex {
    private HashMap<String, List<String>> docIdToContents;
    private HashMap<String, Set<String>> wordToDocId;

    public InvertedIndex() {
        docIdToContents = new HashMap<>();
        wordToDocId = new HashMap<>();
    }

    public HashMap<String, List<String>> getDocIdToContents() {
        return docIdToContents;
    }

    public HashMap<String, Set<String>> getWordToDocId() {
        return wordToDocId;
    }

    public void addToInvertedIndex(HashMap<String,List<String>> newDocs){
        docIdToContents.putAll(newDocs);
        for(Map.Entry<String,List<String>> entry : newDocs.entrySet()){
            addToWordToDocID(entry.getKey(), entry.getValue());
        }
    }

    private void addToWordToDocID(String docId, List<String> words){
        for (String word : words) {
            if(!wordToDocId.containsKey(word)){ 
                wordToDocId.put(word, new HashSet<String>());
            } 
            wordToDocId.get(word).add(docId);
        }
    }

    public Set<String> search(String word) {
        return wordToDocId.get(word) != null ? wordToDocId.get(word) : new HashSet<>();
    }
}