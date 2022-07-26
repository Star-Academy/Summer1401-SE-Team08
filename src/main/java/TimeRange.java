
// Parameter Object to avoid Long Parameter List.
public class TimeRange {
    private final long start;
    private final long end;

    public TimeRange(long start, long end) {
        this.start = start;
        this.end = end;
    }

    @Override
    public String toString() {
        return "(" + calculateTimeTaken() + " seconds)";
    }

    private double calculateTimeTaken() {
        return (end - start) / 1e9;
    }
}
