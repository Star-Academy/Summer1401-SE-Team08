
import java.util.ArrayList;
import java.util.List;
import java.util.PriorityQueue;

public class Word {

    private String text;
    private List<String> containingDocs;
    private int frequency;

    public Word(String text) {
        this.text = text;
        this.containingDocs = new ArrayList<>();
        this.frequency = 0;
    }


    public void increaseCount() {
        this.frequency ++;
    }

    public boolean hasParentDoc(String word) {
        return this.containingDocs.contains(word);
    }

    public void addDoc(String docName) {
        this.containingDocs.add(docName);
    }


    @Override
    public String toString() {
        return this.containingDocs.toString();
    }
}
