import java.util.List;
import java.util.stream.Collectors;

import opennlp.tools.stemmer.PorterStemmer;

public class Stemmer{
    private final PorterStemmer porterStemmer;
    public static Stemmer instance;

    static {
        instance = new Stemmer();
    }

    public Stemmer(){
        porterStemmer = new PorterStemmer();
    }

    public List<String> stemList(List<String> tokens){
         return tokens.stream()
             .map(porterStemmer::stem)
             .collect(Collectors.toList());
    }
}