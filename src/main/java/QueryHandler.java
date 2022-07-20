import java.util.List;
import java.util.HashSet;

public class QueryHandler {
    private InvertedIndex index;

    public QueryHandler(InvertedIndex index){
        this.index = index;
    }

    public void setIndex(InvertedIndex index) {
        this.index = index;
    }

    public HashSet<String> handleQuery(Query query){
        HashSet<String> universalSet = new HashSet<>(index.getDocIdToContents().keySet());
        HashSet<String> answer = getIntersectionSet(query.getAndWords(), universalSet);
        if(!query.getOrWords().isEmpty()){
            answer.retainAll(getUnionSet(query.getOrWords()));
        }
        answer.removeAll(getUnionSet(query.getNotWords()));
        return answer;
    }

    private HashSet<String> getUnionSet(List<String> words){
        HashSet<String> set = new HashSet<>();
        for(String word : words){
            set.addAll(index.search(word));
        }
        return set;
    }

    private HashSet<String> getIntersectionSet(List<String> words, HashSet<String> universalSet){
        HashSet<String> set = new HashSet<>(universalSet);
        for(String word : words){
            set.retainAll(index.search(word));
        }
        return set;
    }
}