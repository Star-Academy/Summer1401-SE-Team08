import java.util.ArrayList;
import java.util.HashSet;

public class QueryHandler {
    private String query;
    private InvertedIndex index;
    private ArrayList<String> andWords;
    private ArrayList<String> orWords;
    private ArrayList<String> notWords;

    public QueryHandler(String query, InvertedIndex index){
        this.query = query;
        this.index = index;
        setLists();
    }

    public void setQuery(String query) {
        this.query = query;
        setLists();
    }

    public void setIndex(InvertedIndex index) {
        this.index = index;
    }

    public void setLists(){
        andWords = new ArrayList<>();
        orWords = new ArrayList<>();
        notWords = new ArrayList<>();
        String[] tokens = Tokenizer.tokenize(query, TokenizerMode.QUERY);
        for(String token : tokens){
            if(token.startsWith("+"))
                orWords.add(token.replaceAll("\\+", ""));
            else if(token.startsWith("-"))
                notWords.add(token.replaceAll("\\-", ""));
            else
                andWords.add(token);
        }
    }

    public HashSet<String> handleQuery(){
        HashSet<String> answer = new HashSet<>();
        answer.addAll(index.getDocIdToContents().keySet());
        answer = handleAndWrods(answer);
        if(!orWords.isEmpty())
            answer = handleOrWords(answer);
        answer = handleNotWords(answer);
        return answer;
    }

    public HashSet<String> handleAndWrods(HashSet<String> set){
        for(String andWord : andWords){
            set.retainAll(index.search(andWord));
        }
        return set;
    }

    public HashSet<String> handleOrWords(HashSet<String> set){
        HashSet<String> temp = new HashSet<>();
        for(String orWord : orWords){
            temp.addAll(index.search(orWord));
        }
        set.retainAll(temp);
        return set;
    }

    public HashSet<String> handleNotWords(HashSet<String> set){
        for(String notWord : notWords){
            set.removeAll(index.search(notWord));
        }
        return set;
    }
}