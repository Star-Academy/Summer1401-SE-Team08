import java.util.ArrayList;
import java.util.TreeSet;

public class QueryHandler {
    private ArrayList<String> andWords;
    private ArrayList<String> orWords;
    private ArrayList<String> notWords;

    public QueryHandler(String query){
        andWords = new ArrayList<>();
        orWords = new ArrayList<>();
        notWords = new ArrayList<>();
        setQuery(query);
    }

    public void setQuery(String query){
        String[] tokens = tokenize(query);
        for(String token : tokens){
            if(token.startsWith("+"))
                orWords.add(token.replaceAll("\\+", ""));
            else if(token.startsWith("-"))
                notWords.add(token.replaceAll("\\-", ""));
            else
                andWords.add(token);
        }
    }

    public TreeSet<String> handleQuery(InvertedIndex index){
        TreeSet<String> answer = new TreeSet<>();
        answer = index.query(orWords.get(0));
        answer = handleOrWords(answer, index);
        answer = handleNotWords(answer, index);
        answer = handleAndWords(answer, index);
        return answer;
    }

    public TreeSet<String> handleAndWords(TreeSet<String> set, InvertedIndex index){
        for(String andWord : andWords){
            set.retainAll(index.query(andWord));
        }
        return set;
    }

    public TreeSet<String> handleOrWords(TreeSet<String> set, InvertedIndex index){
        for(String orWord : orWords){
            set.addAll(index.query(orWord));
        }
        return set;
    }

    public TreeSet<String> handleNotWords(TreeSet<String> set, InvertedIndex index){
        for(String notWord : notWords){
            set.removeAll(index.query(notWord));
        }
        return set;
    }
    
    public String[] tokenize(String contents){
        contents = contents.replaceAll("[^+\\-\\w\\s]", " ");
        contents = contents.toUpperCase();
        return contents.split("[\\s]+");
    }
}
