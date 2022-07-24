import java.util.List;
import java.util.ArrayList;

public class Query {
    private final List<String> andWords;
    private final List<String> orWords;
    private final List<String> notWords;

    // Separating the words of the query.
    public Query(List<String> query) {
        andWords = new ArrayList<>();
        orWords = new ArrayList<>();
        notWords = new ArrayList<>();
        for (String token : query) {
            switch (TokenType.getTokenType(token)) {
                case AND -> andWords.add(token);
                case OR -> orWords.add(token.substring(1));
                case NOT -> notWords.add(token.substring(1));
                default -> {
                }
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