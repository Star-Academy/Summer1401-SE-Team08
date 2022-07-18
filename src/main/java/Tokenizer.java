public class Tokenizer {
    public static final String queryRegex = "[^+\\-\\w\\s]";
    public static final String textRegex = "[^\\w\\s]";

    public static String[] tokenize(String contents, TokenizerMode mode){
        String regex = textRegex;
        if(mode == TokenizerMode.QUERY)
            regex = queryRegex;
        contents = contents.replaceAll(regex, " ");
        contents = contents.toUpperCase();
        return contents.split("[\\s]+");
    }
}