import java.util.List;
import java.util.ArrayList;

public class Query {
    private List<String> andWords;
    private List<String> orWords;
    private List<String> notWords;

    public Query(List<String> query){
        andWords = new ArrayList<>();
        orWords = new ArrayList<>();
        notWords = new ArrayList<>();
        for(String token : query){
            switch (TokenType.getTokenType(token)) {
                case AND:
                    andWords.add(token);
                    break;
                case OR:
                    orWords.add(token.substring(1));
                    break;
                case NOT:
                    notWords.add(token.substring(1));
                    break;
                default:
            }
        }
    }
    
    public List<String> getAndWords() {
        return andWords;
    }

    public List<String> getOrWords() {
        return orWords;
    }

    public List<String> getNotWords() {
        return notWords;
    }
}