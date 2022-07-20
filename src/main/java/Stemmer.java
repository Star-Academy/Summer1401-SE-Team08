import java.util.ArrayList;
import java.util.List;
//import java.util.stream.Collectors;

import opennlp.tools.stemmer.PorterStemmer;

public class Stemmer{
    private PorterStemmer porterStemmer;
    public static Stemmer instance;

    static {
        instance = new Stemmer();
    }

    public Stemmer(){
        porterStemmer = new PorterStemmer();
    }

    public List<String> stemList(List<String> tokens){
        List<String> stemmedWords = new ArrayList<>();
        for(String token : tokens){
            String stemmedWord = porterStemmer.stem(token);
            stemmedWords.add(stemmedWord);
        }
        return stemmedWords;

        // return tokens.stream()
        //     .map(token -> porterStemmer.stem(token))
        //     .collect(Collectors.toList());
    }
}