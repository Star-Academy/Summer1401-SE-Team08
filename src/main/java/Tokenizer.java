import java.util.List;
import java.util.Arrays;

// Class responsible for tokenizing query and doc words.
public class Tokenizer {
    private TokenizerMode mode;

    public static final String queryRegex = "[^+\\-\\w\\s]";
    public static final String textRegex = "[^\\w\\s]";

    public Tokenizer(TokenizerMode mode) {
        setMode(mode);
    }

    // Set the mode of the tokenizer based on the type of the content it's given(text or query).
    public void setMode(TokenizerMode mode) {
        this.mode = mode;
    }

    public String getRegex() {
        if (mode == TokenizerMode.QUERY) {
            return queryRegex;
        }
        return textRegex;
    }

    public List<String> tokenize(String contents) {
        contents = contents.replaceAll(getRegex(), " ").toUpperCase();
        return Arrays.asList(contents.split("[\\s]+"));
    }
}