import java.util.List;
import java.util.Arrays;

public class Tokenizer {
    private TokenizerMode mode;

    public static final String queryRegex = "[^+\\-\\w\\s]";
    public static final String textRegex = "[^\\w\\s]";

    public Tokenizer(TokenizerMode mode){
        setMode(mode);
    }

    public void setMode(TokenizerMode mode) {
        this.mode = mode;
    }

    public String getRegex() {
        if (mode == TokenizerMode.QUERY) {
            return queryRegex;
        }
        return textRegex;
    }

    public List<String> tokenize(String contents){
        contents = contents.replaceAll(getRegex(), " ");
        contents = contents.toUpperCase();
        return Arrays.asList(contents.split("[\\s]+"));
    }
}