namespace InvertedIndex;

public class TimeRange
{
    private readonly long _start;
    private readonly long _end;

    public TimeRange(long start, long end)
    {
        this._start = start;
        this._end = end;
    }

    public override string ToString()
    {
        return "(" + CalculateTimeTaken() + " seconds)";
    }

    private double CalculateTimeTaken()
    {
        return (_end - _start) / 1e9;
    }
}